using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Domain.Interfaces.CoreDomain;
using DRRCore.Infraestructure.Interfaces.CoreRepository;

namespace DRRCore.Domain.Main.CoreDomain
{
    public class TicketDomain : ITicketDomain
    {
        private readonly ITicketRepository _ticketRepository;
        public TicketDomain(ITicketRepository ticketRepository)
        {
            _ticketRepository = ticketRepository;
        }
        public async Task<bool> AddAsync(Ticket obj)
        {
            return await _ticketRepository.AddAsync(obj);
        }

        public async Task<bool?> AddTicketFile(TicketFile obj)
        {
            return await _ticketRepository.AddTicketFile(obj);
        }

        public async Task<bool> AddTicketQuery(TicketQuery query)
        {
            return await _ticketRepository.AddTicketQuery(query);
        }

        public async Task<bool> DeleteAsync(int id)
        {
           return await _ticketRepository.DeleteAsync(id);
        }

        public async Task<bool?> DeleteTicketFile(int id)
        {
            return await _ticketRepository.DeleteTicketFile(id);
        }

        public async Task<List<Ticket>> GetAllAsync()
        {
           return await _ticketRepository.GetAllAsync();
        }

        public async Task<List<Ticket>> GetAllByAsync(string ticket, string name, string subscriber, string type, string procedure)
        {
            return await _ticketRepository.GetAllByAsync(ticket,name,subscriber,type,procedure);
        }

        public async Task<List<Ticket>> GetAllPendingTickets()
        {
            return await _ticketRepository.GetAllPendingTickets();
           
        }

        public async Task<Ticket> GetByIdAsync(int id)
        {
          return await _ticketRepository.GetByIdAsync(id);
        }

        public async Task<List<Ticket>> GetByNameAsync(string name)
        {
            return await _ticketRepository.GetByNameAsync(name);
        }
        public async Task<List<Ticket>> GetByNameAsync(string name, string empresaPersona)
        {
            return await _ticketRepository.GetByNameAsync(name,empresaPersona);
        }

        public async Task<TicketFile> GetFileByPath(string path)
        {
            return await _ticketRepository.GetFileByPath(path);
        }

        public async Task<List<TicketFile>> GetFilesByIdTicket(int idTicket)
        {
            return  await _ticketRepository.GetFilesByIdTicket(idTicket);
        }

        public async Task<List<OldTicket>> GetOldTicketByCompany(string oldCode)
        {
            return await _ticketRepository.GetOldTicketByCompany(oldCode);
        }

        public async Task<List<OldTicket>> GetOldTicketByPerson(string oldCode)
        {
            return await _ticketRepository.GetOldTicketByPerson(oldCode);
        }

        public async Task<List<OldTicket>> GetSimilarByNameAsync(string name, string empresaPersona)
        {
            return await _ticketRepository.GetSimilarByNameAsync(name,empresaPersona);
        }

        public async Task<List<Ticket>> GetTicketByCompany(int id)
        {
            return await _ticketRepository.GetTicketByCompany(id);
        }

        public async Task<List<Ticket>> GetTicketByCompanyOrPerson(string about, int id)
        {
            return await _ticketRepository.GetTicketByCompanyOrPerson(about, id);
        }

        public async Task<List<Ticket>> GetTicketByPerson(int id)
        {
           return await _ticketRepository.GetTicketByPerson(id);
        }

        public async Task<TicketFile> GetTicketFileById(int id)
        {
            return await _ticketRepository.GetTicketFileById(id);
        }

        public async Task<List<Ticket>> GetTicketHistoryByIdSubscriber(int idSubscriber, string? name, DateTime? from, DateTime? until, int? idCountry)
        {
            return await _ticketRepository.GetTicketHistoryByIdSubscriber(idSubscriber, name, from, until, idCountry);
        }

        public async Task<List<TicketHistory>> GetTicketHistoryByIdTicket(int idTicket)
        {
            return await _ticketRepository.GetTicketHistoryByIdTicket(idTicket);
        }

        public async Task<TicketQuery> GetTicketQuery(int idTicket)
        {
            return await _ticketRepository.GetTicketQuery(idTicket);
        }

        public async Task<List<Ticket>> GetTicketsByIdSubscriber(int idSubscriber, string? company, DateTime from, DateTime until, int idCountry)
        {
            return await _ticketRepository.GetTicketsByIdSubscriber(idSubscriber, company, from, until, idCountry);
        }

        public async Task<List<Ticket>> GetTicketSituation(string about, string typeSearch, string? search, int? idCountry)
        {
            return await _ticketRepository.GetTicketSituation(about, typeSearch, search, idCountry);
        }

        public async Task<List<Ticket>> GetTicketsToDispatch()
        {
            return await _ticketRepository.GetTicketsToDispatch();
        }

        public async Task<bool> TicketQueryAnswered(int idTicket, string subscriberResponse)
        {
            return await _ticketRepository.TicketQueryAnswered(idTicket, subscriberResponse);
        }

        public async Task<bool> UpdateAsync(Ticket obj)
        {
            return await _ticketRepository.UpdateAsync(obj);
        }

        public async Task<bool?> UpdateTicketFile(TicketFile obj)
        {
            return await _ticketRepository.UpdateTicketFile(obj);
        }
    }
}
