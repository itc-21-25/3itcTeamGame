using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudioManager : MonoBehaviour
{
    [SerializeField] private AudioSource _AudioSource = null;
    [SerializeField] private List<AudioClip> _DeadAudioClips = new List<AudioClip>();

    public void Init()
    {

    }

    public void PlayDeadAudio()
    {
        if (!_AudioSource.isPlaying)
        {
            _AudioSource.clip = _DeadAudioClips[Random.Range(0, _DeadAudioClips.Count)];
            _AudioSource.Play();
        }
    }


    public void OnCanvasGroupChanged()
    {
        if(_AudioSource != null )
        {

        }
    }
}
