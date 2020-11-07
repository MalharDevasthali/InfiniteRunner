
using UnityEngine;
using PlayerServices;

public class BGScroller : MonoBehaviour
{
    public Material material;
    public static BGScroller instance;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    public void MoveBGBackword()
    {
        Vector2 offset = new Vector2(GetPlayerSpeed(), 0);
        material.mainTextureOffset += offset;
    }
    public void MoveBGForward()
    {
        Vector2 offset = new Vector2(GetPlayerSpeed(), 0);
        material.mainTextureOffset -= offset;
    }


    private float GetPlayerSpeed()
    {
        return PlayerService.instance.GetPlayerController().GetPlayerModel().movementSpeed * Time.deltaTime * 0.1f;
    }
}
