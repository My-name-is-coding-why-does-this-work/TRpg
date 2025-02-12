using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRpg
{
    public enum ItemType
    {
        Weapon = 1,
        Armor,
        Test
    }
    
    public class Item
    {
        public string Name { get; }
        public ItemType Type { get; }
        public int Attack { get; private set; } // private 추가
        public int Defense { get; set; }
        public int Gold { get; set; }
        public bool IsEquipped { get; set; }  // 장착 상태를 나타내는 속성
        public string Description { get; set; } // 아이템 설명

        public Item(string name, ItemType type, int attack, int defense, int gold, string description)
        {
            Name = name;
            Type = type;
            Attack = attack;
            Defense = defense;
            Gold = gold;
            IsEquipped = false;  // 초기 장착 상태는 false로 설정
            Description = description;
        }

        public void ItemStatus()// 아이템 인터페이스
        {
            Console.Write($" {(IsEquipped ? "[E]" : "")}  {Name}");
            Console.Write($"| 타입: {Type}");
            if (Type == ItemType.Weapon) Console.Write($" | 공격력: {Attack}");
            else if (Type == ItemType.Armor) Console.Write($" | 방어력: {Defense}");
            else if (Type == ItemType.Test) Console.Write($" | 공격력: {Attack} | 방어력: {Defense}");
            Console.WriteLine($" | {Description}");
        }

    }
    public class ItemList // 아이템리스트
    {
            public List<Item> itemLists = new List<Item>();
        public ItemList()
        {
            itemLists.Add(new Item("단검", ItemType.Weapon, 10, 0, 0, "수련용 단검이다."));
            itemLists.Add(new Item("천갑옷", ItemType.Armor, 0, 15, 0, "평범한 천갑옷이다."));
            itemLists.Add(new Item("롱소드", ItemType.Weapon, 20, 0, 1000, "평범한 롱소드다."));
            itemLists.Add(new Item("몰락한 왕의 검", ItemType.Weapon, 30, 0, 1000, "몰락한 왕의 검이다 불길한 기운이 든다."));
            itemLists.Add(new Item("낡은 방패", ItemType.Armor, 0, 10, 1000, "평범한 방패다."));
        }
    }
}
