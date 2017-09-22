﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace IntroToASPDotNetCore
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //this if statement below allows developers ONLY to be able to view the directory
            //if not in development, directory browsing will not be allowed
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseFileServer(enableDirectoryBrowsing: env.IsDevelopment());         

            //order matters - place usedefault ABOVE usestatic
            //app.UseDefaultFiles();
            //app.UseStaticFiles();

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync($"Hello {env.EnvironmentName}!");
            });
        }
    }
}
