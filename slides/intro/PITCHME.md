## An intro to Kubernetes

Carlos Mendible @cmendibl3
Technical Manager @everis

---

## Docker & Micro-services

* Run your applications in containers
* Split your application into small services that can be reused, remixed and shared.
* Enables decoupled processes.
* Better tooling enables and encourages microservices.
* Smaller teams

---

## What problems can Kubernetes solve?

* Multi-machine
* Discovery and Naming
* Scaling
* Multiple users
* Failure tolerance and recovery
* Monitoring
* Logging
* High availability
* Deployment lifecycle
* Load balancing
* M0ve from App Ops to Cluster Ops 
* Reduce cost to run many things in production

---

## Kubernetes

Kubernetes is a "Container Orchestrator" or "Cluster Manager".

* Places containers on nodes
* Recovers automatically from failure
* Basic monitoring, logging, health checking
* Enables containers discovery.
* Open Source & based on Google ideas.
* Written in Go

---

## Core Concepts

* Cluster
* Namespaces
* Pod
* Labels
* Deployments
* Service
* Persistent Volumes

---

# Other Concepts

* **Ingress**
  * L7 load balancing
* **Deployments**
  * Declarative version updates
* **Jobs**
  * Run to completion
* **Autoscaling**
  * Automatically adjust replica count
* **DaemonSets**
  * Run something on every node (or subset)
* **StatefulSets**
  * Ensure control over the deployment ordering and access to volumes

---

## Interacting with Kubernetes

* **kubectl**
* **Helm**

---
# Thank you!