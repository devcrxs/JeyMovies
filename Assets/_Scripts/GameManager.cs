using UnityEngine;
using UnityEngine.Video;
public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public VideoPlayer videoPlayer;

    private void Awake()
    {
        if (instance == null) instance = this;
    }
    public bool IsPreparedVideo()
    {
        return videoPlayer.isPrepared;
    }
}
