using AgendaAPI.Models;

namespace AgendaAPI.Services.Interfaces
{
    public interface IAgendaService
    {
        Task<Agenda> Create(string name, string email, string phonenumber);
        Task<string> Delete(Guid id);
        Task<List<Agenda>> GetAll();
        Task<Agenda> GetById(Guid id);
        Task<Agenda> Update(Guid id, string name, string email, string phonenumber);
    }
}
