using FirstRealProject.Models.Commons;
using FirstRealProject.Models.PagesModels.ViewModel.NewAnnounce;
using FirstRealProject.Models.Transports.CarModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstRealProject.Infrastructure.Interface
{
    public interface IAnnounceToAdd
    {
        Task<bool> AddCar(CarAnnounceModel announce);
        Task<bool> AddBus(BusAnnounceModel announce);
        Task<bool> AddMotocycle(MotocycleAnnounceModel announce);
        Task<bool> AddAccessory(AccessoryAnnounceModel announce);
        Task<bool> AddApartment(ApartmentAnnounceModel announce);
        Task<bool> AddHouse(HouseAnnounceModel announce);
        Task<bool> AddQarage(QarageAnnounceModel announce);
        Task<bool> AddLand(LandAnnounceModel announce);
        Task<bool> AddOffice(OfficeAnnounceModel announce);
        Task<bool> AddJob(JobAnnounceModel announce);
        Task<bool> AddBuisness(BusinessAnnounceModel announce);
        Task<bool> AddFood(FoodAnnounceModel announce);
        Task<bool> AddContact(Comment contact);
    }
}
