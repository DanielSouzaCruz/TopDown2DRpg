using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActorSfx : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;

    public void playSfx(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}
