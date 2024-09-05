using Autofac;
using NewReminderASP.Core.Provider;

namespace NewReminderASP.Core.Container
{
    // This class represents the Autofac module for registering core providers.
    public class CoreModule : Module
    {
        // This method is used to load the core module into the container builder.
        protected override void Load(ContainerBuilder builder)
        {
            // Registering UserProvider implementation with IUserProvider interface.
            builder.RegisterType<UserProvider>().As<IUserProvider>();

            // Registering CountryProvider implementation with ICountryProvider interface.
            builder.RegisterType<CountryProvider>().As<ICountryProvider>();

            // Registering AddressProvider implementation with IAddressProvider interface.
            builder.RegisterType<AddressProvider>().As<IAddressProvider>();

            // Registering PersonalInformationProvider implementation with IPersonalInformationProvider interface.
            builder.RegisterType<PersonalInformationProvider>().As<IPersonalInformationProvider>();

            // Registering EventProvider implementation with IEventProvider interface.
            builder.RegisterType<EventProvider>().As<IEventProvider>();

            // Registering PhoneProvider implementation with IPhoneProvider interface.
            builder.RegisterType<PhoneProvider>().As<IPhoneProvider>();
        }
    }
}