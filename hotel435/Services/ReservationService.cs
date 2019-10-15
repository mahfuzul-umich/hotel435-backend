using hotel435.Models;

namespace hotel435.Services
{
    public class ReservationService : DbOperationsBase<Reservation>, IReservationService
    {
        public ReservationService(Hotel435DbContext dbContext) : base(dbContext)
        {

        }
    }
}