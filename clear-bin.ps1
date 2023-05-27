Write-Host "remove bin,obj..."
Get-ChildItem .\ -include bin,obj -Recurse | foreach ($_) { remove-item $_.fullname -Force -Recurse }
Write-Host "remove completed."