using Autofac;
using System.Reflection;
using MojaSzafa.DB.Interfaces;
using MojaSzafa.INFRASTRUCTURE.Interfaces;
using MojaSzafa.INFRASTRUCTURE.Mappers;

namespace MojaSzafa.INFRASTRUCTURE.IoC
{
    /// <summary>
    /// Dependency Injection configuration class
    /// </summary>
    public class ContainerModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var assembly = typeof(ContainerModule)
               .GetTypeInfo()
               .Assembly;

            //Loads all repositories interfaces
            builder.RegisterAssemblyTypes(assembly)
                .Where(x => x.IsAssignableTo<IRepository>())
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            //Loads all service interfaces
            builder.RegisterAssemblyTypes(assembly)
                .Where(x => x.IsAssignableTo<IService>())
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            base.Load(builder);
            MapperConfig.Init();
        }
    }
}
