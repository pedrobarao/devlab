namespace Lab.Customers.Application.DTOs.Outputs;

public class CustomerDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Cpf { get; set; }
    public DateTime BirthDate { get; set; }
}