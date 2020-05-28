using HP_Core;
using HP_Core.Models;
using HP_Core.Notification;

namespace HP_Infrastructure
{
    public class ConsoleNotification : INotificationService
    {
        public void NotifyAppInfraCanged(AppInfra appInfra)
        {
            throw new System.NotImplementedException();
        }

        public void NotifyDLLChanged()
        {
            throw new System.NotImplementedException();
        }
        public void NotifyExtraChanged()
        {
            throw new System.NotImplementedException();
        }
        public void NotifyNameChanged(AppInfra appinfra)
        {
            System.Console.WriteLine($"Infra {appinfra.Id} ");
        }
        public void NotifyNameChanged(HP_Core.Notification.User user)
        {
            throw new System.NotImplementedException();
        }
    }
}