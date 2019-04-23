using FirstRealProject.Infrastructure.Data;
using FirstRealProject.Models.PagesModels.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstRealProject.ViewComponents
{
    public class MenuViewComponent:ViewComponent
    {
        public FirstRealProjectDbContext Db { get; set; }

        public MenuViewComponent(FirstRealProjectDbContext dbContext)
        {
            Db = dbContext;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var data = await Db.BasicMenus.Include(x => x.Categories)
                                .Select(x => new ViewMenu
                                {
                                    Id = x.Id,
                                    Name = x.Name,
                                    Controller = x.Categories.ToList()[0].Controller,
                                    ViewCategories = x.Categories
                                                        .Select(c => new ViewCategory
                                                        {
                                                            Id = c.Id,
                                                            Name = c.Name,
                                                            Controller=c.Controller,
                                                            Action=c.Action
                                                        }).ToList()
                                }).ToListAsync();
            return View(data);
        }
    }
}
