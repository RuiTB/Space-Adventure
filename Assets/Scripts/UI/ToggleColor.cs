using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.UI
{
    public class ToggleColor : MonoBehaviour
    {
        public void ChangeState(bool on)
        {
            if (on)
                GetComponent<Image>().color += new Color(.1f, .1f, .1f, +3f);
            else
            {
                GetComponent<Image>().color += new Color(-.1f, -.1f, -.1f, -3f);

            }
        }
    }
}
