using Autofac;
using HP_Core;
using HP_Core.Models;
using HP_Core.Notification;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace HP_Infrastructure.Module
{
    public class NotificationModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var notificationServiceTypes = Directory.EnumerateFiles(Environment.CurrentDirectory)
                                        .Where(f => f.Contains("HP_Infrastructure") && f.EndsWith("Notification.dll"))
                                        .Select(fp => Assembly.LoadFrom(fp))
                                        .SelectMany(assembly => assembly.GetTypes().Where(type => typeof(INotificationService).IsAssignableFrom(type) && type.IsClass));

            foreach (var notiServiceType in notificationServiceTypes)
            {
                builder.RegisterType(notiServiceType).As<INotificationService>();
            }
        }
    }
}
