using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipGame
{
    class Ship
    {
        Tile OuterTile;
        Tile InnerTile;
        public int Speed { get; set; }
        public int Power { get; set; }
        public int Defense { get; set; }

        public Ship(int speed, int power, int defense)
        {
            this.Speed = speed;
            this.Power = power;
            this.Defense = defense;

            OuterTile = new Tile(0, 0);
            InnerTile = new Tile(0, 0);
        }
    }
}
