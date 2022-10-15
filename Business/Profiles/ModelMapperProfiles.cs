using AutoMapper;
using Business.Requests.Models;
using Business.Responses.Models;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Profiles
{
    public class ModelMapperProfiles : Profile
    {
        public ModelMapperProfiles()
        {
            CreateMap<CreateModelRequest, Model>();
            CreateMap<UpdateModelRequest, Model>();
            CreateMap<DeleteModelRequest, Model>();
            CreateMap<Model, ListModelResponse>();
            CreateMap<Model, GetModelResponse>();
        }
    }
}
