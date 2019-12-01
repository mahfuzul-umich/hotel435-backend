using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hotel435.Services
{
    public interface IMailService
    {
        Task SendConfirmationEmailAsync(Models.Reservation reservation);
        Task SendSummaryEmailAsync(Models.Reservation reservation);
    }
}
