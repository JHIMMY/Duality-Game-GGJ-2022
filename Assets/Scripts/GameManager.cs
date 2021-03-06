using UnityEngine;

public enum Timeline
{
    Past = 0,
    Present
}

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private Animator bgAnimator;

    [SerializeField]
    private PlatformsManager platformsManager;

    public static Timeline GameTimeLine { get; private set; }

    [SerializeField]
    private AudioSource auSFX;

    [SerializeField]
    private AudioSource auMusic;

    [SerializeField] AudioClip sadClip;
    [SerializeField] AudioClip happyClip;

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
        GameTimeLine = Timeline.Present;
        auMusic.clip = happyClip;
        auMusic.Play();

        Camera.main.backgroundColor = new Color32(137, 144, 144, 255);
    }

    void Update()
    {
        
    }

    private void GoToPastTimeLine()
    {
        if (GameTimeLine == Timeline.Present)
        {
            auSFX.PlayOneShot(auSFX.clip);
            bgAnimator.SetTrigger("BackgroundBlink");
            platformsManager.ChangePlatformsToPast();
            GameTimeLine = Timeline.Past;

            auMusic.clip = sadClip;
            auMusic.Play();
        }
    }

    private void GoToPresentTimeLine()
    {
        if (GameTimeLine == Timeline.Past)
        {
            auSFX.PlayOneShot(auSFX.clip);
            bgAnimator.SetTrigger("BackgroundBlink");
            platformsManager.ChangePlatformsToPresent();
            GameTimeLine = Timeline.Present;

            auMusic.clip = happyClip;
            auMusic.Play();
        }
    }
}
