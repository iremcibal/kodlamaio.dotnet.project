using AutoMapper;
using Business.Abstract;
using Business.BusinessRules;
using Business.Requests.Cars;
using Business.Responses.Cars;
using Business.ValidationRules.FluentValidation.Car;
using Core.Business.Requests;
using Core.CrossCuttingConcerns.Validation.FluentValidation;
using Core.DataAccess.Paging;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
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

        public GetCarResponse GetById(GetCarRequest request)
        {
            Car car = _carDal.Get(predicate : b => b.Id == request.Id,include : b => b.Include(bi => bi.Model).Include(bi => bi.carState));
            var response = _mapper.Map<GetCarResponse>(car);

            return response;
        }

        public PaginateListCarResponse GetList(PageRequest request)
        {
            IPaginate<Car> cars = _carDal.GetList(index: request.Index,
                                                    size: request.Size);

            PaginateListCarResponse response = _mapper.Map<PaginateListCarResponse>(cars);

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
