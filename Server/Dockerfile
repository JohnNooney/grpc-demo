FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR ./Server

# Copy everything
COPY . ./

# Restore as distinct layers
RUN dotnet restore
# Build and publish a release
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /Server
COPY --from=build-env /Server/out .

# Set environment variable for gRPC server port
ENV ASPNETCORE_URLS="https://+;http://+"
ENV ASPNETCORE_HTTPS_PORTS=5001
ENV ASPNETCORE_ENVIRONMENT="Development"
ENV ASPNETCORE_Kestrel__Certificates__Default__Password="CRED_PLACEHOLDER"
ENV ASPNETCORE_Kestrel__Certificates__Default__Path=/https/localhost.pfx

# Expose the gRPC server port
EXPOSE 443
EXPOSE 80

ENTRYPOINT ["dotnet","Server.dll"]