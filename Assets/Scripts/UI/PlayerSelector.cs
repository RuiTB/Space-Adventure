using System;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public static class ToggelExtenstion
    {
        public static void AddEventListner<T>(this Toggle toggle, T param, Action<T> onClick)
        {
            toggle.onValueChanged.AddListener(delegate { onClick(param); });
        }
    }

    public class PlayerSelector : MonoBehaviour
    {
        public GameObject ProfileTemplate;
        public NewGame NewGame;
        public int Container;

        // Start is called before the first frame update
        void Start()
        {
            Refresh();
        }

        public void Refresh()
        {
            foreach (Transform o in transform)
            {
                GameObject.Destroy(o.gameObject);
            }

            int i = 0;
            foreach (Profile profile in Database.Profiles)
            {
                GameObject g = Instantiate(ProfileTemplate, transform);
                g.GetComponent<Toggle>().group = GetComponent<ToggleGroup>();
                g.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = profile.Name;
                g.transform.GetChild(1).GetComponent<Image>().sprite = Database.ShipSprites.Where(x => x.name.Equals(profile.Ship)).First();
                g.GetComponent<Toggle>().AddEventListner(i++, ItemClicked);
            }
        }

        private void ItemClicked(int i)
        {
            if (Container == 1)
            {
                NewGame.GetComponent<NewGame>().Player1 = Database.Profiles.ElementAt(i);
            }
            else
            {
                NewGame.GetComponent<NewGame>().Player2 = Database.Profiles.ElementAt(i);
            }
        }
    }
}