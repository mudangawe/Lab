using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAPI.Common.Interface.Shared
{
    public interface Shared<T>
    {
        Task<bool> Add(T obj);
        Task<IEnumerable<T>> GetAll();
    }
}
