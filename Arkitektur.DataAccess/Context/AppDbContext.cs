using Arkitektur.Entity.Entities;
using Arkitektur.Entity.Entities.Common;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Arkitektur.DataAccess.Context
{
    public class AppDbContext(DbContextOptions options):DbContext(options)
    {

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            foreach(var entitiyType in modelBuilder.Model.GetEntityTypes())
            {

                if(typeof(BaseEntity).IsAssignableFrom(entitiyType.ClrType))
                {
                    //wrapper yapýyoruz, yani sorgulara otomatik olarak silinmiþ olanlarý getirme filtresi ekliyoruz
                    //select * from table where IsDeleted = false olanlar gelsin sadece diyeceðiz
                    modelBuilder.Entity(entitiyType.ClrType)
                                .HasQueryFilter(ConvertToDeleteFilter(entitiyType.ClrType));

                }

            }
        }


        private static LambdaExpression ConvertToDeleteFilter(Type type)
        {
         
            var parameter = Expression.Parameter(type, "e");
            
            var property = Expression.Property(Expression.Convert(parameter,typeof(BaseEntity)),"IsDeleted");

            var notDeleted = Expression.Not(property);

            return Expression.Lambda(notDeleted, parameter);



        }



        public DbSet<About> Abouts { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Choose> Chooses { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<TeamSocial> TeamSocials { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<UserMessage> UserMessages { get; set; }
      


    }
}
