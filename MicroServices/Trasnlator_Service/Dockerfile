# Utilizar la imagen base de SDK de .NET para compilar el proyecto
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Copiar los csproj y restaurar las dependencias
COPY *.sln .
COPY ./Holcim.Translate.Application/*.csproj ./Holcim.Translate.Application/
COPY ./Holcim.Translate.Domain/*.csproj ./Holcim.Translate.Domain/
COPY ./Holcim.Translate.Persistence/*.csproj ./Holcim.Translate.Persistence/
COPY ./Holcim.Translate.External/*.csproj ./Holcim.Translate.External/
COPY ./Holcim.Translate.Api/*.csproj ./Holcim.Translate.Api/

RUN dotnet restore

# Copiar el resto de los archivos y construir la aplicación
COPY . ./

# Publicar la aplicación
RUN dotnet publish Holcim.Translate.Api -c Release -o out

# Generar la imagen de runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/out .

# Definir el punto de entrada de la aplicación
ENTRYPOINT ["dotnet", "Holcim.Translate.Api.dll"]

