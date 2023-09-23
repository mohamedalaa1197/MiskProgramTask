FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["MiskProgramTask/MiskProgramTask.csproj", "MiskProgramTask/"]
RUN dotnet restore "MiskProgramTask/MiskProgramTask.csproj"
COPY . .
WORKDIR "/src/MiskProgramTask"
RUN dotnet build "MiskProgramTask.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MiskProgramTask.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MiskProgramTask.dll"]
