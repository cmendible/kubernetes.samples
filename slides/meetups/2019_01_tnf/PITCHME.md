@transition[none]

@snap[south-east]
##### Carlos Mendible @cmendibl3<br>Technical Manager @everis
@snapend

@snap[midpoint]
### A glimpse of Kubernetes
@snapend

---

### Docker & Micro-services

* Run your applications in containers
* Split your application into small services.
* Decoupled processes.
* Smaller teams
* DevOpsSec

---

### Issues you'll find in the wild

* Discovery and Naming
* Scaling & High availability
* Multiple users
* Failure tolerance and recovery
* Monitoring & Logging
* Deployment lifecycle
* Load balancing
* How to move from App Ops to Cluster Ops

---

### Kubernetes

> "Container Orchestrator" or "Cluster Manager"

* Places containers on nodes
* Recovers automatically from failure
* Basic monitoring, logging, health checking
* Enables containers discovery.
* Open Source & based on Google ideas.
* Written in Go

---

### Core Concepts

* Cluster
* Namespaces
* Pod
* Labels
* Deployments
* Service
* Persistent Volumes

---

### Other Concepts

* Ingress
* Deployments
* Jobs
* Autoscaling
* DaemonSets
* StatefulSets

Note:
* **Ingress:** Load balancing (L7)
* **Deployments:**  Declarative version updates
* **Jobs:** Run to completion
* **Autoscaling:** Automatically adjust replica count
* **DaemonSets:** Run something on every node (or subset)
* **StatefulSets:** Control over deployment order and access to volumes

---

### Interacting with Kubernetes

* kubectl
* helm
* draft
* Azure Dev Spaces
* Visual Studio Code

Note:

* **kubectl:** k8s cli
* **helm:** define, install, and upgrade even the most complex k8s application
* **draft:** Draft targets the "inner loop" of a developer's workflow
* **Azure Dev Spaces:** fast, iterative Kubernetes development experience for teams
* **Visual Studio Code:** kubernetes, docker and yaml plugins

---

### Azure Dev Spaces

![azds](slides/meetups/2019_01_tnf/img/collaborate-graphic.gif)

---?color=#e7ad52

@snap[midpoint]
### Demo Time!
@snapend

---

@snap[south-east]
Twitter: [@cmendibl3](https://twitter.com/cmendibl3)
<br>
Blog: [carlos.mendible.com](https://carlos.mendible.com)
@snapend

@snap[midpoint]
### Thank you!
@snapend
