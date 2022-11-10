using TMPro;
using UnityEngine;

namespace Assets.Scripts
{
    public class History : MonoBehaviour
    {
        public GameObject ProfileTemplate;

        void Awake()
        {
            Refresh();
        }

        public void Refresh()
        {
            foreach (Transform o in transform)
            {
                GameObject.Destroy(o.gameObject);
            }

            for (int i = 0; i < Database.Games.Count; i++)
            {
                Game temp = Database.Games[i];
                if (temp.Duration == 0) continue;

                GameObject g = Instantiate(ProfileTemplate, transform);



                g.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text =
                    temp.Player1.Name + " " + temp.Player2.Name;
                g.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = temp.Date.ToShortDateString();
                g.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = temp.Duration.ToString();
                g.transform.GetChild(3).GetComponent<TextMeshProUGUI>().text = temp.Score.ToString();
                g.transform.GetChild(4).GetComponent<TextMeshProUGUI>().text = temp.Winner;
            }
        }
    }
}