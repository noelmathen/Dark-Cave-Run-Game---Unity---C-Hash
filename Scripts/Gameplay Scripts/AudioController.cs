// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class AudioController : MonoBehaviour
// {
//     public static AudioController instance;

//     private void Awake() {
//         if(instance==null)
//             instance=this;
//     }

//     [SerializeField]
//     private AudioClip jumpSound, collectibleSound, SpiderJumperSound, gameOverSound;

//     public void Play_JumpSound()
//     {
//         AudioSource.PlayClipAtPoint(jumpSound ,transform.position, 1f); 
//     }

//     public void Play_CollectibleSound()
//     {
//         AudioSource.PlayClipAtPoint(collectibleSound ,transform.position, 1f);
//     }

//     public void Play_SpiderJumperSound()
//     {
//         AudioSource.PlayClipAtPoint(SpiderJumperSound ,transform.position, 1f);
//     }

//     public void Play_GameOverSound()
//     {
//         AudioSource.PlayClipAtPoint(gameOverSound ,transform.position, 1f);
//     }
// }


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioController instance;

    private AudioSource bgAudioSource;
    public AudioSource jumpAudioSource;
    public AudioSource collectibleAudioSource;
    public AudioSource spiderJumperAudioSource;
    public AudioSource gameOverAudioSource;

    [SerializeField]
    private AudioClip jumpSound, collectibleSound, SpiderJumperSound, gameOverSound;

    private void Awake()
    {
        if (instance == null)
            instance = this;

        // Get the background audio source from the SoundController GameObject
        bgAudioSource = GetComponent<AudioSource>();
    }

    // Play the background music
    public void PlayBackgroundMusic(AudioClip bgMusic)
    {
        bgAudioSource.clip = bgMusic;
        bgAudioSource.Play();
    }

    public void Play_JumpSound()
    {
        jumpAudioSource.PlayOneShot(jumpSound, 1f);
    }

    public void Play_CollectibleSound()
    {
        collectibleAudioSource.PlayOneShot(collectibleSound, 1f);
    }

    public void Play_SpiderJumperSound()
    {
        spiderJumperAudioSource.PlayOneShot(SpiderJumperSound, 1f);
    }

    public void Play_GameOverSound()
    {
        gameOverAudioSource.PlayOneShot(gameOverSound, 1f);
    }
}
