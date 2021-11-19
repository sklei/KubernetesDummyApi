FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 5001
EXPOSE 5002

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY "KubernetesDummyApi.csproj" "./"
RUN dotnet restore "./KubernetesDummyApi.csproj"
COPY . .
WORKDIR "/src/."
RUN dotnet build "KubernetesDummyApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "KubernetesDummyApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /App
# ENV ASPNETCORE_ENVIRONMENT=Development
# ENV ASPNETCORE_URLS=http://+:5002
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "KubernetesDummyApi.dll"]