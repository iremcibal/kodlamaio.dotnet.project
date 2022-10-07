using Business.Requests.CarTypes;
using Business.Responses.Brands;
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
        List<ListCarTypeResponse> GetList();
        void Add(CreateCarTypeRequest request);
        void Delete(DeleteCarTypeRequest request);
        void Update(UpdateCarTypeRequest request);
    }
}
