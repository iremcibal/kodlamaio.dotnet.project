using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.BusinessRules
{
    public class BrandBusinessRules
    {
        private IBrandDal _brandDal;
        public BrandBusinessRules(IBrandDal brandDal)
        {
            this._brandDal = brandDal;
        }

        public void CheckIfBrandExist(Brand? brand)
        {
            if(brand == null)
            {
                throw new Exception("Brand not be exist");
            }
        }

        public void CheckIfBrandNotExist(Brand? brand)
        {
            if (brand != null)
            {
                throw new Exception("Brand already exist");
            }
        }

        public void CheckIfBrandExist(int brandId)
        {
            Brand? brand = _brandDal.GetById(brandId);
            CheckIfBrandExist(brand);
        }

        public void CheckIfBrandNameExist(string brandName)
        {
            Brand? brand = _brandDal.GetByName(brandName);
            CheckIfBrandNotExist(brand);
        }
    }
}
