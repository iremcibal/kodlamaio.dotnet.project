using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BusinessRules
{
    public class FuelBusinessRules
    {
        IFuelDal _fuelDal;
        public FuelBusinessRules(IFuelDal fuelDal)
        {
            _fuelDal = fuelDal;
        }

        public void CheckIfFuelExist(Fuel? fuel)
        {
            if (fuel == null) throw new Exception("Fuel not be exist");
        }

        public void CheckIfFuelNotExist(Fuel fuel)
        {
            if (fuel != null) throw new Exception("Fuel already exist");
        }

        public void CheckIfFuelExist(int fuelId)
        {
            Fuel fuel = _fuelDal.Get(f=>f.Id==fuelId);
            CheckIfFuelExist(fuel);
        }

        public void CheckIfFuelNameExist(string fuelName)
        {
            Fuel fuel = _fuelDal.Get(f => f.Name == fuelName);
            CheckIfFuelNotExist(fuel);
        }



    }
}
