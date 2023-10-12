using System;
using System.Numerics;

public class User : IBuy
{

    private uint _id;

    private string _name;

    private string _surname;

    private double _total = 0;

    private List<Gift> _bougthGifts = new List<Gift>();

    public User(uint id, string name, string surname)
    {
        _id = id;
        _name = name;
        _surname = surname;
    }

    public bool BuyGift(Shop shop, GiftList giftList, Gift gift)
    {
        try
        {
            _bougthGifts.Add(shop.BuyGift(giftList, gift));
            _total += gift.Price;
            return true;
        }
        catch
        {
            return false;
        }
    }

    public override string ToString() { return $"{_name} {_surname}"; }

    public string ToString(bool verify)
    {
        string chartToString = "";
        foreach (Gift gift in _bougthGifts) { chartToString += gift.ToString() + ", "; }
        return $"{_name} {_surname} chart: {chartToString} => chart total = {_total}€";
    }
}