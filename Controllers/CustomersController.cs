using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;



[ApiController]
[Route("customers")]
public class CustomerController : ControllerBase
{

    //get all customers
    [HttpGet]
    [Route("find/customer/all")]
    public List<Customer> getAllCustomers()
    {

        return null;
    }

    //get customer by Id
    [HttpGet]
    [Route("find/customer/{id}")]
    public Customer getCustomer()
    {
        return null;
    }

    //create customer
    [HttpPost]
    [Route("create/customer")]
    public Customer createCustomer()
    {
        return null;
    }

    //update customer
    [HttpPut]
    [Route("update/customer/{id}")]
    public Customer updateCustomer()
    {
        return null;
    }


    //delete customer
    [HttpDelete]
    [Route("delete/customer/{id}")]
    public void deleteCustomer()
    {
    }

}