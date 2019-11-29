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

        /// <summary>
        /// Set check in date for reservation
        /// </summary>
        /// <param name="reservationId">The reservation id</param>
        /// <returns>The updated reservation model</returns>
        Task<Reservation> SetReservationCheckInDate(string reservationId);

        /// <summary>
        /// Set actual check out date for reservation. Calculate total price for reservation. Send email confirmation.
        /// </summary>
        /// <param name="reservationId">The reservation id</param>
        /// <returns>The updated reservation model</returns>
        Task<Reservation> FinalizeReservation(string reservationId);
    }
}
