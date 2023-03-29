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

    public bool southOn, northOn, eastOn, westOn, southeastOn, southwestOn, northeastOn, northwestOn;

    // Start is called before the first frame update
    void Start()
    {
        this.southExit.SetActive(southOn);
        this.northExit.SetActive(northOn);
        this.eastExit.SetActive(eastOn);
        this.westExit.SetActive(westOn);
        this.southeastExit.SetActive(southeastOn);
        this.southwestExit.SetActive(southwestOn);
        this.northeastExit.SetActive(northeastOn);
        this.northwestExit.SetActive(northwestOn);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
