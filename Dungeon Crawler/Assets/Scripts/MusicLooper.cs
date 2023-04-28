using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicLooper : MonoBehaviour
{
    private bool b = true;
    private AudioSource winsound;

    private void Awake()
    {
        if (MasterData.musicLooper == null)
        {
            MasterData.musicLooper = this.gameObject;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
    private void Update()
    {
        if(!MasterData.isEveryoneAlive && b)
        {
            this.winsound = this.GetComponent<AudioSource>();
            this.winsound.Play();
            this.b = false;
        }
    }
}
