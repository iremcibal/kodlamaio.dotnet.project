using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BusinessRules
{
    public class CarTypeBusinessRules
    {
        ICarTypeDal _carTypeDal;
        public CarTypeBusinessRules(ICarTypeDal carTypeDal)
        {
            _carTypeDal = carTypeDal;
        }

        public void CheckIfCarTypeNotExist(CarType carType)
        {
            if (carType == null) throw new Exception("Car Type not be exist");
        }

        public void CheckIfCarTypeExist(CarType carType)
        {
            if (carType != null) throw new Exception("Car Type already exist");
        }

        public void CheckIfCarTypeNotExist(int carTypeId)
        {
            CarType carType = _carTypeDal.Get(ct=>ct.Id == carTypeId);
            CheckIfCarTypeNotExist(carType);
        }

        public void CheckIfCarTypeNameNotExist(string carTypeName)
        {
            CarType carType = _carTypeDal.Get(ct=>ct.Name==carTypeName);
            CheckIfCarTypeExist(carType);
        }
    }
}
