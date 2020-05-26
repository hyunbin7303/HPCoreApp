using HP_Core;
using HP_Core.Models;

namespace HP_Core.Notification
{
    public interface INotificationService
    {
        void NotifyNameChanged(User user);
        void NotifyAppInfraCanged(AppInfra appInfra);
        void NotifyExtraChanged();

        void NotifyDLLChanged();
    }
}