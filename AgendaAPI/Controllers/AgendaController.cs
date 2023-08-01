using AgendaAPI.Repositories.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AgendaAPI.Controllers
{    
    [ApiController]
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class AgendaController : ControllerBase
    {
        private readonly IAgendaRepository _agendaRepository;

        public AgendaController(IAgendaRepository agendaRepository)
        {
            _agendaRepository = agendaRepository;
        }
        
        [HttpGet(Name = "GetAgenda")]
        public async Task<IActionResult> GetAgenda()
        {   
            var result = await _agendaRepository.GetAgenda();
            return Ok(result);
        }

        [HttpGet]
        [Route("GetContactById")]
        public async Task<IActionResult> GetContactById([FromQuery] Guid id)
        {                     
            var result = await _agendaRepository.GetById(id);
            return Ok(result);
        }

        [HttpPost]
        [Route("AddContact")]
        public JsonResult AddContact([FromForm] string newName, [FromForm] string newEmail, [FromForm] string newPhonenumber)
        {           
            var contactId = _agendaRepository.Create(newName, newEmail, newPhonenumber); 
            return new JsonResult("Added Successfully!");
        }

        [HttpPost]
        [Route("UpdateContact")]
        public JsonResult UpdateContact([FromQuery] Guid id, [FromForm] string newName, [FromForm] string newEmail, [FromForm] string newPhonenumber)
        {        
            var result = _agendaRepository.Update(id, newName, newEmail, newPhonenumber);
            return new JsonResult(result);
        }

        [HttpDelete]
        [Route("Delete")]
        public JsonResult DeleteContact([FromQuery] Guid id)
        {          
            var result = _agendaRepository.Delete(id);
            return new JsonResult(result);
        }
    }
}
