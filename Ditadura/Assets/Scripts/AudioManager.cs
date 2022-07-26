using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using System;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    public Sound[] sounds;

    private void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.pitch = s.pitch;
            s.source.volume = s.volume;
        }
    }

    // Update is called once per frame
    void Update()
    {
   
    }

    public void Play(string name)
    {
        //Array.find precisa do using System;
        //Achar o som na Sounds [array] , onde sound[Class] , => [Where] , sound.name == string name

        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }
}
