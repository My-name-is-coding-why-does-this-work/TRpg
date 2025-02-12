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
            Console.Write($"    |   장비 : {Type}");
            if (Type == ItemType.Weapon) Console.Write($"   |   공격력: {Attack}");
            else if (Type == ItemType.Armor) Console.Write($"   |   방어력: {Defense}");
            else if (Type == ItemType.Test) Console.Write($"    |   공격력: {Attack} |   방어력: {Defense}");
            Console.WriteLine($"    |    {Description}");
        }

    }
    public class ItemList // 아이템리스트
    {
            public List<Item> itemLists = new List<Item>();
        public ItemList() // 수정 : 가격 수정
        {
            itemLists.Add(new Item("단검", ItemType.Weapon , 10 , 0 , 100 , "수련용 단검."));
            itemLists.Add(new Item("천갑옷", ItemType.Armor, 0 , 15 , 100 , "평범한 천갑옷."));
            itemLists.Add(new Item("롱소드", ItemType.Weapon , 20 , 0 , 1000 , "평범한 롱소드."));
            itemLists.Add(new Item("몰락한 왕의 검", ItemType.Weapon , 30 , 0 , 1500 , "몰락한 왕의 검이다 불길한 기운이 든다."));
            itemLists.Add(new Item("브라움의 방패", ItemType.Armor , 0 , 20 , 1000 , "자세히 보면 문인것 같다..."));
        }
    }
}
