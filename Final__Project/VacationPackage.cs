using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Final__Project
{
    public class VacationPackage
    {
        public  string destination { get; set; }
        public  decimal price { get; set; }
        public  decimal tax { get; set; }
        public decimal total { get; set; }
        public string scenery { get; set; }
        

        public string ToString(VacationPackage vacationPackage)
        {
            return $"{vacationPackage.destination}, {vacationPackage.price}, {vacationPackage.tax}, {vacationPackage.total}, {vacationPackage.scenery}";
        }
        public decimal GetTotal(VacationPackage package)
        {
            price = package.price;
            tax = package.tax;
            total = price + tax;
            return total;
        }

        public decimal SumOfPrice(List<VacationPackage> packageList)
        {
            if (this.scenery.Equals("Beach"))
            {
                decimal beachTotal = 0m;
                foreach(var s in packageList)
                {
                    VacationPackage package = new VacationPackage();
                    package.destination = s.destination;
                    package.price = s.price;
                    package.tax = s.tax;
                    package.scenery = s.scenery;

                    if (package.destination.Contains("Surfing"))
                    {
                        var surfPrice = packageList.Where(x => x.destination.Contains("Surfing")).Sum(x => x.price);
                        var surfTax = packageList.Where(x => x.destination.Contains("Surfing")).Sum(x => x.tax);
                        beachTotal += GetTotal(package);
                    }
                    if(package.destination.Contains("Scuba Diving")) 
                    {
                        var scubaPrice = packageList.Where(x => x.destination.Contains("Scuba Diving")).Sum(x => x.price);
                        var scubaTax = packageList.Where(x => x.destination.Contains("Scuba Diving")).Sum(x => x.tax);
                        beachTotal += GetTotal(package);
                    }
                    if(package.destination.Contains("Jet Skiing")) 
                    {
                        var jetPrice = packageList.Where(x => x.destination.Contains("Jet Skiing")).Sum(x => x.price);
                        var jetTax = packageList.Where(x => x.destination.Contains("Jet Skiing")).Sum(x => x.tax);
                        beachTotal += GetTotal(package);

                    }
                    
                }
                return beachTotal;
            }
            else if (this.scenery.Equals("Mountain"))
            {
                decimal mountainTotal = 0m;
                foreach (var s in packageList)
                {
                    VacationPackage package = new VacationPackage();
                    package.destination = s.destination;
                    package.price = s.price;
                    package.tax = s.tax;
                    package.scenery = s.scenery;

                    if (package.destination.Contains("Skiing"))
                    {
                        var skiingPrice = packageList.Where(x => x.destination.Contains("Skiing")).Sum(x => x.price);
                        var skiingTax = packageList.Where(x => x.destination.Contains("Skiing")).Sum(x => x.tax);
                        mountainTotal += GetTotal(package);
                    }
                    if (package.destination.Contains("Helicopter Tour"))
                    {
                        var helicopterPrice = packageList.Where(x => x.destination.Contains("Helicopter Tour")).Sum(x => x.price);
                        var helicopterTax = packageList.Where(x => x.destination.Contains("Helicopter Tour")).Sum(x => x.tax);
                        mountainTotal += GetTotal(package);
                    }
                    if (package.destination.Contains("Snowmobiling"))
                    {
                        var snowPrice = packageList.Where(x => x.destination.Contains("Snowmobiling")).Sum(x => x.price);
                        var snowTax = packageList.Where(x => x.destination.Contains("Snowmobiling")).Sum(x => x.tax);
                        mountainTotal += GetTotal(package);
                    }
                }
                return mountainTotal;
            }
            else 
            {
                decimal desertTotal = 0m;
                foreach (var s in packageList)
                {
                    VacationPackage package = new VacationPackage();
                    package.destination = s.destination;
                    package.price = s.price;
                    package.tax = s.tax;
                    package.scenery = s.scenery;

                    if (package.destination.Contains("Horseback Ride"))
                    {
                        var skiingPrice = packageList.Where(x => x.destination.Contains("Horseback Ride")).Sum(x => x.price);
                        var skiingTax = packageList.Where(x => x.destination.Contains("Horseback Ride")).Sum(x => x.tax);
                        desertTotal += GetTotal(package);
                    }
                    if (package.destination.Contains("Whitewater Rafting"))
                    {
                        var helicopterPrice = packageList.Where(x => x.destination.Contains("Whitewater Rafting")).Sum(x => x.price);
                        var helicopterTax = packageList.Where(x => x.destination.Contains("Whitewater Rafting")).Sum(x => x.tax);
                        desertTotal += GetTotal(package);
                    }
                    if (package.destination.Contains("Guided Hike"))
                    {
                        var guidedPrice = packageList.Where(x => x.destination.Contains("Guided Hike")).Sum(x => x.price);
                        var guidedTax = packageList.Where(x => x.destination.Contains("Guided Hike")).Sum(x => x.tax);
                        desertTotal += GetTotal(package);
                    }
                }
                return desertTotal;
            }
        }

    }

    
}
