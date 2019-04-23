using FirstRealProject.Infrastructure.Interface;
using FirstRealProject.Models.Commons.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FirstRealProject.Infrastructure.Implementations
{
    public class SettingAnnounce : ISettingAnnounce
    {
        public string IpAddress()
        {
            return Dns.GetHostEntry(Dns.GetHostName()).AddressList[0].ToString();
        }

        public string GenerateAnnounceName(string announceName, FindTable findTable)
        {
            StringBuilder name = new StringBuilder();

            switch (findTable)
            {
                case FindTable.Car:
                    if (announceName.Length >= 18)
                    {
                        for (int i = 0; i < announceName.Length; i++)
                        {
                            if (i <= 10)
                                name.Append(announceName[i]);
                            else if (i == 11)
                                name.Append(" ");
                            else if (i <= 14)
                                name.Append(".");
                            else if (i == 15)
                                name.Append(",");
                        }
                        name.Append(announceName.Substring(announceName.Length - 4, 4));
                    }
                    else
                    {
                        name.Append(announceName);
                    }
                    
                    break;
                case FindTable.Bus:
                    if (announceName.Length >= 18)
                    {
                        for (int i = 0; i < announceName.Length; i++)
                        {
                            if (i <= 16)
                                name.Append(announceName[i]);
                            else if (i <= 19)
                                name.Append(".");
                        }
                    }
                    else
                    {
                        name.Append(announceName);
                    }
                    break;
                case FindTable.Accessory:
                    if (announceName.Length >= 18)
                    {
                        for (int i = 0; i < announceName.Length; i++)
                        {
                            if (i <= 16)
                                name.Append(announceName[i]);
                            else if (i <= 19)
                                name.Append(".");
                        }
                    }
                    else
                    {
                        name.Append(announceName);
                    }
                    break;
                case FindTable.Motocycle:
                    if (announceName.Length >= 18)
                    {
                        for (int i = 0; i < announceName.Length; i++)
                        {
                            if (i <= 16)
                                name.Append(announceName[i]);
                            else if (i <= 19)
                                name.Append(".");
                        }
                    }
                    else
                    {
                        name.Append(announceName);
                    }
                    break;
                case FindTable.Apartment:
                    if (announceName.Length >= 18)
                    {
                        var announceNames = announceName.Split('/');
                        name.Append(announceName[0] + "-otaqlı");
                        name.Append("," + announceName[1] + "m2");
                    }
                    else
                    {
                        name.Append(announceName);
                    }
                    break;
                case FindTable.House:
                    if (announceName.Length >= 18)
                    {
                        for (int i = 0; i < announceName.Length; i++)
                        {
                            if (i <= 10)
                                name.Append(announceName[i]);
                            else if (i == 11)
                                name.Append(" ");
                            else if (i <= 14)
                                name.Append(".");
                            else if (i == 15)
                                name.Append(",");
                        }
                        name.Append(announceName.Substring(announceName.Length - 4, 4));
                    }
                    else
                    {
                        name.Append(announceName);
                    }
                    break;
                case FindTable.Office:
                    if (announceName.Length >= 18)
                    {
                        for (int i = 0; i < announceName.Length; i++)
                        {
                            if (i <= 10)
                                name.Append(announceName[i]);
                            else if (i == 11)
                                name.Append(" ");
                            else if (i <= 14)
                                name.Append(".");
                            else if (i == 15)
                                name.Append(",");
                        }
                        name.Append(announceName.Substring(announceName.Length - 4, 4));
                    }
                    else
                    {
                        name.Append(announceName);
                    }
                    break;
                case FindTable.Garage:
                    if (announceName.Length >= 18)
                    {
                        for (int i = 0; i < announceName.Length; i++)
                        {
                            if (i <= 16)
                                name.Append(announceName[i]);
                            else if (i <= 19)
                                name.Append(".");
                        }
                    }
                    else
                    {
                        name.Append(announceName);
                    }
                    break;
                case FindTable.Land:
                    if (announceName.Length >= 18)
                    {
                        for (int i = 0; i < announceName.Length; i++)
                        {
                            if (i <= 16)
                                name.Append(announceName[i]);
                            else if (i <= 19)
                                name.Append(".");
                        }
                    }
                    else
                    {
                        name.Append(announceName);
                    }
                    break;
                case FindTable.Job:
                    if (announceName.Length >= 18)
                    {
                        for (int i = 0; i < announceName.Length; i++)
                        {
                            if (i <= 16)
                                name.Append(announceName[i]);
                            else if (i <= 19)
                                name.Append(".");
                        }
                    }
                    else
                    {
                        name.Append(announceName);
                    }
                    break;
                case FindTable.Business:
                    if (announceName.Length >= 18)
                    {
                        for (int i = 0; i < announceName.Length; i++)
                        {
                            if (i <= 16)
                                name.Append(announceName[i]);
                            else if (i <= 19)
                                name.Append(".");
                        }
                    }
                    else
                    {
                        name.Append(announceName);
                    }
                    break;
                case FindTable.Food:
                    if (announceName.Length >= 18)
                    {
                        for (int i = 0; i < announceName.Length; i++)
                        {
                            if (i <= 16)
                                name.Append(announceName[i]);
                            else if (i <= 19)
                                name.Append(".");
                        }
                    }
                    else
                    {
                        name.Append(announceName);
                    }
                    break;
                default:
                    name.Append(announceName);
                    break;

            }
            return name.ToString();
        }
    }
}
