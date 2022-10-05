// See https://aka.ms/new-console-template for more information

using AutoMapper;
using Business.Abstract;
using Business.BusinessRules;
using Business.Concrete;
using Business.Profiles;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;

//IBrandDal brandDal = new InMemoryBrandDal();
//BrandBusinessRules brandBusinessRules = new BrandBusinessRules(brandDal);
//IMapper mapper = new BrandMapperProfiles();

//IBrandService brandService = new BrandManager(brandDal, brandBusinessRules);

//Brand brandToAdd1 = new Brand { Id = 1, Name="Toyota" };
//Brand brandToAdd2 = new Brand { Id = 2, Name = "BMW" };
////Brand brandToException = new Brand { Id = 3, Name = "BMW" };

//brandService.Add(brandToAdd1);
//brandService.Add(brandToAdd2);
////brandService.Add(brandToException);

//Brand brandToUpdate = brandService.GetById(1);
//brandToUpdate.Name = "Audi";
//brandService.Update(brandToUpdate);

//Brand brandToDelete = brandService.GetById(2);
//brandService.Delete(brandToDelete);

//List<Brand> brandList = brandService.GetAll();

//foreach (Brand brand in brandList)
//    Console.WriteLine($"Id : {brand.Name}");