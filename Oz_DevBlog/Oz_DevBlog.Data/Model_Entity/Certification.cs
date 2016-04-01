namespace Oz_DevBlog.Data.Model_Entity
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Certification")]
    public partial class Certification
    {
        public int CertificationID { get; set; }

        public string CertificateName { get; set; }

        public string CertificateContent { get; set; }

        public DateTime? CertificateDay { get; set; }

        public string CertificateLink { get; set; }

        public string CertificateCorporation { get; set; }

        public bool? IsActive { get; set; }

        public DateTime? DateCreated { get; set; }

        public DateTime? DateModified { get; set; }
    }
}
