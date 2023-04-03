using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerCotroller : MonoBehaviour
{
    private Rigidbody rb;
    public GameObject player;
    public GameObject northExit, southExit, eastExit, westExit, southeastExit, southwestExit, northeastExit, northwestExit;
    private float movementSpeed = 40.0f;
    private Vector3 originOfPlayer;
    bool buttonWasPressed = true;

    // Start is called before the first frame update
    void Start()
    {
        this.rb = this.GetComponent<Rigidbody>();
        print(MasterData.count);
        this.originOfPlayer.x = -1.3f;
        this.originOfPlayer.y = 1.54f;
        this.originOfPlayer.z = -0.4f;
    }

    // Update is called once per frame
    void Update()
    {

        if (buttonWasPressed)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                this.rb.AddForce(this.northExit.transform.position * movementSpeed);
                buttonWasPressed = false;
            }
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                this.rb.AddForce(this.southExit.transform.position * movementSpeed);
                buttonWasPressed = false;
            }
            if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                this.rb.AddForce(this.eastExit.transform.position * movementSpeed);
                buttonWasPressed = false;
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                this.rb.AddForce(this.westExit.transform.position * movementSpeed);
                buttonWasPressed = false;
            }
        }

        if (false)
        {
            MasterData.count++;
            SceneManager.LoadScene("DungeonRoom");
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("north"))
        {
            MasterData.count++;
            SceneManager.LoadScene("DungeonRoom");
        }
        if (other.tag.Equals("south"))
        {
            MasterData.count++;
            SceneManager.LoadScene("DungeonRoom");
        }
        if (other.tag.Equals("east"))
        {
            MasterData.count++;
            SceneManager.LoadScene("DungeonRoom");
        }
        if (other.tag.Equals("west"))
        {
            MasterData.count++;
            SceneManager.LoadScene("DungeonRoom");
        }
    }
}
