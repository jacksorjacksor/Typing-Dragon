using UnityEngine.Audio;
using UnityEngine;

// This was made following instructions in Brackey's "Introduction to AUDIO in Unity" video: https://www.youtube.com/watch?v=6OT43pvUyfY&t=337s

[System.Serializable]           // [Attribute]: Added to allow the class to appear in the Inspector
public class Sound {            // Making a custom class - "Sound"

    public string name;         // make a variable for the name of the clip (this'll be shown in the eventual array)

    public AudioClip clip;      // make a variable for the audio clip

    [Range(0f,1f)]              // [Attribute]: Added so that in the Inspector we have a slider with min/max values
    public float volume = 1f;        // make a variable for volume
    
    [Range(0.3f,3f)]           // [Attribute]: Added so that in the Inspector we have a slider with min/max values
    public float pitch = 1f;         // make a variable for pitch
    
    public bool loop;           // Set a boolean value for looping

    public AudioMixerGroup outputGroup;

    public GameObject targetGameObject; // JACKSOR: This allows you to set WHICH object you want the source to be. If null then the source is the audio manager

    [HideInInspector]           // [Attribute]: Added to stop the class appearing in the Inspector
    public AudioSource source;  // Makes a slot for an AudioSource ready to be populated by the AudioManager script
}
