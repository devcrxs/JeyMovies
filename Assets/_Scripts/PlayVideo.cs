using UnityEngine;
using UnityEngine.Video;
public class PlayVideo : MonoBehaviour
{
    [Header("GameObjects")]
    [SerializeField] private GameObject screenVideo;
    [SerializeField] private GameObject textErrorUrl;
    public GameObject loadingVideoAnimationGameObject;
    
    public bool isActiveVideo;
    public static PlayVideo instance;

    private void Awake()
    {
        if (instance == null) instance = this;
    }
    private void Start()
    {
        StatesGameObjects.IsActiveGameObject(screenVideo,false);
    }
    
    public void RunVideo(string url) // OpenVideo
    {
        StatesGameObjects.IsActiveGameObject(screenVideo,true);
        SettingsMobile.ScreeOrientationMobile(ScreenOrientation.Landscape);
        GameManager.instance.videoPlayer.url = url;
        GameManager.instance.videoPlayer.errorReceived += VideoPlayer_errorReceived;
        StatesGameObjects.IsActiveGameObject(textErrorUrl,false);
        GameManager.instance.videoPlayer.Prepare();
        GameManager.instance.videoPlayer.Play();
        isActiveVideo = true;
    }
    public void ExitVideo() // ExitVideo
    {
        isActiveVideo = false;
        GameManager.instance.videoPlayer.Stop();
        StatesGameObjects.IsActiveGameObject(screenVideo,false);
        SettingsMobile.ScreeOrientationMobile(ScreenOrientation.Portrait);
    }

    private void VideoPlayer_errorReceived(VideoPlayer source, string message)
    {
        StatesGameObjects.IsActiveGameObject(textErrorUrl,true);
        GameManager.instance.videoPlayer.errorReceived -= VideoPlayer_errorReceived;
    }

    private void FixedUpdate()
    {
        StatesGameObjects.IsActiveGameObject(loadingVideoAnimationGameObject,IsActiveLoadingAnimation());
    }

    private bool IsActiveLoadingAnimation()
    {
        if (isActiveVideo)
        {
            if (GameManager.instance.IsPreparedVideo() )
            {
                return false;
            }
            return true;
        }
        return true;
    }
}
