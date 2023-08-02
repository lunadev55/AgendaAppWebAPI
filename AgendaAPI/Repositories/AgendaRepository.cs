using AgendaAPI.Data;
using AgendaAPI.Models;
using AgendaAPI.Repositories.Interfaces;

namespace AgendaAPI.Repositories
{
    public class AgendaRepository : IAgendaRepository
    {
        public async Task<Agenda> Create(string newName, string newEmail, string newPhonenumber)
        {
            var agenda = new Agenda();

            try
            {
                await using (var db = new AgendaDbContext())
                {
                    agenda = new Agenda
                    {
                        Name = newName,
                        Email = newEmail,
                        Phonenumber = newPhonenumber
                    };

                    db.Agendas.Add(agenda);
                    db.SaveChanges();
                }

                agenda.Message = "Added Successfully!";
            }
            catch (Exception ex)
            {
                agenda = new Agenda();
                agenda.Message = ex.Message;
            }

            return agenda;
        }

        public async Task<string> Delete(Guid id)
        {          
            string message = string.Empty;
            try
            {
                await using (var db = new AgendaDbContext())
                {
                    var agenda = new Agenda() { Id = id };

                    db.Agendas.Attach(agenda);
                    db.Agendas.Remove(agenda);
                    db.SaveChanges();

                    message = "Deleted";
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return message;
        }

        public async Task<List<Agenda>> GetAgenda()
        {
            try
            {
                var agenda = new List<Agenda>();

                await using (var db = new AgendaDbContext())
                {
                    agenda = db.Agendas.ToList();
                }
                return agenda;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }         
        }

        public async Task<Agenda> GetById(Guid id)
        {
            var contact = new Agenda();
            try
            {
                await using (var db = new AgendaDbContext())
                {
                    contact = db.Agendas.FindAsync(id).Result;
                }

                return contact;
            }
            catch (Exception ex)
            {                
                throw new Exception(ex.Message);
            }
        }

        public async Task<Agenda> Update(Guid id, string newName, string newEmail, string newPhonenumber)
        {
            var agenda = new Agenda();
            try
            {
                await using (var db = new AgendaDbContext())
                {
                    var contact = db.Agendas.SingleOrDefault(c => c.Id == id);

                    if (contact is not null)
                    {
                        contact.Name = newName;
                        contact.Email = newEmail;
                        contact.Phonenumber = newPhonenumber;

                        db.Agendas.Update(contact);
                        db.SaveChanges();
                    }

                    agenda = contact;
                    agenda.Message = "Updated Successfully!";
                }
            } 
            catch (Exception ex)
            {
                agenda = new Agenda();
                agenda.Message = ex.Message;
            }

            return agenda;
        }
    }
}
