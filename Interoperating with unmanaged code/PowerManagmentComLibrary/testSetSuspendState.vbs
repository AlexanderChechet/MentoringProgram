Set objXL = CreateObject("PowerManagmentComLibrary.PowerManagment.PowerManagmentCom")
Set power = objXL.SetSuspendState(false)

Pause("Press Enter to continue")

Sub Pause(strPause)
     WScript.Echo (strPause)
     z = WScript.StdIn.Read(1)
End Sub