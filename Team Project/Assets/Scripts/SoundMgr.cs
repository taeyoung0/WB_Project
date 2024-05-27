using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.WSA;



public class SoundMgr : MonoBehaviour
{
    [SerializeField]
    AudioClip[] audioarr;

    private bool isPlaying = false;
    private float repeattime = 5.0f;

    AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = audioarr[0];
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)){
            playOneShotSounds(1);
        }


    }

    void playOneShotSounds(int i){
        //audioSource.clip = audioarr[i];
        audioSource.PlayOneShot(audioarr[i]);
    }


}
