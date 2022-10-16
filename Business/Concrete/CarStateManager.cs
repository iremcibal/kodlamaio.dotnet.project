﻿using AutoMapper;
using Business.Abstract;
using Business.BusinessRules;
using Business.Requests.CarStates;
using Business.Responses.CarStates;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CarStateManager : ICarStateService
    {
        ICarStateDal _carStateDal;
        IMapper _mapper;
        CarStateBusinessRules _businessRules;

        public CarStateManager(ICarStateDal carStateDal, IMapper mapper, CarStateBusinessRules businessRules)
        {
            _carStateDal = carStateDal;
            _mapper = mapper;
            _businessRules = businessRules;
        }

        public void Add(CreateCarStateRequest request)
        {
            _businessRules.CheckIfCarStateNameExist(request.Name);

            CarState carState = _mapper.Map<CarState>(request);

            _carStateDal.Add(carState);
        }

        public void Delete(DeleteCarStateRequest request)
        {
            _businessRules.CheckIfCarStateExist(request.Id);

            CarState carState = _mapper.Map<CarState>(request);
            _carStateDal.Delete(carState);
        }

        public GetCarStateResponse GetById(int id)
        {
            CarState carState = _carStateDal.Get(b => b.Id == id);
            var response = _mapper.Map<GetCarStateResponse>(carState);

            return response;
        }

        public List<ListCarStateResponse> GetList()
        {
            List<CarState> carStateToList = _carStateDal.GetList();
            List<ListCarStateResponse> response = _mapper.Map<List<ListCarStateResponse>>(carStateToList);

            return response;
        }

        public void Update(UpdateCarStateRequest request)
        {
            _businessRules.CheckIfCarStateExist(request.Id);

            CarState carState = _mapper.Map<CarState>(request);
            _carStateDal.Update(carState);
        }
    }
}
