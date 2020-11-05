using MfpeDrugsApi.Models;
using MfpeDrugsApi.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MfpeDrugsApi.Provider
{
    public class DrugProvider : IProvider
    {
        IRepository _item;
        public DrugProvider(IRepository drugrepo)
        {
            _item = drugrepo;

        }

        public bool getDispatchableDrugStock(int id, string location)
        {
           //DrugRepository obj1 = new DrugRepository();
           // return obj1.getDispatchableDrugStock(DrugId,Location);
          return getDispatchableDrugStock(id,location);
        }

        public List<LocationWiseDrug> searchDrugsByID(int id)
        {
            return _item.searchDrugsByID(id);
        }

        public List<LocationWiseDrug> searchDrugsByName(string name)
        {
           return _item.searchDrugsByName(name);
        }
    }
}
