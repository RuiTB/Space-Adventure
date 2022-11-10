using UnityEngine;
using UnityEngine.Analytics;

namespace Assets.Scripts
{
    public class NewGame : MonoBehaviour
    {
        public Profile Player1;
        public Profile Player2;

        public Sprite Default1Sprite;
        public Sprite Default2Sprite;

        void Awake()
        {
            if (Database.Profiles.Count > 0)
                return;
            Database.Profiles.Add(new Profile("default1", 20, "Red", Gender.Male, Database.ShipSprites[0].name));
            Database.Profiles.Add(new Profile("default2", 20, "Purple", Gender.Female, Database.ShipSprites[1].name));
        }

        public void Play()
        {
            if (Player1 != null && Player2 != null)
            {
                Database.Games.Add(new Game(Player1, Player2, Database.Games.Count + 1));
                StartCoroutine(Loading.Load("Game"));
            }
        }
    }
}