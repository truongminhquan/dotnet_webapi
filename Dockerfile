FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build-env
WORKDIR /app

# Copy csproj and restore
COPY *.csproj ./
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# Generate runtime image
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
EXPOSE 80
COPY --from=build-env /app/out .

COPY ./https /https
RUN apt update
RUN apt install -y curl


ARG ENVIRONMENT="Development"
ARG PASSWORD_CERT

ENV ASPNETCORE_ENVIRONMENT=$ENVIRONMENT
ENV ConnectionStrings__DefaultConnection="Server=ms-sql-server,1433;Initial Catalog=WeatherForecastDB_Stage;User ID=SA;Password=Super_Password_99;"
ENV ASPNETCORE_URLS=https://+:443;http://+:80
ENV ASPNETCORE_HTTPS_PORT=5001
ENV ASPNETCORE_Kestrel__Certificates__Default__Password=$PASSWORD_CERT
ENV ASPNETCORE_Kestrel__Certificates__Default__Path=/https/weatherapi.pfx
ENTRYPOINT ["dotnet", "weatherapi.dll"]