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
    public class CustomerServiceAsync : ICustomerServiceAsync
    {
        private readonly ICustomerRepositoryAsync customerRepositoryAsync;
        public CustomerServiceAsync(ICustomerRepositoryAsync _cus)
        {
            customerRepositoryAsync = _cus;
        }
        public async Task<int> AddCustomerAsync(CustomerModel customer)
        {
            Customer cus = new Customer();
            cus.Name = customer.Name;
            cus.Title = customer.Title;
            cus.Address = customer.Address;
            cus.City = customer.City;
            cus.RegionId = customer.RegionId;
            cus.Country = customer.Country;
            cus.Phone = customer.Phone;
            cus.PostalCode = customer.PostalCode;
            return await customerRepositoryAsync.InsertAsync(cus);
        }

        public async Task<int> DeleteCustomerAsync(int id)
        {
            return await customerRepositoryAsync.DeleteAsync(id);
        }

        public async Task<IEnumerable<CustomerModel>> GetAllAsync()
        {
            var collection = await customerRepositoryAsync.GetAllAsync();
            if(collection != null)
            {
                List<CustomerModel> result = new List<CustomerModel>();
                foreach(var item in collection)
                {
                    CustomerModel model = new CustomerModel();
                    model.Id = item.Id;
                    model.Name = item.Name;
                    model.Title = item.Title;
                    model.Address = item.Address;
                    model.City = item.City;
                    model.RegionId = item.RegionId;
                    model.Country = item.Country;
                    model.Phone = item.Phone;
                    model.PostalCode = item.PostalCode;
                    result.Add(model);
                }
                return result;
            }
            return null;
        }

        public async Task<CustomerModel> GetByIdAsync(int id)
        {
            var item = await customerRepositoryAsync.GetByIdAsync(id);
            if(item != null)
            {
                CustomerModel model = new CustomerModel();
                model.Id = item.Id;
                model.Name = item.Name;
                model.Title = item.Title;
                model.Address = item.Address;
                model.City = item.City;
                model.RegionId = item.RegionId;
                model.Country = item.Country;
                model.Phone = item.Phone;
                model.PostalCode = item.PostalCode;
                return model;
            }
            return null;
        }

        public async Task<CustomerModel> GetCustomerForEditAsync(int id)
        {
            var item = await customerRepositoryAsync.GetByIdAsync(id);
            if (item != null)
            {
                CustomerModel model = new CustomerModel();
                model.Id = item.Id;
                model.Name = item.Name;
                model.Title = item.Title;
                model.Address = item.Address;
                model.City = item.City;
                model.RegionId = item.RegionId;
                model.Country = item.Country;
                model.Phone = item.Phone;
                model.PostalCode = item.PostalCode;
                return model;
            }
            return null;
        }

        public async Task<int> UpdateCustomerAsync(CustomerModel customer)
        {
            Customer cus = new Customer();
            cus.Id = customer.Id;
            cus.Name = customer.Name;
            cus.Title = customer.Title;
            cus.Address = customer.Address;
            cus.City = customer.City;
            cus.RegionId = customer.RegionId;
            cus.Country = customer.Country;
            cus.Phone = customer.Phone;
            cus.PostalCode = customer.PostalCode;
            return await customerRepositoryAsync.UpdateAsync(cus);
        }
    }
}
