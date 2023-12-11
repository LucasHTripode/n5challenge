using Microsoft.EntityFrameworkCore;

namespace n5challenge.Infraestructure.EntityFramework.Context
{
    public static class StaticConfigureEntity<T, J>
        where T : class, new()
        where J : AbstractConfigureEntity<T>, new()
    {
        public static void Configure(ModelBuilder modelBuilder)
        {
            var instance = new J();
            modelBuilder.Entity<T>(instance.Configure);
        }
    }
}
