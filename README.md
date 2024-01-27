# grpc-demo
gRPC Demo Application with a C# client and server. The applications themselves are a simple interaction. The Client makes a request to the Server with the name of a shape and a give dimension. The Server responds with the area of that shape. Based on the shape, different area calculations are made. 

In addition to the Client and Server applications, this project includes the Infrastructure as Code and documentation required to setup:
- a Jenkins pipeline for the Client
- a Jenkins pipeline for the  Server
- a Jenkins pipeline for deploying the Server to GCP
  - Terraform configuration for a GKE cluster that exposes the Server through a GLB

**Scope**

- The Server application will only implement one Protocol Buffer: Shapes. This is was done so the project can demonstrate a simple interaction between a given Client and Server
- The Client application uses the Shapes Protocol Buffer and implements a user input mechanism
- Jenkins pipelines will build the server and client and produce a build artifact in the form of a Docker image
- A Jenkins pipeline will be responsible for deploying the Docker server to a simple GKE cluster through a Terraform and Helm configuration
- The GKE cluster will be a single node cluster containing a helm deployed pod, service, and ingress.


**Application Architecture**
See the below diagram for what the goal architecture is:
![Complete Project Architecture](./Docs/Complete-Architecture.drawio)
**NOTE:** At the moment this application only supports the C# Client. The Python client is shown here to demonstrate the extensibiility option of this project.

# Repository Structure
This repository is structured as a mono-repo. In each folder at the root level you can find the relevant code and READMEs.
- [Client](./Client/) - gRPC Client source code
- [Server](./Server/) - gRPC Server source code
- [IaC](./IaC/) - Terraform and Helm deployment configurations (with additional GCP setup instructions)
- [Jenkins](./Jenkins/) - Jenkins deployment configurations and setup
- [Docs](./Docs) - Diagrams of the project pipeline and architecture


# Dev Setup
To run code locally in Visual Studio
- [Visual Studio Code](https://code.visualstudio.com/download)
- [C# for Visual Studio Code (latest version)](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csharp)
- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)


To run the deployment pipeline you will need a GCP account and project to deploy to. Follow the steps mentioned here - [GCP Setup](#gcp-setup) and [Jenkins - First Time Setup](./Jenkins/README.md#first-time-setup)

# GCP Setup
### Create a GCP Account and Project
- Visit the Google Cloud Console.
- Follow the prompts to create a new GCP account if you don't have one.
- Create a new GCP project for the application.
- **NOTE:** A new GCP user will have $200 to use which should be more than enough for this sample project. 

### Configure GCP Authentication
- Generate service account credentials with the necessary permissions to interact with GCP services.
- Download the JSON key file for the service account. This will be used for the Jenkins pipeline setup. See [Jenkins - Credentials - GCP](./Jenkins/README.md#gcp)


### Enable APIs
#### GKE
- In the GCP Console, navigate to the API & Services > Dashboard.
- Search for and enable the Kubernetes Engine API


### Deployment
- Follow the steps here [IaC](./IaC/README.md)


# Future Improvements
- HTTPs communication so Server and Client services can communicate securely.
- Introduce an Ansible vault to store secrets
- Add a domain to the Server for accessability and CA signed certificates
- Add more Client applications written in different languages to demonstrate the adapability of grpc



