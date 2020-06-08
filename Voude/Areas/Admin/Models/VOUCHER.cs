namespace Voude.Areas.Admin.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("VOUCHER")]
    public partial class VOUCHER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VOUCHER()
        {
            CODEs = new HashSet<CODE>();
            DETAIL_INVOICE = new HashSet<DETAIL_INVOICE>();
            SHOPs = new HashSet<SHOP>();
        }

        public long id { get; set; }

        public long partnerId { get; set; }

        public int categoryId { get; set; }

        public int? hot { get; set; }

        [Required]
        [StringLength(250)]
        public string name { get; set; }

        [StringLength(250)]
        public string images { get; set; }

        public int? percent { get; set; }

        public string description { get; set; }

        public int? quantity { get; set; }

        public decimal? price { get; set; }

        [StringLength(250)]
        public string alt { get; set; }

        public DateTime? startDate { get; set; }

        public DateTime? endDate { get; set; }

        public virtual CATEGORY CATEGORY { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CODE> CODEs { get; set; }

        public virtual PARTNER PARTNER { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DETAIL_INVOICE> DETAIL_INVOICE { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SHOP> SHOPs { get; set; }
    }
}
