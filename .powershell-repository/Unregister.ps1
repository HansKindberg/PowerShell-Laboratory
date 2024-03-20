Write-Host "Unregister-PSRepository -Name ""PowerShell-Laboratory""?";
Write-Host;
Write-Host "Confirm: [y/n]" -ForegroundColor Yellow -NoNewLine;
$confirmed = Read-Host;
Write-Host;
if($confirmed -eq "y") {
    Unregister-PSRepository -Name "PowerShell-Laboratory";
}
Write-Host "Press any key to exit..." -ForegroundColor Yellow -NoNewline:$true;
Read-Host;