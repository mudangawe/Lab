using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Common.Interface.Shared;

namespace WebAPI.Common.Interface.IRepository
{
    public interface IRepository<T> : Shared<T>
    {
       
        Task<bool> GetBy(Expression<Func<T,bool>> obj);
    }
}
