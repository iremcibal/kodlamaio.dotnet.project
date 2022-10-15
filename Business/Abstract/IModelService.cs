using Business.Requests.Models;
using Business.Responses.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IModelService
    {
        GetModelResponse GetById(int id);
        List<ListModelResponse> GetList();
        void Add(CreateModelRequest request);
        void Delete(DeleteModelRequest request);
        void Update(UpdateModelRequest request);
        List<ListModelResponse> GetModelsByBrandId(int brandId);
        List<ListModelResponse> GetModelsByColorId(int colorId);
        List<ListModelResponse> GetModelsByFuelId(int fuelId);
        List<ListModelResponse> GetModelsByCarTypeId(int carTypeId);
    }
}
