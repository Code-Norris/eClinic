kubectl create namespace dapr-system
helm repo add dapr https://daprio.azurecr.io/helm/v1/repo
helm repo update
helm install dapr dapr/dapr --namespace dapr-system --set global.logAsJson=true