using System;
using System.Web.Http;
using BakkiefyBackend.Models;
using BakkiefyBackend.Repositories.Core;
using BakkiefyBackend.Repositories.Interface;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Unity;
using Unity.AspNet.WebApi;
using Unity.Injection;

namespace BakkiefyBackend
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below.
            // Make sure to add a Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your type's mappings here.
            // container.RegisterType<IProductRepository, ProductRepository>();
            var connection = System.Configuration.ConfigurationManager.ConnectionStrings["AuthContext"].ConnectionString;

          

            var options = new DbContextOptionsBuilder<BakkieDbContext>()
               .UseSqlServer(connection)
               .Options;
            
            container.RegisterType<BakkieDbContext>(new InjectionConstructor(options));
            container.RegisterType<IdentityDbContext<IdentityUser>, AuthContext>();
            container.RegisterType<ITicketRepository, TicketRepository>();
            container.RegisterType<IBakkieRequestRepository, BakkieRequestRepository>();
            container.RegisterType<IBakkieSizeRepository, BakkieSizeRepository>();
            container.RegisterType<IBakkieRepository, BakkieRepository>();
            container.RegisterType<ICostRepository, CostRepository>();
            container.RegisterType<ICustomerBlackList, CustomerBakkieBlackListRepository>();
            container.RegisterType<IDriverRepository, DriverRepository>();
            container.RegisterType<IBakkieRepository, BakkieRepository>();
            container.RegisterType<ICustomerRepository, CustomerRepository>();
            container.RegisterType<IOnlineRepository, OnlineRepository>();
            container.RegisterType<IRatingRepository, RatingRepository>();
            container.RegisterType<IAuthRepository, AuthRepository>();

            // DependencyResolver.SetResolver(new UnityDependencyResolver(container));

            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}