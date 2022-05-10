using DepreciationDBApp.Applications.Interfaces;
using DepreciationDBApp.Domain.Entities;
using DepreciationDBApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepreciationDBApp.Applications.Services
{
    public class AssetService : IAssetService
    {
        private IAssetRepository assetRepository;

        public AssetService(IAssetRepository assetRepository)
        {
            this.assetRepository = assetRepository;
        }
        public void Create(Asset t)
        {
            if(t == null)
            {
                throw new ArgumentNullException("El Asset no puede ser null.");
            }

            assetRepository.Create(t);
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
            return assetRepository.FindById(id);
        }

        public List<Asset> FindByName(string name)
        {
            throw new NotImplementedException();
        }

        public List<Asset> GetAll()
        {
            return assetRepository.GetAll();
        }

        public int Update(Asset t)
        {
            throw new NotImplementedException();
        }
    }
}
