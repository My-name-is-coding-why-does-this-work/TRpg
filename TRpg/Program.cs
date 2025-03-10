﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TRpg;


internal class Program
{

    static void Main(string[] args)
    {
        Player player = new Player("코난", 1, 10, 5, 100, 1500, "전사"); //수정 : player를 Main 안으로
        
        StartMessage(player); //수정 : 매개 변수 추가

    }

    static public void StartMessage(Player player) // 수정 : 매개변수, public 메소드로
    {
        Console.Clear();
        Console.WriteLine("***** 스파르타 던전에 오신것을 환영합니다! *****");
        Console.WriteLine("1. 상태 보기");
        Console.WriteLine("2. 전투 시작");
        Console.WriteLine("원하시는 행동을 입력해주세요.");

        while (true)
        {
            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    Console.Clear();
                    player.PlayerStatus();
                    Console.WriteLine("1. 상태 보기");
                    Console.WriteLine("2. 전투 시작");
                    break;
                case "2":
                    Console.WriteLine("전투를 시작합니다!");
                    Console.ReadKey();
                    Battle battle = new Battle(player);
                    battle.BattleStart();
                    break;
                default:
                    Console.WriteLine("잘못된 입력입니다.");
                    break;
            }

            Console.WriteLine("원하시는 행동을 입력해주세요.");
        }
    }
}