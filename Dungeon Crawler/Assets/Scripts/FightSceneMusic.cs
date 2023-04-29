using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightSceneMusic : MonoBehaviour
{
    private bool b = true;
    public AudioSource winsound;
    public AudioSource fightsound;
    public AudioSource losesound;

    private void Start()
    {
        this.fightsound.Play();
    }
    
    private void Update()
    {
        if (!MasterData.isEveryoneAlive && b)
        {
            if(MasterData.p == MasterData.dudeWhoWon)
            {
                this.fightsound.Pause();
                this.winsound.Play();
            }
            else
            {
                this.fightsound.Pause();
                this.losesound.Play();
            }
            this.b = false;
        }
    }
}
