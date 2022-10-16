using Business.Requests.Cars;
using Business.Responses.Cars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarService
    {
        GetCarResponse GetById(int id);
        List<ListCarResponse> GetList();
        void Add(CreateCarRequest request);
        void Delete(DeleteCarRequest request);
        void Update(UpdateCarRequest request);
    }
}
