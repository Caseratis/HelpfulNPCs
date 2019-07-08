using Terraria.ModLoader;

namespace HelpfulNPCs
{
    class HelpfulNPCs : Mod
    {
        internal static Config config;
        public HelpfulNPCs()
        {
            Properties = new ModProperties()
            {
                Autoload = true,
                AutoloadGores = true,
                AutoloadSounds = true
            };
        }


        public override void Unload()
        {
            config = null;
        }

        public override void PostSetupContent()
        {
            Mod censusMod = ModLoader.GetMod("Census");
            if (censusMod != null)
            {
                censusMod.Call("TownNPCCondition", NPCType("Hunter"), "Eye of Cthulhu is defeated");
                censusMod.Call("TownNPCCondition", NPCType("Environmentalist"), "Queen Bee is defeated");
                censusMod.Call("TownNPCCondition", NPCType("Miner"), "Eye of Cthulhu is defeated");
                censusMod.Call("TownNPCCondition", NPCType("Fisherman"), "Have an angler");
            }
        }
    }
}

 
