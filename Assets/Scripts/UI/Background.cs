using UnityEngine;
using UnityEngine.UI;

public class Background : MonoBehaviour
{
    public Sprite[] sprite;
    Image image;

    private void Awake()
    {
        image = GetComponent<Image>();
        image.sprite = sprite[Random.Range(0, sprite.Length)];
    }
}
