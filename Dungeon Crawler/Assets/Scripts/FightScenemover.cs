using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FightScenemover : MonoBehaviour
{
    private Rigidbody rb;
    public GameObject origin;
    private Vector3 startingPosition;
    private Quaternion startingRotation;
    private bool first;
    public TextMeshProUGUI BattleInfo;

    // Start is called before the first frame update
    void Start()
    {
        this.rb = this.GetComponent<Rigidbody>();
        this.startingPosition = this.transform.position;
        this.startingRotation = this.transform.rotation;
        this.first = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "turnaround")
        {
            this.rb.angularVelocity = Vector3.zero;
            this.rb.velocity = Vector3.zero;
            this.rb.AddForce(this.origin.transform.position * 20.0f);
            this.first = true;
        }
        if (other.tag == "Origin" && first)
        {
            this.rb.angularVelocity = Vector3.zero;
            this.rb.velocity = Vector3.zero;
            this.transform.position = this.startingPosition;
            this.transform.rotation = this.startingRotation;
            if (MasterData.isEveryoneAlive)
            {
                this.BattleInfo.text = MasterData.d.fight();
            }
        }
    }
}
