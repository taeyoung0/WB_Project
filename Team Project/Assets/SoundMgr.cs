using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum sounds

public class SoundMgr : MonoBehaviour
{
    [SerializeField]
    AudioClip[] audioarr;

    AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = audioarr[0]; // 현재 오디오 클립을 audioarr의 0번째로 바꾼다(Bgm)
        audioSource.Play(); // 시작과 동시에 BGM을 튼다
    }

    // Update is called once per frame
    void Update()
    {
        if()
    }

    void playOneShotSounds(int i){
        //audioSource.clip = audioarr[i];
        audioSource.PlayOneShot(audioarr[i]);
    }


}
