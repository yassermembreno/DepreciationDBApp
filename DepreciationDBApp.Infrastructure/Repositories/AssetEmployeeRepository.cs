using DepreciationDBApp.Domain.Entities;
using DepreciationDBApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepreciationDBApp.Infrastructure.Repositories
{
    public class AssetEmployeeRepository : IAssetEmployeeRepository
    {
        private IDepreciationDbContext depreciationDbContext;
        public AssetEmployeeRepository(IDepreciationDbContext depreciationDbContext)
        {
            this.depreciationDbContext = depreciationDbContext;
        }
        public void Create(AssetEmployee t)
        {
            try
            {
                depreciationDbContext.AssetEmployees.Add(t);
                depreciationDbContext.SaveChanges();

            }catch (Exception)
            {
                throw;
            }
        }

        public bool Delete(AssetEmployee t)
        {
            try
            {
                if(t == null)
                {
                    throw new ArgumentNullException("El objeto assetEmployee no puede ser null");
                }
                AssetEmployee assetEmployee = FindByAssetEmployeeId(t.EmployeeId, t.AssetId);
                if(assetEmployee == null)
                {
                    throw new ArgumentNullException("assetEmployee no puede ser null");
                }

                depreciationDbContext.AssetEmployees.Remove(assetEmployee);
                int result = depreciationDbContext.SaveChanges();

                return result > 0;

            }
            catch (Exception)
            {
                throw;
            }
        }

        public AssetEmployee FindByAssetEmployeeId(int employeeId, int assetId)
        {
            try
            {
                if(employeeId <= 0)
                {
                    throw new ArgumentException($"el id del employee {employeeId} no puede ser menor o igual a 0");
                }

                if (assetId <= 0)
                {
                    throw new ArgumentException($"el id del asset {assetId} no puede ser menor o igual a 0");
                }

                return depreciationDbContext.AssetEmployees.FirstOrDefault(x => x.EmployeeId == employeeId && x.AssetId == assetId);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public List<AssetEmployee> FindByAssetId(int assetId)
        {
            try
            {
                if(assetId <= 0)
                {
                    throw new ArgumentException("El assetId no puede ser menor o igual a 0");
                }

                return depreciationDbContext.AssetEmployees.Where(x => x.AssetId == assetId)
                                                           .ToList();
            }
            catch
            {
                throw;
            }
        }

        public List<AssetEmployee> FindByEmployeeId(int employeeId)
        {
            throw new NotImplementedException();
        }

        public List<AssetEmployee> GetAll()
        {
            return depreciationDbContext.AssetEmployees.ToList();
        }

        public int Update(AssetEmployee t)
        {
            throw new NotImplementedException();
        }
    }
}
