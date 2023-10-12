using System.Runtime.InteropServices;
using System.Text.Json;

public class Initializer
{
    private Shop _shop;

    /* --------- Take object from json file --------- */

    private void TakeFromJson(string path, bool type)
    {
        string[] lines = File.ReadAllLines(path);
        if (type)
        {
            Gift[] gifts = new Gift[lines.Length];
            int i = 0;

            foreach (var line in lines)
            {
                gifts[i++] = JsonSerializer.Deserialize<Gift>(line);
            }
            InsertIntoInventory(gifts);

        }
        else
        {
            Newlyweds[] newlyweds = new Newlyweds[lines.Length];
            int i = 0;
            foreach (var line in lines)
            {
                newlyweds[i++] = JsonSerializer.Deserialize<Newlyweds>(line);
            }
            InsertIntoNewlyweds(newlyweds);
        }

    }

    private void InsertIntoInventory(Gift[] gifts)
    {
        foreach (var gift in gifts) { _shop.InsertIntoInventory(gift); }
    }

    private void InsertIntoNewlyweds(Newlyweds[] newlyweds)
    {
        foreach (Newlyweds nw in newlyweds) { _shop.InsertIntoNewlyweds(nw); }
    }

    public Initializer(Shop shop)
    {
        _shop= shop;
        TakeFromJson("Inventory/gift.json", true);
        TakeFromJson("Inventory/newlyweds.json", false);
    }
}