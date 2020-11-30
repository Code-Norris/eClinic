helm install elasticsearch elastic/elasticsearch -n dapr-mon --set replicas=1

helm install kibana elastic/kibana -n dapr-mon --set replicas=1