using Business.Requests.Fuels;
using Business.Responses.Fuels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IFuelService
    {
        public void Add(CreateFuelRequest request);
        public void Delete(DeleteFuelRequest request);
        public void Update(UpdateFuelRequest request);
        GetFuelResponse GetById(int id);
        List<ListFuelResponse> GetList();
    }
}
