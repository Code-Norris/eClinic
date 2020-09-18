## Overview

Codename Heirloom or eClinic is a e-clinical system that aims to showcase possible design challenges of a system adopting microservices architecural style,
and demostrating through actual implementation of tactics that can solve these challenges.

* Desktop Frontend with Wails + Reactjs
* AuthN with Azure AD 
* AuthZ with Open Policy Agent
* API Gateway pattern with Traefik
* Inter-service domain events messaging with Nats
* Inter-service mTLS API calls with Linkerd (evaluating, or dapr)
* Logging: Console stdout and stderr. FluentD and ELK for stdout/stderr logs
* Secrets: Azure Key Vault with AAD Pod Identity for secret retrieval
 
