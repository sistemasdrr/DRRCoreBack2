using DRRCore.Domain.Entities.SqlCoreContext;
using DRRCore.Domain.Interfaces.CoreDomain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRRCore.Domain.Interfaces.EmailDomain
{
    public interface ICompanyImageDomain : IBaseDomain<CompanyImage>
    {
        Task<int?> AddCompanyImage(CompanyImage obj);
        Task<CompanyImage> GetImagesByIdCompany(int idCompany);
        Task<bool> UpdateImageCompany(int idCompany, int number, string? base64, string? description, string? descriptionEng, bool? print);
    }
}
