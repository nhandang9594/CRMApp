﻿using Antra.CRMApp.Core.Contract.Repository;
using Antra.CRMApp.Core.Entity;
using Antra.CRMApp.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antra.CRMApp.Infrastructure.Repository
{
    public class RegionRepositoryAsync : BaseRepository<Region>, IRegionRepositoryAsync
    {
        public RegionRepositoryAsync(CrmDbContext _dbContext) : base(_dbContext)
        {
        }
    }
}
