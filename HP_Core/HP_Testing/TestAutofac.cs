using Autofac;
using HP_Core;
using HP_Core.Notification;
using HP_Infrastructure;
using HP_Redis;
using NUnit.Framework;

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
        public void NotificationTest()
        {
            var container = AutofactBuildContainer.BuildContainer();
            var myappRepo = container.Resolve<IAppInfra>();
            var notificationService = container.Resolve<INotificationService>();
        }

        [Test]
        public void Autofac_ModuleTest()
        {
            var container = AutofactBuildContainer.BuildContainer();
            var myappRepo = container.Resolve<ProgramModule>();
        }

    }
}