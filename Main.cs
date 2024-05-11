using MelonLoader;
using BTD_Mod_Helper;
using boxermonkey;
using BTD_Mod_Helper.Api.Display;
using BTD_Mod_Helper.Api.Towers;
using BTD_Mod_Helper.Extensions;
using Il2CppAssets.Scripts.Models.Towers;
using Il2CppAssets.Scripts.Models.Towers.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Emissions;
using Il2CppAssets.Scripts.Models.Towers.Projectiles.Behaviors;
using Il2CppAssets.Scripts.Models.TowerSets;
using Il2CppAssets.Scripts.Simulation.Towers;
using Il2CppAssets.Scripts.Simulation.Towers.Weapons;
using Il2CppAssets.Scripts.Unity;
using Il2CppAssets.Scripts.Unity.Display;
using Il2CppSystem.IO;
using UnityEngine;
using BTD_Mod_Helper.Api.Enums;
using Il2CppAssets.Scripts.Simulation.Bloons;
using Il2CppAssets.Scripts.Simulation.Towers.Projectiles;
using Il2Cpp;
using BTD_Mod_Helper.Api;
using Il2CppAssets.Scripts.Models.Towers.Weapons.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Abilities;
using Il2CppAssets.Scripts.Models.Towers.TowerFilters;
using Il2CppAssets.Scripts.Models.Map;
using System.Collections.Generic;
using System.Linq;
using Il2CppAssets.Scripts.Models.GenericBehaviors;
using Il2CppAssets.Scripts.Models.Towers.Filters;
using System.Runtime.CompilerServices;
using Il2CppAssets.Scripts.Models.Bloons.Behaviors;
using Il2CppAssets.Scripts.Models.Towers.Behaviors.Attack.Behaviors;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Il2CppAssets.Scripts.Models;

[assembly: MelonInfo(typeof(boxermonkey.boxermonkey), ModHelperData.Name, ModHelperData.Version, ModHelperData.RepoOwner)]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]

namespace boxermonkey
{
    public class boxermonkey : BloonsTD6Mod
    {
        public override void OnApplicationStart()
        {
            ModHelper.Msg<boxermonkey>("Boxer Monkey loaded!");
        }
        public class exampul1 : ModTower
        {
            public override string Portrait => "000_boxer";
            public override string Icon => "portrait";

            public override TowerSet TowerSet => TowerSet.Primary;
            public override string BaseTower => TowerType.DartMonkey;
            public override int Cost => 250;

            public override int TopPathUpgrades => 5;
            public override int MiddlePathUpgrades => 5;
            public override int BottomPathUpgrades => 5;
            public override string Description => "Throws strong and fast Punches for the exchange of low range.";

            public override string DisplayName => "Boxer Monkey";

            public override void ModifyBaseTowerModel(TowerModel towerModel)
            {
                towerModel.ApplyDisplay<Wyglad>();
                towerModel.range = 20;
                var attackModel = towerModel.GetAttackModel();
                attackModel.range = 20;
                attackModel.weapons[0].projectile.GetDamageModel().damage = 2;
                var projectile = attackModel.weapons[0].projectile;
                projectile.ApplyDisplay<Projectile1>(); 
                projectile.pierce = 1;
                attackModel.weapons[0].Rate = 0.9f;
                attackModel.weapons[0].projectile.GetBehavior<TravelStraitModel>().Lifespan = 0.2f;
            }
        }
        public class Wyglad : ModCustomDisplay
        {
            public override string AssetBundleName => "boxermonkey222"; // loads from "assets.bundle"
            public override string PrefabName => "boxer000"; // loads the "MyModel" prefab

            public override void ModifyDisplayNode(UnityDisplayNode node)
            {
                node.transform.GetChild(0).transform.localScale *= 86;
                foreach (var meshRenderer in node.GetMeshRenderers())
                {
                    meshRenderer.ApplyOutlineShader();

                    meshRenderer.SetOutlineColor(new Color(108 / 255f, 0 / 255f, 0 / 255f));
                }
            }
        }
        public class Projectile1 : ModDisplay
        {
            public override string BaseDisplay => Generic2dDisplay;

            public override void ModifyDisplayNode(UnityDisplayNode node)
            {
                Set2DTexture(node, Name);
            }
        }
        public class Projectile2 : ModDisplay
        {
            public override string BaseDisplay => Generic2dDisplay;

