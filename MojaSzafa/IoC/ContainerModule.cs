using Autofac;
using System.Reflection;
using MojaSzafa.Repositories;

namespace MojaSzafa.IoC
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

            base.Load(builder);
        }
    }
}
