using UnityEngine;
using UnityEngine.Audio;
using System;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{

	public static AudioManager instance;

	public Sound[] sounds;

    bool menuActive;
    bool gameActive;

	void Awake()
	{
		if (instance != null)
		{
			if (instance != this)
			{
				Destroy(this.gameObject);
			}
		}
		else
		{
			instance = this;
			DontDestroyOnLoad(this);
		}


        foreach(Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.outputAudioMixerGroup = s.mixer;
        }
	}

    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex < 4 && menuActive==false)
        {
            Stop("GameLoop");
            Play("MenuLoop");
            menuActive = true;
            gameActive = false;

        }
        else if(SceneManager.GetActiveScene().buildIndex >= 4 && menuActive == true && gameActive == false)
        {
            Stop("MenuLoop");
            Play("GameLoop");
            gameActive = true;
            menuActive = false;
        }
    }




    public void Play(string name)
	{
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
	}

    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Stop();
    }

}
