## Overview

eClinic is a demo project that aims to showcase all possible challenges of a system adopting microservices architecural style,
and demostrating through actual implementation, the possible tactics that can solve these challenges

* Desktop Frontend with Go Wails and Reactjs
* AuthN with Azure AD 
* AuthZ with Open Policy Agent
* Inter-service domain events messaging with Nats
* Inter-service API calls with Linkerd (evaluating)
* Logging: Console stdout and stderr. FluentD picks up all stdout logs and send to ELK
* Secrets: [Access Key Vault with Managed Identity](https://github.com/dapr/docs/blob/master/howto/setup-secret-store/azure-keyvault-managed-identity.md) as secret store with Dapr
 
