using GOLTestFullStack.Api.Context;
using GOLTestFullStack.Api.Entity;
using GOLTestFullStack.Api.Iinterface;

namespace GOLTestFullStack.Api.Repository
{
    public class AirplaneRepository : Repository<Airplane>, IAirplaneRepository
    {
        private readonly GolContext _context;
        public AirplaneRepository(GolContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }
    }
}
