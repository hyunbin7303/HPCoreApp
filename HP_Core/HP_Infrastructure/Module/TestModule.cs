using Autofac;
using System;
using System.Collections.Generic;
using System.Text;

namespace HP_Infrastructure.Module
{
    public class TestModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Test>().As<ITest>();
            base.Load(builder);  
        }

    }
}



// Flexibility to override
// Module registers its IDrive dependency with the container as well.


    // How to setting up Json/XML configuration
    // 