namespace Oz_DevBlog.Data.Model_Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Employment")]
    public partial class Employment
    {
        public int EmploymentID { get; set; }

        public string EmploymentTitle { get; set; }

        public string EmploymentContent { get; set; }

        public string JobDesc { get; set; }

        [Column(TypeName = "date")]
        public DateTime? StartedDate { get; set; }

        [Column(TypeName = "date")]
        public DateTime FinishedDate { get; set; }

        public bool? IsActive { get; set; }

        public DateTime? DateCreated { get; set; }

        public DateTime? DateModified { get; set; }
    }
}
