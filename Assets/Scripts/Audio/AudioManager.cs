using UnityEngine.Audio;
using UnityEngine;
using System; // Needed for Array function

// This was made following instructions in Brackey's "Introduction to AUDIO in Unity" video: https://www.youtube.com/watch?v=6OT43pvUyfY&t=337s

public class AudioManager : MonoBehaviour
{
    public static AudioManager manager;        // Makes BrackeysAudioManager.manager into a Singleton, accessible in all scripts (in tutorial this is called "instance")

    public Sound[] sounds;                              // Array of our custom class "Sound" objects
    public AudioClip[] keyclicks;
    public AudioClip[] faildrums;
    public AudioClip[] discoDownbeatDrums;
    public AudioClip[] discoOffbeatDrums;
    public AudioClip[] discoBackbeatDrums;
    public AudioClip[] timeAttackCountdown;

    private AudioSource audioSource;

    private void Awake() {                              // "Awake" called BEFORE "Start"
        manager = this;                                 // if it doesn't then define the Singleton as 'this'
        
        foreach (Sound s in sounds) {                   // For each "Sound" element in the "sounds" array (to be called "s" in this for loop)...
            if (s.targetGameObject == null){    // JACKSOR: allows user to specify the game object you'd like to make the AudioSource
                s.source = gameObject.AddComponent<AudioSource>();  // JACKSOR: if you HAVEN'T specified a target gameObject then it just uses the AudioManager (as normal)
            } else {
                s.source = s.targetGameObject.AddComponent<AudioSource>(); // JACKSOR: sets the prefered game object to be the sound source
            }

            s.source.clip = s.clip;                         // Defines that the newly created AudioSource "source" has the clip we defined in the sounds object.
            s.source.volume = s.volume;                     // ... and the volume...
            s.source.pitch = s.pitch;                       // ... and the pitch...
            s.source.loop = s.loop;                         // ... and if it loops...
            s.source.outputAudioMixerGroup = s.outputGroup;      // ... and the output group...
        }   
        
        audioSource = GetComponent<AudioSource>();
    }

    public void PlayKeyclickSound(){
        int randomIndex = UnityEngine.Random.Range(0, keyclicks.Length);
        audioSource.PlayOneShot(keyclicks[randomIndex]);
    }
    public void PlayFailDrum(){
        int randomIndex = UnityEngine.Random.Range(0, faildrums.Length);
        audioSource.PlayOneShot(faildrums[randomIndex]);
    }
    public void PlayTimeAttackCountdown(){
        int randomIndex = UnityEngine.Random.Range(0, timeAttackCountdown.Length);
        audioSource.PlayOneShot(timeAttackCountdown[randomIndex]);
    }


    // Disco
    // Sets if it should be on Down beat or Back beat
    public bool downbeat = true;
    public void PlayDownbeatDrums(){
        if (downbeat){
            int randomIndex = UnityEngine.Random.Range(0, discoDownbeatDrums.Length);
            audioSource.PlayOneShot(discoDownbeatDrums[randomIndex]);
        } else {
            int randomIndex = UnityEngine.Random.Range(0, discoBackbeatDrums.Length);
            audioSource.PlayOneShot(discoBackbeatDrums[randomIndex]);
        }
        downbeat = !downbeat;
    }
    public void PlayOffbeatDrums(){
        int randomIndex = UnityEngine.Random.Range(0, discoOffbeatDrums.Length);
        audioSource.PlayOneShot(discoOffbeatDrums[randomIndex]);
    }

    // PUBLIC METHODS - accessible by any other script in the scene.

    public void Play (string name)  // Public method for other scripts to access it, called "Play" (takes in a string)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);    // In Array "sounds"
        if (s==null)    // Checks to see if 's' is null, which happens if the sound can't be found in the "sounds" array
        {
            Debug.LogWarning("Sound: "+ name + " not found!");      // Debug warning saying that the sound can't be found
            return;     // If it's not (i.e. if s IS null) then stop the function - this avoids a null reference exception.
        }
        s.source.Play();
    }

    public void Stop (string name)  // Public method for other scripts to access it, called "Play" (takes in a string)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);    // In Array "sounds"
        if (s==null)    // Checks to see if 's' is null, which happens if the sound can't be found in the "sounds" array
        {
            Debug.LogWarning("Sound: "+ name + " not found!");      // Debug warning saying that the sound can't be found
            return;     // If it's not (i.e. if s IS null) then stop the function - this avoids a null reference exception.
        }
        s.source.Stop();
    }


    public void PlayOneShot (string name)  // Public method for other scripts to access it, called "Play" (takes in a string)
    {
        
        Sound s = Array.Find(sounds, sound => sound.name == name);    // In Array "sounds"
        if (s==null)    // Checks to see if 's' is null, which happens if the sound can't be found in the "sounds" array
        {
            Debug.LogWarning("Sound: "+ name + " not found!");      // Debug warning saying that the sound can't be found
            return;     // If it's not (i.e. if s IS null) then stop the function - this avoids a null reference exception.
        }
        Debug.Log("Play!" + name + s.clip + s.volume);
        s.source.PlayOneShot(s.clip, s.volume);
    }

 

    



 
}
