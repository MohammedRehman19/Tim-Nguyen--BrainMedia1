using UnityEngine;
using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

// [Assets/Reimport iBoxDB.NET2.dll]
using iBoxDB.LocalServer;

public class UnityDBCSCustom : MonoBehaviour
{

	public AutoBox auto = null;
    public string _context;
   
    public List <string> levels = new List<string>();
    void Start ()
	{
		if (auto == null) {

			DB.Root (Application.persistentDataPath);

			DB db = new DB (5);
		
			db.GetConfig ().EnsureTable<Player> ("Player", "ID");
            db.GetConfig().EnsureTable<Item>("Item","name");

            {
				// [Optional]
				// if device has small memory & disk
				db.MinConfig ();
				// smaller DB file size
				db.GetConfig ().DBConfig.FileIncSize = 1;
			}

			auto = db.Open ();

		}
        getplayer();
		
	}

    void getplayer()
    {

        if (auto.SelectCount("from Player", 0) != 0)
        {
            for (int i = 0; i < 4; i++)
            {
                DrawToString(i);
            }
           

        }
        else
        {
            print("new User");
            addnewuser();
        }

      
    }

    void addnewuser()
    {
        var player = new Player
        {
            ID = 1,
            
            
        };
        auto.Insert("Player", player);
        

        var Item = new Item
        {
            name = "ComposedItem",
            selection1 = "",
            selection2 = "",
            selection3 = "",
            selection4 = ""
        };
        auto.Insert("Item", Item);
      
    }
    public void EnterNumber(int levelindex,string num)
    {
        levels[levelindex] += num;
      
        var selection1 = auto.SelectKey<Item>("Item", "ComposedItem");
        selection1.name = "ComposedItem";
        if (levelindex == 0)
        {
            selection1.selection1 = levels[levelindex];
        }
        else if (levelindex == 1)
        {
            selection1.selection2 = levels[levelindex];
        }
       else if (levelindex == 2)
        {
            selection1.selection3 = levels[levelindex];
        }
       else if (levelindex == 3)
        {
            selection1.selection4 = levels[levelindex];
        }
        auto.Update("Item", selection1);
            
        DrawToString(levelindex);

    }
    public void RemoveNumber(int levelindex, string num)
    {
        levels[levelindex] = num;

        var selection1 = auto.SelectKey<Item>("Item", "ComposedItem");
        selection1.name = "ComposedItem";
        if (levelindex == 0)
        {
            selection1.selection1 = levels[levelindex];
        }
        else if (levelindex == 1)
        {
            selection1.selection2 = levels[levelindex];
        }
        else if (levelindex == 2)
        {
            selection1.selection3 = levels[levelindex];
        }
        else if (levelindex == 3)
        {
            selection1.selection4 = levels[levelindex];
        }
        auto.Update("Item", selection1);

        DrawToString(levelindex);

    }
    void DrawToString (int levelindex)
	{
		_context = "";
		
		_context += "Player \r\n";
		foreach (Player player in auto.Select<Player>("from Player", 0)) {
			_context += player.ID +"_";
		}
        foreach (Item item in auto.Select<Item>("from Item", 0))
        {
            string s = "";
            if (levelindex == 0)
            {
              s = DB.ToString(item.selection1);
            }
            else if (levelindex == 1)
            {
              s = DB.ToString(item.selection2);
            }
            else if (levelindex == 2)
            {
                s = DB.ToString(item.selection3);
            }
            else if (levelindex == 3)
            {
                 s = DB.ToString(item.selection4);
            }
          
            _context += s;
            levels[levelindex] = s;

        }


    }
	//A Player, Normal class
	public class Player
	{
		public long ID;
       
    }
    public class Item 
    {
        public string name;
        public  string selection1;
        public string selection2;
        public string selection3;
        public string selection4;



    }

    // An Item, Dynamic class

}