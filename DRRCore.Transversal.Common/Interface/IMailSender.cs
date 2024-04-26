using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DRRCore.Transversal.Common.Interface
{
    public interface IMailSender
    {
        Task<bool> SendMailAsync(EmailValues values);
        Task<bool> ReSendMailAsync(EmailValues values);

    }
}
