using UnityEngine;

public class StartMenuUIScript : MonoBehaviour
{
    [Header("Volume: 0 - 1")]
    [SerializeField] private float _volume = 1;

    private void OnEnable()
    {
        AudioMgr.Instance.PlayMusic(AudioMgr.MusicType.Start, _volume);
    }

    private void OnDisable()
    {
        AudioMgr.Instance.StopMusic();
    }
}
