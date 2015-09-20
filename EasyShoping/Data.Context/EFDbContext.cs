using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using EasyShoping.Model;
namespace Data.Context
{
  public  class EFDbContext : DbContext
    {
        public EFDbContext()
            : base("DefaultConnection")
       {
          // Database.SetInitializer<EFDbContext>(new ProjectlDBInitializer<EFDbContext>());

        }

        //UserMaster
        public DbSet<UserModel> UserMaster { get; set; }
        public DbSet<LocationModel> LocationMaster { get; set; }

        public DbSet<CategoryModel> CategoryMaster { get; set; }
        public DbSet<BrandModel> BrandMaster { get; set; }
        public DbSet<ProductModel> ProductMaster { get; set; }
        public DbSet<ProductsImagesModel> ProductsImages { get; set; }
        public DbSet<ProductsVideosModel> ProductsVideos { get; set; }
 

   protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
   {
  //     modelBuilder.Entity<ItemMaster>().Property(C => C.itemPrice).HasPrecision(12, 10);
       base.OnModelCreating(modelBuilder);
   }
    }
}
