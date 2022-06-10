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
    public class VendorServiceAsync : IVendorServiceAsync
    {
        private readonly IVendorRepositoryAsync vendorRepositoryAsync;
        public VendorServiceAsync(IVendorRepositoryAsync vendorRepositoryAsync)
        {
            this.vendorRepositoryAsync = vendorRepositoryAsync;
        }
        public async Task<int> AddVendorAsync(VendorRequestModel vendor)
        {
            Vendor ven = new Vendor();
            ven.Name = vendor.Name;
            ven.City = vendor.City;
            ven.Country = vendor.Country;
            ven.Mobile = vendor.Mobile;
            ven.EmailId = vendor.EmailId;
            ven.IsActive = vendor.IsActive;
            return await vendorRepositoryAsync.InsertAsync(ven);
        }

        public async Task<int> DeleteVendorAsync(int id)
        {
            return await vendorRepositoryAsync.DeleteAsync(id);
        }

        public async Task<IEnumerable<VendorResponseModel>> GetAllAsync()
        {
            var collection = await vendorRepositoryAsync.GetAllAsync();

            if (collection != null)
            {
                List<VendorResponseModel> result = new List<VendorResponseModel>();
                foreach (var item in collection)
                {
                    VendorResponseModel model = new VendorResponseModel();
                    model.Id = item.Id;
                    model.Name = item.Name;
                    model.City = item.City;
                    model.Country = item.Country;
                    model.Mobile = item.Mobile;
                    model.EmailId = item.EmailId;
                    model.IsActive = item.IsActive;
                    result.Add(model);
                }
                return result;
            }
            return null;
        }

        public async Task<VendorResponseModel> GetByIdAsync(int id)
        {
            var item = await vendorRepositoryAsync.GetByIdAsync(id);
            if (item != null)
            {
                VendorResponseModel model = new VendorResponseModel();
                model.Id = item.Id;
                model.Name = item.Name;
                model.City = item.City;
                model.Country = item.Country;
                model.Mobile = item.Mobile;
                model.EmailId = item.EmailId;
                model.IsActive = item.IsActive;
                return model;
            }
            return null;
        }

        public async Task<VendorRequestModel> GetVendorForEditAsync(int id)
        {
            var item = await vendorRepositoryAsync.GetByIdAsync(id);
            if (item != null)
            {
                VendorRequestModel model = new VendorRequestModel();
                model.Id = item.Id;
                model.Name = item.Name;
                model.City = item.City;
                model.Country = item.Country;
                model.Mobile = item.Mobile;
                model.EmailId = item.EmailId;
                model.IsActive = item.IsActive;
                return model;
            }
            return null;
        }

        public async Task<int> UpdateVendorAsync(VendorRequestModel vendor)
        {
            Vendor ven = new Vendor();
            ven.Id = vendor.Id;
            ven.Name = vendor.Name;
            ven.City = vendor.City;
            ven.Country = vendor.Country;
            ven.Mobile = vendor.Mobile;
            ven.EmailId = vendor.EmailId;
            ven.IsActive = vendor.IsActive;
            return await vendorRepositoryAsync.UpdateAsync(ven);
        }
    }
}
