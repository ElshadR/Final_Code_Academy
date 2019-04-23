using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstRealProject.Models.PagesModels.ViewModel
{
    public class Pagination
    {
        public Pagination(int commonCount,int itemCount,int page)
        {
            if (commonCount > itemCount)
            {
                ViewItemCount = itemCount;
                View = true;
                ActivePage = page;
                int pageCount = (int)Math.Ceiling(decimal.Divide(commonCount, itemCount));
                if (page == 0)
                    PrevClick = false;
                else
                    PrevClick = true;

                if ((page + 1) == pageCount)
                    NextClick = false;
                else
                    NextClick = true;

                if (page < 5)
                {
                    StartCountPage = 0;

                    if ((page + 5) > pageCount)
                        EndCountPage = pageCount;
                    else
                        EndCountPage = page + 5;

                    ViewLeftDels = false;
                    if (pageCount < EndCountPage)
                        ViewRightDels = true;
                    else
                        ViewRightDels = false;
                }
                else
                {
                    StartCountPage = page - 4;

                    if ((page + 5) > pageCount)
                        EndCountPage = pageCount;
                    else
                        EndCountPage = page + 5;

                    ViewLeftDels = true;
                }
            }
            else
            {
                View = false;
            }
            
        }

        public int ViewItemCount { get; set; }

        public int StartCountPage { get; set; }

        public int EndCountPage { get; set; }

        public int ActivePage { get; set; }

        public bool ViewRightDels { get; set; }

        public bool ViewLeftDels { get; set; }

        public bool PrevClick { get; set; }

        public bool NextClick { get; set; }

        public bool View { get; set; }

        public string AnnounceType { get; set; }
        public string ActionName { get; set; }
        public string ControllerName { get; set; }
        public string AreaName { get; set; }
    }
}
