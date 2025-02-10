using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRpg
{
    public class Inventory
    {
        List<Item> itemList;
        Player player;
        Inventory inventory;

        public Inventory()
        {
            inventory = new Inventory();
            List<Item> itemList = new List<Item>
            {
            new Item("검", ItemType.Weapon,5, 0, 100),
            new Item("방패",ItemType.Weapon, 10, 0, 100),
            new Item("갑옷", ItemType.Weapon, 10, 0, 100),
            };

            foreach (var item in itemList)
            {
                inventory.AddItem(item);
            }

        }
    
    
    public void ShowInventory()
        {
            Console.WriteLine("\n===== 인벤토리 =====");
            if (itemList.Count == 0)
            {
                Console.WriteLine("인벤토리에 아이템이 없습니다");
            }
            else
            {
                foreach(var item in itemList)
                {
                    item.ItemStatus();
                }
            }
            Console.WriteLine();
        }
    }
}

