using System;

public class Program {
    public static void Main(string[] args){
        Shop shop= new("Wedding Shop");
        Console.WriteLine($"\n\n\t\t{shop.ShopName}\n");
        Initializer init = new(shop);
        Client client = new(shop, new(14, "Davide", "Brancato"));
    }
}