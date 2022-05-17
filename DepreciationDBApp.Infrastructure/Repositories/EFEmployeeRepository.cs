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
            try
            {
                if (t == null)
                {
                    throw new ArgumentNullException("El objeto Employee no puede ser null.");
                }

                Employee employee = FindByDni(t.Dni);
                if (employee == null)
                {
                    throw new Exception($"El objeto con dni {t.Dni} no existe.");
                }

                depreciationDbContext.Employees.Remove(employee);
                int result = depreciationDbContext.SaveChanges();

                return result > 0;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Employee FindByDni(string dni)
        {
            try
            {
                if(string.IsNullOrWhiteSpace(dni))
                {

                    throw new ArgumentException($"El objeto dni no puede ser null o estar vacia");
                }

                return depreciationDbContext.Employees.FirstOrDefault(x => x.Dni.Equals(dni));
            }
            catch (Exception)
            {

                throw;
            }
        }

        public Employee FindByEmail(string email)
        {

            try
            {
                if(string.IsNullOrWhiteSpace(email))
                {

                    throw new ArgumentException($"El objeto email no puede ser null o estar vacio");
                }


                return depreciationDbContext.Employees.FirstOrDefault(x => x.Email.Equals(email));

            }
            catch (Exception)
            {

                throw;
            }
        }

        public IEnumerable<Employee> FindByLastnames(string lastnames)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(lastnames))
                {
                    throw new ArgumentException("El objeto apellido no puede ser null o estar vacio");
                }

                return depreciationDbContext.Employees.Where(x => x.Lastnames.Equals(lastnames, StringComparison.CurrentCultureIgnoreCase))
                                        .ToList();

            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<Employee> GetAll()
        {
            try
            {
                return depreciationDbContext.Employees.ToList();
            }
            catch(Exception)
            {
                throw;
            }   
        }
        
        public int Update(Employee t)
        {
            try
            {
                if (t == null)
                {
                    throw new ArgumentNullException("El objeto empleado no puede ser null.");
                }

                Employee employee = FindByDni(t.Dni);
                if (employee == null)
                {
                    throw new Exception($"El objeto empleado con esa dni no existe.");
                }

                employee.Names = t.Names;
                employee.Lastnames = t.Lastnames;
                employee.Address = t.Address;
                employee.Phone = t.Phone;
                employee.Email = t.Email;
                employee.Status = t.Status;

                depreciationDbContext.Employees.Update(employee);
                return depreciationDbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
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
