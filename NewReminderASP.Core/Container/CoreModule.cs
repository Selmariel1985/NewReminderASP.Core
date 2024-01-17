using Autofac;
using NewReminderASP.Core.Provider;

namespace NewReminderASP.Core.Container
{
    public class CoreModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserProvider>().As<IUserProvider>();
            builder.RegisterType<CountryProvider>().As<ICountryProvider>();
            builder.RegisterType<AddressProvider>().As<IAddressProvider>(); 
            builder.RegisterType<PersonalInformationProvider>().As<IPersonalInformationProvider>();

        }
    }
}