using System;
using System.IO;
using Terraria;
using Terraria.IO;
using Terraria.ModLoader;

public static class Config
{
    public static bool MinerCanSpawn = true;
    public static bool FishermanCanSpawn = true;
    public static bool HunterCanSpawn = true;
    public static bool EnvironmentalistCanSpawn = true;

    private static string ConfigPath = Path.Combine(Main.SavePath, "Mod Configs", "HelpfulNPCConfig.json");

    private static Preferences Configuration = new Preferences(Config.ConfigPath, false, false);

    public static void Load()
    {
        if (!Config.ReadConfig())
        {
            ErrorLogger.Log("Failed to read Loot Bag config file! Recreating config...");
            Config.CreateConfig();
        }
    }

    private static bool ReadConfig()
    {
        bool result;
        if (Config.Configuration.Load())
        {
            Config.Configuration.Get<bool>("MinerCanSpawn", ref Config.MinerCanSpawn);
            Config.Configuration.Get<bool>("FishermanCanSpawn", ref Config.FishermanCanSpawn);
            Config.Configuration.Get<bool>("HunterCanSpawn", ref Config.HunterCanSpawn);
            Config.Configuration.Get<bool>("EnvironmentalistCanSpawn", ref Config.EnvironmentalistCanSpawn);
            result = true;
        }
        else
        {
            result = false;
        }
        return result;
    }

    private static void CreateConfig()
    {
        Config.Configuration.Clear();
        Config.Configuration.Put("MinerCanSpawn", Config.MinerCanSpawn);
        Config.Configuration.Put("FishermanCanSpawn", Config.FishermanCanSpawn);
        Config.Configuration.Put("HunterCanSpawn", Config.HunterCanSpawn);
        Config.Configuration.Put("EnvironmentalistCanSpawn", Config.EnvironmentalistCanSpawn);
        Config.Configuration.Save(true);
    }
}
