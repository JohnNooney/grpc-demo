# Overview
This Terraform configuration will provision the following:
- VPC and subnet
- GKE cluster and separately managed node pool
- A service account and RBAC service rule for the Kubernetes dashboard 
  - (this is optional since GCP has its own implementation of the dashboard)
- The gRPC Server Application and a load balancer

## Architecture
See the below diagram of the deployed architecture:
<img width="534" alt="image" src="https://github.com/JohnNooney/grpc-demo/assets/71711553/069acf77-a5b1-4589-b0fc-e783f9c54cec">


# Deployment
### Manual
Login to the GCP Console and activate the Cloud Shell


Upload the `./IaC` directory to your cloud instance


Change directories to the Terraform configuration
```
cd ./IaC/Terraform
```


Initialize terraform
```
terraform init
```


Update the `terraform.tfvars` with your project ID
```
vi terraform.tfvars
```


Apply the configuration
```
terraform apply
```

### Automated
To have an automated deployment please follow the steps outlined in [Jenkins](../../Jenkins/README.md) for creating the Terraform Build pipeline. 


# Manual Teardown
After creating a deployment you can run the below command in the GCP Cloud Shell to delete all provisioned resources
```
terraform destroy
```

# Resources
This terraform chart is based off the hashicorp base GKE configuration
- https://github.com/hashicorp/learn-terraform-provision-gke-cluster
- https://developer.hashicorp.com/terraform/tutorials/kubernetes/gke#optional-configure-terraform-kubernetes-provider
