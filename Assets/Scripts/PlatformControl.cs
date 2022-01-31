using UnityEngine;

public class PlatformControl : MonoBehaviour
{
    [SerializeField] private Sprite presentPlatform;
    [SerializeField] private Sprite pastPlatform;

    private SpriteRenderer sp;    

    void Awake()
    {
        sp = GetComponent<SpriteRenderer>();
    }

    public void ChangePlatformToPresent()
    {
        sp.sprite = presentPlatform;
    }

    public void ChangePlatformToPast()
    {
        sp.sprite = pastPlatform;
    }
}
