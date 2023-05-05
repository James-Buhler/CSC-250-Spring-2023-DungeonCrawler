using System;
public class Inhabitant
{
    protected int maxhp;
    protected int hp;
    protected int ac;
    protected int damage;
    protected string name;
    public Inhabitant(string name)
    {
        this.name = name;
        Random r = new Random();
        this.hp = r.Next(10, 21);
        this.maxhp = this.hp;
        this.ac = r.Next(10, 18);
        this.damage = r.Next(1, 6);
    }

    public void tookDamage(int i)
    {
        this.hp = this.hp - i;
        if (this.hp < 0)
        {
            this.hp = 0;
        }
    }
    public int getHP()
    {
        return this.hp;
    }

    public int getAC()
    {
        return this.ac;
    }

    public int getDamage()
    {
        return this.damage;
    }

    public string getName()
    {
        return this.name;
    }

    public string getData()
    {
        string s = this.name;
        s = s + " - " + this.hp + " / " + this.ac + " / " + this.damage;
        return s;
    }

    public void healHP(int amount)
    {
        if(this.hp + amount >= this.maxhp)
        {
            this.hp = this.maxhp;
        }
        else
        {
            this.hp += amount;
        }
    }

    public int getMaxHP()
    {
        return this.maxhp;
    }
}