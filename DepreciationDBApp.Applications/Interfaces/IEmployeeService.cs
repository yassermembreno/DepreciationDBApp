using DepreciationDBApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepreciationDBApp.Applications.Interfaces
{
    public interface IEmployeeService : IService<Employee>
    {
        bool SetAssetToEmployee(Employee employee, Asset asset, DateTime efectiveDate);
        bool SetAssetsToEmployee(Employee employee, List<Asset> assets, DateTime efectiveDate);
    }
}
