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
        private List<Item> items;

        public Inventory()
        {
            items = new List<Item>();
        }

        public void AddItem(Item item)
        {
            items.Add(item);
            Console.WriteLine($"{item.Name}이(가) 인벤토리에 추가되었습니다.");
        }

        public void RemoveItem(Item item)
        {
            if (items.Remove(item))
            {
                Console.WriteLine($"{item.Name}이(가) 인벤토리에서 제거되었습니다.");
            }
            else
            {
                Console.WriteLine($"{item.Name}이(가) 인벤토리에 없습니다.");
            }
        }

        public void EquipItem(Item item)
        {
            if (items.Contains(item) && !item.IsEquipped)
            {
                item.IsEquipped = true;
                Console.WriteLine($"{item.Name}이(가) 장착되었습니다.");
            }
            else
            {
                Console.WriteLine($"{item.Name}이(가) 인벤토리에 없거나 이미 장착되어 있습니다.");
            }
        }

        public void UnequipItem(Item item)
        {
            if (items.Contains(item) && item.IsEquipped)
            {
                item.IsEquipped = false;
                Console.WriteLine($"{item.Name}이(가) 장착 해제되었습니다.");
            }
            else
            {
                Console.WriteLine($"{item.Name}이(가) 인벤토리에 없거나 이미 장착 해제되어 있습니다.");
            }
        }

        public void ShowInventory()
        {
            Console.WriteLine("\n===== 인벤토리 =====");
            if (items.Count == 0)
            {
                Console.WriteLine("인벤토리에 아이템이 없습니다.");
            }
            else
            {
                foreach (var item in items)
                {
                    item.ItemStatus();
                }
            }
            Console.WriteLine("====================");
        }
    }
}

