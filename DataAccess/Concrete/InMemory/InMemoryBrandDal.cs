using Core.DataAccess.Paging;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.InMemory
{
    public class InMemoryBrandDal : IBrandDal
    {
        private List<Brand> _brands;

        public InMemoryBrandDal()
        {
           _brands = new List<Brand>();
        }

        public void Add(Brand brand)
        {
            Brand brandToAdd = new Brand { Id = _brands.Count+1,Name=brand.Name };
            _brands.Add(brandToAdd);
        }

        public void Delete(Brand brand)
        {
            Brand brandToDelete = _brands.FirstOrDefault(b=>b.Id==brand.Id);
            _brands.Remove(brandToDelete);
        }

        public List<Brand> GetList()
        {
            return _brands;
        }

        public Brand? GetById(int id)
        {
            return _brands.FirstOrDefault(b => b.Id == id);
        }

        public Brand? GetByName(string brandName)
        {
            return _brands.FirstOrDefault(b => b.Name == brandName);
        }

        public void Update(Brand brand)
        {
            var brandToUpdate = _brands.First(b=>b.Id==brand.Id);
            brandToUpdate.Name = brand.Name;
        }

        public Brand? Get(Expression<Func<Brand, bool>> predicate)
        {
            throw new NotImplementedException();
        }

        public List<Brand> GetList(Expression<Func<Brand, bool>>? predicate = null)
        {
            throw new NotImplementedException();
        }

        public Brand? Get(Expression<Func<Brand, bool>> predicate, Func<IQueryable<Brand>, IIncludableQueryable<Brand, object>> include = null, bool enableTracking = true)
        {
            throw new NotImplementedException();
        }

        public IPaginate<Brand> GetList(Expression<Func<Brand, bool>>? predicate = null, Func<IQueryable<Brand>, IIncludableQueryable<Brand, object>> include = null, Func<IQueryable<Brand>, IOrderedQueryable<Brand>> orderBy = null, int index = 0, int size = 10, bool enableTracking = true)
        {
            throw new NotImplementedException();
        }
    }
}
