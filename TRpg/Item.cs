using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TRpg
{
    public enum ItemType
    {
        Weapon,
        Armor
    }
    public class Item
    {
        public string Name { get; }
        public ItemType Type { get; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        public int Gold { get; set; }
        public bool IsEquipped { get; set; }  // 장착 상태를 나타내는 속성

        public Item(string name, ItemType type, int attack, int defense, int gold)
        {
            Name = name;
            Type = type;
            Attack = attack;
            Defense = defense;
            Gold = gold;
            IsEquipped = false;  // 초기 장착 상태는 false로 설정
        }

        public void ItemStatus()
        {
            Console.WriteLine($"이름: {Name} {(IsEquipped ? "[E]" : "")}");
            Console.WriteLine($"타입: {Type}");
            Console.WriteLine($"공격력: {Attack}");
            Console.WriteLine($"방어력: {Defense}");
            Console.WriteLine($"골드: {Gold}G");
        }
    }
}
