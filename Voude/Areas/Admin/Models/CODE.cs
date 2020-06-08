namespace Voude.Areas.Admin.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CODE")]
    public partial class CODE
    {
        public long id { get; set; }

        public long voucherId { get; set; }

        [Column("code")]
        [Required]
        [StringLength(255)]
        public string code1 { get; set; }

        public byte isExpired { get; set; }

        public byte used { get; set; }

        public DateTime expiredAt { get; set; }

        public DateTime usedAt { get; set; }

        public virtual VOUCHER VOUCHER { get; set; }
    }
}
