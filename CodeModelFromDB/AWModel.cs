namespace CodeModelFromDB
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class AWModel : DbContext
    {
        public AWModel()
            : base("name=AWModel")
        {
        }

        public virtual DbSet<C__MigrationHistory> C__MigrationHistory { get; set; }
        public virtual DbSet<Clan> Clans { get; set; }
        public virtual DbSet<NinjaEquipment> NinjaEquipments { get; set; }
        public virtual DbSet<Ninja> Ninjas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Ninja>()
                .HasMany(e => e.NinjaEquipments)
                .WithRequired(e => e.Ninja)
                .HasForeignKey(e => e.Ninja_Id);
        }
    }
}
