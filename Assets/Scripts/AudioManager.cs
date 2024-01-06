using System.Collections;
using System.Collections.Generic;
using System.Media;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public AudioSource PistolShootSoundSource;
    public AudioClip PistolShootSound;
    public Vector2 pistolPitchRange;
    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else { 
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
  
    }

    public void playPistolShootSound() {
        print("Shhoot");
        pitchRandomizer(PistolShootSoundSource, pistolPitchRange);
        PistolShootSoundSource.PlayOneShot(PistolShootSound);
    }

    void pitchRandomizer(AudioSource source, Vector2 range)
    { 
        source.pitch = Random.Range(range.x, range.y);
    }
}
