using System;
using System.Threading;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Deathmatch
{
    private Inhabitant dude1;
    private Inhabitant dude2;
    private GameObject dude1GO;
    private GameObject dude2GO;
    private Rigidbody rbDude1;
    private Rigidbody rbDude2;
    private int turncounter;

    public Deathmatch(Inhabitant dude1, Inhabitant dude2, GameObject dude1GO, GameObject dude2GO)
    {
        this.dude1 = dude1;
        this.dude2 = dude2;
        this.dude1GO = dude1GO;
        this.dude2GO = dude2GO;
        this.rbDude1 = this.dude1GO.GetComponent<Rigidbody>();
        this.rbDude2 = this.dude2GO.GetComponent<Rigidbody>();
        this.turncounter = -1;
    }

    public string fight()
    {
        System.Random r = new System.Random();
        int roll = r.Next(1, 21);
        int damage = 0;
        string s = "";

        if (this.dude2.getHP() <= 0)
        {
            this.dude2GO.SetActive(false);
            MasterData.isEveryoneAlive = false;
            return this.dude1.getName() + " WINS!!!";
        }
        else if (this.dude1.getHP() <= 0)
        {
            this.dude1GO.SetActive(false);
            MasterData.isEveryoneAlive = false;
            return this.dude2.getName() + " WINS!!!";
        }
        if (this.turncounter == -1)
        {
            this.turncounter = r.Next(1, 3);
        }
        if (this.turncounter == 1)
        {
            this.rbDude1.AddForce(this.dude2GO.transform.position * 20.0f);
            damage = this.dude1.getDamage();
            s = s + this.dude1.getName();
            if (roll >= this.dude2.getAC())
            {
                s = s + " hit for " + damage + " damage!!!";
                this.dude2.tookDamage(damage);
            }
            else
            {
                s = s + " missed!!!";
            }
            this.turncounter = 2;
        }
        else
        {
            this.rbDude2.AddForce(this.dude1GO.transform.position * 20.0f);
            damage = this.dude2.getDamage();
            s = s + this.dude2.getName();
            if (roll >= this.dude1.getAC())
            {
                s = s + " hit for " + damage + " damage!!!";
                this.dude1.tookDamage(damage);
            }
            else
            {
                s = s + " missed!!!";
            }
            this.turncounter = 1;
        }

        return s;
        //Console.WriteLine(r.Next(1, 21));


        //goes back and forth having our inhabitant "try" to attack each other
        //-a successful attack means that a D20 is at least as high as the targets AC
        //-upon successful attack, the targets HP reduce by the attackers Attack
        //-an unsuccessful attack results in no change in HP
        //go back and forth like this until an inhabitant dies

    }
}
