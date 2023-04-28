using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightSceneMusic : MonoBehaviour
{
    private bool b = true;
    public AudioSource winsound;
    public AudioSource fightsound;

    private void Start()
    {
        this.fightsound.Play();
    }
    
    private void Update()
    {
        if (!MasterData.isEveryoneAlive && b)
        {
            this.fightsound.Pause();
            this.winsound.Play();
            this.b = false;
        }
    }
}
