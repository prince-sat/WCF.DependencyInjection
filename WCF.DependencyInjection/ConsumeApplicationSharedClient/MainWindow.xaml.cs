using Autofac;
using Autofac.Integration.Wcf;
using Client.Proxies;
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

namespace ConsumeApplicationSharedClient
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ContainerBuilder builder = null;
        IContainer container = null;
        public MainWindow()
        {
            InitializeComponent();

            builder = new Autofac.ContainerBuilder();
            // register proxies
            builder.Register(c => new ChannelFactory<Client.Contracts.IBlogService>("BasicHttpBinding_IBlogService_9002"))
              .InstancePerLifetimeScope();
            builder.RegisterType<BlogClient>().As<Client.Contracts.IBlogService>().UseWcfSafeRelease();
            // build container
            container = builder.Build();

        }

        private void btnSharedClient_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Client.Contracts.IBlogService proxy;
                using (var lifetime = container.BeginLifetimeScope())
                {
                    //string authUsername = "chris";
                    //string authPassword = "sakell";
                    proxy = container.Resolve<Client.Contracts.IBlogService>(new NamedParameter[] {
                    new NamedParameter("authUsername","chris"),
                    new NamedParameter("authPassword","sakell")
                });
                    Client.Entities.BlogInfo _blog = proxy.GetById(new Client.Entities.BlogRequest { BlogId=1});
                    if (_blog != null)
                    {
                        lbxResult.Items.Clear();
                        lbxResult.Items.Add(_blog.Name + " by " + _blog.Owner);
                    }

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}
