using UnityEngine;
using UnityEngine.UI;
public class LoginManager : MonoBehaviour
{
    [SerializeField] private Animator animatorLogin;
    [SerializeField] private Sprite[] perfilImages;
    [SerializeField] private Image imagePerfilPrincipal;
    public void Login(int keyPerfil)
    {
        imagePerfilPrincipal.sprite = perfilImages[keyPerfil];
        AnimatorManager.AnimatorPlay(animatorLogin,Constans.RUN);
    }

    public void ChangeAvatar()
    {
        AnimatorManager.AnimatorPlay(animatorLogin,Constans.RE_LOGIN);
    }
}
