$serviceName = "ServiceName"

# verify if the service already exists, and if yes remove it first
# using WMI to remove Windows service because PowerShell does not have CmdLet for this
$existingService = Get-WmiObject -Class Win32_Service -Filter "name='$serviceName'"

if ($existingService)
{
    $serviceToRemove.Delete()
    "service removed"
}
else
{
    # just do nothing
    "service does not exists"
}

"installing service"

# creating credentials which can be used to run my Windows service
$secpasswd = ConvertTo-SecureString "MyPa$$word" -AsPlainText -Force
$mycreds = New-Object System.Management.Automation.PSCredential (".\MyUserName", $secpasswd)
$binaryPath = "c:\myServiceBinaries\MyService.exe"

# creating Windows service using all provided parameters
New-Service -name $serviceName -binaryPathName $binaryPath -displayName $serviceName -startupType Automatic -credential $mycreds

"installation completed"
