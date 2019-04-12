# coolshop
Virtual Market is containerised polyghot miroservices application consisting of services base on .NET core
, Node JS and more running on Service Mesh. It demostrate how to write up small microservices into a larger
application using microservice architecture principals.

## Table of constents
- RESful API implementation with ASP.NET core
- SQL and NoSQL database (SQLServer, MongoDB, InfluxDB)
- Distributed caching with Redis.
- API Gateway and other patterns designed for microservices
- JWT, authentication, authorization
- Communication via websockets using SignalR
- CQRS, Commands Queries and Events handlers
- Using RabbitMQ as a message queue with RawRabbit
- Dealing with asynchronous request, Process Managers and Sagas.
- Internal HTTP communication with RestEase
- Service discovery with Consul
- Storing secrets with Vault
- Monitoring with App Metrics, Grafana, Prometheus and Jaeger
- Loggin with Serilog, Seq and ELK stack
- Building Docker images, managing containers, network and registries  
- Defining Docker compose stacks
- Managing your own Nuget feeds
- CI and CD with build service such as Travis CI, Bitbucket Pipelines or VSTS
- Deploying serviecs to the Linux Servers and configuring Ngix
- Orchestrating services on your VM or in the Cloud using Portainer and Rancher (built on top of Kubernetes)

## structure of project
- VirtualMarket
- VirtualMarket.Api
- VirtualMarket.Comon
Services
- VirtualMarket.Services.Identity
- VirtualMarket.Services.Customers
- VirtualMarket.Services.Notifications
- VirtualMarket.Services.Operations
- VirtualMarket.Services.Orders
- VirtualMarket.Services.Products
- VirtualMarket.Services.SignalR

## How to start the solution
At first, you need to have the following servies up and running on localhost (so-called bare minimum)
- MongoDB
- RabbitMQ
- Redis

These can be run as standalone services, or via Docker (recommended approach)

docker run --name mongo -d -p 27017:27017  monggo:4
docker run --name rabbitmq -d -p 5672:5672 --hostname rabbitmq rabbitmq:3-management
docker run --name redis -d -p 6379:6379 redis

