

#!/bin/bash


## Setup 
#Retrieve Managed Identity ID

$clientId= az aks show -g <AKSResourceGroup> -n <AKSClusterName> --query identityProfile.kubeletidentity.clientId -otsv

#Assign the Reader role to the managed identity
az role assignment create --role "Reader" --assignee $clientId --scope /subscriptions/[your subscription id]/resourcegroups/[your resource group]

#Assign the Managed Identity Operator role to the AKS Service Principal Refer to previous step about the Resource Group to use and which identity to assign

az role assignment create  --role "Managed Identity Operator"  --assignee $clientId  --scope /subscriptions/[your subscription id]/resourcegroups/[your resource group]

az role assignment create  --role "Virtual Machine Contributor"  --assignee $clientId  --scope /subscriptions/[your subscription id]/resourcegroups/[your resource group]


#allow MI to access AKV
az keyvault set-policy --name [your keyvault] --spn $clientId --secret-permissions get list

#Enable AAD Pod Identity on AKS
kubectl apply -f https://raw.githubusercontent.com/Azure/aad-pod-identity/master/deploy/infra/deployment-rbac.yaml
kubectl apply -f https://raw.githubusercontent.com/Azure/aad-pod-identity/master/deploy/infra/mic-exception.yaml