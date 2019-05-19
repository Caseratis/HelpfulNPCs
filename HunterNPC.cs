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
    public class HunterNPC : ModNPC
    {
        public static bool Drops = false;
        public override bool Autoload(ref string name)
        {
            name = "Hunter";
            return mod.Properties.Autoload;
        }

        public override string Texture
        {
            get
            {
                return "HelpfulNPCs/HunterNPC";
            }
        }


        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hunter");
            Main.npcFrameCount[npc.type] = 25;
            NPCID.Sets.AttackFrameCount[npc.type] = 4;
            NPCID.Sets.DangerDetectRange[npc.type] = 250;
            NPCID.Sets.AttackType[npc.type] = 1;
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
            npc.defense = 30;
            npc.lifeMax = 500;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.knockBackResist = 0.5f;
            animationType = NPCID.Merchant;
        }

        public override bool CanTownNPCSpawn(int numTownNPCs, int money)
        {
            if (NPC.downedBoss1 && Config.HunterCanSpawn)
            {
                return true;
            }
            return false;
        }

        public override string TownNPCName()
        {
            return "Hunter";
        }

        public override string GetChat()
        {
            switch (Main.rand.Next(4))
            {
                case 0:
                    return "Pew Pew Pew";
                case 1:
                    return "Collecting monster souls is child's play.";
                case 2:
                    return "Yes, I am Hunter the Hunter.";
            
                default:
                    return "You should be glad that I'm not hunting you.";
            }
        }

        public override void SetChatButtons(ref string button, ref string button2)
        {
            button = "Monster Drops";
            button2 = "Ammo";
        }

        public override void OnChatButtonClicked(bool firstButton, ref bool shop)
        {
            Drops = firstButton;
            shop = true;


        }

        public override void SetupShop(Chest shop, ref int nextSlot)
        {
            if (Drops)
            {
                shop.item[nextSlot].SetDefaults(ItemID.Gel);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.PinkGel);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.AntlionMandible);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.RottenChunk);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.Vertebrae);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.WormTooth);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.Hook);
                nextSlot++;

                shop.item[nextSlot].SetDefaults(ItemID.SharkFin);
                nextSlot++;

                if (NPC.downedBoss2)
                {
                    shop.item[nextSlot].SetDefaults(ItemID.ShadowScale);
                    nextSlot++;

                    shop.item[nextSlot].SetDefaults(ItemID.TissueSample);
                    nextSlot++;
                }

                if (NPC.downedBoss3)
                {
                    shop.item[nextSlot].SetDefaults(ItemID.Bone);
                    nextSlot++;    
                }

                if (NPC.downedQueenBee || NPC.downedBoss3)
                {
                    shop.item[nextSlot].SetDefaults(ItemID.Feather);
                    nextSlot++;

                    shop.item[nextSlot].SetDefaults(ItemID.Stinger);
                    nextSlot++;

                    shop.item[nextSlot].SetDefaults(ItemID.Vine);
                    nextSlot++;


                }

                if (Main.hardMode == true)
                {
                    shop.item[nextSlot].SetDefaults(ItemID.CursedFlame);
                    nextSlot++;

                    shop.item[nextSlot].SetDefaults(ItemID.Ichor);
                    nextSlot++;

                    shop.item[nextSlot].SetDefaults(ItemID.DarkShard);
                    nextSlot++;

                    shop.item[nextSlot].SetDefaults(ItemID.LightShard);
                    nextSlot++;

                    shop.item[nextSlot].SetDefaults(ItemID.PixieDust);
                    nextSlot++;

                    shop.item[nextSlot].SetDefaults(ItemID.UnicornHorn);
                    nextSlot++;

                    shop.item[nextSlot].SetDefaults(ItemID.LivingFireBlock);
                    shop.item[nextSlot].shopCustomPrice = Item.buyPrice(copper: 5);
                    nextSlot++;

                    shop.item[nextSlot].SetDefaults(ItemID.SoulofLight);
                    nextSlot++;

                    shop.item[nextSlot].SetDefaults(ItemID.SoulofNight);
                    nextSlot++;

                    shop.item[nextSlot].SetDefaults(ItemID.SoulofFlight);
                    nextSlot++;


                }

                if (NPC.downedMechBoss1 && NPC.downedMechBoss2 && NPC.downedMechBoss3)
                {

                    shop.item[nextSlot].SetDefaults(ItemID.HallowedBar);
                    nextSlot++;

                    shop.item[nextSlot].SetDefaults(ItemID.RodofDiscord);
                    shop.item[nextSlot].shopCustomPrice = Item.buyPrice(platinum: 3);
                    nextSlot++;

                    shop.item[nextSlot].SetDefaults(ItemID.SoulofSight);
                    nextSlot++;

                    shop.item[nextSlot].SetDefaults(ItemID.SoulofMight);
                    nextSlot++;

                    shop.item[nextSlot].SetDefaults(ItemID.SoulofFright);
                    nextSlot++;

                    shop.item[nextSlot].SetDefaults(ItemID.TurtleShell);
                    shop.item[nextSlot].shopCustomPrice = Item.buyPrice(gold: 5);
                    nextSlot++;
                }

                if (NPC.downedPlantBoss)
                {
                    shop.item[nextSlot].SetDefaults(ItemID.Ectoplasm);
                    nextSlot++;


                }

                if (NPC.downedGolemBoss)
                {


                    shop.item[nextSlot].SetDefaults(ItemID.LunarTabletFragment);
                    shop.item[nextSlot].shopCustomPrice = Item.buyPrice(silver: 25);
                    nextSlot++;
                }

                if (NPC.downedMoonlord)
                {
                    shop.item[nextSlot].SetDefaults(ItemID.FragmentSolar);
                    nextSlot++;

                    shop.item[nextSlot].SetDefaults(ItemID.FragmentVortex);
                    nextSlot++;

                    shop.item[nextSlot].SetDefaults(ItemID.FragmentNebula);
                    nextSlot++;

                    shop.item[nextSlot].SetDefaults(ItemID.FragmentStardust);
                    nextSlot++;
                }
            }

            

            else {
                shop.item[nextSlot].SetDefaults(ItemID.MusketBall);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.SilverBullet);
                nextSlot++;
                if (NPC.downedBoss2)
                {
                    shop.item[nextSlot].SetDefaults(ItemID.MeteorShot);
                    nextSlot++;
                }
                if (Main.hardMode)
                {
                    shop.item[nextSlot].SetDefaults(ItemID.PartyBullet);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemID.CursedBullet);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemID.IchorBullet);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemID.CrystalBullet);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemID.GoldenBullet);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemID.ExplodingBullet);
                    nextSlot++;
                }

                if (NPC.downedMechBossAny)
                {
                    shop.item[nextSlot].SetDefaults(ItemID.HighVelocityBullet);
                    nextSlot++;
                }
                if (NPC.downedPlantBoss)
                {
                    shop.item[nextSlot].SetDefaults(ItemID.ChlorophyteBullet);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemID.NanoBullet);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemID.VenomBullet);
                    nextSlot++;
                }
                if (NPC.downedMoonlord)
                {
                    shop.item[nextSlot].SetDefaults(ItemID.MoonlordBullet);
                    nextSlot++;
                }

                shop.item[nextSlot].SetDefaults(ItemID.WoodenArrow);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.FlamingArrow);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.FrostburnArrow);
                nextSlot++;
                shop.item[nextSlot].SetDefaults(ItemID.BoneArrow);
                nextSlot++;
                if (NPC.downedBoss1)
                {
                    shop.item[nextSlot].SetDefaults(ItemID.JestersArrow);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemID.UnholyArrow);
                    nextSlot++;
                }
                if (NPC.downedBoss3)
                {
                    shop.item[nextSlot].SetDefaults(ItemID.HellfireArrow);
                    nextSlot++;
                }
                if (Main.hardMode)
                {
                    shop.item[nextSlot].SetDefaults(ItemID.CursedArrow);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemID.IchorArrow);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemID.HolyArrow);
                    nextSlot++;
                }
                if (NPC.downedPlantBoss)
                {
                    shop.item[nextSlot].SetDefaults(ItemID.ChlorophyteArrow);
                    nextSlot++;
                    shop.item[nextSlot].SetDefaults(ItemID.VenomArrow);
                    nextSlot++;
                }
                if (NPC.downedMoonlord)
                {
                    shop.item[nextSlot].SetDefaults(ItemID.MoonlordArrow);
                    nextSlot++;
                }

            }
            
        }

        public override void TownNPCAttackStrength(ref int damage, ref float knockback)
        {
            if (!Main.hardMode)
            {
                damage = 15;
                knockback = 2f;
            }
            else
            {
                damage = 50;
                knockback = 10f;
            }

        }

        public override void DrawTownAttackGun(ref float scale, ref int item, ref int closeness)
        {
            if (!Main.hardMode)
            {
                scale = 1f;
                item = ItemID.Musket;
                closeness = 1;
            }
            else
            {
                scale = 1f;
                item = ItemID.SniperRifle;
                closeness = 1;
            }
        }

        public override void TownNPCAttackCooldown(ref int cooldown, ref int randExtraCooldown)
        {
            if (!Main.hardMode)
            {
                cooldown = 10;
                randExtraCooldown = 20;
            }
            else
            {
                cooldown = 30;
                randExtraCooldown = 40;
            }

        }

        public override void TownNPCAttackProj(ref int projType, ref int attackDelay)
        {
            if (!Main.hardMode)
            {
                projType = ProjectileID.Bullet;
                attackDelay = 3;
            }
            else
            {
                projType = ProjectileID.BulletHighVelocity;
                attackDelay = 5;
            }

        }

        public override void TownNPCAttackProjSpeed(ref float multiplier, ref float gravityCorrection, ref float randomOffset)
        {
            if (!Main.hardMode)
            {
                multiplier = 15f;
                randomOffset = 0.5f;
            }

            else
            {
                multiplier = 20f;
                randomOffset = 0f;
            }

        }
    }
}