using DRRCore.Domain.Entities.SqlCoreContext;

namespace DRRCore.Infraestructure.Interfaces.CoreRepository
{
    public interface ITicketRepository:IBaseRepository<Ticket>
    {
        Task<List<Ticket>> GetTicketByCompany(int id);
        Task<List<Ticket>> GetAllPendingTickets();
        Task<List<Ticket>> GetTicketByPerson(int id);
        Task<List<Ticket>> GetAllByAsync(string ticket, string name, string subscriber, string type, string procedure);
        Task<bool> AddTicketQuery(TicketQuery query);
        Task<TicketQuery> GetTicketQuery(int idTicket);
        Task<bool> TicketQueryAnswered(int idTicket, string subscriberResponse);
        Task<List<OldTicket>> GetSimilarByNameAsync(string name, string empresaPersona);
        Task<List<OldTicket>> GetOldTicketByCompany(string oldCode);
        Task<List<OldTicket>> GetOldTicketByPerson(string oldCode);
        Task<List<Ticket>> GetByNameAsync(string name, string empresaPersona);

        Task<List<TicketFile>> GetFilesByIdTicket(int idTicket);
        Task<TicketFile> GetFileByPath(string path);
        Task<TicketFile> GetTicketFileById(int id);
        Task<bool?> AddTicketFile(TicketFile obj);
        Task<bool?> UpdateTicketFile(TicketFile obj);
        Task<bool?> DeleteTicketFile(int id);
        Task<List<Ticket>> GetTicketsByIdSubscriber(int idSubscriber, string? company,DateTime from, DateTime until, int idCountry);  
        Task<List<Ticket>> GetTicketHistoryByIdSubscriber(int idSubscriber, string? name, DateTime? from, DateTime? until, int? idCountry);

        Task<List<Ticket>> GetTicketSituation(string about, string typeSearch, string? search, int? idCountry);
        Task<List<Ticket>> GetTicketByCompanyOrPerson(string about, int id);

        Task<List<TicketHistory>> GetTicketHistoryByIdTicket(int idTicket);
        Task<List<Ticket>> GetTicketsToDispatch();
    }
}
