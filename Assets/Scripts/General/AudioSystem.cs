using UnityEngine;
using UnityEngine.UI;

public class AudioSystem : MonoBehaviour
{
    private AudioSource _backgroundMusic;
    [SerializeField] private Sprite _musicPlay;
    [SerializeField] private Sprite _musicPause;
    private Image _musicRenderer;

    private void Awake()
    {
        _musicRenderer = GetComponent<Image>();
        _backgroundMusic = GetComponent<AudioSource>();
    }

    public void PauseMusic()
    {
        if (_backgroundMusic.isPlaying)
        {
            _backgroundMusic.Pause();
            _musicRenderer.sprite = _musicPlay;
        }
        else
        {
            _backgroundMusic.Play();
            _musicRenderer.sprite = _musicPause;
        }
    }
}
