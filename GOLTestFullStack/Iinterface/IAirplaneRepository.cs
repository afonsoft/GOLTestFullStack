using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GOLTestFullStack.Api.Entity;

namespace GOLTestFullStack.Api.Iinterface
{
    public interface IAirplaneRepository : IRepository<Airplane>
    {
        void EnsureCreated();
    }
}
