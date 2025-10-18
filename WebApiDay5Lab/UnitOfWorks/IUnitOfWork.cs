namespace WebApiDay5Lab.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Department> DepartmentRepository { get; }
        IRepository<Employee> EmployeeRepository { get; }
        IRepository<Category> CategoryRepository { get; }
        IRepository<Product> ProductRepository { get; }
        IRepository<Customer> CustomerRepository { get; }
        IRepository<Order> OrderRepository { get; }
        IRepository<OrderItem> OrderItemRepository { get; }
        int Complete();
    }
}
