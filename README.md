# Romina's Web API

## Introduction

The aim of this task is to create a Web API using ASP.NET Core. Useful links are the [Microsoft Docs](https://docs.microsoft.com/en-us/aspnet/core/tutorials/first-web-api?view=aspnetcore-2.2&tabs=visual-studio) and this [Video Walkthrough](https://channel9.msdn.com/events/dotnetConf/2017/T322?term=asp.net%20core%20web%20api&lang-en=true)

## API Documentation

### API Endpoints

The API should expose the following endpoints. For ease of use we do not need to add any authentication. 

| Method  |Endpoint   |Usage  | Returns |
| --------|-----------|-------|---------|
| GET  | /v1/product/{productId} | Gets a product | Product |
| POST  | /v1/product | Creates a new product | - |

### Object Types

For simplicity this API will use one object called `Product`.

``` json
{
    "productId": "81adc581-4c4d-4c33-8ec6-5dbcfea1b541",
    "make": "Nike",
    "model": "Oversized T Shirt",
    "description": "",
    "price": 10.00,
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

Your solution should do the following

- API should respond with appropriate HTTP status codes
- API should use Cosmos DB to persist data
- API should use App Insights for logging
- API should use Dependency Injection
- API should read configuration from appsettings
- API should have unit and acceptance tests
- Solution should have an arm template
- Solution should have a script that will build, test and deploy the API
