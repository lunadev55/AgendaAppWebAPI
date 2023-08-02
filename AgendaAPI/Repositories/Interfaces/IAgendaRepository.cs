using AgendaAPI.Models;

namespace AgendaAPI.Repositories.Interfaces
{
    public interface IAgendaRepository
    {
        Task<List<Agenda>> GetAgenda();
        Task<Agenda> GetById(Guid Id);
        Task<Agenda> Create(string newName, string newEmail, string newPhonenumber);        
        Task<Agenda> Update(Guid id, string newName, string newEmail, string newPhonenumber);
        Task<string> Delete(Guid id);
    }
}
