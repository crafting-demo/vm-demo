# Change the working directory to your project folder
Set-Location -Path "C:\Users\Administrator\vm-demo\dotnet\eShopOnWeb\src\Web"
dotnet build
dotnet dev-certs https -v
