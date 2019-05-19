using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Linq;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Utilities;

namespace HelpfulNPCs
{
    [AutoloadHead]
    public class EnvironmentalistNPC : ModNPC
    {
        public static bool Plants = false;

        public override bool Autoload(ref string name)
        {
            name = "Environmentalist";
            return mod.Properties.Autoload;
        }

        public override string Texture
        {
            get
            {
                return "HelpfulNPCs/EnvironmentalistNPC";
            }
        }


        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Environmentalist");
            Main.npcFrameCount[npc.type] = 25;
            NPCID.Sets.AttackFrameCount[npc.type] = 4;
            NPCID.Sets.DangerDetectRange[npc.type] = 150;
            NPCID.Sets.AttackType[npc.type] = 3;
            NPCID.Sets.AttackTime[npc.type] = 17;
            NPCID.Sets.AttackAverageChance[npc.type] = 10;
            NPCID.Sets.HatOffsetY[npc.type] = 4;
        }

        public override void SetDefaults()
        {
            npc.townNPC = true;
            npc.friendly = true;
            npc.width = 18;
            npc.height = 40;
            npc.aiStyle = 7;
            npc.damage = 10;
            npc.defense = 15;
            npc.lifeMax = 500;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.knockBackResist = 0.5f;
            animationType = NPCID.Merchant;
        }

        public override bool CanTownNPCSpawn(int numTownNPCs, int money)
        {
            if (NPC.downedQueenBee && Config.EnvironmentalistCanSpawn)
            {
                return true;
            }
            return false;
        }

        public override string TownNPCName()
        {
            switch (WorldGen.genRand.Next(4))
            {
                case 0:
                    return "Gregor";
                case 1:
                    return "Mendal";
                case 2:
                    return "Theophrastus";
                default:
                    return "Hooke";
            }
        }

        public override string GetChat()
        {
            switch (Main.rand.Next(3))
            {
                case 0:
                    return "Hey! Don't step on my plants!";
                case 1:
                    return "There's no such thing as magic beanstalks.";
                case 2:
                    return "I can pull a bunny out of my hat!";
                default:
                    return "Growing plants takes hardwork and dedication.";
            }
        }

        public override void SetChatButtons(ref string button, ref string button2)
        {
            button = "Plants";
            button2 = "Critters";
        }

        public override void OnChatButtonClicked(bool firstButton, ref bool shop)
        {
            Plants = firstButton;
            shop = true;


        }

        public override void SetupShop(Chest shop, ref int nextSlot)
        {
            if (Plants)
            {

                shop.item[nextSlot].SetDefaults(ItemID.ClayPot);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.StaffofRegrowth);
                shop.item[nextSlot].shopCustomPrice = 10000;
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.FlowerBoots);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.NaturesGift);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.Coral);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.Seashell);
                shop.item[nextSlot].shopCustomPrice = 100;
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.Starfish);
                shop.item[nextSlot].shopCustomPrice = 100;
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.Mushroom);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.GrassSeeds);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.GlowingMushroom);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.MushroomGrassSeeds);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.VileMushroom);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.CorruptSeeds);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.ViciousMushroom);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.CrimsonSeeds);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.Blinkroot);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.BlinkrootSeeds);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.Daybloom);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.DaybloomSeeds);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.Deathweed);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.DeathweedSeeds);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.Fireblossom);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.FireblossomSeeds);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.Moonglow);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.MoonglowSeeds);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.Shiverthorn);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.ShiverthornSeeds);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.Waterleaf);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.WaterleafSeeds);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.Pumpkin);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.PumpkinSeed);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.JungleSpores);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.JungleGrassSeeds);
                nextSlot++;
                if (Main.hardMode)
                {
                    shop.item[nextSlot].SetDefaults(ItemID.HallowedSeeds);
                    nextSlot++;
                }
            }
            else
            {
                shop.item[nextSlot].SetDefaults(ItemID.Bird);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.BlackScorpion);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.BlueJay);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.Buggy);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.Bunny);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.Cardinal);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.Duck);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.Firefly);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.Frog);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.GlowingSnail);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.Goldfish);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.Grasshopper);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.Grubby);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.MallardDuck);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.Mouse);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.Penguin);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.SquirrelRed);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.Scorpion);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.Sluggy);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.Snail);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.Squirrel);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.Worm);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.JuliaButterfly);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.MonarchButterfly);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.PurpleEmperorButterfly);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.RedAdmiralButterfly);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.SulphurButterfly);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.TreeNymphButterfly);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.UlyssesButterfly);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.ZebraSwallowtailButterfly);
                nextSlot++;

                if (Main.hardMode)
                {
                    shop.item[nextSlot].SetDefaults(ItemID.LightningBug);
                    nextSlot++;
                }

                if (NPC.downedGolemBoss || NPC.downedFishron)
                {
                    shop.item[nextSlot].SetDefaults(ItemID.TruffleWorm);
                    nextSlot++;
                }
            }
        }

        public override void TownNPCAttackStrength(ref int damage, ref float knockback)
        {
            damage = 20;
            knockback = 3f;
        }

        public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
        {
            cooldown = 20;
            randExtraCooldown = 20;
        }

        public override void DrawTownAttackSwing(ref Texture2D item, ref int itemSize, ref float scale, ref Vector2 offset)//Allows you to customize how this town NPC's weapon is drawn when this NPC is swinging it (this NPC must have an attack type of 3). Item is the Texture2D instance of the item to be drawn (use Main.itemTexture[id of item]), itemSize is the width and height of the item's hitbox
        {
            scale = 1f;
            item = Main.itemTexture[ItemID.StaffofRegrowth]; ; //this defines the item that this npc will use
            itemSize = 50;
        }

        public override void TownNPCAttackSwing(ref int itemWidth, ref int itemHeight) //  Allows you to determine the width and height of the item this town NPC swings when it attacks, which controls the range of this NPC's swung weapon.
        {
            itemWidth = 50;
            itemHeight = 50;
        }
    }
}