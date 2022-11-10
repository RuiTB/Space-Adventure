using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Assets.Scripts
{
    public class Loading : MonoBehaviour
    {
        public static IEnumerator Load(string sceneName)
        {
            GameObject temp = Instantiate(Resources.Load("Prefabs/LoadingScreen") as GameObject);
            Image loadingBar = temp.transform.Find("Loading").transform.Find("LoadingBar").GetComponent<Image>();
            TextMeshProUGUI percentage = temp.transform.Find("Loading").transform.Find("Percentage").GetComponent<TextMeshProUGUI>();

            int t = 0;
            while (t++ < 10)
            {
                loadingBar.fillAmount += .1f;
                percentage.text = t * 10 + "%";

                yield return new WaitForSeconds(.1f);
            }

            SceneManager.LoadScene(sceneName);
        }
    }
}
