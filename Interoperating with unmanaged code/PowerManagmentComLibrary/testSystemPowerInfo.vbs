Dim objXL
Set objXL = CreateObject("PowerManagmentComLibrary.PowerManagment.PowerManagmentCom")
Set power = objXL.GetPowerInformation()
WScript.Echo "Idleness", (power.Idleness) 
WScript.Echo "CoolingMode", (power.CoolingMode) 
WScript.Echo "TimeRemaining", (power.TimeRemaining) 
WScript.Echo "MaxIdlenessAllowed", (power.MaxIdlenessAllowed) 
Pause("Press Enter to continue")

Sub Pause(strPause)
     WScript.Echo (strPause)
     z = WScript.StdIn.Read(1)
End Sub