helm install stable/nginx-ingress --name my-nginx `
    --set controller.ingressClass=nginx `
    --set controller.service.externalTrafficPolicy=Local `
    --set controller.service.loadBalancerIP=127.0.0.1