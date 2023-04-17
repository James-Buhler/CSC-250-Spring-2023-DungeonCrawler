using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCotroller : MonoBehaviour
{
    private Rigidbody rb;
    public GameObject northExit, southExit, eastExit, westExit, southeastExit, southwestExit, northeastExit, northwestExit;
    public GameObject origin;
    private GameObject[] listOfExits;
    private GameObject[] exitMap;
    public float movementSpeed;
    bool buttonWasPressed;
    bool hasArrivedAtCenter;
    private Vector3 opositeDirection;

    // Start is called before the first frame update
    void Start()
    {
        print(Random.Range(1, 10));
        this.rb = this.GetComponent<Rigidbody>();
        this.listOfExits = new GameObject[8] { northExit, southExit, eastExit, westExit, southeastExit, southwestExit, northeastExit, northwestExit };
        this.exitMap = new GameObject[8] { southExit, northExit, westExit, eastExit, northwestExit, northeastExit, southwestExit, southeastExit };
        print(MasterData.whereDidIComeFrom);
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
            this.hasArrivedAtCenter = true;
            this.buttonWasPressed = true;
        }
        else
        {
            this.hasArrivedAtCenter = false;
            this.buttonWasPressed = false;
            if (MasterData.count > 0)
            {
                if (Random.Range(1, 100) <= 30)
                {
                    SceneManager.LoadScene("FightScene");

                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {

        if (buttonWasPressed)
        {
            if (Input.GetKeyDown(KeyCode.W) && MasterData.p.getCurrentRoom().hasExit("north"))
            {
                this.rb.AddForce(this.northExit.transform.position * movementSpeed);
                buttonWasPressed = false;
            }
            if (Input.GetKeyDown(KeyCode.S) && MasterData.p.getCurrentRoom().hasExit("south"))
            {
                this.rb.AddForce(this.southExit.transform.position * movementSpeed);
                buttonWasPressed = false;
            }
            if (Input.GetKeyDown(KeyCode.D) && MasterData.p.getCurrentRoom().hasExit("east"))
            {
                this.rb.AddForce(this.eastExit.transform.position * movementSpeed);
                buttonWasPressed = false;
            }
            if (Input.GetKeyDown(KeyCode.A) && MasterData.p.getCurrentRoom().hasExit("west"))
            {
                this.rb.AddForce(this.westExit.transform.position * movementSpeed);
                buttonWasPressed = false;
            }
            if (Input.GetKeyDown(KeyCode.Q) && MasterData.p.getCurrentRoom().hasExit("northwest"))
            {
                this.rb.AddForce(this.northwestExit.transform.position * movementSpeed);
                buttonWasPressed = false;
            }
            if (Input.GetKeyDown(KeyCode.E) && MasterData.p.getCurrentRoom().hasExit("northeast"))
            {
                this.rb.AddForce(this.northeastExit.transform.position * movementSpeed);
                buttonWasPressed = false;
            }
            if (Input.GetKeyDown(KeyCode.Z) && MasterData.p.getCurrentRoom().hasExit("southwest"))
            {
                this.rb.AddForce(this.southwestExit.transform.position * movementSpeed);
                buttonWasPressed = false;
            }
            if (Input.GetKeyDown(KeyCode.X) && MasterData.p.getCurrentRoom().hasExit("southeast"))
            {
                this.rb.AddForce(this.southeastExit.transform.position * movementSpeed);
                buttonWasPressed = false;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (this.hasArrivedAtCenter)
        {
            for (int i = 0; i < 8; i++)
            {
                if (other.gameObject == this.listOfExits[i])
                {
                    MasterData.whereDidIComeFrom = this.listOfExits[i].name;
                    MasterData.count++;
                    MasterData.p.getCurrentRoom().takeExit(MasterData.p, MasterData.whereDidIComeFrom);
                    SceneManager.LoadScene("DungeonRoom");
                }
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (this.hasArrivedAtCenter == false)
        {
            if(other.gameObject == origin)
            {
                MasterData.whereDidIComeFrom = "?";
                SceneManager.LoadScene("DungeonRoom");
            }
        }
    }
}
