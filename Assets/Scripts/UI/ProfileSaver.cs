using System;
using System.Collections;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class ProfileSaver : MonoBehaviour
    {
        public TMP_InputField Name;
        public TMP_InputField Age;
        public ToggleGroup Gender;
        public ToggleGroup Color;
        public Image Ship;

        void Awake()
        {
            Reset();
        }

        public void Save()
        {
            string name = Name.text;
            int age = int.Parse(Age.text);
            Gender gender = Gender.ActiveToggles().First().name.Equals("Male") ? UnityEngine.Analytics.Gender.Male : UnityEngine.Analytics.Gender.Female;
            string ship = Ship.sprite.name;
            string color;

            if (name.Length < 2 || name == null)
            {
                showToast("Your must enter a name", 1);
                return;
            }
            if (age == 0)
            {
                showToast("Your must enter your age", 1);
                return;
            }

            try
            {
                color = Color.ActiveToggles().First().name;
            }
            catch (Exception)
            {
                showToast("Your must choose a color", 1);
                return;
            }

            Database.Profiles.Add(new Profile(name, age, color, gender, ship));

            Reset();
        }

        private void Reset()
        {
            Name.text = string.Empty;
            Age.text = string.Empty;
            foreach (var item in Gender.ActiveToggles())
            {
                item.isOn = false;
            }

            foreach (var item in Color.ActiveToggles())
            {
                item.isOn = false;
            }

            FindObjectsOfType<ColorPicker>().First().image.color = UnityEngine.Color.white;

        }


        public Text txt;

        void showToast(string text,
            int duration)
        {
            StartCoroutine(showToastCOR(text, duration));
        }

        private IEnumerator showToastCOR(string text,
            int duration)
        {
            txt.color = UnityEngine.Color.red;

            Color orginalColor = txt.color;

            txt.text = text;
            txt.enabled = true;

            //Fade in
            yield return fadeInAndOut(txt, true, 0.5f);

            //Wait for the duration
            float counter = 0;
            while (counter < duration)
            {
                counter += Time.deltaTime;
                yield return null;
            }

            //Fade out
            yield return fadeInAndOut(txt, false, 0.5f);

            txt.enabled = false;
            txt.color = orginalColor;
        }

        IEnumerator fadeInAndOut(Text targetText, bool fadeIn, float duration)
        {
            //Set Values depending on if fadeIn or fadeOut
            float a, b;
            if (fadeIn)
            {
                a = 0f;
                b = 1f;
            }
            else
            {
                a = 1f;
                b = 0f;
            }

            Color currentColor = UnityEngine.Color.clear;
            float counter = 0f;

            while (counter < duration)
            {
                counter += Time.deltaTime;
                float alpha = Mathf.Lerp(a, b, counter / duration);

                targetText.color = new Color(currentColor.r, currentColor.g, currentColor.b, alpha);
                yield return null;
            }
        }
    }
}