using Business.Requests.Customers;
using Business.Responses.Customers;
using Core.Business.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICustomerService
    {
        GetCustomerResponse GetById(GetCustomerRequest request);
        PaginateListCustomerResponse GetList(PageRequest request);
        void Add(CreateCustomerRequest request);
        void Delete(DeleteCustomerRequest request);
        void Update(UpdateCustomerRequest request);

    }
}
