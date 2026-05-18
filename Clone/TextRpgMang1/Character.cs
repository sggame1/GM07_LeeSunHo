using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRpgMang1
{
    class Character
    {
        public string name { get; set; }
        public int level { get; set; } = 1;
        public int maxHp { get; set; }
        public int hp { get; set; }
        public int damagead { get; set; }
        public int damageap { get; set; }
        public List<Skill> skills { get; set; } = new List<Skill>();
        public Dictionary<int, Item> Inventory { get; set; } = new Dictionary<int, Item>();
        public Character(string name)
        {
            this.name = name;
            this.maxHp = 150;
            this.hp = maxHp;
            this.damagead = 15;
            this.damageap = 15;
            skills.Add(new PowerStrike("파워 스트라이크"));
            skills.Add(new SlashBlast("슬래쉬 블래스트"));
            skills.Add(new MagicBolt("매직 볼트"));
            skills.Add(new MagicSlash("매직 슬래쉬"));
            Inventory[1] = new Potion("회복 포션");
            Inventory[2] = new Boom("폭탄");
            Inventory[3] = new Stone("강화의 돌");            
        }
        public void UseSkill(int skillSlot, Monster monster)
        {
            if (skillSlot <= 2)
            {
                skills[skillSlot].Attack(monster, damagead);
            }
            else if (skillSlot < 2)
            {
                skills[skillSlot].Attack(monster, damageap);
            }
        }
    }
}
