# PowerShell-Laboratory

PowerShell commands for laboration. A portable module that can run on Linux, Mac-OS and Windows. A PowerShell library for testing things. It may change without notice.

[![PowerShell Gallery](https://img.shields.io/powershellgallery/v/HansKindberg.Laboratory.svg?label=PowerShell%20Gallery)](https://www.powershellgallery.com/packages/HansKindberg.Laboratory)

## 1 Commands

### 1.1 Show-LaboratoryInformation

    Show-LaboratoryInformation `
        -Value "Some value";

## 2 Development

### 2.1 Signing

Drop the "StrongName.snk" file in the repository-root. The file should not be included in source control.

### 2.2 Build warnings

At the moment we get the following warning:

- [NETSDK1206](https://learn.microsoft.com/en-us/dotnet/core/tools/sdk-errors/netsdk1206)

Haven't investigated it further.

## 3 Deployment/installation

### 3.1 PowerShell-Gallery

If you want to set up a local PowerShell-Gallery to test with:

    Register-PSRepository -Name "PowerShell-Laboratory" -InstallationPolicy Trusted -SourceLocation "{SOLUTION-DIRECTORY}\.powershell-repository";

or run the following script:

- [Register.ps1](/.powershell-repository/Register.ps1)

If you want to remove it:

	Unregister-PSRepository -Name "PowerShell-Laboratory";

or run the following script:

- [Unregister.ps1](/.powershell-repository/Unregister.ps1)

Get all module repositories:

	Get-PSRepository

Get module repositories by name (with wildcard):

	Get-PSRepository -Name "*Something*"

More information:

- [PowerShellGet](https://learn.microsoft.com/en-us/powershell/module/powershellget#powershellget)

### 3.2 Install

1. Download this repository and build.
2. Run **Publish-Module.ps1** in the output-directory (bin\Release).
3. Enter the NuGetApiKey if required and the name of the Repository or leave it blank to publish to "PSGallery". If you are testing with your local one, press enter for the NuGetApiKey parameter and enter "PowerShell-Laboratory" for the Repository parameter.

Then you can try to install the module:

    Install-Module "HansKindberg.Laboratory";

or save it:

    Save-Module -Name "HansKindberg.Laboratory" -Path "C:\Data\Saved-PowerShell-Modules";

To uninstall the module:

    Uninstall-Module "HansKindberg.Laboratory";

### 3.3 Other

To see if anything is installed from your local "PowerShell-Repository":

	Find-Module -Repository "PowerShell-Laboratory"

The files in [.powershell-repository](/.powershell-repository):

- [ReadMe.md](/.powershell-repository/ReadMe.md)
- [Register.ps1](/.powershell-repository/Register.ps1)
- [Unregister.ps1](/.powershell-repository/Unregister.ps1)

give warnings but it seem to work anyhow.

## 4 Links

- [Testing PowerShell cmdlets written in C#](https://pawelszczygielski.pl/2021/05/06/testing-powershell-cmdlets-written-in-c)
- [PowerShell Cmdlet tests](https://github.com/deadlydog/PowerShellCmdletInCSharpExample)
- [PowerShell testing in C#](https://gist.github.com/DigitalAXPP/935255e8ec984f3e24245386f491bcf1)
- [PowerShell Cmdlet Development in C# - The Ins and Outs](https://www.pluralsight.com/courses/powershell-cmdlet-development-csharp)
- [Invoke-Command does not raise Verbose/Debug/Warning Stream events from Microsoft.PowerShell.SDK 7.x #14843](https://github.com/PowerShell/PowerShell/issues/14843)
- [System.Management.Automation.Cmdlet](https://github.com/PowerShell/PowerShell/blob/master/src/System.Management.Automation/engine/cmdlet.cs)

## 5 Temporary

StrongName.Development.snk:PublicKey = 00240000048000009400000006020000002400005253413100040000010001009d1016571e63e70ba6bdedf4cc5bb13ac3776f9b319d05aba58eca8dbb082124a0b169ed593a445e5b98cc1c37b9015ebc4846051347575d1ea086f91f27e14f46a0a9acaa80244ff1091358d3db024af3079e168725eeaade7eb60363e98df661c13bcbcf32cab1efccf76918a8addd89708ce2718f6826f696592315280bdd