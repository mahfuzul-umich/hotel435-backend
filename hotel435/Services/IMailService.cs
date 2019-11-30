using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hotel435.Models;

namespace hotel435.Services
{
    public interface IMailService
    {
        Task<Reservation> SendConfirmationEmail(string reservationId);
    }
}
