namespace PageObjectTests.models;

public class OrderModel
{
    public string ProductName { get; }
    public string Subtotal{ get; }
    public string ShippingAndHanding{ get; }
    public string GrandTotal{ get; }

    public OrderModel(string productName, string subtotal, string shippingAndHanding, string grandTotal)
    {
        ProductName = productName;
        Subtotal = subtotal;
        ShippingAndHanding = shippingAndHanding;
        GrandTotal = grandTotal;
    }
}