public class Client
{
    private Shop _shop;

    private User _user;

    private Newlyweds _newlyweds;

    private Gift _gift;

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
            
        }
        catch (Exception)
        {
            Console.WriteLine("Insert a valid value");
        }
        return null;
    }




/*------------------- newlyweds - shop -------------------*/





    private string NameTheList(){
        
        Console.WriteLine("Chose the name of your list : ");
        return Console.ReadLine();
    }

    private int ChoseGift(){

        Console.WriteLine("Enter the number of the gift to add it in your list : ");
        return Convert.ToInt32(Console.ReadLine());
    }

    private void CreateNewWeddingList(){

        string? nameList = NameTheList();
        if(nameList == null){
            return;
        }else{
            _newlyweds.CreateList(nameList);
        }
       
       bool keepAddGift = true;

        while(keepAddGift){
            
                Console.WriteLine();
                Console.WriteLine("ADD NEW GIFTS IN YOUR LIST");
                Console.WriteLine();
                Console.WriteLine("These are the gifts that can be bought :");
                Console.WriteLine();
                Console.WriteLine();
                _shop.ShowShopGifts();
                
                try{

                    int indexGift = ChoseGift();
                    _gift = _shop.TakeGift(indexGift);

                    _newlyweds.AddGift(nameList, _gift.Name, _gift);
                    Console.WriteLine();
                    Console.WriteLine("SELECTED GIFT SUCCESSFULLY ADDED IN YOUR WEDDING LIST");
                    Console.WriteLine();

                    Console.WriteLine("Do you wanna add an other gift in your wedding list? y/n");
                    switch(Console.ReadLine()){
                        case "y":
                        Console.WriteLine();
                            break;
                        default:
                            keepAddGift = false;
                            break;
                    }

                }catch(Exception){
                    Console.WriteLine();
                    Console.WriteLine("Invalid input");
                    Console.WriteLine();
                }
        }

        _newlyweds.AddNewlyWedsList(_newlyweds, nameList, _newlyweds.NewlyWedsLists, _shop);
        Console.WriteLine();
        Console.WriteLine("THE WEDDING LIST IS SUCCESSFULLY SAVED!");
        Console.WriteLine();

    }

    private void AddGiftToExistingList(){

        string? nameList = NameTheList();

        if(_shop.WeddingList.ContainsKey(_newlyweds) && _shop.WeddingList[_newlyweds].ContainsKey(nameList)){

            bool keepAddGift = true;

            while(keepAddGift){
                Console.WriteLine();
                Console.WriteLine("ADD NEW GIFTS IN YOUR LIST");
                Console.WriteLine();
                Console.WriteLine("These are the gifts that can be bought :");
                Console.WriteLine();
                Console.WriteLine();
                _shop.ShowShopGifts();
                
                try{

                    int indexGift = ChoseGift();
                    _gift = _shop.TakeGift(indexGift);
                    Console.WriteLine();
                    _newlyweds.AddGift(nameList, _gift.Name, _gift);
                    Console.WriteLine("SELECTED GIFT SUCCESSFULLY ADDED IN YOUR WEDDING LIST");
                    Console.WriteLine();
                    Console.WriteLine("Do you wanna add an other gift in your wedding list? y/n");
                    switch(Console.ReadLine()){
                        case "y":
                        Console.WriteLine();
                            break;
                        default:
                            keepAddGift = false;
                            break;
                    }

                }catch(Exception){
                    Console.WriteLine("Invalid input");
                }
        }

        }
        else{
            Console.WriteLine("There is not a wedding list called " + nameList);
        }
    }



    public Client(Shop shop, User user)
    {
        _user = user;
        _shop = shop;
        UserMenu();
    }

     public Client(Shop shop, Newlyweds newlyweds){
        _newlyweds = newlyweds;
        _shop = shop;
        NewlywedsMenu();
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

    public void NewlywedsMenu(){
        
        bool keepModifyWeddingList = true;

        while(keepModifyWeddingList){

            Console.WriteLine("Press '0' to create a new list, '1' to add gifts to an already existing list, 'z' to exit");
            switch(Console.ReadLine()){

            case "0":
            Console.WriteLine();
            CreateNewWeddingList();
                break;

            case "1":
            Console.WriteLine();
            AddGiftToExistingList();
                break;

            case "z":
                Console.WriteLine();
                keepModifyWeddingList = false;
                break;

            default:
                Console.WriteLine("Invalid input");
                Console.WriteLine();
                break;
            }
        }
    }

}