using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class AudioPlayer : MonoBehaviour
{
    // breyta fyrir audio clipuna
    public AudioClip otherClip;

    IEnumerator Start()
    {
        AudioSource audio = GetComponent<AudioSource>();

        //Spilar audio clipuna
        audio.Play();
        yield return new WaitForSeconds(audio.clip.length);
        audio.clip = otherClip;
    }
}