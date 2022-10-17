using Business.Requests.Models;
using Business.Responses.Models;
using Core.Business.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IModelService
    {
        GetModelResponse GetById(GetModelRequest request);
        PaginateListModelResponse GetList(PageRequest request);
        void Add(CreateModelRequest request);
        void Delete(DeleteModelRequest request);
        void Update(UpdateModelRequest request);
        PaginateListModelResponse GetModelsByBrandId(PageRequest request,int brandId);
        PaginateListModelResponse GetModelsByColorId(PageRequest request,int colorId);
        PaginateListModelResponse GetModelsByFuelId(PageRequest request,int fuelId);
        PaginateListModelResponse GetModelsByCarTypeId(PageRequest request,int carTypeId);
    }
}
