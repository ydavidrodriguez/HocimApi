# Utilizar la imagen base de SDK de .NET para compilar el proyecto
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Copiar los csproj y restaurar las dependencias
COPY *.sln .
COPY ./Holcim.Provider.Application/*.csproj ./Holcim.Provider.Application/
COPY ./Holcim.Provider.Domain/*.csproj ./Holcim.Provider.Domain/
COPY ./Holcim.Provider.Persistence/*.csproj ./Holcim.Provider.Persistence/
COPY ./Holcim.Provider.External/*.csproj ./Holcim.Provider.External/
COPY ./Holcim.Provider.Api/*.csproj ./Holcim.Provider.Api/

RUN dotnet restore

# Copiar el resto de los archivos y construir la aplicación
COPY . ./

# Publicar la aplicación
RUN dotnet publish Holcim.Provider.Api -c Release -o out

# Generar la imagen de runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/out .


# Definir el punto de entrada de la aplicación
ENTRYPOINT ["dotnet", "Holcim.Provider.Api.dll"]