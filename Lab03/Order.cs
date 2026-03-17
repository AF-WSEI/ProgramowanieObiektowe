namespace Lab03;

public class Order
{
    private List<OrderItem> _items = new();

    public decimal TotalPrice
    {
        get
        {
            decimal totalPrice = 0;
            foreach (var item in _items)
            {
                totalPrice += item.Quantity * item.Item.Price;
            }

            return totalPrice;
        }
    }

    public void AddItems(MenuItem item, int quantity)
    {
        OrderItem orderItem = new OrderItem()
        {
            Item = item,
            Quantity = quantity
        };
        _items.Add(orderItem);
    }

    public void DeleteItem(MenuItem item)
    {
        
    }
}