using DepreciationDBApp.Applications.Interfaces;
using DepreciationDBApp.Domain.Entities;
using DepreciationDBApp.Domain.Interfaces;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepreciationDBApp.Applications.Services
{
    public class EmployeeService : IEmployeeService
    {
        private IEmployeeRepository employeeRepository;
        private IAssetEmployeeRepository assetEmployeeRepository;
        private IAssetRepository assetRepository;
        public EmployeeService(IEmployeeRepository employeeRepository, IAssetEmployeeRepository assetEmployeeRepository)
        {
            this.employeeRepository = employeeRepository;
            this.assetEmployeeRepository = assetEmployeeRepository;
        }
        public void Create(Employee t)
        {
            employeeRepository.Create(t);
        }

        public bool Delete(Employee t)
        {
            throw new NotImplementedException();
        }

        public List<Employee> GetAll()
        {
            return employeeRepository.GetAll();
        }

        public bool SetAssetsToEmployee(Employee employee, List<Asset> assets, DateTime efectiveDate)
        {
            bool success = false;
            using IDbContextTransaction transaction = employeeRepository.GetTransaction();
            try
            {
                if(assets == null || assets.Count == 0)
                {
                    throw new ArgumentNullException("La lista no puede estar vacia");
                }
                foreach (Asset asset in assets)
                {
                    success = SetAssetToEmployee(employee, asset, efectiveDate);
                    if (!success)
                    {
                        throw new Exception($"Fallo al asignar el asseId{asset.Id} al empleado {employee.Id}.");
                        //break;
                    }
                    asset.Status = "Asignado";
                    success = assetRepository.Update(asset) > 0;

                    if (!success)
                    {
                        throw new Exception($"Fallo al actualizar el asseId{asset.Id}.");
                    }
                }


                if (success)
                {
                    transaction.Commit();
                }
               
                return success;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public bool SetAssetToEmployee(Employee employee, Asset asset, DateTime efectiveDate)
        {
            
            try
            {
                ValidateAssetEmployee(employee, asset);
                AssetEmployee assetEmployee = new AssetEmployee()
                {
                    AssetId = asset.Id,
                    EmployeeId = employee.Id,
                    Date = efectiveDate,
                    IsActive = true
                };

                return assetEmployeeRepository.Create(assetEmployee) > 0;
                
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void ValidateAssetEmployee(Employee employee, Asset asset)
        {
            if (employee is null)
            {
                throw new ArgumentNullException(nameof(employee));
            }

            if (asset is null)
            {
                throw new ArgumentNullException(nameof(asset));
            }

            if (asset.Status.Equals("No disponible"))
            {
                //TODO: agregar los enums del status de activo y empleado
            }

            Employee employee1 = employeeRepository.FindByDni(employee.Dni);
            if(employee1 == null)
            {
                throw new ArgumentNullException($"El objeto {employee.Names} no existe");
            }
        }

        public int Update(Employee t)
        {
            throw new NotImplementedException();
        }
    }
}
