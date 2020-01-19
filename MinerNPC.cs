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
    public class MinerNPC : ModNPC
    {
        public static bool Bars = false;
        public override bool Autoload(ref string name)
        {
            name = "Miner";
            return mod.Properties.Autoload;
        }

        public override string Texture
        {
            get
            {
                return "HelpfulNPCs/MinerNPC";
            }
        }


        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Miner");
            Main.npcFrameCount[npc.type] = 26;
            NPCID.Sets.AttackFrameCount[npc.type] = 5;
            NPCID.Sets.DangerDetectRange[npc.type] = 150;
            NPCID.Sets.AttackType[npc.type] = 3;
            NPCID.Sets.AttackTime[npc.type] = 25;
            NPCID.Sets.AttackAverageChance[npc.type] = 10;
            NPCID.Sets.HatOffsetY[npc.type] = -1;
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
            npc.lifeMax = 250;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.knockBackResist = 0.5f;
            animationType = NPCID.Guide;
        }

        public override bool CanTownNPCSpawn(int numTownNPCs, int money)
        {
            if (NPC.downedBoss1 && HelpfulNPCs.config.MinerCanSpawn)
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
                    return "Gold";
                case 1:
                    return "John";
                case 2:
                    return "Edward";
                default:
                    return "Thomas";
            }
        }

        public override string GetChat()
        {
            switch (Main.rand.Next(3))
            {
                case 0:
                    return "I was one of the greatest miners during the gold rush.";
                case 1:
                    return "Why go mine if you can buy everything?";
                default:
                    return "Diggy Dig Dig.";
            }
        }

        public override void SetChatButtons(ref string button, ref string button2)
        {
            button = "Bars & More";
            button2 = "Gems";
        }

        public override void OnChatButtonClicked(bool firstButton, ref bool shop)
        {
            Bars = firstButton;
            shop = true;

           
        }

        public override void SetupShop(Chest shop, ref int nextSlot)
        {
            if (Bars)
            {
                shop.item[nextSlot].SetDefaults(ItemID.StoneBlock);
                shop.item[nextSlot].shopCustomPrice = 1;
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.DirtBlock);
                shop.item[nextSlot].shopCustomPrice = 1;
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.MudBlock);
                shop.item[nextSlot].shopCustomPrice = 1;
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.Granite);
                shop.item[nextSlot].shopCustomPrice = 1;
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.Marble);
                shop.item[nextSlot].shopCustomPrice = 1;
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.CopperBar);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.TinBar);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.IronBar);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.LeadBar);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.SilverBar);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.TungstenBar);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.GoldBar);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.PlatinumBar);
                nextSlot++;

                if (NPC.downedBoss1)
                {
                    shop.item[nextSlot].SetDefaults(ItemID.DemoniteBar);
                    nextSlot++;

                    shop.item[nextSlot].SetDefaults(ItemID.CrimtaneBar);
                    nextSlot++;
                }

                if (NPC.downedBoss2)
                {


                    shop.item[nextSlot].SetDefaults(ItemID.MeteoriteBar);
                    nextSlot++;

                    shop.item[nextSlot].SetDefaults(ItemID.Obsidian);
                    shop.item[nextSlot].shopCustomPrice = Item.buyPrice(silver: 5);
                    nextSlot++;
                }

                if (NPC.downedBoss3)
                {
                    shop.item[nextSlot].SetDefaults(ItemID.HellstoneBar);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemID.LifeCrystal);
                    shop.item[nextSlot].shopCustomPrice = Item.buyPrice(gold: 5);
                    nextSlot++;
                }

                if (Main.hardMode)
                {
                    shop.item[nextSlot].SetDefaults(ItemID.CrystalShard);
                    nextSlot++;

                    shop.item[nextSlot].SetDefaults(ItemID.CobaltBar);
                    nextSlot++;

                    shop.item[nextSlot].SetDefaults(ItemID.PalladiumBar);
                    nextSlot++;

                    shop.item[nextSlot].SetDefaults(ItemID.MythrilBar);
                    nextSlot++;

                    shop.item[nextSlot].SetDefaults(ItemID.OrichalcumBar);
                    nextSlot++;

                    shop.item[nextSlot].SetDefaults(ItemID.AdamantiteBar);
                    nextSlot++;

                    shop.item[nextSlot].SetDefaults(ItemID.TitaniumBar);
                    nextSlot++;
                }

                if (NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3)
                {
                    shop.item[nextSlot].SetDefaults(ItemID.ChlorophyteBar);
                    nextSlot++;

                }

                if (NPC.downedPlantBoss)
                {
                    shop.item[nextSlot].SetDefaults(ItemID.LifeFruit);
                    shop.item[nextSlot].shopCustomPrice = Item.buyPrice(gold: 10);
                    nextSlot++;
                }

                if (NPC.downedGolemBoss)
                {
                    
                }
            }

            else
            {
                shop.item[nextSlot].SetDefaults(ItemID.Amethyst);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.Topaz);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.Sapphire);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.Emerald);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.Ruby);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.Diamond);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.Amber);
                nextSlot++;
            }
        }

        public override void TownNPCAttackStrength(ref int damage, ref float knockback)
        {
            damage = 10;
            knockback = 3f;
        }

        public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
        {
            cooldown = 20;
            randExtraCooldown = 20;
        }

        public override void DrawTownAttackSwing(ref Texture2D item, ref int itemSize, ref float scale, ref Vector2 offset)//Allows you to customize how this town NPC's weapon is drawn when this NPC is swinging it (this NPC must have an attack type of 3). Item is the Texture2D instance of the item to be drawn (use Main.itemTexture[id of item]), itemSize is the width and height of the item's hitbox
        {
            scale = 2f;
            item = Main.itemTexture[ItemID.Minecart]; //this defines the item that this npc will use
            itemSize = 32;

            if (npc.spriteDirection == 1)
            {
                offset.X = -13;
            } 

            if (npc.spriteDirection == -1)
            {
                offset.X = 13;
            }
        }

        public override void TownNPCAttackSwing(ref int itemWidth, ref int itemHeight) //  Allows you to determine the width and height of the item this town NPC swings when it attacks, which controls the range of this NPC's swung weapon.
        {
            itemWidth = 32;
            itemHeight = 32;
        }
    }
}