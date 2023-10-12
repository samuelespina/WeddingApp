using System;

public class Newlyweds
{
    private ushort _id;
    private User _wife;
    private User _husband;
    private Dictionary<string, GiftList> _newlyWedsLists;

    public Dictionary<string, GiftList> NewlyWedsLists { get => _newlyWedsLists; }

    public ushort Id { get => _id; }

    public User Husband { get => _husband; }
    
    public User Wife { get => _husband; }


    public Newlyweds(ushort id, User wife, User husband)
    {
        _id = id;
        _husband = husband;
        _wife = wife;
        _newlyWedsLists = new Dictionary<string, GiftList>();
    }

    public void CreateList(string namelist)
    {
        if (!_newlyWedsLists.ContainsKey(namelist))
        {
            _newlyWedsLists[namelist] = new GiftList();
        }
        else
        {
            Console.WriteLine("The list already exist!");
        }
    }

    public void AddGift(string nameList, string ProductName, Gift gift)
    {
        _newlyWedsLists[nameList].AddGift(gift.Name, gift);
    }

    public void AddNewlyWedsList(Newlyweds newlyweds, string nameList, Dictionary<string, GiftList> weddinglist, Shop shop)
    {

        shop.AddNewlyWedsList(newlyweds, nameList, weddinglist);

    }

    public void PrintAllGiftLists()
    {
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine("These are the gifts on your wedding list :");
        Console.WriteLine();

        foreach (var nameList in _newlyWedsLists)
        {
            Console.WriteLine("WEDDING LIST NAME : " + nameList.Key);
            Console.WriteLine();
            Console.WriteLine("GIFT IN YOUR WEDDING LIST:");

            foreach (var giftEntry in nameList.Value._giftList)
            {
                Console.WriteLine("Product: " + giftEntry.Value.ToString());
                Console.WriteLine();
            }
        }
    }

}