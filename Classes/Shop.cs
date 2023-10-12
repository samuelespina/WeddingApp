using System;
using System.Xml;

public class Shop
{
    private string _shopName;

    private Dictionary<Newlyweds, Dictionary<string, GiftList>> _weddingList;

    private Dictionary<ushort, Newlyweds> _newlyweds;

    private List<Gift> _shopGifts = new List<Gift>();

    public string ShopName { get => _shopName; }

    public Shop(string shopName)
    {
        _weddingList = new Dictionary<Newlyweds, Dictionary<string, GiftList>>();
        _newlyweds = new Dictionary<ushort, Newlyweds>();
        _shopName = shopName;
    }



    public void ShowShopGifts(){
        for(int i = 0; i < _shopGifts.Count; i++){
            Console.Write((i+1) +  " ");
            Console.Write(_shopGifts[i].ToString());
            Console.WriteLine();
            Console.WriteLine();
        }
    }

    public Gift TakeGift(int index){
        Gift selectedGift = _shopGifts[index-1];
        _shopGifts.RemoveAt(index-1);
        return selectedGift;
    }

    public void AddNewlyWedsList(Newlyweds newlyweds, string nameList, Dictionary<string, GiftList> weddinglist){//6

        _weddingList[newlyweds] = weddinglist;
    }

    public void ShowAll(){
        foreach(var newlyweds in _weddingList){
            Console.WriteLine(newlyweds.Key);
            foreach(var nameList in newlyweds.Value){
                Console.WriteLine("   " + newlyweds.Key);
                foreach(var gift in nameList.Key){
                    Console.WriteLine("      " + gift.ToString());
                }
            }
            Console.WriteLine("");
        }
    }





    public void ShowNewlyWeds()
    {
        foreach (var newlyweds in _newlyweds)
        {
            Console.WriteLine(newlyweds.Value);
        }
    }

    public Newlyweds TakeNewlyWeds(ushort id)
    {
        if (!_newlyweds.ContainsKey(id))
        {
            throw new NewlyWedsNotFoundException($"{id} not Found!");
        }
        return _newlyweds[id];
    }

    public void ShowNewlyWedsLists(Newlyweds newlyweds)
    {
        var newlywedsList = _weddingList[newlyweds];
        foreach (string key in newlywedsList.Keys)
        {
            Console.WriteLine(key + "\n");
        }
    }

    public GiftList TakeWeddingList(Newlyweds newlyweds, string nameList)
    {
        if (!_weddingList[newlyweds].ContainsKey(nameList))
        {
            throw new GiftListNotFoundException($"{nameList} not Found!");
        }
        return _weddingList[newlyweds][nameList];
    }

    public Gift BuyGift(GiftList giftList, Gift gift)
    {
        try
        {
            Gift returnGift = giftList.TakeGift(gift.Name);
            giftList.RemoveGift(gift);
            return returnGift;
        }
        catch (GiftNotFoundException e)
        {
            Console.WriteLine(e);
            throw new Exception();
        }
    }

    public void InsertIntoInventory(Gift gift) { _shopGifts.Add(gift); }

    public void InsertIntoNewlyweds(Newlyweds newlyweds) { _newlyweds.Add(newlyweds.Id, newlyweds); }
}