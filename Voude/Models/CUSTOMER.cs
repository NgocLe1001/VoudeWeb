namespace Voude.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("CUSTOMER")]
    public partial class CUSTOMER
    {
        public long id { get; set; }

        [Required]
        [StringLength(250)]
        public string name { get; set; }

        public int? gender { get; set; }

        [StringLength(50)]
        public string phone { get; set; }

        [StringLength(250)]
        public string email { get; set; }

        [StringLength(250)]
        public string address { get; set; }

        [StringLength(250)]
        public string username { get; set; }

        [StringLength(250)]
        public string password { get; set; }
    }
}
