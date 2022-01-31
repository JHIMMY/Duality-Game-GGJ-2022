using UnityEngine;

public class PlatformControl : MonoBehaviour
{
    [SerializeField] private GameObject presentPlatform;
    [SerializeField] private GameObject pastPlatform;

    void Awake()
    {
        ChangePlatformToPresent();
    }

    public void ChangePlatformToPresent()
    {
        presentPlatform.SetActive(true);
        pastPlatform.SetActive(false);
    }

    public void ChangePlatformToPast()
    {
        presentPlatform.SetActive(false);
        pastPlatform.SetActive(true);
    }
}
