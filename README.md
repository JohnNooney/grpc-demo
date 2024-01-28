# grpc-demo
Welcome to the gRPC Demo application! This project showcases a simple interaction between a C# client and server, where the client sends a shape and its dimensions to the server, and the server responds with the calculated area of that shape. Additionally, the project includes Infrastructure as Code (IaC) and documentation for setting up Jenkins pipelines for both the client and server, as well as deploying the server to Google Cloud Platform (GCP).

## Sample Server and Client I/O
Client:
```
Enter the shape type: square 
Enter the primary dimension: 5

Certificate not specified. Proceeding with default configuration. 
Sending shape to server to calculate area... 

square has an area of: 25
```

Server:
```
Building...
info: Microsoft.Hosting.Lifetime[14]
      Now listening on: http://localhost:5001
info: Microsoft.Hosting.Lifetime[0]
      Application started. Press Ctrl+C to shut down.
info: Microsoft.Hosting.Lifetime[0]
      Hosting environment: Development
info: Microsoft.Hosting.Lifetime[0]
      Content root path: ~\grpc-demo\Server
info: Microsoft.AspNetCore.Hosting.Diagnostics[1]
      Request starting HTTP/2 POST http://localhost:5001/shapes.AreaCalculator/CalculateArea - application/grpc -
info: Microsoft.AspNetCore.Routing.EndpointMiddleware[0]
      Executing endpoint 'gRPC - /shapes.AreaCalculator/CalculateArea'
info: Microsoft.AspNetCore.Routing.EndpointMiddleware[1]
      Executed endpoint 'gRPC - /shapes.AreaCalculator/CalculateArea'
info: Microsoft.AspNetCore.Hosting.Diagnostics[2]
      Request finished HTTP/2 POST http://localhost:5001/shapes.AreaCalculator/CalculateArea - 200 - application/grpc 84.3018ms   
```

# Project Scope

- The server application supports one Protocol Buffer: Shapes, demonstrating a straightforward interaction.
- The client application utilizes the Shapes Protocol Buffer and features a user-friendly input mechanism.
- Jenkins pipelines automate the building of both server and client, generating Docker images as build artifacts.
- Another Jenkins pipeline deploys the Docker server to a GCP-hosted Kubernetes Engine (GKE) cluster using Terraform and Helm configurations.
- The GKE cluster is a single-node setup with a Helm-deployed pod, service, and ingress.


# Application Architecture
<img width="774" alt="image" src="https://github.com/JohnNooney/grpc-demo/assets/71711553/2b2e4e06-df41-42e1-a3c7-a8dc592b0f65">


*NOTE: At the moment this application only supports the C# Client. The Python client is shown here to demonstrate the extensibiility option of this project.*

# Repository Structure
This repository is organized as a mono-repo, with each folder containing relevant code and READMEs:
- [Client](./Client/) - gRPC Client source code
- [Server](./Server/) - gRPC Server source code
- [IaC](./IaC/) - Terraform and Helm deployment configurations (including GCP deployment instructions)
- [Jenkins](./Jenkins/) - Jenkins deployment configurations and setup
- [Docs](./Docs) - Diagrams of the project pipeline and architecture


# Dev Setup
To run code locally in Visual Studio
- [Visual Studio Code](https://code.visualstudio.com/download)
- [C# for Visual Studio Code (latest version)](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp)
- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)


To run the deployment pipeline you will need a GCP account and project to deploy to. Follow the steps outlined in [GCP Setup](#gcp-setup) and [Jenkins - First Time Setup](./Jenkins/README.md#first-time-setup)

# GCP Setup
## Create a GCP Account and Project
1. Visit the [Google Cloud Console](https://console.cloud.google.com/).
2. Follow the prompts to create a new GCP account if you don't have one.
3. Create a new GCP project for the application.
   - **NOTE:** A new GCP user will have $200 to use which should be more than enough for this sample project. 

## Configure GCP Authentication
1. Generate service account credentials with the necessary permissions to interact with GCP services.
2. Download the JSON key file for the service account. This will be used for the Jenkins pipeline setup. See [Jenkins - Credentials - GCP](./Jenkins/README.md#gcp)


## Enable APIs
### GKE
1. In the GCP Console, navigate to the API & Services > Dashboard.
2. Search for and enable the Kubernetes Engine API


## Deployment
- Follow the steps in [IaC](./IaC/README.md)


# Future Improvements
- HTTPs communication so Server and Client services can communicate securely.
- Introduce an Ansible vault to store secrets
- Add a domain to the Server for accessability and CA signed certificates
- Add more Client applications written in different languages to demonstrate the adapability of grpc



