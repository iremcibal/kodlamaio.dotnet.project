using Business.Requests.Cars;
using Business.Responses.Cars;
using Core.Business.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarService
    {
        GetCarResponse GetById(GetCarRequest request);
        PaginateListCarResponse GetList(PageRequest request);
        void Add(CreateCarRequest request);
        void Delete(DeleteCarRequest request);
        void Update(UpdateCarRequest request);
    }
}
