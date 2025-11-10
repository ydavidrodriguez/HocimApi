# Utilizar la imagen base de SDK de .NET para compilar el proyecto
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Copiar los csproj y restaurar las dependencias
COPY *.sln .
COPY ./Holcim.AuctionService.Api/*.csproj ./Holcim.AuctionService.Api/
COPY ./Holcim.AuctionService.Application/*.csproj ./Holcim.AuctionService.Application/
COPY ./Holcim.AuctionService.Domain/*.csproj ./Holcim.AuctionService.Domain/
COPY ./Holcim.AuctionService.External/*.csproj ./Holcim.AuctionService.External/
COPY ./Holcim.AuctionService.Persistence/*.csproj ./Holcim.AuctionService.Persistence/

RUN dotnet restore

# Copiar el resto de los archivos y construir la aplicación
COPY . ./

# Publicar la aplicación
RUN dotnet publish Holcim.AuctionService.Api -c Release -o out

# Generar la imagen de runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/out .

# Definir el punto de entrada de la aplicación
ENTRYPOINT ["dotnet", "Holcim.AuctionService.Api.dll"]