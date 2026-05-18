using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TextRpgMang1
{
    class Program
    {
        static Random rand = new Random();
        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("===============================================");
            Console.WriteLine("                텍스트 RPG 시작                ");
            Console.WriteLine("===============================================");

            Character character = new Character("모험가");
            Battle battle = new Battle();

            Console.WriteLine("\n엔터를 눌러시작...");
            Console.ReadLine();
            List<Monster> monsters = new List<Monster>
            {
                new Monster("슬라임", 60, 20),   
                new Monster("오크", 100, 20), 
                new Monster("드레이크", 150, 30),     
                new Monster("보스 : 드래곤", 300, 50)
            };         

            int stage = 1;
            foreach (Monster monster in monsters)
            {
                Console.Clear();
                Console.WriteLine("==============================================");
                Console.WriteLine($"               [STAGE {stage}]               ");
                Console.WriteLine("==============================================");
                Console.WriteLine("\n무언가 느껴진다.");
                Console.WriteLine("엔터를 눌러 조우합니다...");
                Console.ReadLine();

                battle.StartBattle(character , monster);
                Console.Clear();
                Console.WriteLine($"\n스테이지 {stage}를 클리어 했습니다!");
                Reward(character);

                Console.WriteLine("\n엔터를 눌러 이동");
                Console.ReadLine();
                stage++;
            }
            Console.Clear();
            Console.WriteLine("=====================================================");
            Console.WriteLine("                    - GAME CLEAR -                   ");
            Console.WriteLine("=====================================================");
            Console.ReadLine();
        }

        static void Reward(Character character)
        {
            Console.WriteLine("\n보상이 주어집니다.");
            Console.WriteLine("체력이 20만큼 증가합니다.\n무작위 아이템과 무작위 스탯이 지급됩니다.");
            character.hp += 20;
            int num = rand.Next(1, 4);
            character.Inventory[num].count++;
            Console.WriteLine($"보상 획득: {character.Inventory[num].name}을 1개 얻었습니다! (현재 보유: {character.Inventory[num].count}개)");
            num = rand.Next(1, 4);
            switch (num)
            {
                case 1:
                    character.maxHp += 5;
                    character.hp += 5;
                    Console.WriteLine($"보상 획득: 체력을 5 흭득했습니다.");
                    break;
                case 2:
                    character.damagead += 5;
                    Console.WriteLine($"보상 획득: 공격력을 5 흭득했습니다.");
                    break;
                case 3:
                    character.damageap += 5;
                    Console.WriteLine($"보상 획득: 주문력을 5 흭득했습니다.");
                    break;
            }            
        }
    }    
}
