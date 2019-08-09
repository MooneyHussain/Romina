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

### Acceptance Criteria 

The API should use / do the following 

- Should respond with appropriate HTTP status codes
- Should use Cosmos DB to persist data
- Should use App Insights for logging
- Should use Dependency Injection 
- Should read configuration from appsettings
- Should have unit and acceptance tests