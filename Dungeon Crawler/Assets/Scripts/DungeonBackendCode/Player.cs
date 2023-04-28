public class Player : Inhabitant
{
    private Room currentRoom;

    public Player(string name) : base(name)
    {
        this.damage = 100;
    }

    public Room getCurrentRoom()
    {
        return this.currentRoom;
    }

    public void setCurrentRoom(Room r)
    {
        if (r != null)
        {
            this.currentRoom = r;
        }
    }

}