# Utilizar la imagen base de SDK de .NET para compilar el proyecto
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Copiar los csproj y restaurar las dependencias
COPY *.sln .
COPY ./Holcim.Application/*.csproj ./Holcim.Application/
COPY ./Holcim.Domain/*.csproj ./Holcim.Domain/
COPY ./Holcim.Persistence/*.csproj ./Holcim.Persistence/
COPY ./Holcim.External/*.csproj ./Holcim.External/
COPY ./Holcim/*.csproj ./Holcim/

RUN dotnet restore

# Copiar el resto de los archivos y construir la aplicación
COPY . ./

# Publicar la aplicación
RUN dotnet publish Holcim -c Release -o out

# Generar la imagen de runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/out .

# Definir el punto de entrada de la aplicación
ENTRYPOINT ["dotnet", "Holcim.dll"]