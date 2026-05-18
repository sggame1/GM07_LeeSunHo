using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRpgMang1
{
    class Monster
    {
        public string name { get; set; }
        public int hp { get; set; }
        public int damage { get; set; }

        public Monster(string name, int hp, int damage)
        {
            this.name = name;
            this.hp = hp;
            this.damage = damage;
        }
        public void Attack(Character character)
        {
            character.hp -= damage;
            Console.WriteLine($"{name}이(가) {damage}를 입혔습니다.");
        }
    }

}
