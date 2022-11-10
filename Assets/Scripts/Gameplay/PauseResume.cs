using UnityEngine;

public class PauseResume : MonoBehaviour
{
    public void Switch()
    {
        if (Time.timeScale == 0)
            Time.timeScale = 1;
        else
        {
            Time.timeScale = 0;
        }
    }

}
