using FirstRealProject.Infrastructure.Data;
using FirstRealProject.Infrastructure.Interface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace FirstRealProject.Controllers.New_Announce
{
    [Route("all/new-announce-ajax/[action]")]
    public class NewAnnounceAjaxController:Controller
    {
        private FirstRealProjectDbContext _dbContext { get; set; }
        private IFindAnnounce _dataFind { get; set; }

        public NewAnnounceAjaxController(FirstRealProjectDbContext dbContext, IFindAnnounce dataFind)
        {
            _dbContext = dbContext;
            _dataFind = dataFind;
        }

        [HttpPost]
        public async Task<IActionResult> GetCarModel(int makeId)
        {
            var data = await _dbContext
                .CarModels
                .Include(cm => cm.CarMake)
                .Where(cm => cm.CarMakeId == makeId)
                .Select(cm=>new CarModelView {
                     Id=cm.Id,
                     Name=cm.Name
                }).ToListAsync();

            return Json(data);
        }
        class CarModelView
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
    }
}
