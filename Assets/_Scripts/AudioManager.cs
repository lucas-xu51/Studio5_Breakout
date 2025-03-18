using System;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    //make static instance to maek reference easyer
    public static AudioManager instance;

    [SerializeField] private AudioSource bumpSource, pinSource;

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
            bumpSource.Play();  // ʹ�� PlayOneShot ��������Ч
        }
        else
        {
            Debug.LogWarning("AudioSource �������Чδ���ã�");
        }
    }
    public void playPin()
    {
        if (pinSource != null)
        {
            pinSource.Play();  // ʹ�� PlayOneShot ��������Ч
        }
        else
        {
            Debug.LogWarning("AudioSource �������Чδ���ã�");
        }
    }
}
