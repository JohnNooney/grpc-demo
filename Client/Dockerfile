FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR ./Client

# Copy everything
COPY . ./
# Restore as distinct layers
RUN dotnet restore
# Build and publish a release
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /Client
COPY --from=build-env /Client/out .

ENV CERT_PASS="CRED_PLACEHOLDER"
ENV CERT_PATH=/https/
ENV CERT_FILE=localhost.pfx
ENV GRPC_SERVER_ADDRESS="https://your-grpc-server-address"

EXPOSE 80
EXPOSE 443

ENTRYPOINT ["dotnet", "Client.dll"]