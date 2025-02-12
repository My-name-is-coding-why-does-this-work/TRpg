using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Numerics; // 추가
using System.Text;
using System.Threading.Tasks;

namespace TRpg
{
    public class Inventory 
    {
        private List<Item> inventoryItem;

        public static Inventory inventory; // 싱글톤 -> 수정 : 인벤토리로 이름 수정
        public static Inventory Instance()
        {
            if (inventory == null)
            {
                inventory = new Inventory(); // 새로운 인스턴스 생성
            }
            return inventory;
        }

        public Inventory() // 추가된 아이템 이름을 출력
        {
            inventoryItem = new List<Item>(); // 아이템을 저장할 빈 리스트를 초기화
        }

        public void AddItem(Item item)
        {
            inventoryItem.Add(item); // 인벤토리 리스트에 아이템을 추가
            Console.WriteLine($"{item.Name}이(가) 인벤토리에 추가되었습니다."); //아이템 장착을 알려줌
        }

        public void RemoveItem(Item item)
        {
            if (inventoryItem.Remove(item)) // 아이템이 인벤토리에서 성공적으로 제거되었을 경우
            {
                Console.WriteLine($"{item.Name}이(가) 인벤토리에서 제거되었습니다.");
            }
            else
            {
                Console.WriteLine($"{item.Name}이(가) 인벤토리에 없습니다.");
            }
        }

        public void EquipItem(Item item, Player player)
        {
            if (inventoryItem.Contains(item) && !item.IsEquipped)
            {
                item.IsEquipped = true; // 아이템을 장착 상태로 설정

                // 장착한 아이템에 따른 상태 반영
                if (item.Type == ItemType.Weapon)
                {
                    player.Attack += item.Attack;  // 플레이어의 공격력 증가
                }
                else if (item.Type == ItemType.Armor)
                {
                    player.Defense += item.Defense;  // 플레이어의 방어력 증가
                }

                Console.WriteLine($"{item.Name}이(가) 장착되었습니다."); // 장착 완료 메시지 출력
                ShowInventory(player); // 인벤토리 화면을 다시 표시
            }
            else
            {
                Console.WriteLine($"{item.Name}이(가) 인벤토리에 없거나 이미 장착되어 있습니다."); // 아이템이 인벤토리에 없거나 이미 장착된 경우
            }
        }

        public void UnequipItem(Item item, Player player) // 아이템 해제 관리
        {
            if (inventoryItem.Contains(item) && item.IsEquipped) // 아이템이 인벤토리에 있고, 이미 장착되어 있는 경우
            {
                item.IsEquipped = false; // 아이템을 장착 해제 상태로 설정

                // 장착 해제 시, 아이템의 영향을 반영
                if (item.Type == ItemType.Weapon)
                {
                    player.Attack -= item.Attack;  // 플레이어의 공격력 감소
                }
                else if (item.Type == ItemType.Armor)
                {
                    player.Defense -= item.Defense;  // 플레이어의 방어력 감소
                }

                Console.WriteLine($"{item.Name}이(가) 장착 해제되었습니다."); // 장착 해제 메시지 출력
            }
            else
            {
                Console.WriteLine($"{item.Name}이(가) 인벤토리에 없거나 이미 장착 해제되어 있습니다.");
            }
        }

        public void ShowInventory(Player player) // 플레이어의 인벤토리 표시
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("\n===== 인벤토리 =====");

                // 인벤토리가 비어있는지 확인
                if (inventoryItem.Count == 0)
                {
                    Console.WriteLine("인벤토리에 아이템이 없습니다.");
                }
                else
                {
                    // 아이템 리스트 출력
                    int i = 1;
                    foreach (var item in inventoryItem)
                    {
                        Console.Write($"{i} ");
                        item.ItemStatus();
                        i++;
                    }
                    Console.WriteLine("장착할 아이템 번호를 입력해주세요.");
                    Console.WriteLine();
                }

                Console.WriteLine("\n0. 메인 화면으로 돌아가기");

                string input = Console.ReadLine();

                // 0번을 입력하면 메인 화면으로 돌아가도록
                if (input == "0")
                {
                    Program.Town(player); // 메인 화면으로 돌아가기
                    break;  // ShowInventory 종료
                }
                else
                {
                    int num = 0;
                    if (int.TryParse(input, out num) && num - 1 >= 0 && num - 1 < inventoryItem.Count)
                    {
                        // 아이템 장착/해제 처리
                        if (inventoryItem[num - 1].IsEquipped == false)
                        {
                            EquipItem(inventoryItem[num - 1], player);  // 아이템 장착
                        }
                        else
                        {
                            UnequipItem(inventoryItem[num - 1], player); // 아이템 해제
                        }
                    }
                    else
                    {
                        Console.WriteLine("잘못된 입력입니다. 다시 선택해주세요.");
                    }
                }
            }
        }
    }
}