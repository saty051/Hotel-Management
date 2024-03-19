using HotelManagementApplication.Models;
using Microsoft.AspNetCore.Mvc;
using HotelManagementApplication.BLL.DTOs;
using HotelManagementApplication.DAL;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using HotelManagementApplication.Repository;

namespace HotelManagementApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HotelController : ControllerBase
    {
        private readonly ILogger<HotelController> _logger;
        private readonly IMapper _mapper;
        private readonly IHotelAppRepository<Hotel> _hotelAppRepository;
        public HotelController(ILogger<HotelController> logger,IMapper mapper, IHotelAppRepository<Hotel> hotelAppRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _hotelAppRepository = hotelAppRepository;
        }

        [HttpGet]
        [Route("All")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<HotelDTO>>> GetHotelsAsync()
        {
            _logger.LogInformation("GetHotels method started");
            var hotels = await _hotelAppRepository.GetAllAsync();

            var hotelDTO = _mapper.Map<List<HotelDTO>>(hotels);

            return Ok(hotelDTO);
        }
        [HttpGet("{id}")]
        //[Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<HotelDTO>> GetHotelByIdAsync(int id)
        {
            _logger.LogInformation("GetHotelById method started");
            if (id <= 0)
            {
                _logger.LogWarning("Bad Request");
                return BadRequest();
            }
                

            var hotel = await _hotelAppRepository.GetByIdAsync(hotel => hotel.HotelId == id);

            if (hotel == null)
            {
                _logger.LogError("Hotel not found with the given Id");
                return NotFound($"The hotel with id {id} not found");
            }
                

            var hotelDTO = _mapper.Map<HotelDTO>(hotel);
            return Ok(hotelDTO);
        }

        [HttpPost]
        [Route("Create")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<HotelDTO>> CreateHotelAsync([FromBody] HotelDTO model)
        {
            _logger.LogInformation("Create method started");
            if (model == null)
            {
                _logger.LogWarning("Bad Request");
                return BadRequest();
            }
           // int newId = _dbContext.Hotels.LastOrDefault().HotelId + 1;
            Hotel hotel = _mapper.Map<Hotel>(model);

            var hotelAfterCreation = await _hotelAppRepository.CreateAsync(hotel);

            model.HotelId = hotelAfterCreation.HotelId;

            return CreatedAtRoute("GetHotelById", new { Id = model.HotelId }, model);
        }

        [HttpPut]
        [Route("Update")]
    
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult> UpdateHotelAsync([FromBody] HotelDTO model) 
        {
            _logger.LogInformation("UpdateHotel method started");
            if (model == null || model.HotelId <= 0)
            {
                _logger.LogWarning("Bad request");
                return BadRequest();
            }

            var existingHotel = await _hotelAppRepository.GetByIdAsync(hotel => hotel.HotelId == model.HotelId,true);
            if (existingHotel == null)
            {
                _logger.LogError("Hotel not found with the given Id");
                return NotFound();
            }
            var newRecord = _mapper.Map<Hotel>(model);
            await _hotelAppRepository.UpdateAsync(newRecord);

            _logger.LogInformation("Hotel has been updated successfully");
            return NoContent();
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> DeleteHotelsAsync(int id)
        {
            _logger.LogInformation("DeleteHotel method started");
            if (id <= 0)
            {
                _logger.LogWarning("Bad Request");
                return BadRequest();
            }

            var hotel = await _hotelAppRepository.GetByIdAsync(hotel => hotel.HotelId == id);
            if (hotel == null)
            {
                _logger.LogError("Hotel not found with the given Id");
                return NotFound($"The hotel with id {id} not found");
            }

            await _hotelAppRepository.DeleteAsync(hotel);

            return Ok(true);
        }
    }
}
