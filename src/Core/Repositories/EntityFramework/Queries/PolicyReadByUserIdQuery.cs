﻿using System;
using System.Collections.Generic;
using System.Linq;
using Bit.Core.Enums;
using Bit.Core.Models.EntityFramework;

namespace Bit.Core.Repositories.EntityFramework.Queries
{
    public class PolicyReadByUserIdQuery : IQuery<Policy>
    {
        private readonly Guid _userId;

        public PolicyReadByUserIdQuery(Guid userId)
        {
            _userId = userId;
        }

        public IQueryable<Policy> Run(DatabaseContext dbContext)
        {
            var query = from p in dbContext.Policies
                        join ou in dbContext.OrganizationUsers
                            on p.OrganizationId equals ou.OrganizationId
                        join o in dbContext.Organizations
                            on ou.OrganizationId equals o.Id
                        where ou.UserId == _userId &&
                            ou.Status == OrganizationUserStatusType.Confirmed &&
                            o.Enabled == true
                        select p;

            return query;
        }
    }
}
