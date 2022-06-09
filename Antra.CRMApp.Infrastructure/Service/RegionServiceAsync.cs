using Antra.CRMApp.Core.Contract.Repository;
using Antra.CRMApp.Core.Contract.Service;
using Antra.CRMApp.Core.Entity;
using Antra.CRMApp.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Antra.CRMApp.Infrastructure.Service
{
    public class RegionServiceAsync:IRegionServiceAsync
    {
        private readonly IRegionRepositoryAsync regionRepositoryAsync;
        public RegionServiceAsync(IRegionRepositoryAsync repo)
        {
            regionRepositoryAsync = repo;
        }
        public async Task<int> AddRegionAsync(RegionModel model)
        {
            Region region = new Region();
            region.Name = model.Name;
         return await  regionRepositoryAsync.InsertAsync(region);
        }

        public async Task<IEnumerable<RegionModel>> GetAllAsync()
        {
          var collection = await regionRepositoryAsync.GetAllAsync();
            if (collection != null)
            {
                List<RegionModel> regionModels = new List<RegionModel>();
                foreach (var item in collection)
                {
                    RegionModel model = new RegionModel();
                    model.Name = item.Name;
                    model.Id   = item.Id;
                    regionModels.Add(model);
                }
                return regionModels;
            }
            return null;
        }
    }
}
