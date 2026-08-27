FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["GymHomie.BFF.Web/GymHomie.BFF.Web.csproj", "GymHomie.BFF.Web/"]
RUN dotnet restore "GymHomie.BFF.Web/GymHomie.BFF.Web.csproj"
COPY . .
WORKDIR "/src/GymHomie.BFF.Web"
RUN dotnet build "GymHomie.BFF.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GymHomie.BFF.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GymHomie.BFF.Web.dll"]