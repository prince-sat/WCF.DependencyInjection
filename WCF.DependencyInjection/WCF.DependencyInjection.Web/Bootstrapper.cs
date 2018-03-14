﻿using Autofac;
using Business.Services.Contracts;
using Business.Services.Implementations;
using Data.Core.Infrastructure;
using Data.Core.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace WCF.Web
{
    public static class Bootstrapper
    {
        /// <summary>
        /// Configures and builds Autofac IOC container.
        /// </summary>
        /// <returns></returns>
        public static Autofac.IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();

            // register services

            builder.RegisterType<BlogService>().As<IBlogService>();
            builder.RegisterType<ArticleService>().As<IArticleService>();

            // register repositories and UnitOfWork
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
            builder.RegisterType<DbFactory>().As<IDbFactory>();
            builder.RegisterType<ArticleRepository>().As<IArticleRepository>();
            builder.RegisterType<BlogRepository>().As<IBlogRepository>();

            // build container
            return builder.Build();
        }
    }
}