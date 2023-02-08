using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tactsoft.Core.Entities;
using Tactsoft.Service.DbDependencies;
using Tactsoft.Service.Services.Base;

namespace Tactsoft.Service.Services
{
    public class EmployeeSalaryTbService : BaseService<EmployeeSalaryTb>, IEmployeeSalaryTbService
    {
        private readonly AppDbContext _appDbContext;
      
        public EmployeeSalaryTbService(AppDbContext context) : base(context)
        {
            this._appDbContext = context;
        }
    }
}
