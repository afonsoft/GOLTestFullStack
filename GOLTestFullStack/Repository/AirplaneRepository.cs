using System;
using System.Collections.Generic;
using GOLTestFullStack.Api.Context;
using GOLTestFullStack.Api.Entity;
using GOLTestFullStack.Api.Iinterface;
using Microsoft.EntityFrameworkCore.Internal;

namespace GOLTestFullStack.Api.Repository
{
    public class AirplaneRepository : Repository<Airplane>, IAirplaneRepository
    {
        private readonly GolContext _context;
        public AirplaneRepository(GolContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }

        public void EnsureCreated()
        {
            if (!Get().Any())
            {
                AddRange(new List<Airplane>
                        {
                            new Airplane()
                            {
                                Id = 1, CodAviao = "PR-AVB",
                                Modelo = "A320",
                                QtsPassageiros = 192,
                                DateCreate = DateTime.Now
                            },
                            new Airplane()
                            {
                                Id = 2, CodAviao = "PR-AVO",
                                Modelo = "A320",
                                QtsPassageiros = 192,
                                DateCreate = DateTime.Now
                            },
                            new Airplane()
                            {
                                Id = 3, CodAviao = "PR-AVC",
                                Modelo = "A320",
                                QtsPassageiros = 192,
                                DateCreate = DateTime.Now
                            },
                            new Airplane()
                            {
                                Id = 4, CodAviao = "PR-OCT",
                                Modelo = "A319",
                                QtsPassageiros = 182,
                                DateCreate = DateTime.Now
                            },
                            new Airplane()
                            {
                                Id = 5, CodAviao = "PR-ARB",
                                Modelo = "A319",
                                QtsPassageiros = 182,
                                DateCreate = DateTime.Now
                            },
                            new Airplane()
                            {
                                Id = 6, CodAviao = "PR-ARR",
                                Modelo = "A318",
                                QtsPassageiros = 162,
                                DateCreate = DateTime.Now
                            },
                            new Airplane()
                            {
                                Id = 7, CodAviao = "PR-ABR",
                                Modelo = "A318",
                                QtsPassageiros = 162,
                                DateCreate = DateTime.Now
                            }
                        });
            }
        }
    }
}
