using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class ShipPicker : MonoBehaviour
    {
        public string SpriteName;

        private static int _i;
        private Image image;

        private void Awake()
        {
            SpriteName = Database.ShipSprites[0].name;
            image = GetComponent<Image>();
        }

        public void NextShip()
        {
            _i++;
            _i %= Database.ShipSprites.Count;
            SpriteName = Database.ShipSprites[_i].name;
            image.sprite = Database.ShipSprites[_i];
        }

        public void PreviousShip()
        {
            if (_i == 0)
            {
                _i = Database.ShipSprites.Count - 1;
                SpriteName = Database.ShipSprites[_i].name;
            }
            else
            {
                _i--;
                SpriteName = Database.ShipSprites[_i].name;
            }
            image.sprite = Database.ShipSprites[_i];
        }
    }
}