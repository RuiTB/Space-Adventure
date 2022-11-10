using UnityEngine;
using Application = UnityEngine.Device.Application;

namespace Assets.Scripts
{
    public class EventSystem : MonoBehaviour
    {
        public GameObject[] SideMenus;

        public void ClosePanel(GameObject panel)
        {
            panel.SetActive(false);
        }

        public void OpenPanel(GameObject panel)
        {
            if (panel.activeSelf)
                panel.SetActive(false);
            else
            {
                CloseSideMenus();

                panel.SetActive(true);
            }
        }

        public void CloseSideMenus()
        {
            foreach (var menu in SideMenus)
            {
                ClosePanel(menu);
            }
        }

        public void ExitApp()
        {
            Application.Quit();
        }

        public void LoadScene(string sceneName)
        {
            StartCoroutine(Loading.Load(sceneName));
        }
    }
}
