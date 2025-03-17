using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    //make static instance to maek reference easyer
    public static AudioManager instance;

    [SerializeField] private AudioSource bumpSource;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        { 
            Destroy(gameObject);
        }
    }
    public void playBump() 
    {
        if (bumpSource != null)
        {
            bumpSource.Play();  // 使用 PlayOneShot 来播放音效
        }
        else
        {
            Debug.LogWarning("AudioSource 组件或音效未设置！");
        }
    }
}
