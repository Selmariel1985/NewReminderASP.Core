using Autofac;
using Microsoft.Extensions.Caching.Memory;
using NewReminderASP.Core.Container;
using NewReminderASP.Data.Container;

namespace NewReminderASP.Dependencies.Container
{
    /// <summary>
    ///     Module for configuring common dependencies used across the application.
    /// </summary>
    public class CommonModule : Module
    {
        /// <summary>
        ///     Loads the configuration of common dependencies into the Autofac container.
        /// </summary>
        /// <param name="builder">The container builder to register dependencies with.</param>
        protected override void Load(ContainerBuilder builder)
        {
            // Register an instance of MemoryCache as IMemoryCache
            builder.RegisterInstance(new MemoryCache(new MemoryCacheOptions())).As<IMemoryCache>();

            // Register all types from CoreModule and DataModule assemblies as implemented interfaces
            builder.RegisterAssemblyTypes(typeof(CoreModule).Assembly).AsImplementedInterfaces();
            builder.RegisterAssemblyTypes(typeof(DataModule).Assembly).AsImplementedInterfaces();

            // Register EmailService as itself
            builder.RegisterType<EmailService>().AsSelf();
        }
    }
}