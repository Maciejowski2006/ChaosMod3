Get-Process -Name "LocalAdmin" -ErrorAction Ignore | Stop-Process

Remove-Item -Path "C:\Users\Maciej\AppData\Roaming\SCP Secret Laboratory\PluginAPI\plugins\global\ChaosMod3.dll" -Force 
Copy-Item -Path "C:\Users\Maciej\Dev\ChaosMod3\ChaosMod3\bin\Release\ChaosMod3.dll" -Destination "C:\Users\Maciej\AppData\Roaming\SCP Secret Laboratory\PluginAPI\plugins\global\ChaosMod3.dll" 

Start-Process -FilePath "P:\Serwery\SteamCMD\steamapps\common\SCP Secret Laboratory Dedicated Server\LocalAdmin.exe" -WorkingDirectory "P:\Serwery\SteamCMD\steamapps\common\SCP Secret Laboratory Dedicated Server" -ArgumentList "7777"