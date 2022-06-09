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
    public class EmployeeServiceAsync : IEmployeeServiceAsync
    {
        private readonly IEmployeeRepositoryAsync employeeRepositoryAsync;
        public EmployeeServiceAsync(IEmployeeRepositoryAsync _emp)
        {
            employeeRepositoryAsync = _emp;
        }

        public async Task<int> AddEmployeeAsync(EmployeeRequestModel employee)
        {
            Employee emp = new Employee();
            emp.Address = employee.Address;
            emp.RegionId = employee.RegionId;
            emp.BirthDate = employee.BirthDate;
            emp.ReportsTo = employee.ReportsTo;
            emp.PhotoPath = employee.PhotoPath;
            emp.City = employee.City;
            emp.Country = employee.Country;
            emp.FirstName = employee.FirstName;
            emp.LastName = employee.LastName;
            emp.Phone = employee.Phone;
            emp.HireDate = employee.HireDate;
            emp.PostalCode = employee.PostalCode;
            emp.Title = employee.Title;
            emp.TitleOfCourtesy = employee.TitleOfCourtesy;
            return await employeeRepositoryAsync.InsertAsync(emp);
        }

        public async Task<IEnumerable<EmployeeResponseModel>> GetAllAsync()
        {
            var collection = await employeeRepositoryAsync.GetAllAsync();

            if (collection != null)
            {
                List<EmployeeResponseModel> result = new List<EmployeeResponseModel>();
                foreach (var item in collection)
                {
                    EmployeeResponseModel model = new EmployeeResponseModel();
                    model.Id = item.Id;
                    model.Phone = item.Phone;
                    model.PhotoPath = item.PhotoPath;
                    model.Title = item.Title;
                    model.BirthDate = item.BirthDate;
                    model.Address = item.Address;
                    model.City = item.City;
                    model.FullName = item.FirstName + " " + item.LastName;
                    model.TitleOfCourtesy = item.TitleOfCourtesy;
                    result.Add(model);
                }
                return result;
            }
            return null;
        }
    }
}