            public override void ModifyDisplayNode(UnityDisplayNode node)
            {
                Set2DTexture(node, Name);
            }
        }
        public class Projectile3 : ModDisplay
        {
            public override string BaseDisplay => Generic2dDisplay;

            public override void ModifyDisplayNode(UnityDisplayNode node)
            {
                Set2DTexture(node, Name);
            }
        }
        public class Projectile4 : ModDisplay
        {
            public override string BaseDisplay => Generic2dDisplay;

            public override void ModifyDisplayNode(UnityDisplayNode node)
            {
                Set2DTexture(node, Name);
            }
        }
        public override void OnWeaponFire(Weapon weapon)
        {
            if (weapon.attack.tower.towerModel.name.Contains("testmod1-exampul1"))
            {
                weapon.attack.tower.Node.graphic.GetComponent<Animator>().SetTrigger("Punch");
            }
        }
        public class u100 : ModUpgrade<exampul1>
        {

            public override int Path => TOP;
            public override int Tier => 1;
            public override int Cost => 190;
            public override string Portrait => "100copy";
            public override string Icon => "100";
            public override string DisplayName => "Faster Punch throws";
            public override string Description => "Slightly increases Attack speed";

            public override void ApplyUpgrade(TowerModel tower)
            {
                tower.ApplyDisplay<looks100>();
                foreach (var weaponModel in tower.GetWeapons())
                {
                    weaponModel.Rate -= 0.1f;
                }
            }
        }
        public class u010 : ModUpgrade<exampul1>
        {
            public override int Path => MIDDLE;
            public override int Tier => 1;
            public override int Cost => 200;

            public override string DisplayName => "Far Strikes";
            public override string Description => "Very Slightly Increases Range";
            public override string Icon => "010";
            public override string Portrait => "010copy";

            public override void ApplyUpgrade(TowerModel tower)
            {
                foreach (var weaponModel in tower.GetWeapons())
                {
                    {
                        tower.ApplyDisplay<looks010>();
                        tower.range += 3;
                        tower.GetAttackModel().range += 3;
                    }
                }
            }
        }
        public class u001 : ModUpgrade<exampul1>
        {
            public override int Path => BOTTOM;
            public override int Tier => 1;
            public override int Cost => 340;

            public override string Description => "Slightly Increases Damage";
            public override string DisplayName => "Haymaker";
            public override string Portrait => "001copy";
            public override string Icon => "001";

            public override void ApplyUpgrade(TowerModel tower)
            {
                tower.ApplyDisplay<looks001>();
                foreach (var weaponModel in tower.GetWeapons())
                {
                    weaponModel.projectile.GetDamageModel().damage += 1;
                }
            }
        }
        public class u002 : ModUpgrade<exampul1>
        {
            public override int Path => BOTTOM;
            public override int Tier => 2;
            public override int Cost => 440;

            public override string Description => "Can pop Lead and Frozen Bloons";
            public override string DisplayName => "Iron Fists";
            public override string Portrait => "002copy";

            public override void ApplyUpgrade(TowerModel tower)
            {
                tower.ApplyDisplay<looks002>();
                foreach (var weaponModel in tower.GetWeapons())
                {
                    tower.GetAttackModel().weapons[0].projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
                }
            }
        }
        public class u020 : ModUpgrade<exampul1>
        {
            public override int Path => MIDDLE;
            public override int Tier => 2;
            public override int Cost => 170;

            public override string Description => "Increases range Even further";
            public override string DisplayName => "Spiked Gloves";
            public override string Portrait => "020copy";

            public override void ApplyUpgrade(TowerModel tower)
            {
                tower.ApplyDisplay<looks020>();
                tower.range += 3;
                tower.GetAttackModel().range += 3;
            }
        }
        public class u200 : ModUpgrade<exampul1>
        {

            public override int Path => TOP;
            public override int Tier => 2;
            public override int Cost => 210;
            public override string Portrait => "200copy";
            public override string DisplayName => "Even faster punches";
            public override string Description => "Increases Attack speed even more";

            public override void ApplyUpgrade(TowerModel tower)
            {
                tower.ApplyDisplay<looks200>();
                    foreach (var weaponModel in tower.GetWeapons())
                {
                    weaponModel.Rate -= 0.15f;
                }
            }
        }
        public class u300 : ModUpgrade<exampul1>
        {

