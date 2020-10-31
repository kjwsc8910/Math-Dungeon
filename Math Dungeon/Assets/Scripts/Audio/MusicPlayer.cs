using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Audio;

public class MusicPlayer : MonoBehaviour
{

    public Sound[] music;
    [SerializeField]
    private List<AudioSource> musicList;

    private string selection;
    public bool playMusic;

	private void Awake()
	{
        foreach (Sound s in music)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = PlayerPrefs.GetFloat("musicVolume");
            s.source.pitch = 1;
            s.source.loop = s.loop;

            musicList.Add(s.source);
        }
    }

	void Start()
    {
        playMusic = false;
    }

    public void PlayMusic()
    {
        if (playMusic == false) return;
        selection = music[UnityEngine.Random.Range(0, music.Length)].name;
        Debug.Log("Now Playing " + selection);

        Sound s = Array.Find(music, sound => sound.name == selection);
        if (s == null) return;
        s.source.Play();
    }

    private void Update()
    {
        foreach (AudioSource audioSource in musicList)
        {
            if (audioSource.isPlaying == true) return;
        }
        PlayMusic();
    }
}
