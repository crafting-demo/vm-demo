Set-Location -Path "C:\Users\Administrator\vm-demo\dotnet\eShopOnWeb\src\Web"
$env:UseOnlyInMemoryDatabase = "true"
$env:RedisServerUrl = "localhost:6379"
dotnet run --launch-profile Web
