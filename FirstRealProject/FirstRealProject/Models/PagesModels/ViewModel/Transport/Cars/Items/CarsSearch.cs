using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstRealProject.Models.PagesModels.ViewModel.Transport.Cars.Items
{
    public class CarsSearch
    {
        public int? CityId { get; set; }
        public int? BPrice { get; set; }
        public int? SPrice { get; set; }
        public string Name { get; set; }
        public int? MakeId { get; set; }
        public int? CarModelId { get; set; }
        public int? CarBodyTypeId { get; set; }
        public int? BYear { get; set; }
        public int? SYear { get; set; }
        public int? BKilometer { get; set; }
        public int? SKilometer { get; set; }
        public int? BMotor { get; set; }
        public int? SMotor { get; set; }
        public int CarCondition { get; set; }
        public bool CarConditionCredit { get; set; }
        public bool CarConditionBarter { get; set; }
    }
}
