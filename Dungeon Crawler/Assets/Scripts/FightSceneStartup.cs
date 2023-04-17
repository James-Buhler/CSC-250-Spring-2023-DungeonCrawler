using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FightSceneStartup : MonoBehaviour
{
    public TextMeshProUGUI playerhealth, playerarmor, playerattack, monsterhealth, monsterarmor, monsterattack;
    private int PlayerHP;
    private int PlayerAC;
    private int PlayerATK;
    private int MonsterHP;
    private int MonsterAC;
    private int MonsterATK;
    // Start is called before the first frame update
    void Start()
    {
        PlayerHP = Random.Range(10, 20);
        PlayerAC = Random.Range(10, 17);
        PlayerATK = Random.Range(1, 5);
        MonsterHP = Random.Range(10, 20);
        MonsterAC = Random.Range(10, 17);
        MonsterATK = Random.Range(1, 5);
        this.playerhealth.text = "Player's health: " + PlayerHP;
        this.playerarmor.text = "Player's armor: " + PlayerAC;
        this.playerattack.text = "Player's attack: " + PlayerATK;
        this.monsterhealth.text = "Monster's health: " + MonsterHP;
        this.monsterarmor.text = "Monster's armor: " + MonsterAC;
        this.monsterattack.text = "Monster's attack: " + MonsterATK;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
