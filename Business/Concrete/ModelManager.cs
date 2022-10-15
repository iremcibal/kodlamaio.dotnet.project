using AutoMapper;
using Business.Abstract;
using Business.BusinessRules;
using Business.Requests.Models;
using Business.Responses.Models;
using DataAccess.Abstract;
using Entities.Concrete;
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

        public GetModelResponse GetById(int id)
        {
            Model model = _modelDal.Get(f => f.Id == id);
            GetModelResponse response = _mapper.Map<GetModelResponse>(model);

            return response;
        }

        public List<ListModelResponse> GetList()
        {
            List<Model> model = _modelDal.GetList();
            List<ListModelResponse> lists = _mapper.Map<List<ListModelResponse>>(model);

            return lists;
        }

        public List<ListModelResponse> GetModelsByBrandId(int brandId)
        {
            List<Model> model = _modelDal.GetList(m=>m.BrandId==brandId);
            List<ListModelResponse> lists = _mapper.Map<List<ListModelResponse>>(model);

            return lists;
        }

        public List<ListModelResponse> GetModelsByCarTypeId(int carTypeId)
        {
            List<Model> model = _modelDal.GetList(m => m.CarTypeId == carTypeId);
            List<ListModelResponse> lists = _mapper.Map<List<ListModelResponse>>(model);

            return lists;
        }

        public List<ListModelResponse> GetModelsByColorId(int colorId)
        {
            List<Model> model = _modelDal.GetList(m => m.ColorId == colorId);
            List<ListModelResponse> lists = _mapper.Map<List<ListModelResponse>>(model);

            return lists;
        }

        public List<ListModelResponse> GetModelsByFuelId(int fuelId)
        {
            List<Model> model = _modelDal.GetList(m => m.FuelId == fuelId);
            List<ListModelResponse> lists = _mapper.Map<List<ListModelResponse>>(model);

            return lists;
        }

        public void Update(UpdateModelRequest request)
        {
            _businessRules.CheckIfModelExist(request.Id);
            Model model = _mapper.Map<Model>(request);
            _modelDal.Update(model);
        }
    }
}
