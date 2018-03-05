using System;
using System.Web;
using LibDDD.Application;
using LibDDD.Application.Interface;
using LibDDD.Domain.Interface.Services;
using LibDDD.Domain.Interfaces.Repositories;
using LibDDD.Domain.Services;
using LibDDD.Infra.Data.Repository;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(LibDDD.MVC.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethod(typeof(LibDDD.MVC.App_Start.NinjectWebCommon), "Stop")]

namespace LibDDD.MVC.App_Start
{

    using Microsoft.Web.Infrastructure.DynamicModuleHelper;

    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Web.Common.WebHost;

    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
            kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

            RegisterServices(kernel);
            return kernel;
        }
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind(typeof(IAppServiceBase<>)).To(typeof(AppServiceBase<>));
            kernel.Bind<ILivroAppService>().To<LivroAppService>();
            kernel.Bind<IAutorAppService>().To<AutorAppService>();
            kernel.Bind<IEditoraAppService>().To<EditoraAppService>();

            kernel.Bind(typeof(IServiceBase<>)).To(typeof(ServiceBase<>));
            kernel.Bind<ILivroService>().To<LivroService>();
            kernel.Bind<IAutorService>().To<AutorService>();
            kernel.Bind<IEditoraService>().To<EditoraService>();

            kernel.Bind(typeof(IRepositoryBase<>)).To(typeof(RepositoryBase<>));
            kernel.Bind<ILivroRepository>().To<LivroRepository>();
            kernel.Bind<IAutorRepository>().To<AutorRepository>();
            kernel.Bind<IEditoraRepository>().To<EditoraRepository>();



        }
    }
}