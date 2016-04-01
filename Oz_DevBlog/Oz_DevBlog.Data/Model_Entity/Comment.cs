namespace Oz_DevBlog.Data.Model_Entity
{
    using Identity_Entity;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Comment")]
    public partial class Comment
    {
        public int CommentID { get; set; }

        public string CommentContent { get; set; }

        public int? BlogID { get; set; }

        public bool? IsAccepted { get; set; }

        public bool? IsActive { get; set; }

        public DateTime? DateCreated { get; set; }

        public DateTime? DateModified { get; set; }

        public virtual Blog Blog { get; set; }
        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser UserOfComment { get; set; }
    }
}
