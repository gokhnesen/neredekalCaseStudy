# Hotel Directory .NET Core Microservices

## Project Overview
A microservices-based hotel directory application built with .NET Core, featuring:
- **Hotel management**: Create, update, delete hotels and manage contact information.
- **Asynchronous reporting system**: Generate location-based reports in the background.
- **Database management**: PostgreSQL with Entity Framework Core.
- **Message Queue**: RabbitMQ for asynchronous communication.
- **Logging**: Serilog integrated with the ELK Stack (ElasticSearch, Logstash, Kibana).

## Prerequisites
Before you begin, ensure you have the following installed on your local machine:
- **.NET 8.0 SDK**: The application is built using .NET Core 8.0.
- **Docker**: For running services such as RabbitMQ and ELK Stack.

## Technology Stack
- **Backend**: .NET Core 8.0
- **Database**: PostgreSQL
- **Message Queue**: RabbitMQ
- **ORM**: Entity Framework Core
- **Logging**: Serilog with ELK Stack (ElasticSearch, Logstash, Kibana)
- **API Communication**: RESTful APIs

## Getting Started

### 1. Clone the Repository
First, clone the repository to your local machine:
```
git clone https://github.com/gokhnesen/neredekalCaseStudy.git
```
### 2. Database Migrations
```
cd src/Infrastructure/neredekalCaseStudy.Persistence
update-database
```
### 3. Build and Run the Application with Docker
```
docker-compose up --build
```
