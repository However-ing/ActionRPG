using UnityEngine;

public class SlimeSound : MonoBehaviour
{
    AudioSource audioSource;
    public AudioClip slash1;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Sword")) print("Sword hit slime");
            audioSource.PlayOneShot(slash1);
    }
}


