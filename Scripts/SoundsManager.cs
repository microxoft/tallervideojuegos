using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundsManager : MonoBehaviour
{
    public AudioSource ClickSound;
    public AudioSource HoverSound;
    
    public void PlayClickSound()
    {
        ClickSound.Play();
    }

    public void PlayHoverSound()
    {
        HoverSound.Play();
    }
}
