using Palmmedia.ReportGenerator.Core;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;  // Required to handle UI elements

public class startAnim : MonoBehaviour
{
    public PlayableDirector timelineDirector;  // Reference to the Timeline
    public Button resumeButton;               // Reference to the UI Button
    public Animator characterAnimator;

    private float timer = 0f;
    private float timer2 = 0f;
    private bool startTimer2 = false;
    private bool isPlaying = false;

    void Awake()
    {
        // Play the Timeline when the scene starts
        if (timelineDirector != null)
        {
            timelineDirector.Play();
            isPlaying = true;
        }

        // Attach the button click event
        if (resumeButton != null)
        {
            resumeButton.onClick.AddListener(ResumeTimeline);
        }
    }

    void Update()
    {
        if (isPlaying)
        {
            timer += Time.deltaTime;

            if (timer >= 3f)
            {
                timelineDirector.Pause();
                isPlaying = false;
            }
        }

        if (startTimer2)
        {
            timer2 += Time.deltaTime;
        }

        if (characterAnimator != null)
        {
            characterAnimator.SetFloat("timer", timer2);  // Set the float parameter in Animator
        }

    }

    // This function will be called when the button is clicked
    public void ResumeTimeline()
    {
        if (timelineDirector != null && !isPlaying)
        {
            timelineDirector.Play();  // Resume playing
            resumeButton.gameObject.SetActive(false);
            startTimer2 = true;
            
        }

        if (characterAnimator != null)
        {
            characterAnimator.SetBool("walking", true); 
        }
    }
}