            public override int Path => TOP;
            public override int Tier => 3;
            public override int Cost => 1600;
            public override string Portrait => "300copy";
            public override string DisplayName => "Welterweight Elite";
            public override string Description => "Greatly increases damage dealt to MOAB class Bloons";

            public override void ApplyUpgrade(TowerModel tower)
            {
                tower.ApplyDisplay<looks300>();
                foreach (var weaponModel in tower.GetWeapons())
                {
                    weaponModel.projectile.AddBehavior(new DamageModifierForTagModel("Moab", "Moab", 1, 13, false, true));
                    weaponModel.projectile.AddBehavior(new DamageModifierForTagModel("Bfb", "Bfb", 1, 5, false, true));
                    weaponModel.projectile.AddBehavior(new DamageModifierForTagModel("Zomg", "Zomg", 1, 5, false, true));
                    weaponModel.Rate -= 0.15f;
                }
            }
        }
        public class u400 : ModUpgrade<exampul1>
        {

            public override int Path => TOP;
            public override int Tier => 4;
            public override int Cost => 4200;
            public override string Portrait => "400copy";
            public override string DisplayName => "Heavyweight Champion";
            public override string Description => "Triple winner of the Ultimate Popping Championship. Increases Damage dealt and Attack rate";

            public override void ApplyUpgrade(TowerModel tower)
            {
                tower.ApplyDisplay<looks400>();
                foreach (var weaponModel in tower.GetWeapons())
                {
                    weaponModel.projectile.GetDamageModel().damage += 13;
                    weaponModel.Rate -= 0.15f;
                    weaponModel.projectile.AddBehavior(new DamageModifierForTagModel("Ddt", "Ddt", 1, 15, false, true));
                }
            }
        }
        public class u500 : ModUpgrade<exampul1>
        {
            public override int Path => TOP;
            public override int Tier => 5;
            public override int Cost => 23500;
            public override string Portrait => "500copy";
            public override string DisplayName => "Atomweight";
            public override string Description => "Nearly died trying to lose weight for the next fight, but was revived after absorbing ghostly energy.";

            public override void ApplyUpgrade(TowerModel tower)
            {
                tower.GetAttackModel().weapons[0].emission = new ArcEmissionModel("ArcEmissionModel_", 2, 0, 320, null, false, false);
                tower.ApplyDisplay<looks500>();
                var attackModel = tower.GetAttackModel();
                attackModel.weapons[0].projectile.GetBehavior<TravelStraitModel>().Lifespan *= 5.0f;
                attackModel.weapons[0].projectile.AddBehavior(Game.instance.model.GetTowerFromId("Adora 20").GetAttackModel().weapons[0].projectile.GetBehavior<AdoraTrackTargetModel>().Duplicate());
                attackModel.weapons[0].projectile.GetBehavior<AdoraTrackTargetModel>().lifespan *= 5f;
                attackModel.weapons[0].projectile.pierce += 65;
                attackModel.weapons[0].projectile.ApplyDisplay<Projectile2>();

                foreach (var weaponModel in tower.GetWeapons())
                {
                    weaponModel.projectile.GetDamageModel().damage -= 10;

                }
            }
        }
        public class u030 : ModUpgrade<exampul1>
        {
            public override int Path => MIDDLE;
            public override int Tier => 3;
            public override int Cost => 540;

            public override string Description => "Now Chops Bloons with an Axe";
            public override string DisplayName => "Axe";
            public override string Portrait => "030copy";

            public override void ApplyUpgrade(TowerModel tower)
            {
                tower.ApplyDisplay<looks030>();
                tower.range += 2;
                tower.GetAttackModel().range += 2;
                var attackModel = tower.GetAttackModel();
                var projectile = attackModel.weapons[0].projectile;
                projectile.ApplyDisplay<Projectile3>();
                projectile.pierce += 2;
                foreach (var weaponModel in tower.GetWeapons())
                {
                    weaponModel.projectile.GetDamageModel().damage += 3;
                    weaponModel.Rate -= 0.2f;
                    attackModel.weapons[0].projectile.GetBehavior<TravelStraitModel>().Lifespan = 0.1f;
                }
            }
        }
        public class u040 : ModUpgrade<exampul1>
        {
            public override int Path => MIDDLE;
            public override int Tier => 4;
            public override int Cost => 8400;

