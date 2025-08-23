using UnityEngine;
using System.Collections;

public class AudioController : MonoBehaviour
{
    public AudioClip gameStartAudio;
    public AudioClip triggerAudio;
    public float delayTime = 2f;
    
    private bool hasTriggered = false;
    
    void Start()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
            audioSource = gameObject.AddComponent<AudioSource>();
            
        if (gameStartAudio != null)
            StartCoroutine(PlayDelayedAudio(audioSource));
    }
    
    private IEnumerator PlayDelayedAudio(AudioSource audioSource)
    {
        yield return new WaitForSeconds(delayTime);
        audioSource.PlayOneShot(gameStartAudio);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (triggerAudio != null && !hasTriggered)
        {
            AudioSource audioSource = GetComponent<AudioSource>();
            if (audioSource != null)
            {
                audioSource.PlayOneShot(triggerAudio);
                hasTriggered = true;
            }
        }
    }
}
