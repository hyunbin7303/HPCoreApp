using Autofac;
using System;
using System.Collections.Generic;
using System.Text;

namespace HP_Infrastructure.Module
{


    //Advantages of using modules
    // Decresed config complexity

    // good for dynamic Configuration

        //Advanced Extensions???
        // -- Attach to component resolution events and extend how parameters are resolved or perform other extensions. (e.g. log4net integration module).

    public class ProgramModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
        }

    }
}
