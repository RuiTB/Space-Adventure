using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class EndGameScreen : MonoBehaviour
    {
        public TextMeshProUGUI winnerName;
        public TextMeshProUGUI winnerScore;
        public Image image;

        // Start is called before the first frame update
        void Start()
        {
            winnerName.text = Database.Games[^1].Winner;
            winnerScore.text = Database.Games[^1].Score.ToString();
            string ship = Database.Games[^1].Player1.Name.Equals(Database.Games[^1].Winner) ? Database.Games[^1].Player1.Ship : Database.Games[^1].Player2.Ship;

            image.sprite = Database.ShipSprites.Where(x => x.name.Equals(ship)).First();
        }


    }
}