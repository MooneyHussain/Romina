# Romina's Web API

## Introduction

The aim of this task is to create a Web API using ASP.NET Core. This API will should be as production like with a focus on clean coding and maintainability.

## API Documentation

### API Endpoints

The API should expose the following endpoints. For ease of use we do **not** need to add any authentication.

| Method | Endpoint                | Usage                 | Return Object |
| ------ | ----------------------- | --------------------- | ------------- |
| GET    | api/v1/product/{productId} | Gets a product        | Product       |
| POST   | api/v1/product             | Creates a new product | -             |

### Object Types

Below is an example of a reponse for a valid `GET` request

```json
{
  "productId": "81adc581-4c4d-4c33-8ec6-5dbcfea1b541",
  "make": "Nike",
  "model": "Oversized T Shirt",
  "description": "",
  "price": 10.0
}
```

### GWT's

Given a valid 'get' request
Then return product information

Given a valid 'get' request
When the product does not exist
Then return NotFound

Given a valid 'post' request
Then store product

Given a invalid 'post' request
Then return BadRequest

## Deployment

The application should include a deployment process so that a user can create the resources needed for this API.

The process should include the following

- Arm Template (to create the azure resources)
- Cake Script (to build, test, deploy arm template, package and deploy the code)

## Acceptance Criteria

### High Level Requirements

- API should respond with appropriate HTTP status codes
- API should use Cosmos DB to persist data
- API should use App Insights for logging
- API should use Dependency Injection
- API should read configuration from appsettings
- API should have unit and acceptance tests
- Solution should have an arm template
- Solution should have a script that will build, test and deploy the API

### Additional Requirements

- Create a new GET endpoint called search 
  - should be accessible via `api/v1/search?filter=nike shoes`
  - should return a list of products
- Should look for matches in the make, model and description of a product
- Should apply prioritisation rules when returning (see below)
  - Make (highest priority)
  - Model 
  - Description (lowest priority)

#### GWTS

**Given** we have a valid search request for "Nike"   
**When** we have 3 products in the database    
**And** product A contains "Nike" in `Make`    
**And** product B contains "Nike" in `Model`  
**And** product C contains "Nike" in `Description`  
**Then** return product information with the order of Product A, B and then C  

## Useful Links / Reading Material

- [Video: Solid Design Patterns](https://www.youtube.com/watch?v=agkWYPUcLpg&t=1427s)
- [Tutorial: Create a web API with ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-2.2&tabs=visual-studio)
- [Video: Building Web APIs with ASP.NET Core](https://channel9.msdn.com/events/dotnetConf/2017/T322?term=asp.net%20core%20web%20api&lang-en=true)
- [Tutorial: Dependency injection in ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-3.1)
- [Video: Dependency injection in ASP.NET Core](https://docs.microsoft.com/en-us/aspnet/core/fundamentals/dependency-injection?view=aspnetcore-3.1)
