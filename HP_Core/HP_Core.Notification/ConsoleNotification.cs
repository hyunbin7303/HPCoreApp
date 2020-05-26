
namespace HP_Core.Notification
{
    public class ConsoleNotification : INotificationService
    {
        public void NotifyAppInfraCanged(AppInfra appInfra)
        {

            // Call Log file in HP_Logging? what do u think?
            System.Console.WriteLine($"appInfra Id : {appInfra.Id} ");
        }
        public void NotifyDLLChanged()
        {
            // Call Log file in HP_Logging? what do u think?
            System.Console.WriteLine("DLL CHECK NECESSARY ");
        }
        public void NotifyExtraChanged()
        {
            // Call Log file in HP_Logging? what do u think?
            System.Console.WriteLine("Anything changed");
        }
        public void NotifyNameChanged(User user)
        {
            System.Console.WriteLine($"User Id : {user.Id} ");
        }
    }
}