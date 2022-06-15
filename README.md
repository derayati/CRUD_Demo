# Derayati Customers Test Project

A simple CRUD application For Customer Of Bank with ASP NET Core that implements the below model:

# About The Project

## Description
A sample RESTful Web Service With Swagger and Test .

<br/>

## Architecture
- ### Common
It includes some of technologies , helper and validations related to application core.

- ### Core
It is Includes application logic and data access implementations and EF Core , entities , domain services , interfaces , value objects , resources , mappings .

- ### WebApi
It is the startup project. Handles requests from client. It includes Web and Http related implementations, RESTful concepts, endpoints, dependency injections, swagger.

- ### Test
It is for all application layers are included (except for the controllers). Test projects could be organized based on the kind of test (unit, functional, integration, performance, etc.) or by the project they are testing (Core, common, Webapi).

<br/>

## Technologies
- .Net 5.0
- AspNetCore WebAPI
- EntityFrameworkCore
- EF Code Firs
- FluentValidation
- ValueObject
- TDD XUint
- AutoMapper
- MSSQLServer
- Helper



<br/><br/>

# Installation

Clone from GitHub
```git bash
git clone https://github.com/derayati/Sample_CRUD_Customer 
```

<br/><br/>

# Build And Deploy

## How to run on local

<br/>

- **Add Migration**
```powershell
dotnet ef migrations add Update-Datebase -project DerayatiBank.Core
```


<br/><br/>


- **Browse Swagger:**
```
http://localhost:9813/swagger/index.html
```
