using AutoMapper;
using Business.Abstract;
using Business.BusinessRules;
using Business.Requests.CarTypes;
using Business.Responses.Brands;
using Business.Responses.CarTypes;
using Core.Business.Requests;
using Core.DataAccess.Paging;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarTypeManager : ICarTypeService
    {
        ICarTypeDal _carTypeDal;
        CarTypeBusinessRules _businessRules;
        IMapper _mapper;

        public CarTypeManager(ICarTypeDal carTypeDal, CarTypeBusinessRules businessRules, IMapper mapper)
        {
            _carTypeDal = carTypeDal;
            _businessRules = businessRules;
            _mapper = mapper;
        }

        public void Add(CreateCarTypeRequest request)
        {
            _businessRules.CheckIfCarTypeNameNotExist(request.Name);
            CarType carType = _mapper.Map<CarType>(request);
            _carTypeDal.Add(carType);


        }

        public void Delete(DeleteCarTypeRequest request)
        {
            _businessRules.CheckIfCarTypeNotExist(request.Id);
            CarType carType = _mapper.Map<CarType>(request);
            _carTypeDal.Delete(carType);
        }

        public GetCarTypeResponse GetById(int id)
        {
            CarType carType = _carTypeDal.Get(ct => ct.Id == id); // data
            _businessRules.CheckIfCarTypeNotExist(carType); //check please
            
            GetCarTypeResponse carTypeResponse = _mapper.Map<GetCarTypeResponse>(carType); //map

            return carTypeResponse;
        }

        public PaginateListCarTypeResponse GetList(PageRequest request)
        {
            IPaginate<CarType> brands = _carTypeDal.GetList(index: request.Index,
                                                             size: request.Size);

            PaginateListCarTypeResponse response = _mapper.Map<PaginateListCarTypeResponse>(brands);

            return response;
        }

        public void Update(UpdateCarTypeRequest request)
        {
            _businessRules.CheckIfCarTypeNotExist(request.Id);
            CarType carType = _mapper.Map<CarType>(request);
            _carTypeDal.Update(carType);

        }
    }
}
