using FirstRealProject.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstRealProject.Areas.Admin.ViewComponents
{
    public class CommentViewComponent:ViewComponent
    {
        public FirstRealProjectDbContext _dbcontext { get; set; }

        public CommentViewComponent(FirstRealProjectDbContext dbContext)
        {
            _dbcontext = dbContext;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var data = await _dbcontext.Comments
                .Where(c => c.CheckIn == false)
                .ToListAsync();
            return View(data);
        }
    }
}
