[![Build status](https://ci.appveyor.com/api/projects/status/8mrfrc2j71ra0bdc?svg=true)](https://ci.appveyor.com/project/luisdeol/twitter-like-api)

# TwitterLike ASP.NET Core application
A Twitter-like ASP.NET Core back-end application. It is designed and implemented based on Clean Architecture and CQRS concepts. 

I decided to develop this application because I wanted to keep improving my architecture design and software practices, and to make that application a reference for the .NET community;

## Running the application

### Clone   
```git clone https://github.com/luisdeol/twitter-like-api.git```   
   
### Change into the TwitterLike.API directory, restore and run the application   
```
cd twitter-like-api   
cd TwitterLike.API   
dotnet restore   
dotnet run
```

### Running Unit Tests  
The units tests are written using xUnit testing framework. It also uses Moq and AutoFixture packages for improving unit testing experience.   
```  
cd TwitterLike.UnitTests   
dotnet test   
```
  
### Swagger   
You can access the API documentation by accessing the http://localhost:5000/swagger URL



