using AutoMapper;
using Business.Abstract;
using Business.BusinessRules;
using Business.Requests.Models;
using Business.Responses.Models;
using Business.ValidationRules.FluentValidation.Model;
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
    public class ModelManager : IModelService
    {
        private IModelDal _modelDal;
        private ModelBusinessRules _businessRules;
        private IMapper _mapper;

        public ModelManager(IModelDal modelDal, ModelBusinessRules businessRules, IMapper mapper)
        {
            _modelDal = modelDal;
            _businessRules = businessRules;
            _mapper = mapper;
        }

        public void Add(CreateModelRequest request)
        {
            ValidationTool<CreateModelRequest>.Validate(typeof(CreateModelRequestValidator),request);
            _businessRules.CheckIfModelNameExist(request.Name);
            Model model = _mapper.Map<Model>(request);
            
            _modelDal.Add(model);
        }

        public void Delete(DeleteModelRequest request)
        {
            _businessRules.CheckIfModelExist(request.Id);
            Model model = _mapper.Map<Model>(request);
            _modelDal.Delete(model);
        }

        public GetModelResponse GetById(GetModelRequest request)
        {
            Model model = _modelDal.Get(f => f.Id == request.Id,
                f=>f.Include(fi=>fi.brand).Include(fi=>fi.carType).Include(fi=>fi.color).Include(fi=>fi.fuel));
            GetModelResponse response = _mapper.Map<GetModelResponse>(model);

            return response;
        }

        public PaginateListModelResponse GetList(PageRequest request)
        {
            IPaginate<Model> brands = _modelDal.GetList(index: request.Index,
                                                                size: request.Size);

            PaginateListModelResponse response = _mapper.Map<PaginateListModelResponse>(brands);

            return response;
        }

        public PaginateListModelResponse GetModelsByBrandId(PageRequest request, int brandId)
        {
            IPaginate<Model> brands = _modelDal.GetList(m=>m.BrandId==brandId, index: request.Index,
                                                                size: request.Size);

            PaginateListModelResponse response = _mapper.Map<PaginateListModelResponse>(brands);

            return response;
        }

        public PaginateListModelResponse GetModelsByCarTypeId(PageRequest request, int carTypeId)
        {
            IPaginate<Model> brands = _modelDal.GetList(m => m.CarTypeId == carTypeId, index: request.Index,
                                                                size: request.Size);

            PaginateListModelResponse response = _mapper.Map<PaginateListModelResponse>(brands);

            return response;
        }

        public PaginateListModelResponse GetModelsByColorId(PageRequest request, int colorId)
        {
            IPaginate<Model> brands = _modelDal.GetList(m => m.ColorId == colorId, index: request.Index,
                                                                size: request.Size);

            PaginateListModelResponse response = _mapper.Map<PaginateListModelResponse>(brands);

            return response;
        }

        public PaginateListModelResponse GetModelsByFuelId(PageRequest request, int fuelId)
        {
            IPaginate<Model> brands = _modelDal.GetList(m => m.FuelId == fuelId, index: request.Index,
                                                              size: request.Size);

            PaginateListModelResponse response = _mapper.Map<PaginateListModelResponse>(brands);

            return response;
        }

        public void Update(UpdateModelRequest request)
        {
            _businessRules.CheckIfModelExist(request.Id);
            Model model = _mapper.Map<Model>(request);
            _modelDal.Update(model);
        }
    }
}
