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
            depreciationDbContext.Assets.Add(t);
            depreciationDbContext.SaveChanges();
        }

        public bool Delete(Asset t)
        {
            throw new NotImplementedException();
        }

        public Asset FindByCode(string code)
        {
            throw new NotImplementedException();
        }

        public Asset FindById(int id)
        {
            depreciationDbContext.Assets.Where(x => x.Id == id).FirstOrDefault();
        }

        public List<Asset> FindByName(string name)
        {
            throw new NotImplementedException();
        }

        public List<Asset> GetAll()
        {
            return depreciationDbContext.Assets.ToList();
        }

        public int Update(Asset t)
        {
            throw new NotImplementedException();
        }
    }
}
