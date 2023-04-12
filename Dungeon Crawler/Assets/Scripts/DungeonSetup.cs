using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DungeonSetup : MonoBehaviour
{
    public GameObject southExit;
    public GameObject northExit;
    public GameObject eastExit;
    public GameObject westExit;
    public GameObject southeastExit;
    public GameObject southwestExit;
    public GameObject northeastExit;
    public GameObject northwestExit;

    // Start is called before the first frame update
    void Start()
    {
        MasterData.setupDungeon();
        string[] map = { "north", "south", "east", "west", "northeast", "northwest", "southwest", "southeast" };

        this.northExit.SetActive(MasterData.p.getCurrentRoom().hasExit(map[0]));
        this.southExit.SetActive(MasterData.p.getCurrentRoom().hasExit(map[1]));
        this.eastExit.SetActive(MasterData.p.getCurrentRoom().hasExit(map[2]));
        this.westExit.SetActive(MasterData.p.getCurrentRoom().hasExit(map[3]));
        this.northeastExit.SetActive(MasterData.p.getCurrentRoom().hasExit(map[4]));
        this.northwestExit.SetActive(MasterData.p.getCurrentRoom().hasExit(map[5]));
        this.southwestExit.SetActive(MasterData.p.getCurrentRoom().hasExit(map[6]));
        this.southeastExit.SetActive(MasterData.p.getCurrentRoom().hasExit(map[7]));



    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
