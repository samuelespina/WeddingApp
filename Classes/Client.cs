public class Client
{
    private Shop _shop;

    private User _user;

    private Newlyweds _newlyweds;

    private Newlyweds? SelectNewlyweds()
    {
        _shop.ShowNewlyWeds();
        Console.WriteLine("Select the Newlyweds");

        try
        {
            string response = Console.ReadLine();
            Newlyweds newlyweds = _shop.TakeNewlyWeds((ushort)int.Parse(response));
            return newlyweds;
        }
        catch (NewlyWedsNotFoundException e)
        {
            Console.WriteLine(e.Message);
            //come faccio a ciclare di nuovo per reinsirire un altro valore? 
        }
        catch (Exception)
        {
            Console.WriteLine("Invalid Value Inserted");
        }

        return null;

    }

    private GiftList? SelectGiftList(Newlyweds newlyweds)
    {
        _shop.ShowNewlyWedsLists(newlyweds);
        Console.WriteLine($"Select a List of {newlyweds}");
        try
        {
            string response = Console.ReadLine();
            if (response != null)
            {
                GiftList giftList = _shop.TakeWeddingList(newlyweds, response);
                return giftList;
            }
            throw new NullReferenceException();


        }
        catch (GiftListNotFoundException e)
        {
            Console.WriteLine(e.Message);
            //come faccio a ciclare di nuovo per reinsirire un altro valore? 
        }
        catch (Exception)
        {
            Console.WriteLine("Insert a valid value");
        }
        return null;
    }

    private Gift? SelectGiftFromList(GiftList list)
    {
        try
        {
            string response = Console.ReadLine();
            if (response != null)
            {
                Gift gift = list.TakeGift(response);
                return gift;
            }
            throw new NullReferenceException();
        }
        catch (GiftNotFoundException e)
        {
            Console.WriteLine(e.Message);
            //come faccio a ciclare di nuovo per reinsirire un altro valore? 
        }
        catch (Exception)
        {
            Console.WriteLine("Insert a valid value");
        }
        return null;
    }

    public Client(Shop shop, User user)
    {
        _user = user;
        _shop = shop;
        UserMenu();
    }
    
    public void UserMenu()
    {
        Console.WriteLine($"\n\t\tAccess As: {_user}\n");
        try
        {
            bool exit = false;
            while (!exit)
            {
                Newlyweds? newlyweds = SelectNewlyweds();
                if(newlyweds == null) return;
                Console.WriteLine();
                GiftList? list = SelectGiftList(newlyweds);
                if (list == null) return;
                bool KeepBuy = true;

                while (KeepBuy)
                {
                    Console.WriteLine();
                    list.ShowList();
                    Console.WriteLine();
                    Console.WriteLine("Select a Gift");
                    Gift? gift = SelectGiftFromList(list);

                    if (_user.BuyGift(_shop, list, gift)) Console.WriteLine($"\n{_user.ToString(true)}");
                    else Console.WriteLine("Purchase failed");
                    Console.WriteLine("\nWanna buy some more Gift? (y/n)");
                    if (Console.ReadLine().ToLower() != "y") { KeepBuy = false; }
                }
                Console.WriteLine("\nExit? (y/n)"); 
                if(Console.ReadLine().ToLower() == "y") { exit = true;}
            }
        }
        catch (Exception)
        {
            Console.WriteLine("ERROR");
        }
    }

}