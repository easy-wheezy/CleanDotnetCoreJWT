using System.Collections.Generic;
using System.Linq;
using GateKeeper.Core.Contracts;
using GateKeeper.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace GateKeeper.Gateways
{
    public class AccessRightRepository : BaseRepository<AccessRight>, IAccessRightRepository
    {
        public AccessRightRepository(DbContext context):base(context)
        {
            
        }
        public List<string> ValidateAccessRight(AccessRight accessRight)
        {
            List<string> errors = new List<string>();
            if(dbset.Any(ar => ar.Name == accessRight.Name && ar.ProductID == accessRight.ProductID))
                errors.Add($"Access right already exists for product");
            return errors;
        }
    }
}