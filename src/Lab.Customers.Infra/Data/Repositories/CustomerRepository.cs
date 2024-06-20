using Dapper;
using Lab.Core.Commons.Communication;
using Lab.Core.Commons.Data;
using Lab.Customers.Domain.Entities;
using Lab.Customers.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Lab.Customers.Infra.Data.Repositories;

public sealed class CustomerRepository : ICustomerRepository
{
    private readonly CustomerDbContext _context;

    public CustomerRepository(CustomerDbContext context)
    {
        _context = context;
    }

    public IUnitOfWork UnitOfWork => _context!;

    public void Add(Customer customer)
    {
        _context.Customers.Add(customer);
    }

    public async Task<Customer?> GetByIdAsync(Guid id)
    {
        return await _context.Customers.FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<PagedResult<Customer>> ListPagedAsync(int pageSize, int pageIndex, string? query = null)
    {
        var sql = @$"SELECT * FROM Customers 
                      WHERE (@Name IS NULL OR Name LIKE '%' + @Name + '%') 
                      ORDER BY [Name] 
                      OFFSET {pageSize * (pageIndex - 1)} ROWS 
                      FETCH NEXT {pageSize} ROWS ONLY
                      SELECT COUNT(Id) FROM Customers 
                      WHERE (@Name IS NULL OR Nome LIKE '%' + @Name + '%')";

        var multi = await _context.Database.GetDbConnection()
            .QueryMultipleAsync(sql, new { Name = query });

        var customers = multi.Read<Customer>();
        var totalItems = multi.Read<int>().FirstOrDefault();

        return new PagedResult<Customer>(customers, totalItems, pageIndex, pageSize, query);
    }

    public void Update(Customer customer)
    {
        _context.Customers.Update(customer);
    }

    public void Delete(Customer customer)
    {
        _context.Customers.Remove(customer);
    }

    public void Dispose()
    {
        _context?.Dispose();
    }
}