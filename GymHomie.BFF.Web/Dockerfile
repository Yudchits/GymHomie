FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["GymHomie.BFF.Web/GymHomie.BFF.Web.csproj", "GymHomie.BFF.Web/"]
COPY ["GymHomie.TrainingPlan.Application/GymHomie.TrainingPlan.Application.csproj", "GymHomie.TrainingPlan.Application/"]
COPY ["GymHomie.TrainingPlan.Domain/GymHomie.TrainingPlan.Domain.csproj", "GymHomie.TrainingPlan.Domain/"]
COPY ["GymHomie.TrainingPlan.Data/GymHomie.TrainingPlan.Data.csproj", "GymHomie.TrainingPlan.Data/"]
COPY ["GymHomie.Domain.Core/GymHomie.Domain.Core.csproj", "GymHomie.Domain.Core/"]
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
