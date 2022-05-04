using DepreciationDBApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepreciationDBApp.Domain.Interfaces
{
    public interface IAssetRepository : IRepository<Asset>
    {
        Asset FindById(int id);
        Asset FindByCode(string code);
        List<Asset> FindByName(string name);
    }
}
