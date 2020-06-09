namespace Voude.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SHOP")]
    public partial class SHOP
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SHOP()
        {
            VOUCHERs = new HashSet<VOUCHER>();
        }

        public long id { get; set; }

        public long? partnerId { get; set; }

        [Required]
        [StringLength(250)]
        public string name { get; set; }

        [StringLength(50)]
        public string phone { get; set; }

        [StringLength(250)]
        public string address { get; set; }

        [StringLength(50)]
        public string gps { get; set; }

        public virtual PARTNER PARTNER { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<VOUCHER> VOUCHERs { get; set; }
    }
}
