using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvent : MonoBehaviour
{
    [SerializeField] private AudioClip explosionSfx;

    public void SendExplosionSound()
    {
        FindObjectOfType<AudioController>().PlaySfx(explosionSfx);
    }
    public void DestroyExplosion()
    {
        Destroy(gameObject);
    }
}
