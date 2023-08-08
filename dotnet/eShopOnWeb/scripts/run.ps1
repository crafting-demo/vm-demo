Set-Location -Path "C:\Users\Administrator\Desktop\eShopOnWeb\src\Web"
$env:UseOnlyInMemoryDatabase = "true"
$env:RedisServerUrl = "localhost:6379"
$prev = Import-Clixml -Path (Join-Path $ENV:temp 'sandbox-process.xml')
$prev | Stop-Process -ErrorAction SilentlyContinue
$process = Start-Process "dotnet" -ArgumentList "run --launch-profile Web" -PassThru
$process | Export-Clixml -Path (Join-Path $ENV:temp 'sandbox-process.xml')
Wait-Process -Id $process.Id
