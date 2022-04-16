FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/KubeDog/KubeDog.csproj", "KubeDog/"]
RUN dotnet restore "KubeDog/KubeDog.csproj"
COPY . .
WORKDIR "/src/KubeDog"
RUN dotnet build "KubeDog.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "KubeDog.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "KubeDog.dll"]

ENV ASPNETCORE_URLS=http://+:80