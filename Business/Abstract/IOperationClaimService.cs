using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Business;
using Core.Entities.Concrete;
using Core.Utilities.Results;

namespace Business.Abstract
{
    public interface IOperationClaimService: IEntityManagerRepository<OperationClaim>
    {
        IDataResult<OperationClaim> GetByName(string name);
    }
}