            public override string Description => "Lumberjack's Cocktail: Increases Attack rate of all Boxer Monkeys in range by 100%";
            public override string DisplayName => "Lumberjack's Cocktail";
            public override string Portrait => "040copy";

            public override void ApplyUpgrade(TowerModel tower)
            {
                tower.ApplyDisplay<looks040>();
                TowerFilterModel filter1 = new FilterInBaseTowerIdModel("BaseTowerFilter", new Il2CppStringArray(new string[] { tower.baseId }));
                ActivateRateSupportZoneModel az = Game.instance.model.towers.First(t => t.name == "IceMonkey-050").GetAbility().GetBehavior<ActivateRateSupportZoneModel>().Clone().Cast<ActivateRateSupportZoneModel>();
                az.name = "FireRateBuff";
                az.mutatorId = "boxerFireRateBuff";
                az.rateModifier = 0.3f;
                az.useTowerRange = true;
                az.isGlobal = false;
                az.canEffectThisTower = true;
                az.lifespan = 20;
                az.lifespanFrames = 999;
                az.buffIconName = "";
                az.buffLocsName = "";
                az.filters = new Il2CppReferenceArray<TowerFilterModel>(new TowerFilterModel[] { filter1 });
                AbilityModel ability = new AbilityModel("CocktailAbility", "Lumberjacks Cocktail", "Double the attack speed of all nearby Boxer Monkeys for a short time.", 1, -1,
               ModContent.GetSpriteReference(this.mod, "u040-Icon"), 60, new Il2CppReferenceArray<Model>(new Model[] { az}),
               false, false, "", 0, 0, -1, false, false);
                ability.AddBehavior(Game.instance.model.GetTowerFromId("AdmiralBrickell 3").GetBehavior<AbilityModel>().GetBehavior<CreateEffectOnAbilityModel>());
                tower.AddBehavior(ability);

            }
        }
        public class u050 : ModUpgrade<exampul1>
        {
            public override int Path => MIDDLE;
            public override int Tier => 5;
            public override int Cost => 35400;

            public override string Description => "Cuts right through Bloons with a Trusty Chainsaw";
            public override string DisplayName => "Chainsaw";
            public override string Portrait => "050copy";

            public override void ApplyUpgrade(TowerModel tower)
            {
                tower.ApplyDisplay<looks050>();
                tower.range += 3;
                tower.GetAttackModel().range += 3;
                var attackModel = tower.GetAttackModel();
                var projectile = attackModel.weapons[0].projectile;
                projectile.pierce -= 2;
                projectile.ApplyDisplay<Projectile3>();
                foreach (var weaponModel in tower.GetWeapons())
                {
                    weaponModel.Rate = 0.05f;

                }

            }
        }
        public class u003 : ModUpgrade<exampul1>
        {
            public override int Path => BOTTOM;
            public override int Tier => 3;
            public override int Cost => 1440;

            public override string Description => "Slams Bloons istead dealing AOE damage.";
            public override string DisplayName => "Primitive Techniques";
            public override string Portrait => "003copy";

            public override void ApplyUpgrade(TowerModel tower)
            {
                tower.ApplyDisplay<looks003>();
                var attackModel = tower.GetAttackModel();
                attackModel.weapons[0].projectile.AddBehavior(Game.instance.model.GetTowerFromId("BombShooter-200").GetWeapon().projectile.GetBehavior<CreateProjectileOnContactModel>().Duplicate());
                attackModel.weapons[0].projectile.AddBehavior(Game.instance.model.GetTowerFromId("BombShooter").GetWeapon().projectile.GetBehavior<CreateSoundOnProjectileCollisionModel>().Duplicate());
                attackModel.weapons[0].projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
                attackModel.weapons[0].projectile.ApplyDisplay<Projectile4>();
                foreach (var weaponModel in tower.GetWeapons())
                {
                    weaponModel.projectile.GetDamageModel().damage += 2;

                }
            }
        }
        public class u004 : ModUpgrade<exampul1>
        {
            public override int Path => BOTTOM;
            public override int Tier => 4;
            public override int Cost => 5200;

            public override string Description => "ME SEE BLOON. NO MORE BLOON";
            public override string DisplayName => "Primal Monkey";
            public override string Portrait => "004copy";

