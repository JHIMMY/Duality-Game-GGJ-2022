using UnityEngine;

public enum Timeline
{
    Past = 0,
    Present
}

public class GameManager : MonoBehaviour
{
    [Header("Platform Colors")]
    [SerializeField] private Color presentColor;
    [SerializeField] private Color pastColor;

    [SerializeField]
    private Animator cameraAnim;

    [SerializeField]
    private PlatformsManager platformsManager;

    public static Timeline GameTimeLine { get; private set; }

    private AudioSource au;

    private void OnEnable()
    {
        Interaction.OnDrinkingAntidote += GoToPresentTimeLine;
        Interaction.OnDrinkingElixir += GoToPastTimeLine;
    }

    private void OnDisable()
    {
        Interaction.OnDrinkingAntidote -= GoToPresentTimeLine;
        Interaction.OnDrinkingElixir -= GoToPastTimeLine;
    }    

    void Start()
    {
        au = GetComponent<AudioSource>();
        GameTimeLine = Timeline.Present;
    }

    void Update()
    {
        
    }

    private void GoToPastTimeLine()
    {
        if (GameTimeLine == Timeline.Present)
        {
            au.PlayOneShot(au.clip);
            cameraAnim.SetTrigger("CameraBlink");
            platformsManager.ChangePlatformsColor(pastColor);
            GameTimeLine = Timeline.Past;
        }
    }

    private void GoToPresentTimeLine()
    {
        if (GameTimeLine == Timeline.Past)
        {
            au.PlayOneShot(au.clip);
            cameraAnim.SetTrigger("CameraBlink");
            platformsManager.ChangePlatformsColor(presentColor);
            GameTimeLine = Timeline.Present;
        }
    }
}
