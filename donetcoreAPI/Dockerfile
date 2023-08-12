#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["donetcoreAPI/appsettings.json", "donetcoreAPI/"] 
COPY [".learningtransport/", ".learningtransport/"] 
COPY ["donetcoreAPI/donetcoreAPI.csproj", "donetcoreAPI/"] 
COPY ["BusinessLayer/CommandLayer.csproj", "BusinessLayer/"]
COPY ["DataLayer/DataLayer.csproj", "DataLayer/"] 
RUN dotnet restore "donetcoreAPI/donetcoreAPI.csproj"
COPY . .
RUN dotnet publish -c Release -o /publish

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS runtimeimage
WORKDIR /publish
COPY --from=build /publish .
EXPOSE 80
EXPOSE 5001
EXPOSE 443
ENTRYPOINT ["dotnet", "donetcoreAPI.dll"]