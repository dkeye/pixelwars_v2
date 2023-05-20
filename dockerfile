# syntax=docker/dockerfile:1

FROM mcr.microsoft.com/dotnet/sdk:7.0 as build-env
WORKDIR /BackendWebAPI
COPY BackendWebAPI/*.csproj .
RUN dotnet restore
COPY BackendWebAPI .
RUN dotnet publish -c Release -o /publish

FROM mcr.microsoft.com/dotnet/aspnet:7.0 as runtime
WORKDIR /publish
COPY --from=build-env /publish .
EXPOSE 80
ENTRYPOINT ["dotnet", "BackendWebAPI.dll"]