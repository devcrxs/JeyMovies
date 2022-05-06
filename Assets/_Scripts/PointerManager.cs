using UnityEngine;
public class PointerManager : MonoBehaviour
{
    public void PointDownSlider()
    {
        GameManager.instance.videoPlayer.Pause();
        StatesGameObjects.IsActiveGameObject(SliderVideoManager.instance.previewVideo,true);
        SliderVideoManager.instance.isPress= true;
    }

    public void PointerUpSlider()
    {
        GameManager.instance.videoPlayer.frame = SliderVideoManager.instance.ChangeFrameVideoPlayer();
        if (OptionsVideo.instance.isPause)
        {
            GameManager.instance.videoPlayer.Pause();
            StatesGameObjects.IsActiveGameObject(SliderVideoManager.instance.previewVideo,false);
            SliderVideoManager.instance.isPress = false;
            return;
        }
        GameManager.instance.videoPlayer.Play();
        StatesGameObjects.IsActiveGameObject(SliderVideoManager.instance.previewVideo,false);
        SliderVideoManager.instance.isPress = false;
    }
    
    public void PointerDownVideo()
    {
        if (GameManager.instance.IsPreparedVideo()) StatesGameObjects.
            IsActiveGameObject(OptionsVideo.instance.moreOptionesContainer,true);
    }

    public void PointerUpVideo()
    {
        if (GameManager.instance.IsPreparedVideo()) 
            StartCoroutine(OptionsVideo.instance.WaitDesactiveMoreOptions());
    }
}
