using FirstRealProject.Models.Transports.CarModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using k = FirstRealProject.Models.PagesModels.ViewModel.Common.Transport.Item;

namespace FirstRealProject.Models.PagesModels.ViewModel.Transport.Cars.Item
{
    public class CarView : k.ViewItem
    {
        public CarView()
        {
            Photos = new HashSet<CarPhoto>();
            AutoEquipment = new HashSet<AutoEquipment>();
        }


        public CarBodyType CarBodyType { get; set; }
        public Transmission Transmission { get; set; }
        public SpeedBox SpeedBox { get; set; }
        public FuelType FuelType { get; set; }
        public int CarMotorStrength { get; set; }
        public string ModelName { get; set; }
        public string MakeName { get; set; }
        public int Motor { get; set; }
        public int Year { get; set; }
        public int Kilometer { get; set; }
        public bool Condition { get; set; }
        public bool ConditionCredit { get; set; }
        public bool ConditionBarter { get; set; }
        public string Color { get; set; }

        public ICollection<AutoEquipment> AutoEquipment { get; set; }
        public ICollection<CarPhoto> Photos { get; set; }
    }
}
