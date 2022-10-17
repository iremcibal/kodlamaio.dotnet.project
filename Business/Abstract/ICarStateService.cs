using Business.Requests.CarStates;
using Business.Responses.CarStates;
using Core.Business.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICarStateService
    {
        GetCarStateResponse GetById(int id);
        PaginateListCarStateResponse GetList(PageRequest request);
        void Add(CreateCarStateRequest request);
        void Delete(DeleteCarStateRequest request);
        void Update(UpdateCarStateRequest request);
    }
}
