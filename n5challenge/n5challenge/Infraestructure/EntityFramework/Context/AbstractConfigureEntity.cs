using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace n5challenge.Infraestructure.EntityFramework.Context
{
    public abstract class AbstractConfigureEntity<T>
        where T : class, new()
    {
        public void ConfigureMolderBuilder(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<T>(Configure);
        }
        public abstract void Configure(EntityTypeBuilder<T> entity);
    }
}
