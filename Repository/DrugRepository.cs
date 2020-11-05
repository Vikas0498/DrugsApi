using MfpeDrugsApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MfpeDrugsApi.Repository
{
    public class DrugRepository : IRepository
    {
        static readonly log4net.ILog _log4net = log4net.LogManager.GetLogger(typeof(DrugRepository));

        public static List<Drug> druglist = new List<Drug>()
        {
          new Drug { Id = 1, Name = "Disprin", ManufacturedDate = Convert.ToDateTime("2020-5-6 12:12:00.0000000"), ExpiryDate = Convert.ToDateTime("2021-5-6 12:12:00.0000000"), Manufacturer = "Abbot"},
          new Drug { Id = 2, Name = "Paracetamol", ManufacturedDate = Convert.ToDateTime("2019-10-2 12:12:00.0000000"), ExpiryDate = Convert.ToDateTime("2023-9-2 12:12:00.0000000"), Manufacturer = "Intas"}
        };
        public static List<DrugLocation> druglocationlist = new List<DrugLocation>()
        {
          new DrugLocation { Id = 1, Location = "Delhi", Quantity = 10, DrugName = "Disprin" },
          new DrugLocation { Id = 1, Location = "Rishikesh", Quantity = 20, DrugName = "Disprin" },
          new DrugLocation { Id = 2, Location = "Dehradun", Quantity = 15, DrugName = "Paracetamol" }
        };
        public List<LocationWiseDrug> locationwisedrugslist = new List<LocationWiseDrug>();

        public bool getDispatchableDrugStock(int id, string location)
        {
            _log4net.Info("Response sent according to the data recieved by calling API");
            return druglocationlist.Any(u => u.Id == id && u.Location == location);
        /* bool temp= druglocationlist.Any(u => u.Id == id && u.Location == location);
          if (temp)
           {
                foreach (var i in druglocationlist)
                {
                    if (i.Id == id && i.Location==location)
                    {
                    if (i.Quantity == 0)
                        return false;
                    }
                }
             }
            return true;*/
            
        }
        public List<LocationWiseDrug> searchDrugsByID(int id)
        {
            _log4net.Info("Searchng started according to Id");
            Drug l1= druglist.Find(p => p.Id == id);
            if (l1 != null)
            {
                foreach (var i in druglocationlist)
                {
                    if (i.Id == l1.Id)
                    {
                        LocationWiseDrug lwd = new LocationWiseDrug();
                        lwd.Id = l1.Id;
                        lwd.Name = l1.Name;
                        lwd.ManufacturedDate = l1.ManufacturedDate;
                        lwd.ExpiryDate = l1.ExpiryDate;
                        lwd.Manufacturer = l1.Manufacturer;
                        lwd.Quantity = i.Quantity;
                        lwd.Location = i.Location;
                        locationwisedrugslist.Add(lwd);
                    }
                }
            }
            _log4net.Info("Drugs Details Returned According to Id");
            return locationwisedrugslist;
        }
        public List<LocationWiseDrug> searchDrugsByName(string name)
        {
            _log4net.Info("Searchng started according to Name");
            Drug l1= druglist.Find(p => p.Name == name);
            if (l1 != null)
            {
                foreach (var i in druglocationlist)
                {
                    if (i.Id == l1.Id)
                    {
                        LocationWiseDrug lwd = new LocationWiseDrug();
                        lwd.Id = l1.Id;
                        lwd.Name = l1.Name;
                        lwd.ManufacturedDate = l1.ManufacturedDate;
                        lwd.ExpiryDate = l1.ExpiryDate;
                        lwd.Manufacturer = l1.Manufacturer;
                        lwd.Quantity = i.Quantity;
                        lwd.Location = i.Location;
                        locationwisedrugslist.Add(lwd);
                    }
                }
            }
            _log4net.Info("Drugs Details Returned According to Name");
            return locationwisedrugslist;
        }
    }
}
