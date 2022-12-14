using AutoMapper;
using Business.Abstract;
using Business.BusinessRules;
using Business.Requests.Users;
using Business.Responses.Users;
using Core.Business.Requests;
using Core.DataAccess.Paging;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        IMapper _mapper;
        UserBusinessRules _businessRules;

        public UserManager(IUserDal userDal, IMapper mapper, UserBusinessRules businessRules)
        {
            _userDal = userDal;
            _mapper = mapper;
            _businessRules = businessRules;
        }

        public void Add(CreateUserRequest request)
        {
            _businessRules.CheckIfUserNameExist(request.FirstName);

            User user = _mapper.Map<User>(request);

            _userDal.Add(user);
        }

        public void Delete(DeleteUserRequest request)
        {
            _businessRules.CheckIfUserExist(request.Id);

            User user = _mapper.Map<User>(request);

            _userDal.Delete(user);
        }

        public GetUserResponse GetById(int id)
        {
            User user = _userDal.Get(b => b.Id == id);
            var response = _mapper.Map<GetUserResponse>(user);

            return response;
        }

        public PaginateListUserResponse GetList(PageRequest request)
        {
            IPaginate<User> brands = _userDal.GetList(index: request.Index,
                                                                   size: request.Size);

            PaginateListUserResponse response = _mapper.Map<PaginateListUserResponse>(brands);

            return response;
        }

        public void Update(UpdateUserRequest request)
        {
            _businessRules.CheckIfUserExist(request.Id);

            User user = _mapper.Map<User>(request);

            _userDal.Update(user);
        }
    }
}
