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
Create the development certificates to enable SSL from the container
```
dotnet dev-certs https -ep ${HOME}/.aspnet/https/localhost.pfx -p <password>
```
- NOTE: If you want to connect a non-docker Client to the Docker Server, you will need to install this certificate locally as well. 

Build the Docker image with the below command
```
docker build -t mygrpcserver:1 . 
```

Create and start the Docker image with the below command (make sure to use the same password from the created dev certificate)
```
docker run -rm --name grpcserver -p 8000:80 5001:443 -e ASPNETCORE_Kestrel__Certificates__Default__Password=<password> -v ${HOME}/.aspnet/https:/https/ mygrpcserver:1
```


