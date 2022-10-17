using Business.Requests.CarTypes;
using Business.Responses.Brands;
using Business.Responses.CarTypes;
using Core.Business.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarTypeService
    {
        GetCarTypeResponse GetById(int id);
        PaginateListCarTypeResponse GetList(PageRequest request);
        void Add(CreateCarTypeRequest request);
        void Delete(DeleteCarTypeRequest request);
        void Update(UpdateCarTypeRequest request);
    }
}
