using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{

    public Sound[] sounds;
    public Sound Level1;
    public Sound Level2;
    public Sound Level3;

    public static AudioManager instance;

    bool PlaySoundLevel1;
    bool PlaySoundLevel2;
    bool PlaySoundLevel3;

    void Start()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        string sceneName = currentScene.name;

        Level1 = Array.Find(sounds, sound => sound.name == "BG_Scene1");
        Level2 = Array.Find(sounds, sound => sound.name == "BG_Scene2");
        Level3 = Array.Find(sounds, sound => sound.name == "BG_Scene3");

        if (sceneName == "Level1")
        {
            PlaySoundLevel1 = true;
            PlaySoundLevel2 = false;
            PlaySoundLevel3 = false;
        }
        else if (sceneName == "Level2")
        {
            PlaySoundLevel1 = false;
            PlaySoundLevel2 = true;
            PlaySoundLevel3 = false;
        }
        else if (sceneName == "Level3")
        {
            PlaySoundLevel1 = false;
            PlaySoundLevel2 = false;
            PlaySoundLevel3 = true;
        }

        PlaySoundLevel();
    }
    void Awake()
    {

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.spatialBlend = s.spatial;

        }
    }

    void Update()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        string sceneName = currentScene.name;

        if (TimeCount.ChangeScene)
        {
            if (sceneName == "Level1")
            {
                PlaySoundLevel1 = true;
                PlaySoundLevel2 = false;
                PlaySoundLevel3 = false;
            }
            else if (sceneName == "Level2")
            {
                PlaySoundLevel1 = false;
                PlaySoundLevel2 = true;
                PlaySoundLevel3 = false;
            }
            else if (sceneName == "Level3")
            {
                PlaySoundLevel1 = false;
                PlaySoundLevel2 = false;
                PlaySoundLevel3 = true;
            }
            StopSoundLevel();
            TimeCount.ChangeScene = false;
        }
    }

    public void Play (string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }
        s.source.Play();
    }

    public void PlaySoundLevel ()
    {
        if (PlaySoundLevel1)
        {
            Level1.source.Play();
        }
        else if (PlaySoundLevel2)
        {
            Level2.source.Play();
        }
        else if (PlaySoundLevel3)
        {
            Level3.source.Play();
        }
    }

    public void StopSoundLevel()
    {
        if (PlaySoundLevel1)
        {
            Level1.source.Play();
            Level2.source.Stop();
            Level3.source.Stop();
        }
        else if (PlaySoundLevel2)
        {
            Level1.source.Stop();
            Level2.source.Play();
            Level3.source.Stop();
        }
        else if (PlaySoundLevel3)
        {
            Level1.source.Stop();
            Level2.source.Stop();
            Level3.source.Play();
        }
    }
}
