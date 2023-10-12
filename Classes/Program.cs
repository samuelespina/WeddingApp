using System;

public class Program {
    public static void Main(string[] args){

        Shop shop= new("Wedding Shop");
        Initializer init = new(shop);
        Console.WriteLine($"\n\n\t\t{shop.ShopName}\n");

        Newlyweds newlyweds = new Newlyweds(1, new User(1, "Michele", "Malgeri"), new User(2, "Vincenza", "Carchiolo"));

        Client clientNewlyweds = new Client(shop, newlyweds);
        newlyweds.PrintAllGiftLists();

        Client clientUser = new(shop, new User(14, "Mario", "Rossi"));
    }
}