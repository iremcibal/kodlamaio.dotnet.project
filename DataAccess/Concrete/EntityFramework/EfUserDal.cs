using Core.CrossCuttingConcerns.Security.Entities;
using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Context;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, ReCapProjectContext>, IUserDal
    {
        public ICollection<OperationClaim> GetClaims(User user) // user: id 1
        {
            using (ReCapProjectContext context = new())
            {
                IQueryable<OperationClaim> query = from operationClaim in context.OperationClaims
                                                   join userOperationClaim in context.UserOperationClaims
                                                       on operationClaim.Id equals userOperationClaim.OperationClaimId
                                                   where userOperationClaim.UserId == user.Id
                                                   select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return query.ToHashSet();
            }
        }
    }
}
