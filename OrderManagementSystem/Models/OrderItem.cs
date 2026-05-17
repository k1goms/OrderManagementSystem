namespace OrderManagementSystem.Models;

public class OrderItem
{

    public Product Product { get; private set; }
    public int Qty { get; private set; }
    public decimal Subtotal { get; private set; }

    public OrderItem(Product product, int qty)
    {
        Product = product;
        Qty = qty;
        Subtotal = product.Price * Qty;
    }

    public override string? ToString()
    {
        return $"[ ITEM: {Product.Name} | Qty: {Qty} | ${Subtotal:F2} ]";

    }

}
