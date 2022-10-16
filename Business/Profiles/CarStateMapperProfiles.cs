using AutoMapper;
using Business.Requests.CarStates;
using Business.Responses.CarStates;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class CarStateMapperProfiles : Profile
    {
        public CarStateMapperProfiles()
        {
            CreateMap<CreateCarStateRequest, CarState>();
            CreateMap<UpdateCarStateRequest, CarState>();
            CreateMap<DeleteCarStateRequest, CarState>();
            CreateMap<CarState, ListCarStateResponse>();
            CreateMap<CarState, GetCarStateResponse>();
        }
    }
}
