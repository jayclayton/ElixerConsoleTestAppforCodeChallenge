$adminKey = "HKLM:\SOFTWARE\Microsoft\Windows\CurrentVersion\Policies\System"
$val = Get-ItemProperty $adminKey | Select-Object -ExpandProperty "EnableLUA"

if ($val -eq 0) {
    # Elevate the current PowerShell session to run as administrator
    Start-Process PowerShell.exe "-NoProfile -ExecutionPolicy Bypass -Command `"&{&'$PSCommandPath'}`"" -Verb RunAs
}
else {
    # Create the folder "elixercodechallenge" in the root directory
    New-Item -ItemType Directory -Path "C:\elixercodechallenge"
    
    # Set the folder "elixercodechallenge" attributes to full access for everyone
    $Acl = Get-Acl "C:\elixercodechallenge"
    $Ar = New-Object  System.Security.AccessControl.FileSystemAccessRule("Everyone","FullControl","Allow")
    $Acl.SetAccessRule($Ar)
    Set-Acl "C:\elixercodechallenge" $Acl

    # Copy the file "temptext.txt" to the folder "elixercodechallenge"
    

    # Create a blank file named "mytext.txt" in the folder "elixercodechallenge"
    New-Item -ItemType File -Path "C:\elixercodechallenge\mytext.txt"
}


$elixirCodeChallenge = "C:\elixercodechallenge"
$applicationFolder = "$elixirCodeChallenge\applicationfolder"
New-Item -ItemType Directory -Path $applicationFolder -ErrorAction SilentlyContinue | Out-Null
$fullAccess = [System.Security.AccessControl.FileSystemRights] "FullControl"
$everyone = [System.Security.Principal.WellKnownSidType] "WorldSid"
$fileSecurity = New-Object System.Security.AccessControl.FileSecurity
$fileSecurity.SetAccessRuleProtection($False, $True)
$fileSecurity.SetAccessRule($everyone, $fullAccess, [System.Security.AccessControl.InheritanceFlags] "ContainerInherit, ObjectInherit", [System.Security.AccessControl.PropagationFlags] "None", [System.Security.AccessControl.AccessControlType] "Allow")
Set-Acl -Path $applicationFolder -AclObject $fileSecurity



$elixirCodeChallenge = "C:\elixercodechallenge\applicationfolder"
New-Item -ItemType Directory -Path $elixirCodeChallenge -ErrorAction SilentlyContinue | Out-Null
$currentDirectory = Split-Path -Parent $MyInvocation.MyCommand.Definition
$applicationFolder = Join-Path $currentDirectory "applicationfolder"
Get-ChildItem $applicationFolder | Copy-Item -Destination $elixirCodeChallenge -Rec


