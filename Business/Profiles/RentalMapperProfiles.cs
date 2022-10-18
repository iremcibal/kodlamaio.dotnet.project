using AutoMapper;
using Business.Requests.Rentals;
using Business.Responses.Rentals;
using Core.DataAccess.Paging;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class RentalMapperProfiles : Profile
    {
        public RentalMapperProfiles()
        {
            CreateMap<CreateRentalRequest, Rental>();
            CreateMap<UpdateRentalRequest, Rental>();
            CreateMap<DeleteRentalRequest, Rental>();
            CreateMap<Rental, ListRentalResponse>();
            CreateMap<Rental, GetRentalResponse>();
            CreateMap<IPaginate<Rental>, PaginateListRentalResponse>();
        }
    }
}
