using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class ColorPicker : MonoBehaviour
    {
        public Image image;
        public void PickColor(string colorName)
        {
            Color color;
            switch (colorName)
            {
                case "Blue":
                    color = Color.blue;
                    break;
                case "Purple":
                    color = new Color(0.4921875f, 0.13671875f, 0.6796875f);
                    break;
                case "Red":
                    color = Color.red;
                    break;
                case "Orange":
                    color = new Color(0.984375f, 0.5f, 0f);
                    break;
                case "Yellow":
                    color = Color.yellow;
                    break;
                case "Green":
                    color = Color.green;
                    break;
                default:
                    color = Color.white;
                    break;
            }

            image.color = color;
        }

    }
}
