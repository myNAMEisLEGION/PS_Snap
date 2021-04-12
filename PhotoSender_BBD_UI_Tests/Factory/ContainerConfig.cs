using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using OpenQA.Selenium;
using PhotoSender_BBD_UI_Tests.Pages;

namespace PhotoSender_BBD_UI_Tests.Factory
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<DriverContext>().SingleInstance().As<IDriverContext>();
            builder.RegisterType<MainWorkflow>().SingleInstance().As<IMainWorkflow>();
            builder.RegisterType<MainWorkflow>().AsSelf();
            builder.RegisterType<LoginPage>().SingleInstance().AsSelf();
            builder.RegisterType<LoginPage>().SingleInstance().As<ILoginPage>();
            builder.RegisterType<TitlePage>().SingleInstance().As<ITitlePage>();
            builder.RegisterType<TitlePage>().SingleInstance().AsSelf();
            builder.RegisterType<CroppingPage>().SingleInstance().As<ICroppingPage>();
            builder.RegisterType<CroppingPage>().SingleInstance().AsSelf();
            builder.RegisterType<DeliveryPage>().SingleInstance().As<IDeliveryPage>();
            builder.RegisterType<DeliveryPage>().SingleInstance().AsSelf();
            builder.RegisterType<LabAccountPage>().SingleInstance().As<ILabAccountPage>();
            builder.RegisterType<LabAccountPage>().SingleInstance().AsSelf();
            builder.RegisterType<LabAdminTopMenu>().SingleInstance().As<ILabAdminTopMenu>();
            builder.RegisterType<LabAdminTopMenu>().SingleInstance().AsSelf();
            builder.RegisterType<LabClientLoginPage>().SingleInstance().As<ILabClientLoginPage>();
            builder.RegisterType<LabClientLoginPage>().SingleInstance().AsSelf();
            builder.RegisterType<LabClientWelcome>().SingleInstance().As<ILabClientWelcome>();
            builder.RegisterType<LabClientWelcome>().SingleInstance().AsSelf();
            builder.RegisterType<NewOrderPage>().SingleInstance().As<INewOrderPage>();
            builder.RegisterType<NewOrderPage>().SingleInstance().AsSelf();
            builder.RegisterType<OrderCompletedPage>().SingleInstance().As<IOrderCompletedPage>();
            builder.RegisterType<OrderCompletedPage>().SingleInstance().AsSelf();
            builder.RegisterType<OrdersPage>().SingleInstance().As<IOrdersPage>();
            builder.RegisterType<OrdersPage>().SingleInstance().AsSelf();
            builder.RegisterType<OverviewPage>().SingleInstance().As<IOverviewPage>();
            builder.RegisterType<OverviewPage>().SingleInstance().AsSelf();
            builder.RegisterType<PaymentPage>().SingleInstance().As<IPaymentPage>();
            builder.RegisterType<PaymentPage>().SingleInstance().AsSelf();
            builder.RegisterType<ParametersPage>().SingleInstance().As<IParametersPage>();
            builder.RegisterType<ParametersPage>().SingleInstance().AsSelf();
            builder.RegisterType<PayUCardPaymentPage>().SingleInstance().As<IPayUCardPaymentPage>();
            builder.RegisterType<PayUCardPaymentPage>().SingleInstance().AsSelf();
            builder.RegisterType<PayUPage>().SingleInstance().As<IPayUPage>();
            builder.RegisterType<PayUPage>().SingleInstance().AsSelf();
            builder.RegisterType<PayUPaymentSummaryPage>().SingleInstance().As<IPayUPaymentSummaryPage>();
            builder.RegisterType<PayUPaymentSummaryPage>().SingleInstance().AsSelf();
            builder.RegisterType<PhotoSelectionPage>().SingleInstance().As<IPhotoSelectionPage>();
            builder.RegisterType<PhotoSelectionPage>().SingleInstance().AsSelf();
            builder.RegisterType<SummaryPage>().SingleInstance().As<ISummaryPage>();
            builder.RegisterType<SummaryPage>().SingleInstance().AsSelf();
            builder.RegisterType<TopMenuUserLab>().SingleInstance().As<ITopMenuUserLab>();
            builder.RegisterType<TopMenuUserLab>().SingleInstance().AsSelf();
            builder.RegisterType<UserLabOrderPage>().SingleInstance().As<IUserLabOrderPage>();
            builder.RegisterType<UserLabOrderPage>().SingleInstance().AsSelf();


            return builder.Build();
        }
    }
}
