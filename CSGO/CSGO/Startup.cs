//using System;
//using System.Diagnostics;
//using System.Threading.Tasks;
//using Microsoft.Owin;
//using Owin;
//using Quartz;

//[assembly: OwinStartup(typeof(CSGO.Startup))]

//namespace CSGO
//{
//    public class Startup
//    {
//        public void Configuration(IAppBuilder app)
//        {
//            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
//            Debug.WriteLine("t");
//        }


//    }
//}

using System;
using System.Diagnostics;
using Quartz;
using Hangfire;
using Hangfire.MySql;
using Microsoft.Owin;
using Owin;
using System.Transactions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Quartz.Impl;
using Quartz.Spi;

[assembly: OwinStartup(typeof(CSGO.Startup))]

namespace CSGO
{
    public class Startup
    {
        //public Startup(IConfiguration configuration)
        //{
        //    Config = configuration;
        //}
        //public IConfiguration Config { get; }

        public IScheduler Scheduler { get; set; }

        public void Configuration(IAppBuilder app)
        {
            Debug.WriteLine("test");
            //Scheduler.Start();
            

        }

        public void ConfigureServices(IServiceCollection services)
        {
            Debug.WriteLine("test");
            // Add Quartz services
            services.AddSingleton<IJobFactory, SingletonJobFactory>();
            services.AddSingleton<ISchedulerFactory, StdSchedulerFactory>();

            // Add our job
            services.AddSingleton<DataJob>();
            services.AddSingleton(new JobSchedule(
                jobType: typeof(DataJob),
                cronExpression: "0/3 * * * * ?")); // run every 5 seconds
            services.AddHostedService<QuartzHostedService>();
        }
    }
}
