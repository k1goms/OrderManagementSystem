using OrderManagementSystem.Repositories;

public class Program
{
    static void Main(string[] args)
    {
        
        var repository = new ProductRepository();

        foreach (var item in repository.GetAll())
        {
            Console.WriteLine(item);
        }

    }
}
