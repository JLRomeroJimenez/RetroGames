using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    [SerializeField] private AudioSource[] sfxChannel;

    public void PlaySfx(AudioClip clip)
    {
        for (int i = 0; i < sfxChannel.Length; i++)
        {
            if (sfxChannel[i].clip==null)
            {
                sfxChannel[i].clip = clip;
                sfxChannel[i].Play();
                
                StartCoroutine(CleanAudioChannel(clip.length, i));
                
                break;
                
                //MEJORAR ESTE METODO
            }
        }
    }

    IEnumerator CleanAudioChannel(float length, int channel)
    {
        yield return new WaitForSeconds(length);
        
        //Limpiar los canales de audio para usarlos infinitamente
        sfxChannel[channel].clip = null;
    }
}
