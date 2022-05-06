using UnityEngine;
public class StatesGameObjects : MonoBehaviour
{
    public static void IsActiveGameObject(GameObject go, bool value)
    {
        go.SetActive(value);
    } 
}
