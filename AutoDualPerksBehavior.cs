using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.CharacterDevelopment;
using TaleWorlds.Core;

namespace AutoDualPerks
{
    public class AutoDualPerksBehavior : CampaignBehaviorBase
    {
        public override void RegisterEvents()
        {
            CampaignEvents.OnSessionLaunchedEvent.AddNonSerializedListener(this, OnSessionLaunched);
            CampaignEvents.OnGameLoadedEvent.AddNonSerializedListener(this, OnGameLoaded);
            CampaignEvents.OnNewGameCreatedEvent.AddNonSerializedListener(this, OnNewGameCreated);
            CampaignEvents.HeroGainedSkill.AddNonSerializedListener(this, OnHeroGainedSkill);
        }

        public override void SyncData(IDataStore dataStore)
        {
        }

        private void OnSessionLaunched(CampaignGameStarter starter)
        {
            CheckAndGrantAllPerks(Hero.MainHero);
        }

        private void OnGameLoaded(CampaignGameStarter starter)
        {
            CheckAndGrantAllPerks(Hero.MainHero);
        }

        private void OnNewGameCreated(CampaignGameStarter starter)
        {
            CheckAndGrantAllPerks(Hero.MainHero);
        }

        private void OnHeroGainedSkill(Hero hero, SkillObject skill, int change, bool shouldNotify)
        {
            if (hero == Hero.MainHero && skill != null)
            {
                CheckAndGrantPerksForSkill(hero, skill);
            }
        }

        public static void CheckAndGrantAllPerks(Hero hero)
        {
            if (hero == null || hero.HeroDeveloper == null) return;
            if (PerkObject.All == null) return;

            foreach (PerkObject perk in PerkObject.All)
            {
                if (perk == null || perk.Skill == null) continue;
                if (hero.GetSkillValue(perk.Skill) >= perk.RequiredSkillValue)
                {
                    if (!hero.GetPerkValue(perk))
                    {
                        hero.HeroDeveloper.AddPerk(perk);
                    }
                    if (perk.AlternativePerk != null && !hero.GetPerkValue(perk.AlternativePerk))
                    {
                        hero.HeroDeveloper.AddPerk(perk.AlternativePerk);
                    }
                }
            }
        }

        public static void CheckAndGrantPerksForSkill(Hero hero, SkillObject skill)
        {
            if (hero == null || hero.HeroDeveloper == null || skill == null) return;
            if (PerkObject.All == null) return;

            int skillValue = hero.GetSkillValue(skill);
            foreach (PerkObject perk in PerkObject.All)
            {
                if (perk == null || perk.Skill != skill) continue;
                if (skillValue >= perk.RequiredSkillValue)
                {
                    if (!hero.GetPerkValue(perk))
                    {
                        hero.HeroDeveloper.AddPerk(perk);
                    }
                    if (perk.AlternativePerk != null && !hero.GetPerkValue(perk.AlternativePerk))
                    {
                        hero.HeroDeveloper.AddPerk(perk.AlternativePerk);
                    }
                }
            }
        }
    }
}