            public override void ApplyUpgrade(TowerModel tower)
            {
                tower.ApplyDisplay<looks004>();
                var attackModel = tower.GetAttackModel();
                attackModel.weapons[0].projectile.ApplyDisplay<Projectile4>();
                var slammer = attackModel.weapons[0].Duplicate();
                slammer.rate = 2.7f;
                slammer.projectile.AddBehavior(Game.instance.model.GetTowerFromId("BombShooter-400").GetWeapon().projectile.GetBehavior<CreateProjectileOnContactModel>().Duplicate());
                slammer.projectile.AddBehavior(Game.instance.model.GetTowerFromId("BombShooter-400").GetWeapon().projectile.GetBehavior<CreateSoundOnProjectileCollisionModel>().Duplicate());
                attackModel.weapons[0].projectile.AddBehavior(Game.instance.model.GetTowerFromId("BombShooter").GetWeapon().projectile.GetBehavior<CreateEffectOnContactModel>().Duplicate());
                slammer.projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
                slammer.projectile.ApplyDisplay<Projectile4>();
                slammer.projectile.AddBehavior(new DamageModifierForTagModel("DamageModifierForTagModel_Fortified","Fortified", 1, 30, false, false));
                attackModel.AddWeapon(slammer);
            }
        }
        public class u005 : ModUpgrade<exampul1>
        {
            public override int Path => BOTTOM;
            public override int Tier => 5;
            public override int Cost => 55200;

            public override string Description => "Has been battling the Bloons since the beginning of Time.";
            public override string DisplayName => "Primodial Ancestor";
            public override string Portrait => "005copy";

            public override void ApplyUpgrade(TowerModel tower)
            {
                tower.ApplyDisplay<looks005>();
                var attackModel = tower.GetAttackModel();
                attackModel.weapons[0].projectile.ApplyDisplay<Projectile4>();
                var slammer = attackModel.weapons[0].Duplicate();
                slammer.rate = 4.7f;
                slammer.projectile.AddBehavior(Game.instance.model.GetTowerFromId("BombShooter-500").GetWeapon().projectile.GetBehavior<CreateProjectileOnContactModel>().Duplicate());
                slammer.projectile.AddBehavior(Game.instance.model.GetTowerFromId("BombShooter-500").GetWeapon().projectile.GetBehavior<CreateSoundOnProjectileCollisionModel>().Duplicate());
                attackModel.weapons[0].projectile.AddBehavior(Game.instance.model.GetTowerFromId("BombShooter").GetWeapon().projectile.GetBehavior<CreateEffectOnContactModel>().Duplicate());
                slammer.projectile.GetDamageModel().immuneBloonProperties = BloonProperties.None;
                slammer.projectile.AddBehavior(new DamageModifierForTagModel("DamageModifierForTagModel_Fortified", "Fortified", 1, 30, false, false));
                slammer.projectile.AddBehavior(new DamageModifierForTagModel("DamageModifierForTagModel_Ceramic", "Ceramic",1, 30, false, false));
                slammer.projectile.ApplyDisplay<Projectile4>();
                slammer.projectile.AddBehavior(new DamageModifierForTagModel("Moab", "Moab", 1, 7, false, true));
                slammer.projectile.AddBehavior(new DamageModifierForTagModel("Bfb", "Bfb", 1, 7, false, true));
                slammer.projectile.AddBehavior(new DamageModifierForTagModel("Zomg", "Zomg", 1, 7, false, true));
                attackModel.AddWeapon(slammer);
                foreach (var weaponModel in tower.GetWeapons())
                {
                    weaponModel.projectile.GetDamageModel().damage += 27;

                }
            }
        }
        public class looks002 : ModCustomDisplay
        {
            public override string AssetBundleName => "boxermonkey222"; // loads from "assets.bundle"
            public override string PrefabName => "boxer002"; // loads the "MyModel" prefab

            public override void ModifyDisplayNode(UnityDisplayNode node)
            {
                node.transform.GetChild(0).transform.localScale *= 86;
                foreach (var meshRenderer in node.GetMeshRenderers())
                {
                    meshRenderer.ApplyOutlineShader();

                    meshRenderer.SetOutlineColor(new Color(108 / 255f, 0 / 255f, 0 / 255f));
                }
            }
        }
        public class looks001 : ModCustomDisplay
        {
            public override string AssetBundleName => "boxermonkey222"; // loads from "assets.bundle"
            public override string PrefabName => "boxer001"; // loads the "MyModel" prefab

