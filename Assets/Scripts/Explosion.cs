using UnityEngine;

public class Explosion : MonoBehaviour
{

    private AudioSource soundEffect;

    private void Awake()
    {
        soundEffect = GetComponent<AudioSource>();
    }
    private void Start()
    {
        PlayAudio("Explosion", 0);
    }

    public void PlayAudio(string filename, ulong delay)
    {
        soundEffect.clip = Resources.Load<AudioClip>("Audioclips/" + filename);
        soundEffect.Play(delay);
    }
}
