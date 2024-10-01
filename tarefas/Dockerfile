# Etapa base - para execução da aplicação
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5174

# Etapa de build - para compilar o projeto
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

# Copia o arquivo de projeto e restaura as dependências
COPY ["tarefas.csproj", "./"]  
# Copia o tarefas.csproj para a raiz de /src
RUN dotnet restore "./tarefas.csproj"

# Copia o restante dos arquivos e constrói o projeto
COPY . .  
# Copia todo o restante do código para o diretório de build
RUN dotnet build "tarefas.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Etapa de publicação - prepara os arquivos de execução
FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "tarefas.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Etapa final - copia os arquivos publicados para o container final e define o ponto de entrada
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "./tarefas.dll"]