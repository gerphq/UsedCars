using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsedCars.Core;
using UsedCars.Core.Entities;
using UsedCars.Infrastructure;

namespace UsedCars.Infrastructure.Repositories
{
    public class TestRepository
    {
        private readonly UsedCarsContext _usedCarsContext;

        public TestRepository(UsedCarsContext usedCarsContext)
        {
            _usedCarsContext = usedCarsContext;
        }

        public List<AvKeboardProgram> GetAllKeyboardPrograms()
        {
            return _usedCarsContext.AvKeboardPrograms.OrderBy(x => x.SetlistOrder).ToList();
        }
    }
}
