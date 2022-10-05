using Business.Requests.Brands;
using Business.Responses.Brands;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IBrandService
    {
        GetBrandResponse GetById(int id);
        List<ListBrandResponse> GetList();
        void Add(CreateBrandRequest request);
        void Delete(DeleteBrandRequest request);
        void Update(UpdateBrandRequest request);
    }
}
