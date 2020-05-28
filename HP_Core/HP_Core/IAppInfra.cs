using System;
using System.Collections.Generic;
using System.Text;

namespace HP_Core
{
    public interface IAppInfra
    {
        void Print(AppInfra outInfra);
        bool ChangeName(string newName);
        bool ChangeUsage(string newUsage);
        bool ChangeAppStatus(bool isStart);
    }
}
