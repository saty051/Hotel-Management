using AutoMapper;
using HotelManagementApplication.BLL.DTOs;
using HotelManagementApplication.DAL;
using HotelManagementApplication.Models;
using HotelManagementApplication.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Reflection.Metadata.Ecma335;

namespace HotelManagementApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")]
    public class EmployeeController : ControllerBase
    {
        private readonly ILogger<EmployeeController> _logger;
        private readonly IMapper _mapper;
        private readonly IHotelAppRepository<Employee> _hotelAppRepository;
        public EmployeeController(ILogger<EmployeeController> logger, IMapper mapper, IHotelAppRepository<Employee> hotelAppRepository)
        {

            _logger = logger;
            _mapper = mapper;
            _hotelAppRepository = hotelAppRepository;
        }

        [HttpGet]
        [Route("All")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<EmployeeDTO>>> GetEmployeesAsync()
        {
            _logger.LogInformation("GetEmployees method started");
            var employees = await _hotelAppRepository.GetAllAsync();

            var employeeDTO = _mapper.Map<List<EmployeeDTO>>(employees);

            return Ok(employeeDTO);
        }
        [HttpGet("{id:int}", Name = "GetEmployeeById")]
        //[Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [AllowAnonymous]
        public async Task<ActionResult<Employee>> GetEmployeesByIdAsync(int id)
        {
            _logger.LogInformation("GetEmployeesById method started");
            if (id <= 0)
            {
                _logger.LogWarning("Bad request");
                return BadRequest();
            }
                

            var employee = await _hotelAppRepository.GetByIdAsync(employee => employee.EmployeeId == id);

            if (employee == null)
            {
                _logger.LogError("Employee not found with the given Id");
                return NotFound($"The employee with id {id} not found");
            }
                
            var employeeDTO = _mapper.Map<EmployeeDTO>(employee);   
            return Ok(employeeDTO);
        }

        [HttpPost]
        [Route("Create")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<EmployeeDTO>> CreateEmployeeAsync([FromBody] EmployeeDTO model)
        {
            _logger.LogInformation("CreateEmployee method started");
            if (model == null)
            {
                _logger.LogWarning("Bad request");
                return BadRequest();
            }
                
           // int newEmployeeId = EmployeeRepository.Employees.LastOrDefault().EmployeeId + 1;
            Employee employee = _mapper.Map<Employee>(model);
           
            var employeeAfterCreation = await _hotelAppRepository.CreateAsync(employee);

            model.EmployeeId = employeeAfterCreation.EmployeeId;

            return CreatedAtRoute("GetEmployeeById", new { Id = model.EmployeeId }, model);

        }

        [HttpPut]
        [Route("Update")]

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult> UpdateEmployeesAsync([FromBody] EmployeeDTO model)
        {
            _logger.LogInformation("UpdateEmployees method started");
            if (model == null || model.EmployeeId <= 0)
            {
                _logger.LogWarning("Bad Request");
                return BadRequest();
            }
                
            var existingEmployee = await _hotelAppRepository.GetByIdAsync(employee => employee.EmployeeId == model.EmployeeId,true);
            if(existingEmployee == null)
            {
                _logger.LogError("Employee not found with the given Id");
                return NotFound();
            }

            var newRecord = _mapper.Map<Employee>(model);
            await _hotelAppRepository.UpdateAsync(newRecord);
           

            _logger.LogInformation("Employee has been updated successfully");
            return NoContent();
        }
       

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> DeleteEmployeesAsync(int id)
        {
            _logger.LogInformation("DeleteEmployee method started");
            if (id <= 0)
            {
                _logger.LogWarning("Bad request");
                return BadRequest();
            }

            var employee = await _hotelAppRepository.GetByIdAsync(employee => employee.EmployeeId == id);

            if (employee == null)
            {
                _logger.LogError("Employee not found with the given Id");
                return NotFound($"The employee with id {id} not found");
            }

            await _hotelAppRepository.DeleteAsync(employee);

            return Ok(true);
        }
    }
}

