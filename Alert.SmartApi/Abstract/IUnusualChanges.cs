using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alert.SmartApi.Abstract
{
    public interface IUnusualChanges
    {
        string ReportUnusualChanges(AngelBroking.SmartApi connect, DateTime dt);
    }
}
