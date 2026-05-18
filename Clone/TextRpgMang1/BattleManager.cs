using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRpgMang1
{
    class Battle
    {
        private Character character;
        private Monster monster;
        public void StartBattle(Character Character, Monster Monster)
        {
            this.character = Character;
            this.monster = Monster;

            Console.Clear();
            Console.WriteLine($"{monster.name}이(가) 나타났다!");
            Console.WriteLine("엔터를 눌러 전투 시작");
            Console.ReadLine();

            while (monster.hp > 0)
            {
                Clear();
                PlayerTurn(); 

                if (monster.hp > 0)
                {
                    monster.Attack(character);
                    Console.WriteLine("\n엔터를 눌러 다음 턴");
                    Console.ReadLine();

                    if(character.hp <= 0)
                    {
                        Console.WriteLine($"{character.hp}가 0이하가 되었습니다.\n사망합니다.");
                        Environment.Exit(0);
                    }
                }
            }

            if (monster.hp <= 0)
            {
                Console.WriteLine($"\n{monster.name}을(를) 물리쳤다!");
            }
        }
        private void Clear()
        {
            Console.Clear();
            Console.WriteLine( "=======================================");
            Console.WriteLine($"| [상대] {monster.name} (HP: {monster.hp}) (공격력: {monster.damage}) |");
            Console.WriteLine( "=======================================");
            Console.WriteLine($"| [자신] {character.name} (HP: {character.hp}/{character.maxHp})         |" +
                $"\n| (공격력: {character.damagead} 주문력: {character.damageap})             |");
            Console.WriteLine( "=======================================");
        }

        private void PlayerTurn()
        {
            bool isTurnEnded = false;

            while (!isTurnEnded)
            {
                Clear();
                Console.WriteLine("\n[ 무엇을 할까? ]");
                Console.WriteLine("1. 스킬 사용   2. 아이템");
                Console.WriteLine("3. 스킬 강화   4. 게임 종료");
                Console.Write("▶ 선택: ");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        isTurnEnded = SelectSkillMenu();
                        break;
                    case "2":
                        isTurnEnded = UseItemMenu();
                        break;
                    case "3":
                        isTurnEnded = UpGradeMenu();
                        break;
                    case "4":
                        Console.WriteLine("\n게임 종료 선택. 프로그램을 종료합니다.");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("잘못된 입력입니다. 다시 선택하세요.");
                        Console.ReadLine();
                        break;
                }
            }
        }

        private bool SelectSkillMenu()
        {
            Clear();
            Console.WriteLine($"\n[ {character.name}의 스킬 목록 ]");

            for (int i = 0; i < character.skills.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {character.skills[i].name}");
            }
            Console.WriteLine("5. 뒤로가기");
            Console.Write("▶ 선택: ");

            string input = Console.ReadLine();

            if (input == "5") return false; 

            if (int.TryParse(input, out int num) && num >= 1 && num <= 4)
            {
                character.UseSkill(num - 1, monster);
                Console.WriteLine("\n엔터를 누르면 몬스터의 턴으로 넘어갑니다");
                Console.ReadLine();
                return true; 
            }

            Console.WriteLine("올바른 숫자를 누르세요.");
            Console.ReadLine();
            return false;
        }
        private bool UseItemMenu()
        {
            Clear();
            Console.WriteLine("\n[ 가방 안의 아이템 ]");
            Console.WriteLine($"1. {character.Inventory[1].name} (HP +50) - 보유 개수: {character.Inventory[1].count}개");
            Console.WriteLine($"2. {character.Inventory[2].name} (적에게 50의 피해를 준다.) - 보유 개수: {character.Inventory[2].count}개");
            Console.WriteLine("3. 뒤로가기");
            Console.Write("▶ 선택: ");

            string input = Console.ReadLine();
            if (input == "3") return false;

            if (input == "1")
            {
                if (character.Inventory[1].count > 0)
                {
                    character.Inventory[1].count--; 
                    Potion potion = character.Inventory[1] as Potion;
                    character.hp = Math.Min(character.maxHp, character.hp + potion.heal);

                    Console.WriteLine($"\n{character.Inventory[1].name}을 사용했습니다! {character.name}의 HP가 {potion.heal} 회복되었습니다.");
                    Console.WriteLine($"-> 현재 HP: {character.hp}/{character.maxHp}");
                    Console.WriteLine("\n엔터를 누르면 몬스터의 턴으로 넘어갑니다");
                    Console.ReadLine();
                    return true; 
                }
                else
                {
                    Console.WriteLine($"\n{character.Inventory[1].name}이 부족하여 사용할 수 없습니다!");
                    Console.ReadLine();
                }
            }
            else if(input == "2")
            {
                if (character.Inventory[2].count > 0)
                {
                    character.Inventory[2].count--; 

                    Boom boom = character.Inventory[2] as Boom;

                    Console.WriteLine($"\n{character.Inventory[2].name}을 사용했습니다! {monster.name}에게 {boom.damage} 피해를 주었습니다.");
                    monster.hp = Math.Max(0, monster.hp - boom.damage);
                    Console.WriteLine($"\n{monster.name}의 체력 : {monster.hp}");
                    Console.WriteLine("\n엔터를 누르면 몬스터의 턴으로 넘어갑니다");
                    Console.ReadLine();
                    return true; 
                }
                else
                {
                    Console.WriteLine($"\n{character.Inventory[2].name}이 부족하여 사용할 수 없습니다!");
                    Console.ReadLine();
                }
            }
            return false;
        }
        private bool UpGradeMenu()
        {
            Clear();

            Console.WriteLine($"\n[ 스킬을 업그레이드 할 수 있는 강화의 돌이다. 보유 개수 {character.Inventory[3].count} ]");
            for (int i = 0; i < character.skills.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {character.skills[i].name}을(를) 강화한다.{character.skills[i].ShowDamage()}만큼 증가한다.");
            }
            Console.WriteLine("5. 뒤로가기");
            Console.Write("▶ 선택: ");

            string input = Console.ReadLine();
            if (input == "5") return false; 
            if (int.TryParse(input, out int num) && num >= 1 && num <= 4 && character.Inventory[3].count > 0)
            {
                character.skills[num - 1].Levelup();
                character.Inventory[3].count--;
                Console.WriteLine("\n강화를 성공했다!");
                Console.WriteLine("\n엔터를 누르면 몬스터의 턴으로 넘어갑니다");
                Console.ReadLine();
                return true; 
            }
            else
            {
                Console.WriteLine("\n강화의 돌이 부족하여 사용할 수 없습니다!");
                Console.ReadLine();
            }
            return false;
        }
    }
}
