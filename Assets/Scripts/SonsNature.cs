using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SonsNature : MonoBehaviour
{
    public AudioSource randomSound;

    public AudioClip[] audioSources;

    public float transitionTime;
    public AudioMixerSnapshot NatureOnSnapshot;
    public AudioMixerSnapshot NatureOffSnapshot;

    

    // Use this for initialization
    void Start()
    {

        //CallAudio();

    }

    private void Update()
    {
        if (!Input.GetKey("space"))
        {
            if (!randomSound.isPlaying)
            {
                StartCoroutine("playRandSound", 10);
                NatureOnSnapshot.TransitionTo(transitionTime);
               
            }
        }
        else
        {
            NatureOffSnapshot.TransitionTo(transitionTime);
            StopCoroutine("playRandSound");
            randomSound.Pause();

        }
    }


    private IEnumerator playRandSound(float waitTime)
    {

        randomSound.clip = audioSources[Random.Range(0, audioSources.Length)];
        print(randomSound.clip.name);
        randomSound.PlayScheduled(AudioSettings.dspTime + 0);
        randomSound.Play();
        yield return new WaitForSeconds(waitTime);
        StartCoroutine("playRandSound", waitTime);
    }
}
