using AutoMapper;
using Business.Abstract;
using Business.Requests.Customers;
using Business.Responses.Customers;
using Core.Business.Requests;
using Core.DataAccess.Paging;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        private ICustomerDal _customerDal;
        private IMapper _mapper;

        public CustomerManager(ICustomerDal customerDal, IMapper mapper)
        {
            _customerDal = customerDal;
            _mapper = mapper;
        }

        public void Add(CreateCustomerRequest request)
        {
            Customer customer = _mapper.Map<Customer>(request);

            _customerDal.Add(customer);
        }

        public void Delete(DeleteCustomerRequest request)
        {
            Customer customer = _mapper.Map<Customer>(request);

            _customerDal.Delete(customer);
        }

        public GetCustomerResponse GetById(GetCustomerRequest request)
        {
            Customer customer = _customerDal.Get(c => c.Id == request.Id, c => c.Include(ci=>ci.User));
            var response = _mapper.Map<GetCustomerResponse>(request);

            return response;
        }


        public PaginateListCustomerResponse GetList(PageRequest request)
        {
            IPaginate<Customer> brands = _customerDal.GetList(index: request.Index,
                                                               size: request.Size);

            PaginateListCustomerResponse response = _mapper.Map<PaginateListCustomerResponse>(brands);

            return response;
        }

        public void Update(UpdateCustomerRequest request)
        {
            Customer customer = _mapper.Map<Customer>(request);

            _customerDal.Update(customer);
        }
    }
}
