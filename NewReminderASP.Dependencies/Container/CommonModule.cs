using Autofac;
using Microsoft.Extensions.Caching.Memory;
using NewReminderASP.Core.Container;
using NewReminderASP.Data.Container;

namespace NewReminderASP.Dependencies.Container
{
    public class CommonModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance(new MemoryCache(new MemoryCacheOptions())).As<IMemoryCache>();
            builder.RegisterAssemblyTypes(typeof(CoreModule).Assembly)
                .AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(typeof(DataModule).Assembly)
                .AsImplementedInterfaces();
        }
    }
}