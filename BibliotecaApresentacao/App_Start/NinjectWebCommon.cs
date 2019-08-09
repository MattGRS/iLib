using BibliotecaAplicacao.Interfaces;
using BibliotecaAplicacao.Classes;
using BibliotecaDominio.Interfaces.Servicos;
using System;
using System.Web;
using BibliotecaDados.Repositorios;
using BibliotecaDominio.Interfaces.Repositorio;
using BibliotecaDominio.Servicos;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using Ninject;
using Ninject.Web.Common;
using Ninject.Web.Common.WebHost;


[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(BibliotecaApresentacao.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethod(typeof(BibliotecaApresentacao.App_Start.NinjectWebCommon), "Stop")]

namespace BibliotecaApresentacao.App_Start
{
    public class NinjectWebCommon
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
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

                RegisterServices(kernel);
                return kernel;
            }
            catch 
            {
                kernel.Dispose();
                throw;
            }
        }

        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind(typeof(IBibliotecaAppServicoBase<>)).To(typeof(BibliotecaAppServico<>));
            kernel.Bind<IAssuntoAppServico>().To<AssuntoAppServico>();

            kernel.Bind(typeof(IBibliotecaServicoBase<>)).To(typeof(BibliotecaServicoBase<>));
            kernel.Bind<IAssuntoServico>().To<AssuntoServico>();

            kernel.Bind(typeof(IBibliotecaRepositorioBase<>)).To(typeof(BibliotecaRepositorioBase<>));
            kernel.Bind<IAssuntoRepositorio>().To<AssuntoRepositorio>();
        }
    }
}