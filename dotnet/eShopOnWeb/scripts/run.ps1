Set-Location -Path "C:\Users\Administrator\Desktop\eShopOnWeb\src\Web"
$env:UseOnlyInMemoryDatabase = "true"
$env:RedisServerUrl = "localhost:6379"
$filePath = Join-Path 'C:\Users\Administrator' 'sandbox-process.xml'
if (Test-Path -Path $filePath -PathType Leaf) {
  $prev = Import-Clixml -Path $filePath
  $prev | Stop-Process -ErrorAction SilentlyContinue
}
$process = Start-Process "dotnet" -ArgumentList "run --launch-profile Web" -PassThru
$process | Export-Clixml -Path $filePath
Wait-Process -Id $process.Id
