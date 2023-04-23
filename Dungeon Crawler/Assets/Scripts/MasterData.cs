using UnityEngine;

public class MasterData
{
    public static int count = 0;
    public static string whereDidIComeFrom = "?";
    private static bool isDungeonSetup = false;
    public static Dungeon cs = null;
    public static Player p = null;
    public static Monster m = null;
    public static bool hasArrivedAtCenter = true;
    public static GameObject musicLooper = null;
    public static Deathmatch d = null;
    public static bool isEveryoneAlive = true;

    public static void setupDungeon()
    {
        if(MasterData.isDungeonSetup == false)
        {
            MasterData.cs = new Dungeon(100);
            MasterData.cs.populateCSDepartment();

            MasterData.m = new Monster("Rat");
            MasterData.p = new Player("Mike");
            MasterData.cs.addPlayer(p);
            MasterData.isDungeonSetup = true;
        }
    }
}