using System.Collections;
using System.Threading;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RefereeController : MonoBehaviour
{
    public TextMeshProUGUI playerhealth, playerarmor, playerattack, monsterhealth, monsterarmor, monsterattack;
    public GameObject monsterGO;
    public GameObject playerGO;
    private Monster theMonster;
    public TextMeshProUGUI BattleInfo;
    private bool b;

    // Start is called before the first frame update
    void Start()
    {
        this.theMonster = new Monster("goblin");
        this.b = true;

        this.playerhealth.text = "Player's health: " + MasterData.p.getHP();
        this.playerarmor.text = "Player's armor: " + MasterData.p.getAC();
        this.playerattack.text = "Player's attack: " + MasterData.p.getDamage();
        this.monsterhealth.text = "Monster's health: " + this.theMonster.getHP();
        this.monsterarmor.text = "Monster's armor: " + this.theMonster.getAC();
        this.monsterattack.text = "Monster's attack: " + this.theMonster.getDamage();

        MasterData.d = new Deathmatch(MasterData.p, this.theMonster, this.playerGO, this.monsterGO);
    }

    // Update is called once per frame
    void Update()
    {
        if(this.b)
        {
            startFight();
            this.b = false;
        }
        this.playerhealth.text = "Player's health: " + MasterData.p.getHP();
        this.playerarmor.text = "Player's armor: " + MasterData.p.getAC();
        this.playerattack.text = "Player's attack: " + MasterData.p.getDamage();
        this.monsterhealth.text = "Monster's health: " + this.theMonster.getHP();
        this.monsterarmor.text = "Monster's armor: " + this.theMonster.getAC();
        this.monsterattack.text = "Monster's attack: " + this.theMonster.getDamage();
    }

    public void startFight()
    {
        this.BattleInfo.text = MasterData.d.fight();
    }
}
