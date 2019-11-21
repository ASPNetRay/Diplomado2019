using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using ServiciosABC.EntityFramework;
using ServiciosABC.Interfaces;
using ServiciosABC.Interfaces.ServiciosI;
using ServiciosABC.Objetos;

namespace SistemaAbc
{
    public static class ContainerConfig
    {
        internal static void ResolveDependencies()
    {
        var builder = new ContainerBuilder();
        builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterType<STickets>().As<ITickets>().InstancePerRequest();
            builder.RegisterType<SSoporte>().As<ISoporte>().InstancePerRequest();
            builder.RegisterType<STicketNoAsign>().As<ITicketsNoAsign>().InstancePerRequest();
            

            builder.RegisterType<BaseDatosTickets>().InstancePerRequest();
            builder.RegisterType<BaseDatosCloseTickets>().InstancePerRequest();
            builder.RegisterType<BaseDatosNoneTickets>().InstancePerRequest();
            builder.RegisterType<BdSoporte>().InstancePerRequest();

            var container = builder.Build();

        DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

    }
}
}