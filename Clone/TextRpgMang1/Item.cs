using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRpgMang1
{
    enum ItemType
    {
        potion,
        boom,
        stone,
    }
    abstract class Item
    {
        public string name { get; set; }
        public int count { get; set; }
        public ItemType itemType { get; set; }
    }
    class Potion : Item
    {
        public int heal { get; set; }
        public Potion(string name)
        {
            this.name = name;
            this.count = 1;
            this.heal = 50;
            this.itemType = ItemType.potion;
        }
    }
    class Boom : Item
    {
        public int damage { get; set; }
        public Boom(string name)
        {
            this.name = name;
            this.count = 1;
            this.damage = 50;
            this.itemType = ItemType.boom;
        }
    }
    class Stone : Item
    {
        public Stone(string name)
        {
            this.name = name;
            this.count = 1;
            this.itemType = ItemType.stone;
        }
    }
}
