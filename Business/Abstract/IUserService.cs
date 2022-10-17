using Business.Requests.Users;
using Business.Responses.Users;
using Core.Business.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        GetUserResponse GetById(int id);
        PaginateListUserResponse GetList(PageRequest request);
        void Add(CreateUserRequest request);
        void Delete(DeleteUserRequest request);
        void Update(UpdateUserRequest request);
    }
}
