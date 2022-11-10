using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class Statistics : MonoBehaviour
    {
        public Text Games, Profiles, HighestScore, LowestScore, MinimumD, MaximumD, TotalD;

        private void Awake()
        {
            Refresh();
        }

        public void Refresh()
        {
            if (Database.Profiles.Count > 0)
            {
                Profiles.text = Database.Profiles.Count.ToString();
            }
            if (Database.Games.Count > 0)
            {
                Games.text = Database.Games.Count.ToString();
                HighestScore.text = Database.Games.OrderByDescending(item => item.Score).First().Score.ToString();
                LowestScore.text = Database.Games.OrderBy(item => item.Score).First().Score.ToString();
                MinimumD.text = Database.Games.OrderBy(item => item.Duration).First().Duration + "S";
                MaximumD.text = Database.Games.OrderByDescending(item => item.Duration).First().Duration + "S";
                TotalD.text = Database.Games.Sum(item => item.Duration) + "S";
            }
        }
    }
}
