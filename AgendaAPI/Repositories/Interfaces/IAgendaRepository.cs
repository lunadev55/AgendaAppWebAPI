using AgendaAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace AgendaAPI.Repositories.Interfaces
{
    public interface IAgendaRepository
    {
        Task<List<Agenda>> GetAgenda();
        Task<Agenda> GetById(Guid Id);
        public string Create(string newName, string newEmail, string newPhonenumber);
        public string Update(Guid id, string newName, string newEmail, string newPhonenumber);
        public string Delete(Guid id);

    }
}
