using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioManager : MonoBehaviour
{

    // Music
    [SerializeField] private AudioSource _MusicAudioSource = null;

    [SerializeField] private List<AudioClip> _BackgroundMusic = new List<AudioClip>();
    [SerializeField] private List<AudioClip> _FightMusic = new List<AudioClip>();

    // SFX
    [SerializeField] private AudioSource _SfxAudioSource = null;

    [SerializeField] private List<AudioClip> _FightCollisionSFX = new List<AudioClip>();

    // Death audio
    [SerializeField] private AudioSource _DeathAudioSource = null;


    [SerializeField] private List<AudioClip> _DeadAudioClips = new List<AudioClip>();





    public void Init()
    {

    }

    //Music

    public void PlayBackgroundMusic()
    {
        if (!_MusicAudioSource.isPlaying)
        {
            _MusicAudioSource.clip = _BackgroundMusic[Random.Range(0, _BackgroundMusic.Count)];
            _MusicAudioSource.Play();
        }
    }

    public void PlayFightMusic()
    {
        if (!_MusicAudioSource.isPlaying)
        {
            _MusicAudioSource.clip = _FightMusic[Random.Range(0, _FightMusic.Count)];
            _MusicAudioSource.Play();
        }
    }


    // DEATH AUDIO

    public void PlayDeadAudio()
    {
        if (!_DeathAudioSource.isPlaying)
        {
            _DeathAudioSource.clip = _DeadAudioClips[Random.Range(0, _DeadAudioClips.Count)];
            _DeathAudioSource.Play();
        }
    }


    // SFX

    public void PlayFightCollisionSFX()
    {
        if (!_SfxAudioSource.isPlaying)
        {
            _SfxAudioSource.clip = _FightCollisionSFX[Random.Range(0, _FightCollisionSFX.Count)];
            _SfxAudioSource.Play();
        }
    }

 

    public void OnCanvasGroupChanged()
    {
        if(_MusicAudioSource != null & _SfxAudioSource != null & _DeathAudioSource != null )
        {

        }
    }
}
