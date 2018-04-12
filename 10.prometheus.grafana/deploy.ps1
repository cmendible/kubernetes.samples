helm install --name gbbhackprometheus stable/prometheus --version 4.6.13 -f prometheus-configforhelm.yaml

helm install --name gbbhackgrafana stable/grafana --version 0.5.1 --set server.service.type=LoadBalancer, server.adminUser=admin, server.adminPassword=admin, server.image=grafana/grafana:4.6.3, server.persistentVolume.enabled=false
