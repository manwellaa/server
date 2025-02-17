﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Bit.Core.Models.Data;
using Bit.Core.Models.Table.Provider;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using EfModel = Bit.Core.Models.EntityFramework;
using TableModel = Bit.Core.Models.Table;

namespace Bit.Core.Repositories.EntityFramework
{
    public class ProviderRepository : Repository<Provider, EfModel.Provider.Provider, Guid>, IProviderRepository
    {

        public ProviderRepository(IServiceScopeFactory serviceScopeFactory, IMapper mapper)
            : base(serviceScopeFactory, mapper, context => context.Providers)
        { }

        public async Task<ICollection<Provider>> SearchAsync(string name, string userEmail, int skip, int take)
        {
            using (var scope = ServiceScopeFactory.CreateScope())
            {
                var dbContext = GetDatabaseContext(scope);
                var query = !string.IsNullOrWhiteSpace(userEmail) ?
                    (from p in dbContext.Providers
                     join pu in dbContext.ProviderUsers
                         on p.Id equals pu.ProviderId
                     join u in dbContext.Users
                         on pu.UserId equals u.Id
                     where (string.IsNullOrWhiteSpace(name) || p.Name.Contains(name)) &&
                         u.Email == userEmail
                     orderby p.CreationDate descending
                     select new { p, pu, u }).Skip(skip).Take(take).Select(x => x.p) :
                    (from p in dbContext.Providers
                     where string.IsNullOrWhiteSpace(name) || p.Name.Contains(name)
                     orderby p.CreationDate descending
                     select new { p }).Skip(skip).Take(take).Select(x => x.p);
                var providers = await query.ToArrayAsync();
                return Mapper.Map<List<Provider>>(providers);
            }
        }

        public async Task<ICollection<ProviderAbility>> GetManyAbilitiesAsync()
        {
            using (var scope = ServiceScopeFactory.CreateScope())
            {
                var dbContext = GetDatabaseContext(scope);
                return await GetDbSet(dbContext)
                    .Select(e => new ProviderAbility
                    {
                        Enabled = e.Enabled,
                        Id = e.Id,
                        UseEvents = e.UseEvents,
                    }).ToListAsync();
            }
        }
    }
}
