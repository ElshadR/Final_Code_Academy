using FirstRealProject.Models.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FirstRealProject.Areas.Admin.Models.Commons
{
    public class CommentModel
    {
        public CommentModel()
        {
            Comments = new HashSet<Comment>();
        }
        public PaginationA Pagination { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}
