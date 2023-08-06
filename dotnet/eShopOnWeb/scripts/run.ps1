Set-Location -Path "C:\Users\Administrator\Desktop\eShopOnWeb\src\Web"
$env:UseOnlyInMemoryDatabase = "true"
$env:RedisServerUrl = "localhost:6379"
dotnet run --launch-profile Web
