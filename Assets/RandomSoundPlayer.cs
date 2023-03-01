using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSoundPlayer : MonoBehaviour
{
    public AudioClip[] clips;
    private AudioSource source;
    private void Start()
    {
        source = this.GetComponent<AudioSource>();
        if (source.playOnAwake)
            Play();
    }

    public void Play()
    {
        source.clip = clips[Random.Range(0, clips.Length)];
        source.Play();
    }

    public bool IsPlaying()
    {
        return source.isPlaying;
    }
}
