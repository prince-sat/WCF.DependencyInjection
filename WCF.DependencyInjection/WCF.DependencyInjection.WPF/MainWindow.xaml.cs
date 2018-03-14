using Autofac;
using Autofac.Integration.Wcf;
using Business.Services.Contracts;
using Business.Services.Implementations;
using Data.Core.Infrastructure;
using Data.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WCF.DependencyInjection.WPF
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ServiceHost svcArticleHost = null;
        ServiceHost svcBlogHost = null;
        ContainerBuilder builder = null;
        IContainer container = null;
        public MainWindow()
        {
            InitializeComponent();

            // Init Autofac.WCF container
            builder = new ContainerBuilder();
            // register services
            builder.RegisterType<BlogService>().As<IBlogService>();
            builder.RegisterType<ArticleService>().As<IArticleService>();

            // register repositories and UnitOfWork
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
            builder.RegisterType<DbFactory>().As<IDbFactory>();
            builder.RegisterType<ArticleRepository>().As<IArticleRepository>();
            builder.RegisterType<BlogRepository>().As<IBlogRepository>();

            // build container
            container = builder.Build();


        }
        private void btnStartService_Click(object sender, RoutedEventArgs e)
        {
            try
            {

                svcArticleHost = new ServiceHost(typeof(ArticleService));
                svcBlogHost = new ServiceHost(typeof(BlogService));

                // add using statement: using Autofac.Integration.Wcf;
                svcArticleHost.AddDependencyInjectionBehavior<Business.Services.Contracts.IArticleService>(container);
                svcBlogHost.AddDependencyInjectionBehavior<Business.Services.Contracts.IBlogService>(container);


                svcArticleHost.Open();
                svcBlogHost.Open();

                this.btnStopService.IsEnabled = true;
                this.btnStartService.IsEnabled = false;
                this.lblStatus.Content = "Service is running..";
                this.lblStatus.Foreground = new SolidColorBrush(Colors.RoyalBlue);
            }
            catch (Exception ex)
            {
                container.Dispose();
                MessageBox.Show(ex.Message);
            }
        }

        private void btnStopService_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                svcArticleHost.Close();
                svcBlogHost.Close();

                this.btnStopService.IsEnabled = false;
                this.btnStartService.IsEnabled = true;
                this.lblStatus.Content = "Service is stopped.";
                this.lblStatus.Foreground = new SolidColorBrush(Colors.Crimson);
            }
            catch (Exception ex)
            {
                container.Dispose();
                MessageBox.Show(ex.Message);
            }
        }
    }
}
