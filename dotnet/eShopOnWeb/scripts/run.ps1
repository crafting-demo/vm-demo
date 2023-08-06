Set-Location -Path "C:\Users\Administrator\eShopOnWeb\src\Web"
$env:UseOnlyInMemoryDatabase = "true"
$env:RedisServerUrl = "localhost:6379"
dotnet run --launch-profile Web
