# Imagem base com SDK do .NET 6.0
# Dockerfile padrão gerado pelo VS2022 não funciona!

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src

# Copia arquivo do projeto e restaura dependências
COPY ["src/B3Test.Worker/B3Test.Worker.csproj", "src/B3Test.Worker/"]
RUN dotnet restore "src/B3Test.Worker/B3Test.Worker.csproj"

# Copia os arquivos do projeto e compila o código
COPY . .
WORKDIR "/src/src/B3Test.Worker"
RUN dotnet build "B3Test.Worker.csproj" -c Release -o /app/build

# Publica o projeto em uma imagem separada para garantir que os frameworks sejam incluídos
FROM build AS publish
RUN dotnet publish "B3Test.Worker.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Imagem de tempo de execução do .NET 6.0
FROM mcr.microsoft.com/dotnet/runtime:6.0 AS final
WORKDIR /app

# Copia os arquivos publicados do projeto para a imagem final
COPY --from=publish /app/publish .

# Define o ponto de entrada do aplicativo
ENTRYPOINT ["dotnet", "B3Test.Worker.dll"]