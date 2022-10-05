using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IBrandDal
    {
        Brand GetById(int id);
        List<Brand> GetList();
        void Add(Brand brand);
        void Delete(Brand brand);
        void Update(Brand brand);
        Brand GetByName(string brandName);

    }
}