            public override void ModifyDisplayNode(UnityDisplayNode node)
            {
                node.transform.GetChild(0).transform.localScale *= 86;
                foreach (var meshRenderer in node.GetMeshRenderers())
                {
                    meshRenderer.ApplyOutlineShader();

                    meshRenderer.SetOutlineColor(new Color(108 / 255f, 0 / 255f, 0 / 255f));
                }
            }
        }
        public class looks020 : ModCustomDisplay
        {
            public override string AssetBundleName => "boxermonkey222"; // loads from "assets.bundle"
            public override string PrefabName => "boxer020"; // loads the "MyModel" prefab

            public override void ModifyDisplayNode(UnityDisplayNode node)
            {
                node.transform.GetChild(0).transform.localScale *= 86;
                foreach (var meshRenderer in node.GetMeshRenderers())
                {
                    meshRenderer.ApplyOutlineShader();

                    meshRenderer.SetOutlineColor(new Color(108 / 255f, 0 / 255f, 0 / 255f));
                }
            }
        }
        public class looks010 : ModCustomDisplay
        {
            public override string AssetBundleName => "boxermonkey222"; // loads from "assets.bundle"
            public override string PrefabName => "boxer010"; // loads the "MyModel" prefab

            public override void ModifyDisplayNode(UnityDisplayNode node)
            {
                node.transform.GetChild(0).transform.localScale *= 86;
                foreach (var meshRenderer in node.GetMeshRenderers())
                {
                    meshRenderer.ApplyOutlineShader();

                    meshRenderer.SetOutlineColor(new Color(108 / 255f, 0 / 255f, 0 / 255f));
                }
            }
        }
        public class looks200 : ModCustomDisplay
        {
            public override string AssetBundleName => "boxermonkey222"; // loads from "assets.bundle"
            public override string PrefabName => "boxer200"; // loads the "MyModel" prefab

            public override void ModifyDisplayNode(UnityDisplayNode node)
            {
                node.transform.GetChild(0).transform.localScale *= 86;
                foreach (var meshRenderer in node.GetMeshRenderers())
                {
                    meshRenderer.ApplyOutlineShader();

                    meshRenderer.SetOutlineColor(new Color(108 / 255f, 0 / 255f, 0 / 255f));
                }
            }
        }
        public class looks100 : ModCustomDisplay
        {
            public override string AssetBundleName => "boxermonkey222"; // loads from "assets.bundle"
            public override string PrefabName => "boxer100"; // loads the "MyModel" prefab

            public override void ModifyDisplayNode(UnityDisplayNode node)
            {
                node.transform.GetChild(0).transform.localScale *= 86;
                foreach (var meshRenderer in node.GetMeshRenderers())
                {
                    meshRenderer.ApplyOutlineShader();

                    meshRenderer.SetOutlineColor(new Color(108 / 255f, 0 / 255f, 0 / 255f));
                }
            }
        }
        public class looks300 : ModCustomDisplay
        {
            public override string AssetBundleName => "boxertoppath1"; // loads from "assets.bundle"
            public override string PrefabName => "boxer300"; // loads the "MyModel" prefab

            public override void ModifyDisplayNode(UnityDisplayNode node)
            {
                node.transform.GetChild(0).transform.localScale *= 86;
                foreach (var meshRenderer in node.GetMeshRenderers())
                {
                    meshRenderer.ApplyOutlineShader();

                    meshRenderer.SetOutlineColor(new Color(108 / 255f, 0 / 255f, 0 / 255f));
                }
            }
        }
        public class looks400 : ModCustomDisplay
        {
            public override string AssetBundleName => "boxertoppath1"; // loads from "assets.bundle"
            public override string PrefabName => "boxer400"; // loads the "MyModel" prefab

            public override void ModifyDisplayNode(UnityDisplayNode node)
            {
                node.transform.GetChild(0).transform.localScale *= 86;
                foreach (var meshRenderer in node.GetMeshRenderers())
                {
                    meshRenderer.ApplyOutlineShader();

                    meshRenderer.SetOutlineColor(new Color(108 / 255f, 0 / 255f, 0 / 255f));
                }
            }
        }
        public class looks500 : ModCustomDisplay
        {
            public override string AssetBundleName => "boxertoppath1"; // loads from "assets.bundle"
            public override string PrefabName => "ghost500"; // loads the "MyModel" prefab

