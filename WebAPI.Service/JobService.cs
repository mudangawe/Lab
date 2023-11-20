using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Common.Entities;
using WebAPI.Common.Interface.IRepository;
using WebAPI.Common.Interface.Shared;

namespace WebAPI.Service
{
    public class JobService : Shared<JobModel>
    {
        private readonly IRepository<JobModel> _iRepository;
        public JobService(IRepository<JobModel> _iRepository) 
        {
            this._iRepository = _iRepository;
        }
        public async Task<bool> Add(JobModel obj)
        {
           return await _iRepository.Add(obj);
        }

        public async Task<IEnumerable<JobModel>> GetAll()
        {
            return await _iRepository.GetAll();
        }
    }
}
