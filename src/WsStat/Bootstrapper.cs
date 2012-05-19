using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc3;
using Microsoft.Practices.ServiceLocation;
using WSStat.Common.Logging;
using WSStat.Repository;

namespace WSStat
{
    public static class Bootstrapper
    {
        public static void Initialise()
        {
            var container = BuildUnityContainer();
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            container = new UnityContainer();
            container.RegisterType<ILogger, EnterpriseLogger>();
            container.RegisterType<IWSStatContext, WSStatContext>(new HierarchicalLifetimeManager());
            container.RegisterType<IEquipmentRepository, EquipmentRepository>();
            container.RegisterType<ISailingSessionsRepository, SailingSessionRepository>();

            ServiceLocator.SetLocatorProvider(() => new UnityServiceLocator(container));      

            //container.ReRegisterControllers();

            return container;
        }
    }
}