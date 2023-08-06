# Change the working directory to your project folder
Set-Location -Path "C:\Users\Administrator\Desktop\eShopOnWeb\src\Web"
dotnet build
dotnet dev-certs https -v
