using AutoMapper;
using HotelManagementApplication.BLL.DTOs;
using HotelManagementApplication.DAL;
using HotelManagementApplication.Models;
using HotelManagementApplication.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelManagementApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly IMapper _mapper;
        private readonly IHotelAppRepository<Customer> _hotelAppRepository;

        public CustomerController(ILogger<CustomerController> logger, IMapper mapper, IHotelAppRepository<Customer> hotelAppRepository)
        {
            _logger = logger;
            _mapper = mapper;
            _hotelAppRepository = hotelAppRepository;   
        }


        [HttpGet("All", Name = "GetAllCustomersAsync")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<CustomerDTO>>> GetCustomersAsync()
        {
            _logger.LogInformation("GetCustomers method started");
            var customers = await _hotelAppRepository.GetAllAsync();

            var customerDTO = _mapper.Map<List<CustomerDTO>>(customers);
           
            return Ok(customerDTO);
        }


        [HttpGet("{id:int}", Name = "GetCustomerById")]
        
        //[Route("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<CustomerDTO>> GetCustomerByIdAsync(int id)
        {
            _logger.LogInformation("GetCustomerById method started");
            if (id <= 0)
            {
                _logger.LogWarning("Bad Request");
                return BadRequest();
            }
                
            var customer = await _hotelAppRepository.GetByIdAsync(customer => customer.CustomerId == id);
            

            if (customer == null)
            {
                _logger.LogError("Customer not found with the given Id");
                return NotFound($"The customer with id {id} not found");
            }
                
            var customerDTO = _mapper.Map<CustomerDTO>(customer);
            return Ok(customerDTO);
        }

        [HttpPost]
        [Route("Create", Name = "CreateAsync")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult<CustomerDTO>> CreateCustomerAsync([FromBody] CustomerDTO model)
        {
            _logger.LogInformation("Create method started");
            if (model == null)
            {
                _logger.LogWarning("Bad Request");
                return BadRequest();
            }

            var customer = _mapper.Map<Customer>(model);

            var customerAfterCreation = await _hotelAppRepository.CreateAsync(customer);

            model.CustomerId = customerAfterCreation.CustomerId;

            return CreatedAtRoute("GetCustomerById", new { Id = model.CustomerId }, model);
        }
        [HttpPut]
        [Route("Update")]

        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]

        public async Task<ActionResult> UpdateCustomerAsync([FromBody]CustomerDTO model)
        {
            _logger.LogInformation("UpdateCustomer method started");
            if (model == null || model.CustomerId <= 0)
            {
                _logger.LogWarning("Bad request");
                return BadRequest();
            } 
                
            var existingCustomer = await _hotelAppRepository.GetByIdAsync(customer => customer.CustomerId == model.CustomerId,true);
            if(existingCustomer == null)
            {
                _logger.LogError("Customer not found with the given Id");
                return NotFound();
            }

            var newRecord = _mapper.Map<Customer>(model);
            await _hotelAppRepository.UpdateAsync(newRecord);     
           

            _logger.LogInformation("Customer has been updated successfully");
            return NoContent();
        }


        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<bool>> DeleteCustomersAsync(int id)
        {
            _logger.LogInformation("DeleteCustomers method started");
            if (id <= 0)
            {
                _logger.LogWarning("Bad request");
                return BadRequest();
            }
                
            var customer = await _hotelAppRepository.GetByIdAsync(customer => customer.CustomerId == id);

            if (customer == null)
            {
                _logger.LogError("Customer not found with the given Id");
                return NotFound($"The customer with id {id} not found");
            }

            await _hotelAppRepository.DeleteAsync(customer);

            return Ok(true);
        }
    }
}


