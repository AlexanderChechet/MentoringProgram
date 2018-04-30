using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace PowerManagmentComLibrary.SystemPowerInformation
{
    [ComVisible(true)]
    [Guid("ebb20b3a-49d7-4ba8-a2b0-663f181720c7")]
    [InterfaceType(ComInterfaceType.InterfaceIsDual)]
    public interface ISystemPowerInformation
    {
        byte CoolingMode { get; set; }
        uint Idleness { get; set; }
        uint TimeRemaining { get; set; }
        uint MaxIdlenessAllowed { get; set; }
    }
}
