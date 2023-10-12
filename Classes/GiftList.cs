using System;

public class GiftList
{
    public Dictionary<string, Gift> _giftList { get; private set; }

    public GiftList()
    {
        _giftList = new Dictionary<string, Gift>();
    }

    public void AddGift(string ProductName, Gift gift){
        _giftList.Add(ProductName, gift);
    }

    public void ShowList()
    {
        foreach (var giftName in _giftList)
        {
            Console.Write("\n" + giftName.Value + "\n");
        }
    }

    public Gift TakeGift(string giftName)
    {
        if (_giftList.ContainsKey(giftName))
        {
            return _giftList[giftName];
        }
        else throw new GiftListNotFoundException($"{giftName} not found");
    }

    //Dovrebbe essere un oggetto Gift
    public bool RemoveGift(Gift gift)
    {
        if (_giftList.Remove(gift.Name)) return true;
        return false;
    }
}