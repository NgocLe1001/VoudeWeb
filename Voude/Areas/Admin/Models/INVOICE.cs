namespace Voude.Areas.Admin.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("INVOICE")]
    public partial class INVOICE
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public INVOICE()
        {
            DETAIL_INVOICE = new HashSet<DETAIL_INVOICE>();
        }

        public long id { get; set; }

        public int paymentMethodId { get; set; }

        public DateTime time { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DETAIL_INVOICE> DETAIL_INVOICE { get; set; }

        public virtual PAYMENT_METHOD PAYMENT_METHOD { get; set; }
    }
}
