namespace Oz_DevBlog.Data.Model_Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Project")]
    public partial class Project
    {
        public int ProjectID { get; set; }

        public string ProjectName { get; set; }

        public string ProjectContent { get; set; }

        public string ProjectLink { get; set; }

        public int? ImageID { get; set; }

        public bool? IsActive { get; set; }

        public DateTime? DateCreated { get; set; }

        public DateTime? DateModified { get; set; }

        public virtual Image Image { get; set; }
    }
}
