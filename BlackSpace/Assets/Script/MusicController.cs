using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public float pauseSoundLevel = 0.3f;
    public float normalSoundLevel = 0.7f;

    public AudioClip loopSong;

    public AudioSource audioSource;

    void Start()
    {
        StartCoroutine(PlayLevelMusic());
    }

    IEnumerator PlayLevelMusic()
    {
        if (audioSource.clip != null)
        {
            yield return new WaitForSeconds(audioSource.clip.length);

            audioSource.loop = true;
            audioSource.clip = loopSong;

            normalSoundLevel /= 2;
            pauseSoundLevel /= 2;

            audioSource.volume /= 2;

            audioSource.Play();
        }
    }

    public void ModifyMusicVolume(float volume)
    {
        audioSource.volume = volume;
    }
}
