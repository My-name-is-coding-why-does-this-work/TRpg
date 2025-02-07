using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

public class Player
{
    public int Lv { get; set; }
    public string Name { get; set; }
    public string Job { get; set; }
    public int Attack { get; set; }
    public int Defense { get; set; }
    public int Health { get; set; }
    public int Gold { get; set; }

    public void PlayerStatus()
    {
        Console.WriteLine($"레벨: {Lv}");
        Console.WriteLine($"이름: {Name}");
        Console.WriteLine($"직업: {Job}");
        Console.WriteLine($"공격력: {Attack}");
        Console.WriteLine($"방어력: {Defense}");
        Console.WriteLine($"체력: {Health}");
        Console.WriteLine($"골드: {Gold}G");
    }
}
public class Monster
    {
        public int Lv { get; set; }
        public string Name { get; set; }
        public int Health { get; set; }
        public int Attack { get; set; }
        public void MonsterStatus()
        {
            Console.WriteLine($"레벨: {Lv}");
            Console.WriteLine($"이름: {Name}");
            Console.WriteLine($"체력: {Health}");
            Console.WriteLine($"공격력: {Attack}");
        }
    }


