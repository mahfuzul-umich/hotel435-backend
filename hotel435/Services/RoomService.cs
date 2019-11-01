using hotel435.Models;

namespace hotel435.Services
{
    public class RoomService : DbOperationsBase<Room>, IRoomService
    {
        public RoomService(Hotel435DbContext dbContext) : base(dbContext)
        {
        }


    }
}