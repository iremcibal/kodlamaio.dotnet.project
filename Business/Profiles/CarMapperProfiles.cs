using AutoMapper;
using Business.Requests.Cars;
using Business.Responses.Cars;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class CarMapperProfiles : Profile
    {
        public CarMapperProfiles()
        {
            CreateMap<CreateCarRequest, Car>();
            CreateMap<UpdateCarRequest, Car>();
            CreateMap<DeleteCarRequest, Car>();
            CreateMap<Car, ListCarResponse>();
            CreateMap<Car, GetCarResponse>();
        }
    }
}
