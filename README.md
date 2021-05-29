## SERVICE1

### ABOUT

This is a customer API in charge of performing CRUD operations with the DB. It is used as SERVICE 1 out of 2 of our Microservice architecture.

### API DOC

### RUN THE SERVICE
Create database with the following name:(microservicesdb)
1. dotnet restore
2. dotnet ef migrations add InitialCreate
3. dotnet ef database update
4. dotnet run
### API DOC
The following are the API endpoints
* https://localhost:5001/customers/find/customer/all
* https://localhost:5001/customers/find/customer/{id}
* https://localhost:5001/customers/create/customer
* https://localhost:5001/customers/update/customer/{id}
* https://localhost:5001/customers/delete/customer/{id}

