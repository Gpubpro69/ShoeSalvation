FROM mcr.microsoft.com/dotnet/sdk:9.0 AS dev
WORKDIR /app
COPY *.sln .
COPY src/ShoeSalvation.API/*.csproj ./src/ShoeSalvation.API/
COPY src/ShoeSalvation.Service/*.csproj ./src/ShoeSalvation.Service/
COPY src/ShoeSalvation.Repository/*.csproj ./src/ShoeSalvation.Repository/
COPY src/ShoeSalvation.Domain/*.csproj ./src/ShoeSalvation.Domain/
COPY src/ShoeSalvation.Tests/*.csproj ./src/ShoeSalvation.Tests/
RUN dotnet restore
COPY . .
RUN dotnet build --no-restore
CMD ["dotnet", "watch", "--project", "src/ShoeSalvation.API", "run", "--urls", "http://+:8080"]