using Microsoft.EntityFrameworkCore;
public class CustomersContext: DbContext{

    public CustomersContext(DbContextOptions options):base(options){

    }
    public DbSet<Customer> customers{get;set;}

}