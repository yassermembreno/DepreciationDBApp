using DepreciationDBApp.Domain.Entities;
using DepreciationDBApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepreciationDBApp.Infrastructure.Repositories
{
    public class EFAssetRepository : IAssetRepository
    {
        public IDepreciationDbContext depreciationDbContext;
        public EFAssetRepository(IDepreciationDbContext depreciationDbContext)
        {
            this.depreciationDbContext = depreciationDbContext;
        }
        public void Create(Asset t)
        {
            try
            {
                depreciationDbContext.Assets.Add(t);
                depreciationDbContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        public bool Delete(Asset t)
        {
          
            try
            {
                if (t == null)
                {
                    throw new ArgumentNullException("El objeto Asset no puede ser null.");
                }
                
                Asset asset = FindById(t.Id);
                if(asset == null)
                {
                    throw new Exception($"El objeto con id {t.Id} no existe.");
                }

                depreciationDbContext.Assets.Remove(asset);
                int result = depreciationDbContext.SaveChanges();

                return result > 0;
            }
            catch(Exception)
            {
                throw;
            }
        }

        public Asset FindByCode(string code)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(code))
                {
                    throw new Exception($"El parametro code {code} no tiene el formato correcto.");
                }

                return depreciationDbContext.Assets.FirstOrDefault(x => x.Code.Equals(code));
            }
            catch
            {
                throw;
            }
            
        }

        public Asset FindById(int id)
        {
            try
            {
                if(id <= 0)
                {
                    throw new Exception($"El id {id} no puede ser menor o igual a cero.");
                }

                return depreciationDbContext.Assets.FirstOrDefault(x => x.Id == id);
            }
            catch
            {
                throw;
            }
            
        }

        public List<Asset> FindByName(string name)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(name))
                {
                    throw new Exception($"El parametro name '{name}' no tiene el formato correcto.");
                }

                return depreciationDbContext.Assets
                                        .Where(x => x.Name.Equals(name, StringComparison.CurrentCultureIgnoreCase))
                                        .ToList();
            }
            catch
            {
                throw;
            }
            
        }

        public List<Asset> GetAll()
        {
            return depreciationDbContext.Assets.ToList();
        }

        public int Update(Asset t)
        {
            try
            {
                if(t == null)
                {
                    throw new ArgumentNullException("El objeto asset no puede ser null.");
                }

                Asset asset = FindById(t.Id);
                if(asset == null)
                {
                    throw new Exception($"El objeto asset con id {t.Id} no existe.");
                }

                asset.Name = t.Name;
                asset.Description = t.Description;
                //asset.Amount = t.Amount;
                asset.AmountResidual = t.AmountResidual;
                //asset.Terms = t.Terms;
                asset.Status = t.Status;
                asset.IsActive = t.IsActive;
                //asset.Code = t.Code;

                depreciationDbContext.Assets.Update(asset);
                return depreciationDbContext.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
    }
}
