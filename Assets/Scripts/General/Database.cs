using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts
{
    public static class Database
    {
        public static SortedSet<Profile> Profiles = new();
        public static List<Game> Games = new();
        public static List<Sprite> ShipSprites;
        public static List<string> Colors;
        public static List<Sprite> BullitSprites;

        static Database()
        {
            Colors = new List<string> { "Blue", "Purple", "Red", "Orange", "Yellow", "Green" };
            ShipSprites = Resources.LoadAll<Sprite>("Sprites/Gameplay/SpaceShip").ToList();
            BullitSprites = Resources.LoadAll<Sprite>("Sprites/Gameplay/LaserSprites").ToList();
        }
    }
}