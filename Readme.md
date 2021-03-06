## Overview

Project Heirloom or eClinic is a e-clinical system that aims to showcase possible design challenges of a system adopting microservices architectural style,
and demostrating through actual implementation of tactics that can solve these challenges.

* Frontend - Reactjs
* AuthN with Azure AD 
* AuthZ
  * authorization policies with Open Policy Agent
  * user retrieval from Azure AD Graph API
  * handles user role assignment
* API Gateway with Traefik
* Inter-service domain events messaging with Nats
* Inter-service mTLS API calls with Linkerd (evaluating, or dapr)
* Logging: Console stdout and stderr. FluentD and ELK for stdout/stderr logs
* Distributed Tracing with Zipkin
* Secrets Management with Azure Key Vault provider for Secret Store CSI Driver


<b>*Project temporary shelved</b>
 
