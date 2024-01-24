# Overview
This branch contains all the IaC (Infrastructure as Code) related to deploying the gRPC Demo application. It contains:
- Dockerfile and startup script for deploying the Jenkins pipeline
- Terraform files for the deployment of the gRPC Server into GCP

# How to Use
## Jenkins
### Pre-requisite
- [Docker](https://docs.docker.com/engine/install/)

### Deployment
Build the Docker image locally using
```
docker build -t myjenkins-blueocean:2.426.2-1 .
```

Run the batch file to startup the container
```
./StartJenkins.bat
```

### First Time Setup
Upon first starting up you will need to configure an Admin user and the necessary plugins to build the gRPC projects.

#### Admin
1. Navigate to the deployed Jenkins web portal: http://localhost:8080/
2. To unlock Jenkins use the below command to find the default password:
```
docker exec -it jenkins-blueocean cat  /var/lib/jenkins/secrets/initialAdminPassword
```
3. Follow the steps to install the 'Install suggested plugins' on Jenkins
4. Setup the Admin user with your credentials

#### Plugins
5. Navigate to Manage Jenkins > Plugins > Available plugins
6. Search and download MSBuild Plugin and .NET SDK Support
7. Navigate to Manage Jenkins > Tools > .NET SDK installations and use the following SDK configurations:
    - Name: .NET 8
    - .NET Version: .NET 8.0
    - Release: 8.0.1
    - SDK: 8.0.101
    - Platform: linux-x64 (Linux -x64)
8. Save and Apply changes
9.  Restart the Jenkins container for changes to take effect:
```
docker restart jenkins-blueocean
```

#### Credentials
**GitHub**
1. Navigate to Manage Jenkins > Credentials
2. Select System Store > Global credentials (unrestricted)
3. Add Credentials and configure with:
    - Username: `Your_Github_Username`
    - Password: `Your_Github_Password`
    - ID: `github-credentials`
    - Description: Jenkins GitHub Credentials
4. Create

**Docker**
1. Navigate to Manage Jenkins > Credentials
2. Select System Store > Global credentials (unrestricted)
3. Add Credentials and configure with:
    - Username: `Your_Docker_Username`
    - Password: `Your_Docker_Password`
    - ID: `docker-hub-credentials`
    - Description: Jenkins DockerHub Credentials
4. Create

#### Server Pipeline
1. From the Dashboard create a New item
2. Select Pipeline and use the following configurations:
    - Description: Pipeline for the gRPC Server
    - Discard old builds with Max # of builds to keep: 5
    - Do not allow concurrent builds
    - Pipeline:
      - Definition: Pipeline script from SCM
      - SCM: Git
      - Repositories:
        - Repository URL: https://github.com/JohnNooney/grpc-demo.git
        - Credentials: Jenkins Git Credentials
      - Branches to build:
        - Branch Specified: */shapes
    - Script Path: Server/Jenkinsfile
3. Save

#### Client Pipeline
1. From the Dashboard create a New item
2. Select Pipeline and use the following configurations:
    - Description: Pipeline for the gRPC Server
    - Discard old builds with Max # of builds to keep: 5
    - Do not allow concurrent builds
    - Pipeline:
      - Definition: Pipeline script from SCM
      - SCM: Git
      - Repositories:
        - Repository URL: https://github.com/JohnNooney/grpc-demo.git
        - Credentials: Jenkins Git Credentials
      - Branches to build:
        - Branch Specified: */shapes
    - Script Path: Client/Jenkinsfile
3. Save