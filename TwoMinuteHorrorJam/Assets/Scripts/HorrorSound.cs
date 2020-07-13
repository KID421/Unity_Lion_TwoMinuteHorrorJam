using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class HorrorSound : HorrorObject
{
    [Header("音效")]
    public AudioClip sound;
    [Header("音量"), Range(0, 5)]
    public float volume = 1f;

    private AudioSource aud;

    private void Start()
    {
        aud = GetComponent<AudioSource>();
    }

    public override void TriggerEvent()
    {
        aud.PlayOneShot(sound, volume);
    }
}
