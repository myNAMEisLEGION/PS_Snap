using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using PhotoSender_BBD_UI_Tests.Factory;


namespace PhotoSender_BBD_UI_Tests.Steps
{
    public class BaseStep
    {
        public static  ILifetimeScope InitializeApp()
        {
            var container = ContainerConfig.Configure();
            var scope = container.BeginLifetimeScope();
            return scope;
        }

    }


}
