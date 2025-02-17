﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bit.Core.Models.Data;
using Bit.Core.Models.Table;

namespace Bit.Core.Services
{
    public interface IGroupService
    {
        Task SaveAsync(Group group, IEnumerable<SelectionReadOnly> collections = null);
        Task DeleteAsync(Group group);
        Task DeleteUserAsync(Group group, Guid organizationUserId);
    }
}
