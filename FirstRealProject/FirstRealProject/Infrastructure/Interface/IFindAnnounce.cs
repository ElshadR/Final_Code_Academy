using FirstRealProject.Areas.Admin.Models;
using FirstRealProject.Areas.Admin.Models.CRUD.Edit.Jobs;
using FirstRealProject.Areas.Admin.Models.CRUD.Edit.RealEstate;
using FirstRealProject.Areas.Admin.Models.CRUD.Edit.Transport;
using FirstRealProject.Areas.Admin.Models.Enums;
using FirstRealProject.Areas.User.Models.ViewModels;
using FirstRealProject.Models.Accounts;
using FirstRealProject.Models.Commons.Enums;
using FirstRealProject.Models.PagesModels.ViewModel;
using FirstRealProject.Models.PagesModels.ViewModel.Home;
using FirstRealProject.Models.PagesModels.ViewModel.Jobs.Businesses.Item;
using FirstRealProject.Models.PagesModels.ViewModel.Jobs.Foods.Item;
using FirstRealProject.Models.PagesModels.ViewModel.Jobs.Job.Item;
using FirstRealProject.Models.PagesModels.ViewModel.NewAnnounce;
using FirstRealProject.Models.PagesModels.ViewModel.RealEstate.Apartments.Item;
using FirstRealProject.Models.PagesModels.ViewModel.RealEstate.Garages.Item;
using FirstRealProject.Models.PagesModels.ViewModel.RealEstate.Houses.Item;
using FirstRealProject.Models.PagesModels.ViewModel.RealEstate.Lands.Item;
using FirstRealProject.Models.PagesModels.ViewModel.RealEstate.Offices.Item;
using FirstRealProject.Models.PagesModels.ViewModel.Transport;
using FirstRealProject.Models.PagesModels.ViewModel.Transport.Accessories.Item;
using FirstRealProject.Models.PagesModels.ViewModel.Transport.Buses.Item;
using FirstRealProject.Models.PagesModels.ViewModel.Transport.Cars.Item;
using FirstRealProject.Models.PagesModels.ViewModel.Transport.Motocycles.Item;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstRealProject.Infrastructure.Interface
{
    public interface IFindAnnounce
    {
        Task<IEnumerable<ViewAnnounce>> CommonAnnounce(ViewPage viewPage, string announceName, int startItem = 0, int dataCount = int.MaxValue);
        //transport
        Task<IEnumerable<ViewAnnounce>> GetTransports(ViewPage viewPage, string announceName, int startItem = 0, int dataCount = int.MaxValue);
        Task<IEnumerable<ViewAnnounce>> GetCars(ViewPage viewPage, string announceName, int startItem = 0, int dataCount = int.MaxValue);
        Task<CarView> GetCar(int id, string unicode, bool view = true);
        Task<IEnumerable<ViewAnnounce>> GetBuses(ViewPage viewPage, string announceName, int startItem = 0, int dataCount = int.MaxValue);
        Task<BusViewItem> GetBus(int id, string unicode, bool view = true);
        Task<IEnumerable<ViewAnnounce>> GetMotocycles(ViewPage viewPage, string announceName, int startItem = 0, int dataCount = int.MaxValue);
        Task<MotocycleViewItem> GetMotocycle(int id, string unicode, bool view = true);
        Task<IEnumerable<ViewAnnounce>> GetAccessories(ViewPage viewPage, string announceName, int startItem = 0, int dataCount = int.MaxValue);
        Task<AccessoryViewItem> GetAccessory(int id, string unicode, bool view = true);

        //real estate
        Task<IEnumerable<ViewAnnounce>> GetRealEstates(ViewPage viewPage, string announceName, int startItem = 0, int dataCount = int.MaxValue);
        Task<IEnumerable<ViewAnnounce>> GetApartments(ViewPage viewPage, string announceName, int startItem = 0, int dataCount = int.MaxValue);
        Task<ApartmentView> GetApartment(int id, string unicode, bool view = true);
        Task<IEnumerable<ViewAnnounce>> GetHouses(ViewPage viewPage, string announceName, int startItem = 0, int dataCount = int.MaxValue);
        Task<HouseView> GetHouse(int id, string unicode, bool view = true);
        Task<IEnumerable<ViewAnnounce>> GetOffices(ViewPage viewPage, string announceName, int startItem = 0, int dataCount = int.MaxValue);
        Task<OfficeView> GetOffice(int id, string unicode, bool view = true);
        Task<IEnumerable<ViewAnnounce>> GetGarages(ViewPage viewPage, string announceName, int startItem = 0, int dataCount = int.MaxValue);
        Task<GarageView> GetGarage(int id, string unicode, bool view = true);
        Task<IEnumerable<ViewAnnounce>> GetLands(ViewPage viewPage, string announceName, int startItem = 0, int dataCount = int.MaxValue);
        Task<LandView> GetLand(int id, string unicode, bool view = true);
        //jobs
        Task<IEnumerable<ViewAnnounce>> GetJobAlls(ViewPage viewPage, string announceName, int startItem = 0, int dataCount = int.MaxValue);
        Task<IEnumerable<ViewAnnounce>> GetJobs(ViewPage viewPage, string announceName, int startItem = 0, int dataCount = int.MaxValue);
        Task<JobView> GetJob(int id, string unicode, bool view = true);
        Task<IEnumerable<ViewAnnounce>> GetBusinesses(ViewPage viewPage, string announceName, int startItem = 0, int dataCount = int.MaxValue);
        Task<BusinessView> GetBusiness(int id, string unicode, bool view = true);
        Task<IEnumerable<ViewAnnounce>> GetFoods(ViewPage viewPage, string announceName, int startItem = 0, int dataCount = int.MaxValue);
        Task<FoodView> GetFood(int id, string unicode, bool view = true);
        //new announce
        Task<SettingModel> SettingDataAsync(string categoryName = "", int makeId = 0);
        //user 
        Task<UserViewModel> FindUserDataAsync(string id);
        bool SelectedAnnounce(string announceIds, int announceId, FindTable find);

        //Admin
        Task<AppUser> GetAppUsers(RoleType role);
        Task<IEnumerable<ViewAnnounceA>> GetAnnouncesA(FindTableA findTable,FindStatusAnnounceA findStatusAnnounce,int startItem = 0, int dataCount = int.MaxValue);
        Task<CarEditModel> GetCarA(int? id);
        Task<BusEditModel> GetBusA(int? id);
        Task<MotorcycleEditModel> GetMotocycleA(int? id);
        Task<AccessoryEditModel> GetAccessoryA(int? id);
        Task<ApartmentEditModel> GetApartmentA(int? id);
        Task<HouseVillaEditModel> GetHouseA(int? id);
        Task<GarageEditModel> GetGarageA(int? id);
        Task<CommercialEditModel> GetOfficeA(int? id);
        Task<LandEditModel> GetLandA(int? id);
        Task<JobEditModel> GetJobA(int? id);
        Task<BusinessEditModel> GetBusinessA(int? id);
        Task<FoodEditModel> GetFoodA(int? id);



    }
}
