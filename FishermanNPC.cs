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
    public class FishermanNPC : ModNPC
    {
        public static bool Bait = false;

        public override bool Autoload(ref string name)
        {
            name = "Fisherman";
            return mod.Properties.Autoload;
        }

        public override string Texture
        {
            get
            {
                return "HelpfulNPCs/FishermanNPC";
            }
        }


        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fisherman");
            Main.npcFrameCount[npc.type] = 25;
            NPCID.Sets.AttackFrameCount[npc.type] = 4;
            NPCID.Sets.DangerDetectRange[npc.type] = 150;
            NPCID.Sets.AttackType[npc.type] = 3;
            NPCID.Sets.AttackTime[npc.type] = 23;
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
            npc.lifeMax = 250;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.knockBackResist = 0.5f;
            animationType = NPCID.Merchant;
        }

        public override bool CanTownNPCSpawn(int numTownNPCs, int money)
        {
            if (NPC.npcsFoundForCheckActive[NPCID.Angler] && Config.FishermanCanSpawn)
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
                    return "Ernest";
                case 1:
                    return "Thomas";
                case 2:
                    return "Michael";
                default:
                    return "Curt";
            }
        }

        public override string GetChat()
        {
            switch (Main.rand.Next(3))
            {
                case 0:
                    return "Give a man a fish, and you feed him for a day. Teach a man to fish, and you feed him for a lifetime.";
                case 1:
                    return "*Snore*";
                default:
                    return "How come sometimes I fish up junk? Who's been throwing things in the water?";
            }
        }

        public override void SetChatButtons(ref string button, ref string button2)
        {
            button = "Fish and Bait";
            button2 = "Quest Fish";
        }

        public override void OnChatButtonClicked(bool firstButton, ref bool shop)
        {
            Bait = firstButton;
            shop = true;


        }

        public override void SetupShop(Chest shop, ref int nextSlot)
        {
            if (Bait)
            {
                shop.item[nextSlot].SetDefaults(ItemID.ApprenticeBait);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.JourneymanBait);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.MasterBait);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.ArmoredCavefish);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.AtlanticCod);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.Bass);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.ChaosFish);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.CrimsonTigerfish);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.Damselfish);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.DoubleCod);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.Ebonkoi);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.FlarefinKoi);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.FrostMinnow);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.GoldenCarp);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.Hemopiranha);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.Honeyfin);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.NeonTetra);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.Obsidifish);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.RedSnapper);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.Salmon);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.Shrimp);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.SpecularFish);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.Stinkfish);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.Trout);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.Tuna);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.VariegatedLardfish);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.Coral);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.Seashell);
                shop.item[nextSlot].shopCustomPrice = 100;
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.Starfish);
                shop.item[nextSlot].shopCustomPrice = 100;
                nextSlot++;

                if (Main.hardMode)
                {
                    shop.item[nextSlot].SetDefaults(ItemID.PrincessFish);
                    nextSlot++;

                    shop.item[nextSlot].SetDefaults(ItemID.Prismite);
                    nextSlot++;
                }

                if (NPC.downedGolemBoss || NPC.downedFishron)
                {
                    shop.item[nextSlot].SetDefaults(ItemID.TruffleWorm);
                    nextSlot++;
                }
            }

            else
            {
                shop.item[nextSlot].SetDefaults(ItemID.AmanitiaFungifin);
                shop.item[nextSlot].shopCustomPrice = 100000;
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.Angelfish);
                shop.item[nextSlot].shopCustomPrice = 100000;
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.Batfish);
                shop.item[nextSlot].shopCustomPrice = 100000;
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.BloodyManowar);
                shop.item[nextSlot].shopCustomPrice = 100000;
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.Bonefish);
                shop.item[nextSlot].shopCustomPrice = 100000;
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.BumblebeeTuna);
                shop.item[nextSlot].shopCustomPrice = 100000;
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.Bunnyfish);
                shop.item[nextSlot].shopCustomPrice = 100000;
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.CapnTunabeard);
                shop.item[nextSlot].shopCustomPrice = 100000;
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.Catfish);
                shop.item[nextSlot].shopCustomPrice = 100000;
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.Cloudfish);
                shop.item[nextSlot].shopCustomPrice = 100000;
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.Clownfish);
                shop.item[nextSlot].shopCustomPrice = 100000;
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.Cursedfish);
                shop.item[nextSlot].shopCustomPrice = 100000;
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.DemonicHellfish);
                shop.item[nextSlot].shopCustomPrice = 100000;
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.Derpfish);
                shop.item[nextSlot].shopCustomPrice = 100000;
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.Dirtfish);
                shop.item[nextSlot].shopCustomPrice = 100000;
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.DynamiteFish);
                shop.item[nextSlot].shopCustomPrice = 100000;
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.EaterofPlankton);
                shop.item[nextSlot].shopCustomPrice = 100000;
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.FallenStarfish);
                shop.item[nextSlot].shopCustomPrice = 100000;
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.TheFishofCthulu);
                shop.item[nextSlot].shopCustomPrice = 100000;
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.Fishotron);
                shop.item[nextSlot].shopCustomPrice = 100000;
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.Fishron);
                shop.item[nextSlot].shopCustomPrice = 100000;
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.GuideVoodooFish);
                shop.item[nextSlot].shopCustomPrice = 100000;
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.Harpyfish);
                shop.item[nextSlot].shopCustomPrice = 100000;
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.Hungerfish);
                shop.item[nextSlot].shopCustomPrice = 100000;
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.Ichorfish);
                shop.item[nextSlot].shopCustomPrice = 100000;
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.InfectedScabbardfish);
                shop.item[nextSlot].shopCustomPrice = 100000;
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.Jewelfish);
                shop.item[nextSlot].shopCustomPrice = 100000;
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.MirageFish);
                shop.item[nextSlot].shopCustomPrice = 100000;
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.Mudfish);
                shop.item[nextSlot].shopCustomPrice = 100000;
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.MutantFlinxfin);
                shop.item[nextSlot].shopCustomPrice = 100000;
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.Pengfish);
                shop.item[nextSlot].shopCustomPrice = 100000;
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.Pixiefish);
                shop.item[nextSlot].shopCustomPrice = 100000;
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.Slimefish);
                shop.item[nextSlot].shopCustomPrice = 100000;
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.Spiderfish);
                shop.item[nextSlot].shopCustomPrice = 100000;
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.TropicalBarracuda);
                shop.item[nextSlot].shopCustomPrice = 100000;
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.TundraTrout);
                shop.item[nextSlot].shopCustomPrice = 100000;
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.UnicornFish);
                shop.item[nextSlot].shopCustomPrice = 100000;
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.Wyverntail);
                shop.item[nextSlot].shopCustomPrice = 100000;
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.ZombieFish);
                shop.item[nextSlot].shopCustomPrice = 100000;
                nextSlot++;
            }
        }
            

            

        

        public override void TownNPCAttackStrength(ref int damage, ref float knockback)
        {
            damage = 15;
            knockback = 6f;
        }

        public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
        {
            cooldown = 25;
            randExtraCooldown = 25;
        }

        public override void DrawTownAttackSwing(ref Texture2D item, ref int itemSize, ref float scale, ref Vector2 offset)//Allows you to customize how this town NPC's weapon is drawn when this NPC is swinging it (this NPC must have an attack type of 3). Item is the Texture2D instance of the item to be drawn (use Main.itemTexture[id of item]), itemSize is the width and height of the item's hitbox
        {
            scale = 1f;
            item = Main.itemTexture[ItemID.Rockfish]; ; //this defines the item that this npc will use
            itemSize = 35;
        }

        public override void TownNPCAttackSwing(ref int itemWidth, ref int itemHeight) //  Allows you to determine the width and height of the item this town NPC swings when it attacks, which controls the range of this NPC's swung weapon.
        {
            itemWidth = 35;
            itemHeight = 35;
        }
    }
}