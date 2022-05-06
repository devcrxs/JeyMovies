using UnityEngine;
using UnityEngine.UI;
public class SliderVideoManager : MonoBehaviour
{
    private float _totalTimeVideo;
    private float _totalSeconds;
    private int _totalMinutes;
    private int _totalHours;
    private float _currentFrame;
    private float _currentSeconds;
    private int _currentMinutes;
    private int _currentHours;
    public bool isPress;

    public static SliderVideoManager instance;
    
    [SerializeField] private Slider sliderProgress;
    public GameObject previewVideo;

    [Header("Textos")]
    [SerializeField] private Text textMaxDuration;
    [SerializeField] private Text textTimeElapsed;

    private void Awake()
    {
        if (instance == null) instance = this;
    }

    private void Start()
    {
        StatesGameObjects.IsActiveGameObject(previewVideo,false);
    }

    public long ChangeFrameVideoPlayer()
    {
        var frame = sliderProgress.value * GameManager.instance.videoPlayer.frameCount;
        return (long) frame;
    }
    
    private void Update()
    {
        ControllerValueSlider();
        InfoSliderVideo();
    }
    private void ControllerValueSlider()
    {
        if (isPress) return;
        var valueSlider = GameManager.instance.videoPlayer.frame / (float) GameManager.instance.videoPlayer.frameCount;
        sliderProgress.value = valueSlider;
    }

    private void InfoSliderVideo()
    {
        if (GameManager.instance.IsPreparedVideo() && PlayVideo.instance.isActiveVideo)
        {
            textTimeElapsed.text = TimeElapsed();
            textMaxDuration.text = DurationVideo();
        }
    }

    private string TimeElapsed()
    {
        //Frame actual = CantFramesActuales / fps
        _currentFrame = GameManager.instance.videoPlayer.frame / GameManager.instance.videoPlayer.frameRate;
        _currentSeconds = _currentFrame % Constans.DEFAULT_FRAME_RATE;
        _currentMinutes = (int) _currentFrame / Constans.DEFAULT_FRAME_RATE;
        _currentHours = _currentMinutes / Constans.DEFAULT_FRAME_RATE;
        var time = _currentHours.ToString(Constans.FORMAT_TEXT) + Constans.SEPARATION_TEXT + _currentMinutes.ToString(Constans.FORMAT_TEXT) 
                          + Constans.SEPARATION_TEXT  +_currentSeconds.ToString(Constans.FORMAT_TEXT) + " /";
        return time;
    }
    
    public string DurationVideo()
    {
        //TiempoTotal = Total frames / Frame Rate
            
        _totalTimeVideo = GameManager.instance.videoPlayer.frameCount / GameManager.instance.videoPlayer.frameRate;
        _totalSeconds = _totalTimeVideo % Constans.DEFAULT_FRAME_RATE;
        _totalMinutes = (int)_totalTimeVideo / Constans.DEFAULT_FRAME_RATE;
        _totalHours = _totalMinutes / Constans.DEFAULT_FRAME_RATE;
        if (_totalMinutes > Constans.DEFAULT_FRAME_RATE)
        {
            _totalMinutes -= Constans.DEFAULT_FRAME_RATE;
        }
        var duration = _totalHours.ToString(Constans.FORMAT_TEXT) + Constans.SEPARATION_TEXT  + _totalMinutes.ToString(Constans.FORMAT_TEXT) 
                       + Constans.SEPARATION_TEXT  + _totalSeconds.ToString(Constans.FORMAT_TEXT);
        return duration;
    }
    
}
