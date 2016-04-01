using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oz_DevBlog.Data.Identity_Entity
{
    public class ApplicationRole:IdentityRole
    {
        public string Desc { get; set; }
        public ApplicationRole()
        {

        }
        public ApplicationRole(string roleName, string description):base(roleName)
        {
            this.Desc = description;
        }
    }
}
