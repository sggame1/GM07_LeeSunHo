using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRpgMang1
{
    interface Iutil
    {
        void Levelup();
        int ShowDamage();
    }
    abstract class Skill : Iutil
    {
        public string name { get; set; }
        protected int skillDamage { get; set; }
        protected int skillLevel { get; set; }
        public abstract void Attack(Monster monster, int damage);

        public void Levelup()
        {
            this.skillLevel++;
        }
        public int ShowDamage()
        {
            return skillDamage;
        }
    }

    class PowerStrike : Skill
    {
        public PowerStrike(string name)
        {
            this.name = name;
            this.skillLevel = 1;
            skillDamage = 5;
        }
        public override void Attack(Monster monster, int damage)
        {
            int hap = skillDamage * skillLevel + damage;
            monster.hp -= hap;
            Console.WriteLine($"{monster.name}에게 {hap}의 데미지를 주었습니다.");
        }
    }
    class SlashBlast : Skill
    {
        Random rand = new Random();
        public SlashBlast(string name)
        {
            this.name = name;
            this.skillLevel = 1;
            skillDamage = 3;
        }
        public override void Attack(Monster monster, int damage)
        {
            int cri = rand.Next(1, 100); 
            int hap = skillDamage * skillLevel + damage;            
            if (cri < 30)
            {
                hap *= 2;
                Console.WriteLine("크리티컬 !");
            }
            monster.hp -= hap;
            Console.WriteLine($"{monster.name}에게 {hap}의 데미지를 주었습니다.");
        }
    }
    class MagicBolt : Skill
    {
        public MagicBolt(string name)
        {
            this.name = name;
            this.skillLevel = 1;
            skillDamage = 5;
        }
        public override void Attack(Monster monster, int damage)
        {
            int hap = skillDamage * skillLevel + damage;
            monster.hp -= hap;
            Console.WriteLine($"{monster.name}에게 {hap}의 데미지를 주었습니다.");
        }
    }
    class MagicSlash : Skill
    {
        Random rand = new Random();
        public MagicSlash(string name)
        {
            this.name = name;
            this.skillLevel = 1;
            skillDamage = 3;
        }
        public override void Attack(Monster monster, int damage)
        {
            int cri = rand.Next(1, 100 - (skillLevel * 5));
            int hap = skillDamage * skillLevel + damage;
            if (cri < 30)
            {
                hap *= 2;
                Console.WriteLine("크리티컬 !");
            }
            monster.hp -= hap;
            Console.WriteLine($"{monster.name}에게 {hap}의 데미지를 주었습니다.");
        }
    }
}
