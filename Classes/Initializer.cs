using System.Runtime.InteropServices;
using System.Text.Json;

public class Initializer
{

    /* --------- Json inventory file Init --------- */

    private Shop _shop;

    private Gift[] shopInventory =
    {
        new(1, "Oven", "Amazing oven, over 500Fahrenheit", 350.98),
        new(2, "Nespresso Coffe Machine","A brand new Nespresso coffe machine", 250),
        new(3, "Dishwasher", "The faster dishwasher in the world", 510.50),
        new(4, "Samsung Smart TV", "Smart 8k television, 75inches of pure fun", 800),
        new(5,"Bosh Washing Machine" ,"With over 9 differnt types of wash, this brand new Bosh washing machine will surprise you", 680.90)
    };

    private Newlyweds[] newlyweds =
    {
        new( 1, new(1, "Mario", "Rossi"), new(2, "Angela", "Robertini")),
        new( 2, new(3, "Marcello", "Italia"), new(4, "Marcella", "Napoli")),
        new( 3, new(5, "Alberto", "Milazzo"), new(6, "Roberta", "Castelli"))
    };

    private void CreateJason()
    {
        string[] produtctJson = new string[shopInventory.Length];
        int i = 0;
        foreach (Gift product in shopInventory)
        {
            produtctJson[i++] = JsonSerializer.Serialize(product);
        }
        InsertIntoFileJson(produtctJson, "Inventory/gift.json");

        string[] newlywedsJson = new string[newlyweds.Length];
        i = 0;
        foreach (Newlyweds newlyweds in newlyweds)
        {
            newlywedsJson[i++] = JsonSerializer.Serialize(newlyweds);
        }
        InsertIntoFileJson(newlywedsJson, "Inventory/newlyweds.json");
    }

    private void InsertIntoFileJson(string[] line, string jsonFilePath)
    {
        File.WriteAllLines(jsonFilePath, line);
    }

    /* --------------------------------------------- */


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
        //Insert the json into inventory DS
        foreach (var gift in gifts) { _shop.InsertIntoInventory(gift); }
    }

    private void InsertIntoNewlyweds(Newlyweds[] newlyweds)
    {
        foreach (Newlyweds nw in newlyweds) { _shop.InsertIntoNewlyweds(nw); }
    }

    public Initializer(Shop shop)
    {
        _shop= shop;
        CreateJason();
        TakeFromJson("Inventory/gift.json", true);
        TakeFromJson("Inventory/newlyweds.json", false);
    }
}