            public override void ModifyDisplayNode(UnityDisplayNode node)
            {
                node.transform.GetChild(0).transform.localScale *= 86;
                foreach (var meshRenderer in node.GetMeshRenderers())
                {
                    meshRenderer.ApplyOutlineShader();

                    meshRenderer.SetOutlineColor(new Color(135 / 255f, 251 / 255f, 255 / 255f));
                }
            }
        }
        public class looks030 : ModCustomDisplay
        {
            public override string AssetBundleName => "boxermidpath1"; // loads from "assets.bundle"
            public override string PrefabName => "boxer030"; // loads the "MyModel" prefab

            public override void ModifyDisplayNode(UnityDisplayNode node)
            {
                node.transform.GetChild(0).transform.localScale *= 86;
                foreach (var meshRenderer in node.GetMeshRenderers())
                {
                    meshRenderer.ApplyOutlineShader();

                    meshRenderer.SetOutlineColor(new Color(108 / 255f, 0 / 255f, 0 / 255f));
                }
            }
        }
        public class looks040 : ModCustomDisplay
        {
            public override string AssetBundleName => "boxermidpath1"; // loads from "assets.bundle"
            public override string PrefabName => "boxer040"; // loads the "MyModel" prefab

            public override void ModifyDisplayNode(UnityDisplayNode node)
            {
                node.transform.GetChild(0).transform.localScale *= 86;
                foreach (var meshRenderer in node.GetMeshRenderers())
                {
                    meshRenderer.ApplyOutlineShader();

                    meshRenderer.SetOutlineColor(new Color(108 / 255f, 0 / 255f, 0 / 255f));
                }
            }
        }
        public class looks050 : ModCustomDisplay
        {
            public override string AssetBundleName => "boxermidpath1"; // loads from "assets.bundle"
            public override string PrefabName => "boxer050"; // loads the "MyModel" prefab

            public override void ModifyDisplayNode(UnityDisplayNode node)
            {
                node.transform.GetChild(0).transform.localScale *= 86;
                foreach (var meshRenderer in node.GetMeshRenderers())
                {
                    meshRenderer.ApplyOutlineShader();

                    meshRenderer.SetOutlineColor(new Color(108 / 255f, 0 / 255f, 0 / 255f));
                }
            }
        }
        public class looks003 : ModCustomDisplay
        {
            public override string AssetBundleName => "boxerbotpath1"; // loads from "assets.bundle"
            public override string PrefabName => "boxer003"; // loads the "MyModel" prefab

            public override void ModifyDisplayNode(UnityDisplayNode node)
            {
                node.transform.GetChild(0).transform.localScale *= 86;
                foreach (var meshRenderer in node.GetMeshRenderers())
                {
                    meshRenderer.ApplyOutlineShader();

                    meshRenderer.SetOutlineColor(new Color(77 / 255f, 32 / 255f, 6 / 255f));
                }
            }
        }
        public class looks004 : ModCustomDisplay
        {
            public override string AssetBundleName => "boxerbotpath1"; // loads from "assets.bundle"
            public override string PrefabName => "boxer004"; // loads the "MyModel" prefab

            public override void ModifyDisplayNode(UnityDisplayNode node)
            {
                node.transform.GetChild(0).transform.localScale *= 89;
                foreach (var meshRenderer in node.GetMeshRenderers())
                {
                    meshRenderer.ApplyOutlineShader();

                    meshRenderer.SetOutlineColor(new Color(77 / 255f, 32 / 255f, 6 / 255f));
                }
            }
        }
        public class looks005 : ModCustomDisplay
        {
            public override string AssetBundleName => "boxerbotpath1"; // loads from "assets.bundle"
            public override string PrefabName => "boxer005"; // loads the "MyModel" prefab

            public override void ModifyDisplayNode(UnityDisplayNode node)
            {
                node.transform.GetChild(0).transform.localScale *= 96;
                foreach (var meshRenderer in node.GetMeshRenderers())
                {
                    meshRenderer.ApplyOutlineShader();

                    meshRenderer.SetOutlineColor(new Color(77 / 255f, 32 / 255f, 6 / 255f));
                }
            }
        }

    }
}
