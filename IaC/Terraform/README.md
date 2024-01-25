# Overview
This Terraform configuration will provision the following:
- VPC and subnet
- GKE cluster and separately managed node pool
- A service account and RBAC service rule for the Kubernetes dashboard 
  - (this is optional since GCP has its own implementation of the dashboard)
- The gRPC Server Application and a load balancer

## Architecture
TBD

# Deployment
TBD

# Resources
This terraform chart is based off the hashicorp base GKE configuration
- https://github.com/hashicorp/learn-terraform-provision-gke-cluster