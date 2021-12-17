FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app
#EXPOSE 5000

#ENV ASPNETCORE_URLS=http://+:5000

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["LocationDetailsAPI.csproj", "./"]
RUN dotnet restore "LocationDetailsAPI.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "LocationDetailsAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LocationDetailsAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LocationDetailsAPI.dll"]
