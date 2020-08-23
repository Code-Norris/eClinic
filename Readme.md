## Overview

eClinic is a demo project that aims to highlight all possible challenges of a system adopting microservices architecural style,
and showing the possible tactics that can solve these challenges

* AuthN with Dex
* AuthZ with Open Policy Agent
* Inter-service domain events messaging with Nats
* Inter-service API calls with Dapr
* Logging: Console stdout and stderr. FluentD picks up all console logs and send to ELK
* Secrets: [Access Key Vault with Managed Identity](https://github.com/dapr/docs/blob/master/howto/setup-secret-store/azure-keyvault-managed-identity.md) as secret store with Dapr
 