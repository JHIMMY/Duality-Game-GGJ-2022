using System.Collections.Generic;
using UnityEngine;

public class PlatformsManager : MonoBehaviour
{     
    private List<PlatformControl> platformsControls = new List<PlatformControl>();

    private void Start()
    {
        foreach (Transform child in transform)
        {
            var platform = child.GetComponent<PlatformControl>();
            if (platform != null)
            {
                platformsControls.Add(child.GetComponent<PlatformControl>());
            }
        }
    }

    public void ChangePlatformsToPresent()
    {
        foreach (var platform in platformsControls)
        {
            platform.ChangePlatformToPresent();
        }
    }

    public void ChangePlatformsToPast()
    {
        foreach (var platform in platformsControls)
        {
            platform.ChangePlatformToPast();
        }
    }
}
