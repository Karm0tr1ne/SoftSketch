using System;
using System.Collections;
using System.Collections.Generic;
using Taichi.Soft2D.Plugin;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    private AudioSource _audioSource;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {
        _audioSource = gameObject.GetComponent<AudioSource>();
        _audioSource.loop = true;
        _audioSource.playOnAwake = true;
        _audioSource.Play();
    }
}
