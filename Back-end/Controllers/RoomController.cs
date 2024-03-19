using AutoMapper;
using HotelManagementApplication.BLL.DTOs;
using HotelManagementApplication.DAL;
using HotelManagementApplication.Models;
using HotelManagementApplication.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System.Security.Cryptography.Xml;

namespace HotelManagementApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomController : ControllerBase
    {
        private readonly ILogger<RoomController> _logger;
        private readonly IMapper _mapper;
        private readonly IHotelAppRepository<Room> _hotelAppRepository;
        public RoomController(ILogger<RoomController> logger, IMapper mapper, IHotelAppRepository<Room> hotelAppRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _hotelAppRepository = hotelAppRepository;
        }

        [HttpGet]
        [Route("All")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<RoomDTO>>> GetRoomsAsync()
        {
            _logger.LogInformation("GetRooms method started");
            var rooms = await _hotelAppRepository.GetAllAsync();

            var roomDTO = _mapper.Map<List<RoomDTO>>(rooms);

            return Ok(roomDTO);
        }
        [HttpGet("{id}")]
        //[Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<RoomDTO>> GetRoomByIdAsync(int id)
        {
            _logger.LogInformation("GetRoomById method started");

            if (id <= 0)
            {
                _logger.LogWarning("Bad request");
                return BadRequest();
            }
                

            var room = await _hotelAppRepository.GetByIdAsync(room => room.RoomId == id);

            if (room == null)
            {
                _logger.LogError("Room not found with the given Id");
                return NotFound($"The room with id {id} not found");
            }
                
            var roomDTO = _mapper.Map<RoomDTO>(room);
            return Ok(roomDTO);
        }

        [HttpPost]
        [Route("Create")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        
        public async Task<ActionResult<RoomDTO>> CreateRoomAsync([FromBody]RoomDTO model)
        {
            _logger.LogInformation("Create method started");
            if (model == null)
            {
                _logger.LogWarning("Bad request");
                return BadRequest();
            }

            // int newId = _dbContext.Rooms.LastOrDefault().RoomId + 1;
  
            Room room = _mapper.Map<Room>(model);
            var roomAfterCreation = await _hotelAppRepository.CreateAsync(room);

            model.RoomId = roomAfterCreation.RoomId;

            return CreatedAtRoute("GetEmployeeById", new { Id = model.RoomId }, model); ;
        }

        [HttpPut]
        [Route("Update")]

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult> UpdateRoomAsync([FromBody]RoomDTO model)
        {
            _logger.LogInformation("UpdateRoom method started");
            if(model == null || model.RoomId <= 0)
            {
                _logger.LogWarning("Bad request");
                return BadRequest();
            }
                
            var existingRoom = await _hotelAppRepository.GetByIdAsync(room => room.RoomId == model.RoomId, true);
            if(existingRoom == null)
            {
                _logger.LogError("Room not found with the given Id");
                return NotFound();
            }
            var newRecord = _mapper.Map<Room>(model);
            await _hotelAppRepository.UpdateAsync(newRecord);

            return NoContent();
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> DeleteRoomsAsync(int id)
        {
            _logger.LogInformation("DeleteRooms method started");
            if (id <= 0)
            {
                _logger.LogWarning("Bad request");
                return BadRequest();
            }
               
            var room = await _hotelAppRepository.GetByIdAsync(room => room.RoomId == id);

            if (room == null)
            {
                _logger.LogError("Room not found with the given Id");
                return NotFound($"The room with id {id} not found");
            }

            await _hotelAppRepository.DeleteAsync(room);

            return Ok(true);
        }
    }
}
