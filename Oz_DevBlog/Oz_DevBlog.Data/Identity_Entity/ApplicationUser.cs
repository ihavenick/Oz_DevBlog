using Microsoft.AspNet.Identity.EntityFramework;
using Oz_DevBlog.Data.Model_Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oz_DevBlog.Data.Identity_Entity
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public List<Comment> CommentsOfUser { get; set; }

        public int? ImageID { get; set; }
        public virtual Image ImageofUser { get; set; }

    }
}
