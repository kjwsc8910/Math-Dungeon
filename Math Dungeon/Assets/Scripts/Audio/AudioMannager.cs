using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioMannager : MonoBehaviour
{

    public Sound[] sounds;
    public Sound[] music;
    [SerializeField]
    public List<AudioSource> musicList;

    private AudioSource[] allAudioSources;

    private string selection;
    public bool playMusic;

    void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = PlayerPrefs.GetFloat("sfxVolume");
            s.source.pitch = 1;
            s.source.loop = s.loop;
        }

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
        playMusic = true;
        PlayMusic();
	}

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null) return;
        s.source.Play();
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

    public void StopAllAudio()
    {
        allAudioSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
        foreach (AudioSource audioS in allAudioSources)
        {
            audioS.Stop();
        }
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
