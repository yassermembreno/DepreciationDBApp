using DepreciationDBApp.Domain.Entities;
using DepreciationDBApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepreciationDBApp.Infrastructure.Repositories
{
    public class EFEmployeeRepository : IEmployeeRepository
    {
        private IDepreciationDbContext depreciationDbContext;

        public EFEmployeeRepository(IDepreciationDbContext depreciationDbContext)
        {
            this.depreciationDbContext = depreciationDbContext;
        }
        public void Create(Employee t)
        {
            try
            {
                ValidateEmployee(t);
                depreciationDbContext.Employees.Add(t);
                depreciationDbContext.SaveChanges();
            }
            catch 
            {
                throw;
            }
        }

        public bool Delete(Employee t)
        {
            throw new NotImplementedException();
        }

        public Employee FindByDni(string dni)
        {
            throw new NotImplementedException();
        }

        public Employee FindByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Employee> FindByLastnames(string lastnames)
        {
            throw new NotImplementedException();
        }

        public List<Employee> GetAll()
        {
            throw new NotImplementedException();
        }

        public bool SetAssetsToEmployee(Employee employee, List<Asset> assets)
        {
            throw new NotImplementedException();
        }

        public bool SetAssetToEmployee(Employee employee, Asset asset)
        {
            throw new NotImplementedException();
        }

        public int Update(Employee t)
        {
            throw new NotImplementedException();
        }

        private void ValidateEmployee(Employee employee)
        {
            if(employee == null)
            {
                throw new ArgumentNullException("El objeto employee no puede ser null.");
            }

            if (string.IsNullOrWhiteSpace(employee.Email))
            {
                throw new Exception("El email no puede ser null o vacio.");
            }

            if (string.IsNullOrWhiteSpace(employee.Names))
            {
                throw new Exception("El nombre del empleado no puede ser null o vacio.");
            }
        }
    }
}
