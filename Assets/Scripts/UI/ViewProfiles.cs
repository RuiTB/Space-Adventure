using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class ViewProfiles : MonoBehaviour
    {
        private TMP_Dropdown _dropdown;

        private List<string> _list;

        public GameObject ProfileViewPanel;

        // Start is called before the first frame update
        void Start()
        {
            _dropdown = GetComponent<TMP_Dropdown>();

            Refresh();
        }

        public void Refresh()
        {
            try
            {
                _dropdown.ClearOptions();
            }
            catch (Exception)
            {
                // ignored
            }

            _list = new List<string>();
            foreach (Profile profile in Database.Profiles)
            {
                _list.Add(profile.Name);
            }

            try
            {
                _dropdown.AddOptions(_list);
                ShowProfile(0);
            }
            catch (Exception)
            {
                // ignored
            }
        }

        public void ShowProfile(int i)
        {
            Profile temp = Database.Profiles.ElementAt(i);

            ProfileViewPanel.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = temp.Name;
            ProfileViewPanel.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = temp.Age.ToString();
            ProfileViewPanel.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = temp.Gender.ToString();
            ProfileViewPanel.transform.GetChild(3).GetComponent<Image>().sprite = Database.ShipSprites.Where(x => x.name.Equals(temp.Ship)).First();

            Color color;
            switch (temp.Color)
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

            ProfileViewPanel.transform.GetChild(4).GetComponent<Image>().color = color;
        }
    }
}