using hotel435.Models;
using System.Linq;
using System.Threading.Tasks;

namespace hotel435.Services
{
    public class ReservationService : DbOperationsBase<Reservation>, IReservationService
    {
        private readonly Hotel435DbContext _dbContext;
        public ReservationService(Hotel435DbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public Reservation GetReservationByConfirmationNumber(string confirmationNumber)
        {
            return _dbContext.Reservations.First(r => r.ConfirmationNumber == confirmationNumber);
        }
    }
}