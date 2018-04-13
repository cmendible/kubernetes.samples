helm install --name bootcampprometheus stable/prometheus --version 4.6.13 -f prometheus-configforhelm.yaml

helm install --name bootcampgrafana stable/grafana --version 0.5.1 --set 'server.service.type=ClusterIP,server.adminUser=admin,server.adminPassword=admin,server.image=grafana/grafana:4.6.3,server.persistentVolume.enabled=false'

kubectl apply -f ./ingress_rules.yaml