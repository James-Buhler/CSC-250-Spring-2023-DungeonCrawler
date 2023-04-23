using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MonsterTrigger : MonoBehaviour
{

    public bool enableFights = true;
    public float changeToGetIntoFight = 30.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if (MasterData.count > 0 && MasterData.hasArrivedAtCenter || MasterData.count ==0 && enableFights)
        {

            if (Random.Range(1, 100) <= this.changeToGetIntoFight)
            {
                Destroy(MasterData.musicLooper);
                MasterData.musicLooper = null;

                SceneManager.LoadScene("FightScene");
            }
        }
    }
}
