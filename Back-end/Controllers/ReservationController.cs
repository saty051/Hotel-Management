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
    public class ReservationController : ControllerBase
    {
        private readonly ILogger<ReservationController> _logger;
        private readonly IMapper _mapper;
        private readonly IHotelAppRepository<Reservation> _hotelAppRepository;
        public ReservationController(ILogger<ReservationController> logger, IMapper mapper, IHotelAppRepository<Reservation> hotelAppRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _hotelAppRepository = hotelAppRepository;
        }

        [HttpGet]
        [Route("All")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<ReservationDTO>>> GetReservationsAsync()
        {
            _logger.LogInformation("GetResrevations method started");
            var reservations = await _hotelAppRepository.GetAllAsync();

            var reservationDTO = _mapper.Map<List<ReservationDTO>>(reservations);

            return Ok(reservationDTO);
        }
        [HttpGet("{id}")]
        //[Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<Reservation>> GetReservationbyIdAsync(int id)
        {
            _logger.LogInformation("GetReservationById method started");
            if (id <= 0)
            {
                _logger.LogWarning("Bad request");
                return BadRequest();
            }
                

            var reservation = await _hotelAppRepository.GetByIdAsync(reservation => reservation.ReservationId == id);

            if (reservation == null)
            {
                _logger.LogError("Reservation not found with the given Id");
                return NotFound($"The reservation with id {id} not found");
            }
                
            var reservationDTO = _mapper.Map<ReservationDTO>(reservation);
            return Ok(reservationDTO);
        }

        [HttpPost]
        [Route("Create")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<ReservationDTO>> CreateReservationAsync([FromBody]ReservationDTO model)
        {
            _logger.LogInformation("Create method started");
            if (model == null)
            {
                _logger.LogWarning("Bad request");
                return BadRequest();
            }
                
          //  int newId = _dbContext.Reservations.LastOrDefault().ReservationId + 1;
            Reservation reservation = _mapper.Map<Reservation>(model);

            var reservationAfterCreation = await _hotelAppRepository.CreateAsync(reservation);

            model.ReservationId = reservationAfterCreation.ReservationId;

            return CreatedAtRoute("GetReservationById", new { Id = model.ReservationId }, model); ;

        }

        [HttpPut]
        [Route("Update")]

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult> UpdateReservationAsync([FromBody]ReservationDTO model)
        {
            _logger.LogInformation("UpdateReservation method started");
            if (model == null || model.ReservationId <= 0)
            {
                _logger.LogWarning("Bad request");
                return BadRequest();
            }
                
            var existingReservation = await _hotelAppRepository.GetByIdAsync(reservation => reservation.ReservationId == model.ReservationId, true);
            if (existingReservation == null)
            {
                _logger.LogError("Reservation not found with the given Id");
                return NotFound();

            }
            var newRecord = _mapper.Map<Reservation>(model);
            await _hotelAppRepository.UpdateAsync(newRecord);

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> DeleteReservationAsync(int id)
        {
            _logger.LogInformation("DeleteReservations method started");
            if (id <= 0)
            {
                _logger.LogWarning("Bad request");
                return BadRequest();
            }


            var reservation = await _hotelAppRepository.GetByIdAsync(reservation => reservation.ReservationId == id);
            if (reservation == null)
            {
                _logger.LogError("Reservation not found with the given Id");
                return NotFound($"The reservation with id {id} not found");
            }

            await _hotelAppRepository.DeleteAsync(reservation);

            return Ok(true);
        }
    }
}

