using AgendaAPI.Data;
using AgendaAPI.Models;
using AgendaAPI.Repositories.Interfaces;

namespace AgendaAPI.Repositories
{
    public class AgendaRepository : IAgendaRepository
    {
        public string Create(string newName, string newEmail, string newPhonenumber)
        {
            try
            {
                using (var db = new AgendaDbContext())
                {
                    var agenda = new Agenda
                    {
                        Name = newName,
                        Email = newEmail,
                        Phonenumber = newPhonenumber
                    };

                    db.Agendas.Add(agenda);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return "Added Successfully!";
        }

        public string Delete(Guid id)
        {          
            try
            {
                using (var db = new AgendaDbContext())
                {
                    var agenda = new Agenda() { Id = id };

                    db.Agendas.Attach(agenda);
                    db.Agendas.Remove(agenda);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }

            return "Deleted Successfully!";
        }

        public async Task<List<Agenda>> GetAgenda()
        {
            var agenda = new List<Agenda>();   

            await using (var db = new AgendaDbContext())
            {
                agenda = db.Agendas.ToList();
            }          

            return agenda;
        }

        public async Task<Agenda> GetById(Guid id)
        {
            var contact = new Agenda();

            await using (var db = new AgendaDbContext())
            {
                contact = db.Agendas.FindAsync(id).Result;
            }

            return contact;
        }

        public string Update(Guid id, string newName, string newEmail, string newPhonenumber)
        {     
            try
            {
                using (var db = new AgendaDbContext())
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
                }
            } 
            catch (Exception ex)
            {
                return ex.Message;
            }

            return "Updated Successfully!";
        }
    }
}
