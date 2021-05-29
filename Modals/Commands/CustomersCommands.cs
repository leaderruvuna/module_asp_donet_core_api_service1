using System.Data.Common;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;

public class CustomersSql
{

    private MySqlConnection connection = null;
    private MySqlCommand sqlCommand = null;


    public CustomersSql(IConfiguration configuration)
    {
        connection = new MySqlConnection(configuration.GetSection("ConnectionStrings").GetSection("Default").Value);
    }

    public async Task<DbDataReader> Create(string firstName, string lastName, string address, string phoneNumber, string email)
    {

        await connection.OpenAsync();

        sqlCommand = new MySqlCommand("INSERT INTO customers(FirstName,LastName,Address,PhoneNumber,Email)VALUES('" + firstName + "','" + lastName + "','" + address + "','" + phoneNumber + "','" + email + "')", connection);

        var customer = await sqlCommand.ExecuteReaderAsync();

        return customer;

    }

    public async Task<DbDataReader> Update(int customerId, string firstName, string lastName, string address, string phoneNumber, string email)
    {

        await connection.OpenAsync();

        sqlCommand = new MySqlCommand("UPDATE  customers SET FirstName='" + firstName + "',LastName='" + lastName + "',Address='" + address + "',PhoneNumber='" + phoneNumber + "',Email='" + email + "' WHERE CustomerId=" + customerId + "", connection);

        var customer = await sqlCommand.ExecuteReaderAsync();

        await customer.ReadAsync();

        return customer;

    }

    public async Task<DbDataReader> FindAll()
    {

        await connection.OpenAsync();

        sqlCommand = new MySqlCommand("SELECT * FROM customers", connection);

        var customer = await sqlCommand.ExecuteReaderAsync();

        return customer;

    }

    public async Task<DbDataReader> FindById(int customerId)
    {

        await connection.OpenAsync();

        sqlCommand = new MySqlCommand("SELECT * FROM customers WHERE CustomerId=" + customerId + "", connection);

        var customer = await sqlCommand.ExecuteReaderAsync();

        await customer.ReadAsync();

        return customer;

    }

    public async Task<DbDataReader> DeleteById(int customerId)
    {

        await connection.OpenAsync();

        sqlCommand = new MySqlCommand("DELETE FROM customers WHERE CustomerId=" + customerId + "", connection);

        var customer = await sqlCommand.ExecuteReaderAsync();

        await customer.ReadAsync();

        return customer;

    }
}