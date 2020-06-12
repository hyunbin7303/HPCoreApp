using Autofac;
using HP_Core;
using HP_Core.Notification;
using HP_Infrastructure;
using HP_Infrastructure.Module;
using HP_Redis;
using NUnit.Framework;
using System.Runtime.CompilerServices;

namespace HP_Testing
{
    public class TestAutofac
    {

        // Naming Convention: MethodName_StateUnderTest_ExpectedBehavior:

        // Feature to be tested
        /*
         * IsNotAnAdultIfAgeLessThan18
        FailToWithdrawMoneyIfAccountIsInvalid
        StudentIsNotAdmittedIfMandatoryFieldsAreMissing
         */

        [Test]
        public void Autofac_AppInfra_DisplayMessage()
        {
            AppInfra appInfra = new AppInfra()
            {
                Id = 1,
                Name = "MyTask",
                Usage = "Management service for my task."
            };
            var container = AutofactBuildContainer.BuildContainer();
            var myappRepo = container.Resolve<IAppInfra>();
            myappRepo.Print(appInfra);
        }
        [Test]
        public void Autofac_AppInfra_Testing()
        {

        }
        [Test]
        public void NotificationTest()
        {
            var container = AutofactBuildContainer.BuildContainer();
            var notificationService = container.Resolve<INotificationService>();
            System.Console.WriteLine("NOTIFICATION DELL CALLED");
            notificationService.NotifyDLLChanged();
        }
        [Test]
        public void NotifyExtraChanged()
        {
            var container = AutofactBuildContainer.BuildContainer();
            var notificationService = container.Resolve<INotificationService>();
            notificationService.NotifyExtraChanged();
        }


        [Test]
        public void Autofac_ModuleTest()
        {
            var container = AutofactBuildContainer.BuildContainer();
            var myappRepo = container.Resolve<ProgramModule>();
            //var programService = container
            
        }

    }
}