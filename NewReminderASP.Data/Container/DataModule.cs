using Autofac;
using NewReminderASP.Data.Client;
using NewReminderASP.Data.Repository;

namespace NewReminderASP.Data.Container
{
    public class DataModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserClient>().As<IUserClient>();
            builder.RegisterType<UserRepository>().As<IUserRepository>();
            builder.RegisterType<CountryClient>().As<ICountryClient>();
            builder.RegisterType<CountryRepository>().As<ICountryRepository>();
            builder.RegisterType<AddressClient>().As<IAddressClient>();
            builder.RegisterType<AddressRepository>().As<IAddressRepository>();
            builder.RegisterType<PersonalInformationClient>().As<IPersonalInformationClient>();
            builder.RegisterType<PersonalInformationRepository>().As<IPersonalInformationRepository>();
            builder.RegisterType<EventClient>().As<IEventClient>();
            builder.RegisterType<EventRepository>().As<IEventRepository>();
            builder.RegisterType<PhoneClient>().As<IPhoneClient>();
            builder.RegisterType<PhoneRepository>().As<IPhoneRepository>();
        }
    }
}