using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PowerManagmentComLibrary.SystemPowerInformation
{
    [ComVisible(true)]
    [Guid("b4edd4e5-49c8-4231-9cbf-11035743c6e9")]
    [ClassInterface(ClassInterfaceType.None)]
    public class SystemPowerInformationCom : ISystemPowerInformation
    {
        private byte coolingMode;
        private uint idleness;
        private uint timeRemaining;
        private uint maxIdlenessAllowed;

        byte ISystemPowerInformation.CoolingMode
        {
            get { return coolingMode; }
            set { coolingMode = value; }
        }

        uint ISystemPowerInformation.Idleness
        {
            get { return idleness; }
            set { idleness = value; }
        }

        uint ISystemPowerInformation.TimeRemaining
        {
            get { return timeRemaining; }
            set { timeRemaining = value; }
        }

        uint ISystemPowerInformation.MaxIdlenessAllowed
        {
            get { return maxIdlenessAllowed; }
            set { maxIdlenessAllowed = value; }
        }
    }
}
