FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

WORKDIR /app

COPY ./ ./
RUN dotnet restore words.csproj

COPY . ./
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /app/out .
ENV ASPNETCORE_URLS=http://+:7002
ENTRYPOINT ["dotnet", "words.dll"]
