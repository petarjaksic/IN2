namespace IN2.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class IN2_DbContext : DbContext
    {
        public IN2_DbContext()
            : base("name=IN2_DbContext")
        {
        }

        public virtual DbSet<POLOZENI_ISPITI> POLOZENI_ISPITI { get; set; }
        public virtual DbSet<PREDMET> PREDMET { get; set; }
        public virtual DbSet<STUDENT> STUDENT { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<STUDENT>()
                .Property(e => e.ImePrezime)
                .IsFixedLength();
        }
    }
}
