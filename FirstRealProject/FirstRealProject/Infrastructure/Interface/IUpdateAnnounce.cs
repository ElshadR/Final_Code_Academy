using FirstRealProject.Areas.Admin.Models.CRUD.Edit.Jobs;
using FirstRealProject.Areas.Admin.Models.CRUD.Edit.RealEstate;
using FirstRealProject.Areas.Admin.Models.CRUD.Edit.Transport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstRealProject.Infrastructure.Interface
{
    public interface IUpdateAnnounce
    {
        Task<bool> UpdateCarA(CarEditModel editModel);
        Task<bool> UpdateBusA(BusEditModel editModel);
        Task<bool> UpdateMotocycleA(MotorcycleEditModel editModel);
        Task<bool> UpdateAccessoryA(AccessoryEditModel editModel);
        Task<bool> UpdateApartmentA(ApartmentEditModel editModel);
        Task<bool> UpdateHouseA(HouseVillaEditModel editModel);
        Task<bool> UpdateOfficeA(CommercialEditModel editModel);
        Task<bool> UpdateLandA(LandEditModel editModel);
        Task<bool> UpdateGarageA(GarageEditModel editModel);
        Task<bool> UpdateJobA(JobEditModel editModel);
        Task<bool> UpdateBusinessA(BusinessEditModel editModel);
        Task<bool> UpdateFoodA(FoodEditModel editModel);



    }
}
