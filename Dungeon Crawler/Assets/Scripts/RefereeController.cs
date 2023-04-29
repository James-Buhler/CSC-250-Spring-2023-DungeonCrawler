using System.Collections;
using System.Threading;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class RefereeController : MonoBehaviour
{
    public TextMeshProUGUI playerhealth, playerarmor, playerattack, monsterhealth, monsterarmor, monsterattack;
    public GameObject monsterGO;
    public GameObject playerGO;
    private Monster theMonster;
    public TextMeshProUGUI BattleInfo;
    private bool b;
    public GameObject blackout;


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
        if (this.b)
        {
            StartCoroutine(waitBeforeFight(2.0f));
            this.b = false;
        }
        this.playerhealth.text = "Player's health: " + MasterData.p.getHP();
        this.playerarmor.text = "Player's armor: " + MasterData.p.getAC();
        this.playerattack.text = "Player's attack: " + MasterData.p.getDamage();
        this.monsterhealth.text = "Monster's health: " + this.theMonster.getHP();
        this.monsterarmor.text = "Monster's armor: " + this.theMonster.getAC();
        this.monsterattack.text = "Monster's attack: " + this.theMonster.getDamage();
        if (MasterData.p == MasterData.dudeWhoWon)
        {
            if (!MasterData.isEveryoneAlive && !MasterData.isWinnerCelebrating)
            {
                StartCoroutine(jump());
                MasterData.isWinnerCelebrating = true;
                StartCoroutine(goBackToDungeon());
            }
        }
        else
        {
            if (!MasterData.isEveryoneAlive && !MasterData.isWinnerCelebrating)
            {
                StartCoroutine(jump());
                MasterData.isWinnerCelebrating = true;
                StartCoroutine(loadYouLoseScreen());
            }
        }
    }

    IEnumerator loadYouLoseScreen ()
    {
        yield return new WaitForSeconds(1.5f);
        this.blackout.SetActive(true);
        this.BattleInfo.text = "GAME OVER";
        
    }


    IEnumerator goBackToDungeon ()
    {
        yield return new WaitForSeconds(6.0f);
        SceneManager.LoadScene("DungeonRoom");
    }

    IEnumerator jump()
    {
        MasterData.winner.AddForce(Vector3.up * 125);
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(jump());
    }

    IEnumerator waitBeforeFight(float f)
    {
        this.BattleInfo.text = "FIGHT!!!";
        yield return new WaitForSeconds(f);
        startFight();
    }

    public void startFight()
    {
        this.BattleInfo.text = MasterData.d.fight();
    }
}
