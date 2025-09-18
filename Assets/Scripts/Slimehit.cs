using UnityEngine;

public class Slimehit : MonoBehaviour
{

    AudioSource audioSource;
    public AudioClip slash1;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Sword")) print("Slime hit!");
        audioSource.PlayOneShot(slash1);
    }
}
