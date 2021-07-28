using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TestLoadBalancer.Data
{
    public class EntityConfig : IEntityTypeConfiguration<Entity>
    {
        public void Configure(EntityTypeBuilder<Entity> builder)
        {
            builder.ToTable("Entity");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd().IsRequired();
            builder.Property(x => x.UserName).IsRequired(false);
            builder.Property(x => x.Password).IsRequired(false);

            builder.HasData(new Entity
            {
                Id = 1,
                Password = "Pass",
                UserName = "UserName"
            }, new Entity
            {
                Id = 2,
                Password = "Pass2",
                UserName = "UserName2"
            }, new Entity
            {
                Id = 3,
                Password = "Pass3",
                UserName = "UserName3"
            });
        }
    }
}