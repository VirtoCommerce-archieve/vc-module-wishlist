using Microsoft.Practices.Unity;
using VirtoCommerce.Platform.Core.Common;
using VirtoCommerce.Platform.Core.Modularity;
using VirtoCommerce.Platform.Data.Infrastructure;
using VirtoCommerce.Platform.Data.Infrastructure.Interceptors;
using VirtoCommerce.WishlistModule.Core.Services;
using VirtoCommerce.WishlistModule.Data.Repositories;
using VirtoCommerce.WishlistModule.Data.Services;

namespace VirtoCommerce.WishlistModule.Web
{
    public class Module : ModuleBase
    {
        private readonly IUnityContainer _container;
        private static readonly string _connectionString = ConfigurationHelper.GetNonEmptyConnectionStringValue("VirtoCommerce");

        public Module(IUnityContainer container)
        {
            _container = container;
        }

        public override void SetupDatabase()
        {
            base.SetupDatabase();

            using (var db = new WishlistRepositoryImpl(_connectionString, _container.Resolve<AuditableInterceptor>()))
            {
                var initializer = new SetupDatabaseInitializer<WishlistRepositoryImpl, VirtoCommerce.WishlistModule.Data.Migrations.Configuration>();

                initializer.InitializeDatabase(db);
            }
        }

        public override void Initialize()
        {
            base.Initialize();

            _container.RegisterType<IWishlistRepository>(new InjectionFactory(c => new WishlistRepositoryImpl(_connectionString, _container.Resolve<AuditableInterceptor>(), new EntityPrimaryKeyGeneratorInterceptor())));

            _container.RegisterType<IWishlistLinkSearchService, WishlistLinkSearchService>();
            _container.RegisterType<IWishlistLinkService, WishlistLinkService>();
            _container.RegisterType<IWishlistSearchService, WishlistSearchService>();
            _container.RegisterType<IWishlistService, WishlistService>();
        }

        public override void PostInitialize()
        {
            base.PostInitialize();

            // This method is called for each installed module on the second stage of initialization.

            // Register implementations 
            // _container.RegisterType<IMyService, MyService>();

            // Resolve registered implementations:
            // var settingManager = _container.Resolve<ISettingsManager>();
            // var value = settingManager.GetValue("Pricing.ExportImport.Description", string.Empty);
        }
    }
}
