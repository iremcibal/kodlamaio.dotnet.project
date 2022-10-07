using AutoMapper;
using Business.Requests.CarTypes;
using Business.Responses.Brands;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class CarTypeMapperProfiles : Profile
    {
        public CarTypeMapperProfiles()
        {
            CreateMap<CreateCarTypeRequest, CarType>()
                .ForMember(ct=>ct.Name,config=>config.MapFrom(ct=>ct.Name));
            CreateMap<DeleteCarTypeRequest, CarType>()
                .ForMember(ct => ct.Id, config => config.MapFrom(ct => ct.Id)); 
            CreateMap<UpdateCarTypeRequest, CarType>();
            CreateMap<CarType, GetCarTypeResponse>();
            CreateMap<CarType, ListCarTypeResponse>();
        }
    }
}
