namespace Oz_DevBlog.Data.Model_Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Seminar")]
    public partial class Seminar
    {
        public int SeminarID { get; set; }

        public string SeminarName { get; set; }

        public string SeminarPlace { get; set; }

        public DateTime? SeminarDate { get; set; }

        public string SeminarLink { get; set; }

        public string SeminarContent { get; set; }

        public bool? IsActive { get; set; }

        public DateTime? DateCreated { get; set; }

        public DateTime? DateModified { get; set; }
    }
}
