namespace Voude.Areas.Admin.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PARTNER")]
    public partial class PARTNER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PARTNER()
        {
            VOUCHERs = new HashSet<VOUCHER>();
        }

        public long id { get; set; }

        [Required]
        [StringLength(250)]
        public string name { get; set; }

        [StringLength(50)]
        public string alt { get; set; }

        [StringLength(250)]
        public string logo { get; set; }

        [StringLength(50)]
        public string phone { get; set; }

        [StringLength(10)]
        public string percent { get; set; }

        public string description { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VOUCHER> VOUCHERs { get; set; }
    }
}
