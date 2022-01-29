using System.Collections.Generic;
using UnityEngine;

public class PlatformsManager : MonoBehaviour
{     
    private List<SpriteRenderer> spriteRenderers = new List<SpriteRenderer>();

    private void Awake()
    {
        foreach (Transform child in transform)
        {
            spriteRenderers.Add(child.GetComponent<SpriteRenderer>());
        }
    }

    public void ChangePlatformsColor(Color color)
    {
        foreach (var sp in spriteRenderers)
        {
            sp.color = color;
        }
    }
}
