using Argotic.Syndication;
using Autofac;
using Autofac.Integration.Mvc;
using FeedCobra.Models;
using FeedCobra.Services;

namespace FeedCobra
{
    public class Bootstrapper
    {
        public IContainer Build()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterType<SubscriptionContext>().InstancePerHttpRequest();
            builder.RegisterModule<FeedsModule>();

            return builder.Build();
        }
    }

    public class FeedsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<FeedService>().As<IFeedService<RssItem>>().InstancePerHttpRequest();
        }
    }
}