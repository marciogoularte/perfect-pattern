using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Integration.WebApi;
using System.Reflection;
using PerfectPattern.DAL.DbFactory;
using PerfectPattern.DAL.Repositories.Student;

namespace PerfectPattern.API.IoC
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            // Register your Web API controllers.
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<DbFactory>().As<IDbFactory>()
                .WithParameter("connectionString", "DB");
            builder.RegisterType<StudentRepository>().As<IStudentRepository>();

            // Set the dependency resolver to be Autofac.
            var container = builder.Build();

            return container;
        }
    }
}
