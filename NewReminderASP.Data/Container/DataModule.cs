﻿using Autofac;
using NewReminderASP.Data.Client;
using NewReminderASP.Data.Repository;

namespace NewReminderASP.Data.Container
{
    /// <summary>
    ///     Module for configuring dependency injection for data-related components.
    /// </summary>
    public class DataModule : Module
    {
        /// <summary>
        ///     Loads the configuration of data-related dependencies into the Autofac container.
        /// </summary>
        /// <param name="builder">The container builder to register dependencies with.</param>
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