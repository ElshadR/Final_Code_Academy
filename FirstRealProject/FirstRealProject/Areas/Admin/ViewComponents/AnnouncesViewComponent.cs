using FirstRealProject.Areas.Admin.Models.Enums;
using FirstRealProject.Infrastructure.Data;
using FirstRealProject.Infrastructure.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstRealProject.Areas.Admin.ViewComponents
{
    public class AnnouncesViewComponent : ViewComponent
    {
        public FirstRealProjectDbContext _dbcontext { get; set; }
        public IFindAnnounce _findData { get; set; }

        public AnnouncesViewComponent(FirstRealProjectDbContext dbContext,IFindAnnounce find)
        {
            _dbcontext = dbContext;
            _findData = find;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var data = await _findData.GetAnnouncesA(0,FindStatusAnnounceA.NonCheckIn);
            return View(data.Count());
        }
    }
}
