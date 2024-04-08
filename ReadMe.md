# PowerShell-Laboratory

PowerShell commands for laboration. A portable module that can run on Linux, Mac-OS and Windows. A PowerShell library for testing things. It may change without notice.

[![PowerShell Gallery](https://img.shields.io/powershellgallery/v/HansKindberg.Laboratory.svg?label=PowerShell%20Gallery)](https://www.powershellgallery.com/packages/HansKindberg.Laboratory)

## 1 Commands

### 1.1 Show-LaboratoryInformation

    Show-LaboratoryInformation `
        -Value "Some value";

### 1.2 Show-LoggingInformation

    Show-LoggingInformation;

### 1.3 Common parameters

- Debug (db)
- ErrorAction (ea)
- ErrorVariable (ev)
- InformationAction (infa)
- InformationVariable (iv)
- OutVariable (ov)
- OutBuffer (ob)
- PipelineVariable (pv)
- ProgressAction (proga)
- Verbose (vb)
- WarningAction (wa)
- WarningVariable (wv)

#### 1.3.1 Risk mitigation parameters

- Confirm (cf)
- WhatIf (wi)

#### 1.3.1 Display all logs without prompts

	Show-LaboratoryInformation `
		-Confirm `
		-Debug `
		-ErrorAction Continue `
		-InformationAction Continue `
		-Verbose `
		-WarningAction Continue `
        -Value "Some value";

or

	Show-LoggingInformation `
		-Confirm `
		-Debug `
		-ErrorAction Continue `
		-InformationAction Continue `
		-Verbose `
		-WarningAction Continue;

#### 1.3.2 Links

- [about_CommonParameters](https://learn.microsoft.com/en-us/powershell/module/microsoft.powershell.core/about/about_commonparameters)

## 2 Development

### 2.1 Signing

Drop the "StrongName.snk" file in the repository-root. The file should not be included in source control.

### 2.2 Build warnings

At the moment we get the following warning:

- [NETSDK1206](https://learn.microsoft.com/en-us/dotnet/core/tools/sdk-errors/netsdk1206)

Haven't investigated it further.

## 3 Tests

### 3.1 Links

- Google: [icommandruntime powershell testing](https://www.google.com/search?q=icommandruntime+powershell+testing)
- [Unit Testing Powershell Cmdlets in C#](https://fgimian.github.io/unit-testing-powershell-cmdlets-in-c-sharp/)
- [Testing PowerShell cmdlets written in C#](https://pawelszczygielski.pl/2021/05/06/testing-powershell-cmdlets-written-in-c)
- [PowerShell Cmdlet tests](https://github.com/deadlydog/PowerShellCmdletInCSharpExample)
- [PowerShell testing in C#](https://gist.github.com/DigitalAXPP/935255e8ec984f3e24245386f491bcf1)

## 4 Deployment/installation

### 4.1 PowerShell-Gallery

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

### 4.2 Install

1. Download this repository and build.
2. Run **Publish-Module.ps1** in the output-directory (bin\Release).
3. Enter the NuGetApiKey if required and the name of the Repository or leave it blank to publish to "PSGallery". If you are testing with your local one, press enter for the NuGetApiKey parameter and enter "PowerShell-Laboratory" for the Repository parameter.

Then you can try to install the module:

    Install-Module "HansKindberg.Laboratory";

or (local)

	Install-Module "HansKindberg.Laboratory" -Repository "PowerShell-Laboratory";

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

## 5 Links

- [PowerShell Cmdlet Development in C# - The Ins and Outs](https://www.pluralsight.com/courses/powershell-cmdlet-development-csharp)
- [Invoke-Command does not raise Verbose/Debug/Warning Stream events from Microsoft.PowerShell.SDK 7.x #14843](https://github.com/PowerShell/PowerShell/issues/14843)
- [System.Management.Automation.Cmdlet](https://github.com/PowerShell/PowerShell/blob/master/src/System.Management.Automation/engine/cmdlet.cs)