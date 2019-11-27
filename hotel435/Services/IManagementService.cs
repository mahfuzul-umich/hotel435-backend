using hotel435.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hotel435.Services
{
    public interface IManagementService
    {
        List<ManagementReservationViewModel> GetManagementReservationViewModel();
        Task<Reservation> SetReservationCheckInDate(string reservationId);
        Task<Reservation> SetReservationCheckOutDate(string reservationId);
    }
}
