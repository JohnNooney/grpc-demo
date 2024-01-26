# Overview
TBD

# Local Dev Setup Pre-Req
To run code locally in Visual Studio
- [Visual Studio Code](https://code.visualstudio.com/download)
- [C# for Visual Studio Code (latest version)](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp)
- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)

## Running the Client
Open a terminal window at the root of the repo and run this command:
```
code -r Client
```
This will open a window of the Server in its own project space

Build the client with this command
```
dotnet build
```

Start the client with this command
```
dotnet start
```

# Deployment
## Client
Create the development certificates (if not already done in the [Deployment - Server](../Server/README.md#deployment) steps)
```
dotnet dev-certs https -ep ${HOME}/.aspnet/https/localhost.pfx -p <password>
```

Build the Docker image with the below command
```
docker build -t my-grpc-client:1 . 
```

Create and start the Docker image with the below command (make sure to use the same password from the created dev certificate)
```
docker run -it --name grpc-client -e GRPC_SERVER_ADDRESS="https://grpc-server" -e CERT_PASS=<password> -v ${HOME}/.aspnet/https:/https/ my-grpc-client:1
```

# Deployment Clean Up
Stop and remove docker container
```
docker rm -f grpc-client
```

Delete Image
```
docker rmi grpc-client
```

Delete dotnet dev certs
```
dotnet dev-certs https --clean
```

