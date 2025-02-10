using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;

public interface ICharacter
{
    public bool IsDead { get; set; }
    public int Lv { get; set; }
    public string Name { get; set; }
    public string IClass { get; set; }
    public int Attack { get; set; }
    public int Defense { get; set; }
    public int Health { get; set; }
    public int Gold { get; set; }
    //public void Status();
}

public class Skill
{
    public string Name { get; set; }
    public int ManaCost { get; set; }
    public int Damege {  get; set; }
    public bool Mul {  get; set; }

    public Skill(string name, int manaCost, int damege, bool mul)
    {
        Name = name;
        ManaCost = manaCost;
        Damege = damege;
        Mul = mul;
    }
}

public class Player : ICharacter
{
    public bool IsDead { get; set; }
    public int Lv { get; set; }
    public string Name { get; set; }
    public string IClass { get; set; }
    public int Attack { get; set; }
    public int Defense { get; set; }
    public int Health { get; set; }
    public int Mana { get; set; }
    public int Gold { get; set; }
    public List<Skill> SkillList { get; set; }
    

    public Player(string name, int lv, int attack, int defense, int health, int mana, int gold, string iClass)
    {
        Name = name;
        Lv = lv;
        Attack = attack;
        Defense = defense;
        Health = health;
        Mana = mana;
        Gold = gold;
        IClass = iClass;
        IsDead = false;
        SkillList = new List<Skill>();
    }
    public void AddSkill(Skill skill)
    {
        SkillList.Add(skill);
    }
    public void PlayerStatus()
    {
        Console.WriteLine($"레벨: {Lv}");
        Console.WriteLine($"이름: {Name}");
        Console.WriteLine($"직업: {IClass}");
        Console.WriteLine($"공격력: {Attack}");
        Console.WriteLine($"방어력: {Defense}");
        Console.WriteLine($"체력: {Health}");
        Console.WriteLine($"마나: {Mana}");
        Console.WriteLine($"골드: {Gold}G");

        Console.WriteLine("\n[스킬]");
        //추가된 스킬 출력
        for ( int i = 0; i < SkillList.Count; i++ )
        {
            Console.WriteLine($"{SkillList[i].Name} 마나 소모 {SkillList[i].ManaCost} 데미지 {SkillList[i].Damege}");
        }
    }
}


public class Monster : ICharacter
{
    public bool IsDead { get; set; }
    public int Lv { get; set; }
    public string Name { get; set; }
    public string IClass { get; set; }
    public int Attack { get; set; }
    public int Defense { get; set; }
    public int Health { get; set; }
    public int Gold { get; set; }

    public Monster(string name, int lv, int attack, int defense, int health, int gold, string iClass)
    {
        Name = name;
        Lv = lv;
        Attack = attack;
        Defense = defense;
        Health = health;
        Gold = gold;
        IClass = iClass;
        IsDead = false;
    }

    public void MonsterStatus()
    {
        Console.WriteLine($"레벨: {Lv}");
        Console.WriteLine($"이름: {Name}");
        Console.WriteLine($"체력: {Health}");
        Console.WriteLine($"공격력: {Attack}");
    }
}

