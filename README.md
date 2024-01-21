# grpc-demo
gRPC Demo Application with a C# client and server


# Pre-Req
To run in Visual Studio
- [Visual Studio Code](https://code.visualstudio.com/download)
- [C# for Visual Studio Code (latest version)](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp)
- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)

## Running the Server

Open a terminal window at the root of the repo and run this command:
```
code -r Server
```
This will open a window of the Server in its own project space


For running the server the first time, you will need to trust the HTTPS development certificate. Run this command:
```
dotnet dev-certs https --trust
```
- Select Yes to trust the development certificate.

Build the server with this command
```
dotnet build
```

Start the server with this command
```
dotnet start
```

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
## Server
Build the Docker image with the below command
```
docker build -t mygrpcserver:1 .  
```

Create and start the Docker image with the below command
```
docker start --name grpcserver mygrpcserver:1 -p 8080:8080 -it
```


