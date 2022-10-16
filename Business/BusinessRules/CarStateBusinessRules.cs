using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BusinessRules
{
    public class CarStateBusinessRules
    {
        private ICarStateDal _carStateDal;

        public CarStateBusinessRules(ICarStateDal carStateDal)
        {
            _carStateDal = carStateDal;
        }

        public void CheckIfCarStateExist(CarState? carState)
        {
            if (carState == null)
            {
                throw new Exception("CarState not be exist");
            }
        }

        public void CheckIfCarStateNotExist(CarState? carState)
        {
            if (carState != null)
            {
                throw new Exception("CarState already exist");
            }
        }

        public void CheckIfCarStateExist(int carStateId)
        {
            CarState? carState = _carStateDal.Get(b => b.Id == carStateId);
            CheckIfCarStateExist(carState);
        }

        public void CheckIfCarStateNameExist(string carStateName)
        {
            CarState? carState = _carStateDal.Get(b => b.Name == carStateName);
            CheckIfCarStateNotExist(carState);
        }
    }
}
