using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BusinessRules
{
    public class CarBusinessRules
    {
        private ICarDal _carDal;

        public CarBusinessRules(ICarDal carDal)
        {
            _carDal = carDal;
        }

        public void CheckIfCarExist(Car? car)
        {
            if (car == null)
            {
                throw new Exception("Car not be exist");
            }
        }

        public void CheckIfCarNotExist(Car? car)
        {
            if (car != null)
            {
                throw new Exception("Car already exist");
            }
        }

        public void CheckIfCarExist(int carId)
        {
            Car? car = _carDal.Get(b => b.Id == carId);
            CheckIfCarExist(car);
        }

        public void CheckIfCarNameExist(string carName)
        {
            Car? car = _carDal.Get(b => b.CarName == carName);
            CheckIfCarNotExist(car);
        }
    }
}
