FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copiar os arquivos .csproj das classlibs e do projeto principal
COPY ["../tarefas/tarefas.csproj", "./tarefas/"]
COPY ["../Repository/Repository.csproj", "./Repository/"]
COPY ["../Services/Services.csproj", "./Services/"]

# Restaurar as dependências de todos os projetos
RUN dotnet restore "./tarefas/tarefas.csproj"

# Copiar o código do projeto para o container
COPY ../ .

# Compilar o projeto
RUN dotnet build "tarefas/tarefas.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "tarefas/tarefas.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "tarefas.dll"]
