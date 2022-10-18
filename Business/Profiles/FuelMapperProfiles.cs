using AutoMapper;
using Business.Requests.Fuels;
using Business.Responses.Fuels;
using Core.DataAccess.Paging;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class FuelMapperProfiles : Profile
    {
        public FuelMapperProfiles()
        {
            CreateMap<CreateFuelRequest, Fuel>();
            CreateMap<DeleteFuelRequest, Fuel>();
            CreateMap<UpdateFuelRequest, Fuel>();
            CreateMap<Fuel, ListFuelResponse>();
            CreateMap<Fuel, GetFuelResponse>();
            CreateMap<IPaginate<Fuel>, PaginateListFuelResponse>();
        }
    }
}
