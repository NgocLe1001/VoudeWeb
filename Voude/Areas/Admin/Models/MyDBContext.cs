namespace Voude.Areas.Admin.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class MyDBContext : DbContext
    {
        public MyDBContext()
            : base("name=MyDBContext")
        {
        }

        public virtual DbSet<CATEGORY> CATEGORies { get; set; }
        public virtual DbSet<CODE> CODEs { get; set; }
        public virtual DbSet<CUSTOMER> CUSTOMERs { get; set; }
        public virtual DbSet<INVOICE> INVOICEs { get; set; }
        public virtual DbSet<PARTNER> PARTNERs { get; set; }
        public virtual DbSet<PAYMENT_METHOD> PAYMENT_METHOD { get; set; }
        public virtual DbSet<SHOP> SHOPs { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<VOUCHER> VOUCHERs { get; set; }
        public virtual DbSet<DETAIL_INVOICE> DETAIL_INVOICE { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CATEGORY>()
                .HasMany(e => e.VOUCHERs)
                .WithRequired(e => e.CATEGORY)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CODE>()
                .Property(e => e.code1)
                .IsUnicode(false);

            modelBuilder.Entity<CUSTOMER>()
                .Property(e => e.phone)
                .IsUnicode(false);

            modelBuilder.Entity<CUSTOMER>()
                .Property(e => e.email)
                .IsUnicode(false);

            modelBuilder.Entity<CUSTOMER>()
                .Property(e => e.username)
                .IsUnicode(false);

            modelBuilder.Entity<CUSTOMER>()
                .Property(e => e.password)
                .IsUnicode(false);

            modelBuilder.Entity<INVOICE>()
                .HasMany(e => e.DETAIL_INVOICE)
                .WithRequired(e => e.INVOICE)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PARTNER>()
                .Property(e => e.logo)
                .IsUnicode(false);

            modelBuilder.Entity<PARTNER>()
                .Property(e => e.phone)
                .IsUnicode(false);

            modelBuilder.Entity<PARTNER>()
                .HasMany(e => e.VOUCHERs)
                .WithRequired(e => e.PARTNER)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PAYMENT_METHOD>()
                .HasMany(e => e.INVOICEs)
                .WithRequired(e => e.PAYMENT_METHOD)
                .HasForeignKey(e => e.paymentMethodId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<SHOP>()
                .Property(e => e.phone)
                .IsUnicode(false);

            modelBuilder.Entity<SHOP>()
                .Property(e => e.gps)
                .IsUnicode(false);

            modelBuilder.Entity<SHOP>()
                .HasMany(e => e.VOUCHERs)
                .WithMany(e => e.SHOPs)
                .Map(m => m.ToTable("VOUCHER_SHOP").MapLeftKey("shopId").MapRightKey("voucherId"));

            modelBuilder.Entity<VOUCHER>()
                .Property(e => e.images)
                .IsUnicode(false);

            modelBuilder.Entity<VOUCHER>()
                .Property(e => e.price)
                .HasPrecision(18, 0);

            modelBuilder.Entity<VOUCHER>()
                .Property(e => e.alt)
                .IsUnicode(false);

            modelBuilder.Entity<VOUCHER>()
                .HasMany(e => e.CODEs)
                .WithRequired(e => e.VOUCHER)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<VOUCHER>()
                .HasMany(e => e.DETAIL_INVOICE)
                .WithRequired(e => e.VOUCHER)
                .WillCascadeOnDelete(false);
        }
    }
}
