using DRRCore.Domain.Entities.SqlCoreContext;

namespace DRRCore.Domain.Interfaces.CoreDomain
{
    public interface IComercialLatePaymentDomain : IBaseDomain<ComercialLatePayment>
    {
        Task<List<ComercialLatePayment>> GetComercialLatePaymetByIdCompany(int idCompany);
        Task<List<ComercialLatePayment>> GetComercialLatePaymetByIdPerson(int idPerson);
    }
}
