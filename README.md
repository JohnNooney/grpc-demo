# grpc-demo
gRPC Demo Application with a C# client and server. The applications themselves are a simple interaction. The Client makes a request to the Server with the name of a shape and a give dimension. The Server responds with the area of that shape. Based on the shape, different area calculations are made. 

In addition to the Client and Server applications, this project includes the Infrastructure as Code and documentation required to setup:
- a Jenkins pipeline for the Client
- a Jenkins pipeline for the  Server
- a Jenkins pipeline for deploying the Server to GCP
  - Terraform configuration for a GKE cluster that exposes the Server through a GLB

**Scope**

TBD


**Objectives**

TBD

# Repository Structure
This repository is structured as a mono-repo. In each folder at the root level you can find the relevant code and READMEs.
- Client
- Server
- IaC 
- Jenkins


# Dev Pre-Req
To run code locally in Visual Studio
- [Visual Studio Code](https://code.visualstudio.com/download)
- [C# for Visual Studio Code (latest version)](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp)
- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)


To run the deployment pipeline you will need a GCP account and project to deploy to. Follow the steps mentioned here - [GCP Setup](#gcp-setup)

# GCP Setup




