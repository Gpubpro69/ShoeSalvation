FROM mcr.microsoft.com/dotnet/sdk:9.0 AS dev
WORKDIR /app
COPY . .
RUN dotnet restore
CMD ["dotnet", "watch", "--project", "src/ShoeSalvation.API", "run", "--urls", "http://+:8080"]
