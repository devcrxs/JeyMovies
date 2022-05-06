using System.Collections;
using UnityEngine;
using UnityEngine.UI;
public class OptionsVideo : MonoBehaviour
{
    private float waitTime = 2.5f;
    private long framesChange = 300;
    private int _countTouchButton;
    private int _countTouchDefault = 0;
    private int timeInvoke = 1;
    public bool isPause;
    
    private Sprite _defaultImageButtonPlay;

    public static OptionsVideo instance;
    
    public GameObject moreOptionesContainer;
    [SerializeField] private Image imagePlayButton;
    [SerializeField] private Sprite playImage;
    
    [Header("Animators")]
    [SerializeField] private Animator animatorAdvance;
    [SerializeField] private Animator animatorBack;

    private void Awake()
    {
        if (instance == null) instance = this;
    }

    private void Start()
    {
        StatesGameObjects.IsActiveGameObject(moreOptionesContainer,false);
        _defaultImageButtonPlay = imagePlayButton.sprite;
    }

    public IEnumerator WaitDesactiveMoreOptions()
    {
        yield return new WaitForSeconds(waitTime);
        while (SliderVideoManager.instance.isPress)
        {
            yield return null;
        }
        Invoke("DesactiveMoreOptions", timeInvoke);
    }
    private void DesactiveMoreOptions()
    {
        StatesGameObjects.IsActiveGameObject(moreOptionesContainer,false);
    }
    
    public void ButtonPausePlay()
    {
        if (_countTouchButton <= Constans.ZERO)
        {
            GameManager.instance.videoPlayer.Pause();
            SetSpriteButtonPlay(playImage);
            _countTouchButton++;
            isPause = true;
            return;
        }
        GameManager.instance.videoPlayer.Play();
        SetSpriteButtonPlay(_defaultImageButtonPlay);
        _countTouchButton = _countTouchDefault;
        isPause = false;
    }

    private void SetSpriteButtonPlay(Sprite sprite)
    {
        imagePlayButton.sprite = sprite;
    }
    
    public void AdvancedFrames()
    {
        AnimatorManager.AnimatorTrigger(animatorAdvance,Constans.ADVANCE);
        GameManager.instance.videoPlayer.frame = ChangeFrameVideoPlayer(framesChange);
    }

    public void BackFrames()
    {
        AnimatorManager.AnimatorTrigger(animatorBack,Constans.BACK);
        GameManager.instance.videoPlayer.frame = ChangeFrameVideoPlayer(-framesChange);
    }
    private long ChangeFrameVideoPlayer(long changeValue)
    {
        var newFrame = GameManager.instance.videoPlayer.frame + changeValue;
        return newFrame;
    }

    private void Update()
    {
        if (PlayVideo.instance.isActiveVideo) return;
        SetSpriteButtonPlay(_defaultImageButtonPlay);
    }
}
