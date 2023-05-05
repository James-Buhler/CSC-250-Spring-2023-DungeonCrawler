using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCotroller : MonoBehaviour
{
    private Rigidbody rb;
    public GameObject northExit, southExit, eastExit, westExit, southeastExit, southwestExit, northeastExit, northwestExit;
    public GameObject hp1, hp2, hp3, hp4, hp5, hp6, hp7, hp8, hp9, hp10;
    public GameObject origin;
    private GameObject[] listOfExits;
    private GameObject[] exitMap;
    private GameObject[] hpBank;
    public float movementSpeed;
    private bool buttonWasPressed;
    private Vector3 opositeDirection;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(HealthBarUpdate());
        this.rb = this.GetComponent<Rigidbody>();
        this.listOfExits = new GameObject[8] { northExit, southExit, eastExit, westExit, southeastExit, southwestExit, northeastExit, northwestExit };
        this.exitMap = new GameObject[8] { southExit, northExit, westExit, eastExit, northwestExit, northeastExit, southwestExit, southeastExit };
        this.hpBank = new GameObject[10] { hp1, hp2, hp3, hp4, hp5, hp6, hp7, hp8, hp9, hp10 };
        for(int i = 0; i < 8; i++)
        {
            if (this.listOfExits[i].name.Equals(MasterData.whereDidIComeFrom))
            {
                this.rb.position = this.exitMap[i].transform.position;
                this.opositeDirection = this.listOfExits[i].transform.position;
            }
        }
        
        this.rb.AddForce(opositeDirection * movementSpeed);
        if (MasterData.whereDidIComeFrom.Equals("?"))
        {
            MasterData.hasArrivedAtCenter = true;
            this.buttonWasPressed = true;
        }
        else
        {
            MasterData.hasArrivedAtCenter = false;
            this.buttonWasPressed = false;
        }
        StartCoroutine(PlayerHeal());
    }

    // Update is called once per frame
    void Update()
    {
        
        if (buttonWasPressed)
        {
            if (Input.GetKeyDown(KeyCode.W) && MasterData.thePlayer.getCurrentRoom().hasExit("north"))
            {
                this.rb.AddForce(this.northExit.transform.position * movementSpeed);
                buttonWasPressed = false;
                MasterData.directionheaded = "north";
            }
            if (Input.GetKeyDown(KeyCode.S) && MasterData.thePlayer.getCurrentRoom().hasExit("south"))
            {
                this.rb.AddForce(this.southExit.transform.position * movementSpeed);
                buttonWasPressed = false;
                MasterData.directionheaded = "south";
            }
            if (Input.GetKeyDown(KeyCode.D) && MasterData.thePlayer.getCurrentRoom().hasExit("east"))
            {
                this.rb.AddForce(this.eastExit.transform.position * movementSpeed);
                buttonWasPressed = false;
                MasterData.directionheaded = "east";
            }
            if (Input.GetKeyDown(KeyCode.A) && MasterData.thePlayer.getCurrentRoom().hasExit("west"))
            {
                this.rb.AddForce(this.westExit.transform.position * movementSpeed);
                buttonWasPressed = false;
                MasterData.directionheaded = "west";
            }
            if (Input.GetKeyDown(KeyCode.Q) && MasterData.thePlayer.getCurrentRoom().hasExit("northwest"))
            {
                this.rb.AddForce(this.northwestExit.transform.position * movementSpeed);
                buttonWasPressed = false;
                MasterData.directionheaded = "northwest";
            }
            if (Input.GetKeyDown(KeyCode.E) && MasterData.thePlayer.getCurrentRoom().hasExit("northeast"))
            {
                this.rb.AddForce(this.northeastExit.transform.position * movementSpeed);
                buttonWasPressed = false;
                MasterData.directionheaded = "northeast";
            }
            if (Input.GetKeyDown(KeyCode.Z) && MasterData.thePlayer.getCurrentRoom().hasExit("southwest"))
            {
                this.rb.AddForce(this.southwestExit.transform.position * movementSpeed);
                buttonWasPressed = false;
                MasterData.directionheaded = "southwest";
            }
            if (Input.GetKeyDown(KeyCode.X) && MasterData.thePlayer.getCurrentRoom().hasExit("southeast"))
            {
                this.rb.AddForce(this.southeastExit.transform.position * movementSpeed);
                buttonWasPressed = false;
                MasterData.directionheaded = "southeast";
            }
        }
    }

    IEnumerator HealthBarUpdate()
    {
        yield return new WaitForSeconds(0.5f);
        updatehealth();
        StartCoroutine(HealthBarUpdate());
    }

    private void updatehealth()
    {
        int currentHPPercent = -1;
        currentHPPercent = MasterData.thePlayer.getHP() * 10 / MasterData.thePlayer.getMaxHP();
        for(int i = 0; i < 10; i++)
        {
            if(i <= currentHPPercent)
            {
                this.hpBank[i].SetActive(true);
            }
            else
            {
                this.hpBank[i].SetActive(false);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (MasterData.hasArrivedAtCenter)
        {
            for (int i = 0; i < 8; i++)
            {
                if (other.gameObject == this.listOfExits[i])
                {
                    MasterData.whereDidIComeFrom = this.listOfExits[i].name;
                    MasterData.count++;
                    MasterData.thePlayer.getCurrentRoom().takeExit(MasterData.thePlayer, MasterData.whereDidIComeFrom);
                    SceneManager.LoadScene("DungeonRoom");
                }
            }
        }
    }

    IEnumerator PlayerHeal()
    {
        yield return new WaitForSeconds(3f);
        MasterData.thePlayer.healHP(1);
        StartCoroutine(PlayerHeal());
    }

    private void OnTriggerEnter(Collider other)
    {
        if (MasterData.hasArrivedAtCenter == false)
        {
            if(other.gameObject == origin)
            {
                MasterData.whereDidIComeFrom = "?";
                SceneManager.LoadScene("DungeonRoom");
            }
        }
    }
}
