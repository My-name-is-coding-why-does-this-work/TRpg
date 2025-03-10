﻿using System;
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


public class Player : ICharacter
{
    public bool IsDead { get; set; }
    public int Lv { get; set; }
    public string Name { get; set; }
    public string IClass { get; set; }
    public int Attack { get; set; }
    public int Defense { get; set; }
    public int Health { get; set; }
    public int Gold { get; set; }

    public Player(string name, int lv, int attack, int defense, int health, int gold, string iClass)
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
    public void PlayerStatus()
    {
        Console.WriteLine($"레벨: {Lv}");
        Console.WriteLine($"이름: {Name}");
        Console.WriteLine($"직업: {IClass}");
        Console.WriteLine($"공격력: {Attack}");
        Console.WriteLine($"방어력: {Defense}");
        Console.WriteLine($"체력: {Health}");
        Console.WriteLine($"골드: {Gold}G");
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

    public bool IsDeadCheck()
    {
        return Health <= 0;
    }

    public void DisplayStatus()
    {
        if (IsDeadCheck())
            Console.ForegroundColor = ConsoleColor.Red; // 사망 시 빨간색
        else
            Console.ForegroundColor = ConsoleColor.White; // 기본 색상

        Console.WriteLine($"{Name} - HP: {Health}");
        Console.ResetColor(); // 색상 초기화
    }
}

