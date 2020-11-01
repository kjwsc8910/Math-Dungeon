using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class OptionsMenu : MonoBehaviour
{

    public Slider sfxVolume;
    public Slider musicVolume;
    private AudioSource[] allAudioSources;
    private AudioMannager audioMannager;


    void Awake()
    {
        audioMannager = Camera.main.gameObject.GetComponent<AudioMannager>();

        sfxVolume.value = PlayerPrefs.GetFloat("sfxVolume");
        musicVolume.value = PlayerPrefs.GetFloat("musicVolume");
    }

    public void ChangeVolume()
	{
        PlayerPrefs.SetFloat("sfxVolume", sfxVolume.value);
        PlayerPrefs.SetFloat("musicVolume", musicVolume.value);

        allAudioSources = FindObjectsOfType(typeof(AudioSource)) as AudioSource[];
        foreach (AudioSource audioS in allAudioSources)
        {
            audioS.volume = PlayerPrefs.GetFloat("sfxVolume");
        }
        foreach (AudioSource audioS in audioMannager.musicList)
        {
            audioS.volume = PlayerPrefs.GetFloat("musicVolume");
        }

        audioMannager.Play("Select");

    }

    void Update()
    {
        sfxVolume.value = PlayerPrefs.GetFloat("sfxVolume");
        musicVolume.value = PlayerPrefs.GetFloat("musicVolume");
    }
}
