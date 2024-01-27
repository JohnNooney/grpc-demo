# Overview
This folder contains all the CI/CD IaC related to deploying the gRPC Demo application. It contains:
- Dockerfile and startup script for deploying the Jenkins pipeline
- Instructions below on what post-deployment configurations/setup are required


The Client and Server build pipelines are seen below:
<img width="506" alt="image" src="https://github.com/JohnNooney/grpc-demo/assets/71711553/d982bfdc-0e2a-43bf-8832-ab2849d1dfc4">



The Terraform deployment build pipeline can be seen below:
<img width="651" alt="image" src="https://github.com/JohnNooney/grpc-demo/assets/71711553/9ed0379d-ffc3-4708-9827-d020acc4091b">



# Pre-requisite
- [Docker](https://docs.docker.com/engine/install/)

# Deployment
Run the batch file to startup the container
```
./StartJenkins.bat
```

## First Time Setup
Upon first starting up you will need to configure an Admin user and the necessary plugins to build the gRPC projects.

### Admin
1. Navigate to the deployed Jenkins web portal: http://localhost:8080/
2. To unlock Jenkins use the below command to find the default password:
```
docker exec -it jenkins-blueocean cat  /var/lib/jenkins/secrets/initialAdminPassword
```
3. Follow the steps to install the 'Install suggested plugins' on Jenkins
4. Setup the Admin user with your credentials

### Plugins
5. Navigate to Manage Jenkins > Plugins > Available plugins
6. Search and download **MSBuild Plugin**, **Terraform Plugin**, **GCP Secrets Manager Credentials Provider**, **Google Kubernetes Engine**, and **.NET SDK Support**
7. Navigate to Manage Jenkins > Tools > .NET SDK installations and use the following SDK configurations:
    - Name: .NET 8
    - .NET Version: .NET 8.0
    - Release: 8.0.1
    - SDK: 8.0.101
    - Platform: linux-x64 (Linux -x64)
8. Save and Apply changes
9. Navigate to Manage Jenkins > Tools > Terraform and add the following Terraform configuration:
   - Name: Terraform
   - Install automatically
     - Version: Terraform 1.7.1 linux (Match your processor. I was: `amd64`)
10. Restart the Jenkins container for changes to take effect:
```
docker restart jenkins-blueocean
```

### Credentials
#### GitHub
1. Navigate to Manage Jenkins > Credentials
2. Select System Store > Global credentials (unrestricted)
3. Add Credentials and configure with:
    - Username: `Your_Github_Username`
    - Password: `Your_Github_Password`
    - ID: `github-credentials`
    - Description: Jenkins GitHub Credentials
4. Create

#### Docker
1. Navigate to Manage Jenkins > Credentials
2. Select System Store > Global credentials (unrestricted)
3. Add Credentials and configure with:
    - Username: `Your_Docker_Username`
    - Password: `Your_Docker_Password`
    - ID: `docker-hub-credentials`
    - Description: Jenkins DockerHub Credentials
4. Create

#### GCP
**Pre-requisite**
You will need to have a GCP account with a project and Service Account key exported.

Create the Jenkins service account and grant source and GKE roles to it. In the GCP console web app > Activate Cloud Shell and run the below commands:
```
export SA=jenkins-sa
export SA_EMAIL=${SA}@${PROJECT_ID}.iam.gserviceaccount.com

gcloud iam service-accounts create $SA

gcloud projects add-iam-policy-binding $PROJECT_ID --member serviceAccount:$SA_EMAIL  --role roles/source.writer

gcloud projects add-iam-policy-binding $PROJECT_ID --member serviceAccount:$SA_EMAIL --role roles/container.developer
```

Create and download the JSON service account key
```
  gcloud iam service-accounts keys create ~/jenkins-gke-key.json --iam-account $SA_EMAIL
```
**Create Jenkins Credential**
1. Navigate to Manage Jenkins > Credentials
2. Select System Store > Global credentials (unrestricted)
3. Add Credentials and configure with:
    - Kind: Google Service Account from private key
    - ID: `grpc-google-sa`
    - Description: GCP Service Account private key
    - Project Name: your-project-name (see steps done in [GCP Setup](../README.md#gcp-setup))
    - JSON key file: (upload your download key from [GCP Setup](../README.md#gcp-setup))
4. Create

### Pipeline Setup
#### Server
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
        - Branch Specified: */main
    - Script Path: Server/Jenkinsfile
3. Save

#### Client
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
        - Branch Specified: */main
    - Script Path: Client/Jenkinsfile
3. Save

#### Terraform
1. From the Dashboard create a New item
2. Select Pipeline and use the following configurations:
    - Description: Pipeline for the Terraform deployment
    - Discard old builds with Max # of builds to keep: 5
    - Do not allow concurrent builds
    - Pipeline:
      - Definition: Pipeline script from SCM
      - SCM: Git
      - Repositories:
        - Repository URL: https://github.com/JohnNooney/grpc-demo.git
        - Credentials: Jenkins Git Credentials
      - Branches to build:
        - Branch Specified: */main
    - Script Path: IaC/Jenkinsfile
3. Save

# Teardown
Run the below commands to completely teardown your Jenkins deployment and remove any resources:
```
docker rm -f jenkins-blueocean
docker rm - jenkins-docker
docker rmi myjenkins-blueocean
docker rmi docker:dind
docker volume rm jenkins-data 
docker volume rm jenkins-docker-certs
docker network rm jenkins
```

# Resources 
- https://cloud.google.com/kubernetes-engine/docs/archive/continuous-delivery-jenkins-kubernetes-engine
