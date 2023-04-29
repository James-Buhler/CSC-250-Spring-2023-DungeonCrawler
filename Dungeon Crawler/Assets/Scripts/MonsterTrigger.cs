using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MonsterTrigger : MonoBehaviour
{

    public bool enableFights = true;
    public float changeToGetIntoFight = 30.0f;
    public GameObject northExit, southExit, eastExit, westExit, southeastExit, southwestExit, northeastExit, northwestExit;
    private GameObject[] listOfExits;
    private string[] direcitons;
    // Start is called before the first frame update
    void Start()
    {
        this.listOfExits = new GameObject[8] { northExit, southExit, eastExit, westExit, southeastExit, southwestExit, northeastExit, northwestExit };
        this.direcitons = new string[8] { "north", "south", "east", "west", "southeast", "southwest", "northeast", "northwest" };
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if (MasterData.count > 0 && MasterData.hasArrivedAtCenter || MasterData.count == 0 && enableFights)
        {

            if (Random.Range(1, 100) <= this.changeToGetIntoFight)
            {
                for (int i = 0; i < 8; i++)
                {
                    if (this.direcitons[i].Equals(MasterData.directionheaded))
                    {
                        Destroy(MasterData.musicLooper);
                        MasterData.musicLooper = null;
                        MasterData.whereDidIComeFrom = this.listOfExits[i].name;
                        MasterData.count++;
                        MasterData.p.getCurrentRoom().takeExit(MasterData.p, MasterData.whereDidIComeFrom);
                        SceneManager.LoadScene("FightScene");
                    }
                }
            }
        }
    }
}
