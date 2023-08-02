using AgendaAPI.Helpers;
using AgendaAPI.Models;
using AgendaAPI.Repositories.Interfaces;
using AgendaAPI.Services.Interfaces;

namespace AgendaAPI.Services
{
    public class AgendaService : IAgendaService
    {
        private readonly IAgendaRepository _agendaRepository;

        public AgendaService(IAgendaRepository agendaRepository)
        {
            _agendaRepository = agendaRepository;
        }
        public Task<Agenda> Create(string name, string email, string phonenumber)
        {            
            if (!Utils.IsValidEmailAddress(email))
                throw new Exception("Invalid Email Address!");
            if (!Utils.IsDigitsOnly(phonenumber) && !Utils.IsValidPhoneNumber(phonenumber))
                throw new Exception("Invalid Phone Number!");

            try
            {
                var result = _agendaRepository.Create(name, email, phonenumber);
                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<string> Delete(Guid id)
        {           
            try
            {
                var result = await _agendaRepository.Delete(id);
                return result;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Agenda>> GetAll()
        {
            try
            {
                var result = await _agendaRepository.GetAgenda();
                return result;
            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message);
            }            
        }

        public async Task<Agenda> GetById(Guid id)
        {            
            try
            {
                var result = await _agendaRepository.GetById(id);
                return result;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Agenda> Update(Guid id, string name, string email, string phonenumber)
        {            
            if (!Utils.IsValidEmailAddress(email))
                throw new Exception("Invalid Email Address!");
            if (!Utils.IsDigitsOnly(phonenumber) && !Utils.IsValidPhoneNumber(phonenumber))
                throw new Exception("Invalid Phone Number!");

            try
            {
                var result = await _agendaRepository.Update(id, name, email, phonenumber);
                return result;
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
