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


Then you will need to trust the HTTPS development certificate. Run this command:
```
dotnet dev-certs https --trust
```
- Select Yes to trust the development certificate.


Press `Ctrl+F5` to run without the debugger

## Running the Client
Open a terminal window at the root of the repo and run this command:
```
code -r Client
```
This will open a window of the Server in its own project space


Press `Ctrl+F5` to run without the debugger


