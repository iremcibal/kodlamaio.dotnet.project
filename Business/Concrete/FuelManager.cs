using AutoMapper;
using Business.Abstract;
using Business.BusinessRules;
using Business.Requests.Fuels;
using Business.Responses.Fuels;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class FuelManager : IFuelService
    {
        IFuelDal _fuelDal;
        IMapper _mapper;
        FuelBusinessRules _businessRules;

        public FuelManager(IFuelDal fuelDal, IMapper mapper, FuelBusinessRules businessRules)
        {
            _fuelDal = fuelDal;
            _mapper = mapper;
            _businessRules = businessRules;
        }

        public void Add(CreateFuelRequest request)
        {
            _businessRules.CheckIfFuelNameExist(request.Name);
            Fuel fuel = _mapper.Map<Fuel>(request);
            _fuelDal.Add(fuel);
        }

        public void Delete(DeleteFuelRequest request)
        {
            _businessRules.CheckIfFuelExist(request.Id);
            Fuel fuel = _mapper.Map<Fuel>(request);
            _fuelDal.Delete(fuel);
        }

        public GetFuelResponse GetById(int id)
        {
            Fuel fuel = _fuelDal.Get(f=>f.Id == id);
            GetFuelResponse response = _mapper.Map<GetFuelResponse>(fuel);

            return response;
        }

        public List<ListFuelResponse> GetList()
        {
            List<Fuel> fuel = _fuelDal.GetList();
            List<ListFuelResponse> lists = _mapper.Map<List<ListFuelResponse>>(fuel);

            return lists;

        }

        public void Update(UpdateFuelRequest request)
        {
            _businessRules.CheckIfFuelExist(request.Id);
            Fuel fuel = _mapper.Map<Fuel>(request);
            _fuelDal.Update(fuel);

        }
    }
}
