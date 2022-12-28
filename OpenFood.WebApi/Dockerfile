FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
WORKDIR /App
    
COPY . .

RUN dotnet restore OpenFood.WebApi/FoodScrapper.WebApi.csproj
RUN dotnet publish OpenFood.WebApi/FoodScrapper.WebApi.csproj -c Release -o out 
   
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /App
COPY --from=build-env /App/out .
EXPOSE 80
ENTRYPOINT ["dotnet", "FoodScrapper.WebApi.dll"]