using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio : MonoBehaviour
{
    public AudioSource audioSourceMusicaDeFundo;
    public AudioClip[] musicaDeFundo;
    // Start is called before the first frame update
    void Start()
    {
      AudioClip musicaDeFundo1 = musicaDeFundo[0];  
      audioSourceMusicaDeFundo.clip = musicaDeFundo1;
      audioSourceMusicaDeFundo.loop = true;
      audioSourceMusicaDeFundo.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
