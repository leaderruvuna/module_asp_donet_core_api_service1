using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

[ApiController]
[Route("customers")]
public class CustomerController : ControllerBase
{

    private CustomersSql customersSql;

    public CustomerController(IConfiguration configuration)
    {
        customersSql = new CustomersSql(configuration);
    }

    //get all customers
    [HttpGet]
    [Route("find/customer/all")]
    public async Task<List<Customer>> getAllCustomers()
    {

        List<Customer> customers = new List<Customer>();
        DbDataReader customerReaderData = null;
        try
        {
            customerReaderData = await customersSql.FindAll();
            while (await customerReaderData.ReadAsync())
            {
                customers.Add(
                  new Customer()
                  {
                      FirstName = customerReaderData.GetValue("FirstName").ToString(),
                      LastName = customerReaderData.GetValue("LastName").ToString(),
                      Address = customerReaderData.GetValue("Address").ToString(),
                      Email = customerReaderData.GetValue("Email").ToString(),
                  }
                );
            }

        }
        catch (System.Exception)
        {

            throw;
        }
        return customers;
    }

    //get customer by Id
    [HttpGet]
    [Route("find/customer/{id}")]
    public async Task<Customer> getCustomer(int id)
    {
        Customer customer = null;
        DbDataReader customerReaderData = null;
        try
        {
            customerReaderData = await customersSql.FindById(id);
            customer = new Customer
            {
                CustomerId = (int)customerReaderData.GetValue("CustomerId"),
                FirstName = customerReaderData.GetValue("FirstName").ToString(),
                LastName = customerReaderData.GetValue("LastName").ToString(),
                Address = customerReaderData.GetValue("Address").ToString(),
                Email = customerReaderData.GetValue("Email").ToString(),
            };
        }
        catch (System.Exception)
        {

            throw;
        }
        return customer;
    }

    //create customer
    [HttpPost]
    [Route("create/customer")]
    public async Task<HttpStatusCode> createCustomer(Customer customer)
    {
        string firstName = customer.FirstName;
        string lastName = customer.LastName;
        string address = customer.Address;
        string phoneNumber = customer.PhoneNumber;
        string email = customer.Email;
        HttpStatusCode statusCode = HttpStatusCode.Created;
        DbDataReader customerReaderData = null;
        try
        {
            customerReaderData = await customersSql.Create(firstName, lastName, address, phoneNumber, email);
        }
        catch (System.Exception)
        {

            statusCode = HttpStatusCode.Forbidden;
        }

        return statusCode;
    }

    //update customer
    [HttpPut]
    [Route("update/customer/{id}")]
    public async Task<HttpStatusCode> updateCustomer(int id, Customer customer)
    {
        //
        string firstName = customer.FirstName;
        string lastName = customer.LastName;
        string address = customer.Address;
        string phoneNumber = customer.PhoneNumber;
        string email = customer.Email;

        HttpStatusCode statusCode = HttpStatusCode.Created;
        DbDataReader customerReaderData = null;
        if (validateCustomers(id, firstName, lastName, address, phoneNumber, email) == false)
        {
            return HttpStatusCode.BadRequest;
        }
        try
        {
            customerReaderData = await customersSql.Update(id, firstName, lastName, address, phoneNumber, email);
        }
        catch (System.Exception)
        {

            statusCode = HttpStatusCode.Forbidden;
        }

        return statusCode;

    }


    //delete customer
    [HttpDelete]
    [Route("delete/customer/{id}")]
    public async Task deleteCustomer(int id)
    {
        try
        {
            await customersSql.DeleteById(id);
        }
        catch (System.Exception)
        {

            throw;
        }
    }

    public static Boolean validateCustomers(int id, string firstName, string lastName, string address, string phoneNumber, string email)
    {
        if (firstName == "" || lastName == "" || address == "" || phoneNumber == "" || email == "" || id == 0)
        {
            return false;
        }
        return true;
    }

}