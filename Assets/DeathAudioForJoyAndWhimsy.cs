using UnityEngine;

public class DeathAudioForJoyAndWhimsy : MonoBehaviour
{
    // HEY SO, IF YOU FOUND THIS SCRIPT... IT WAS FOR JOY AND WHIMSY. You can't blame me.
    
    public float targetPitch = 2.0f;
    public float pitchChangeSpeed = 1.0f;
    public AudioSource audioSource;

    void Start()
    {
        if (audioSource == null)
        {
            audioSource = GetComponent<AudioSource>();
        }

        if (audioSource != null)
        {
            audioSource.Play();
        }
        else
        {
            Debug.LogWarning("No AudioSource assigned or found on GameObject.");
        }
    }

    void Update()
    {
        if (audioSource != null)
        {
            audioSource.pitch = Mathf.Lerp(audioSource.pitch, targetPitch, pitchChangeSpeed * Time.deltaTime);
        }
    }
}
