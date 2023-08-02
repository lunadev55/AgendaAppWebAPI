using AgendaAPI.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AgendaAPI.Controllers
{    
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class AgendaController : ControllerBase
    {
        private readonly IAgendaService _agendaService;

        public AgendaController(IAgendaService agendaService)
        {            
            _agendaService = agendaService;
        }
        
        [HttpGet(Name = "GetAgenda")]
        public async Task<IActionResult> GetAgenda()
        {   
            try
            {
                var result = await _agendaService.GetAll();
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }            
        }

        [HttpGet]
        [Route("GetContactById")]
        public async Task<IActionResult> GetContactById([FromQuery] Guid id)
        {                     
            try
            {
                var result = await _agendaService.GetById(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }

        [HttpPost]
        [Route("AddContact")]
        public async Task<IActionResult> AddContact([FromForm] string newName, [FromForm] string newEmail, [FromForm] string newPhonenumber)
        {    
            try
            {
                var contact = await _agendaService.Create(newName, newEmail, newPhonenumber);
                return Ok(contact);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }        
        }

        [HttpPost]
        [Route("UpdateContact")]
        public async Task<IActionResult> UpdateContact([FromQuery] Guid id, [FromForm] string newName, [FromForm] string newEmail, [FromForm] string newPhonenumber)
        { 
            try
            {
                var result = await _agendaService.Update(id, newName, newEmail, newPhonenumber);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }                    
        }

        [HttpDelete]
        [Route("Delete")]
        public async Task<IActionResult> DeleteContact([FromQuery] Guid id)
        {   
            try
            {
                var result = await _agendaService.Delete(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
