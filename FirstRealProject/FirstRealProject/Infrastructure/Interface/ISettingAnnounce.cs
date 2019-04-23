using FirstRealProject.Models.Commons.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstRealProject.Infrastructure.Interface
{
    public interface ISettingAnnounce
    {
        string GenerateAnnounceName(string announceName,FindTable findTable);
        string IpAddress();
    }
}
