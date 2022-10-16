using AutoMapper;
using Business.Abstract;
using Business.BusinessRules;
using Business.Requests.Cars;
using Business.Responses.Cars;
using Business.ValidationRules.FluentValidation.Car;
using Core.CrossCuttingConcerns.Validation.FluentValidation;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        IMapper _mapper;
        CarBusinessRules _businessRules;

        public CarManager(ICarDal carDal, IMapper mapper, CarBusinessRules businessRules)
        {
            _carDal = carDal;
            _mapper = mapper;
            _businessRules = businessRules;
        }

        public void Add(CreateCarRequest request)
        {
            ValidationTool<CreateCarRequest>.Validate(typeof(CreateCarRequestValidator), request);
            _businessRules.CheckIfCarNameExist(request.CarName);

            Car car = _mapper.Map<Car>(request);

            _carDal.Add(car);
        }

        public void Delete(DeleteCarRequest request)
        {
            _businessRules.CheckIfCarExist(request.Id);

            Car car = _mapper.Map<Car>(request);

            _carDal.Delete(car);
        }

        public GetCarResponse GetById(int id)
        {
            Car car = _carDal.Get(b => b.Id == id);
            var response = _mapper.Map<GetCarResponse>(car);

            return response;
        }

        public List<ListCarResponse> GetList()
        {
            List<Car> car = _carDal.GetList();
            List<ListCarResponse> response = _mapper.Map<List<ListCarResponse>>(car);

            return response;
        }

        public void Update(UpdateCarRequest request)
        {
            _businessRules.CheckIfCarExist(request.Id);

            Car car = _mapper.Map<Car>(request);

            _carDal.Update(car);
        }
    }
}
