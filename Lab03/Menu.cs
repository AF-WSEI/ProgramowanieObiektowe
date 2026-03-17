namespace Lab03;

public class Menu(List<MenuItem> menuItems)
{
    private List<MenuItem> _menuItems = menuItems;

    public void Print()
    {
        foreach (var menuItem in _menuItems)
        {
            Console.WriteLine(menuItem);
        }
    }

    public MenuItem? FindById(int id)
    {
        foreach (var menuItem in _menuItems)
        {
            if (menuItem.Id == id)
            {
                return menuItem;
            }
        }
        return null;
    }
}