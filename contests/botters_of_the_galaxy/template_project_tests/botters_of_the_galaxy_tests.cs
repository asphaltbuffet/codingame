using System;
using System.IO;
using Xunit;

namespace template_project_tests
{
    public class BottersOfTheGalaxyTests
    {
        public Game g;

        public BottersOfTheGalaxyTests()
        {
            Console.SetIn(new StreamReader("../../assets/wood3_default.txt"));

            g = new Game();

            Assert.NotNull(g);
        }

    #region Initialization Tests
        [Fact]
        public void Load_TeamNumber_Initialization()
        {
            Assert.Equal(g.TeamNumber, 0);
        }

        [Fact]
        public void Load_BushSpawnCount_Initialization()
        {
            Assert.Equal(g.BushSpawnCount, 0);
        }

        [Fact]
        public void Load_ItemCount_Initialization()
        {
            Assert.Equal(g.ItemCount, 0);
        }

        [Fact]
        public void Load_Items_Initialization()
        {
            Console.SetIn(new StreamReader("../../assets/wood2_single.txt"));

            g = new Game();
            g.Update();

            Assert.IsType<Item>(g.Items[0]);
        }

        [Fact]
        public void Load_ItemBlade_Initialization()
        {
            Console.SetIn(new StreamReader("../../assets/wood2_single.txt"));

            g = new Game();
            g.Update();

            var item = g.Items[0];

            Assert.Equal("Golden_Blade_14", item.Name);
            Assert.Equal(903, item.Cost);
            Assert.Equal(56, item.Damage);
            Assert.Equal(1004, item.Health);
            Assert.Equal(1004, item.MaxHealth);
            Assert.Equal(0, item.Mana);
            Assert.Equal(0, item.MaxMana);
            Assert.Equal(0, item.Speed);
            Assert.Equal(0, item.Regeneration);
            Assert.False(item.isPotion);

        }

        [Fact]
        public void Load_ItemPotion_Initialization()
        {
            Console.SetIn(new StreamReader("../../assets/wood2_single.txt"));

            g = new Game();
            g.Update();

            var item = g.Items[2];

            Assert.Equal("xxl_potion", item.Name);
            Assert.Equal(330, item.Cost);
            Assert.Equal(0, item.Damage);
            Assert.Equal(500, item.Health);
            Assert.Equal(0, item.MaxHealth);
            Assert.Equal(0, item.Mana);
            Assert.Equal(0, item.MaxMana);
            Assert.Equal(0, item.Speed);
            Assert.Equal(0, item.Regeneration);
            Assert.True(item.isPotion);

        }

        [Fact]
        public void Load_ItemBoots_Initialization()
        {
            Console.SetIn(new StreamReader("../../assets/wood2_single.txt"));

            g = new Game();
            g.Update();

            var item = g.Items[10];

            Assert.Equal("Bronze_Boots_5", item.Name);
            Assert.Equal(89, item.Cost);
            Assert.Equal(5, item.Damage);
            Assert.Equal(0, item.Health);
            Assert.Equal(0, item.MaxHealth);
            Assert.Equal(0, item.Mana);
            Assert.Equal(0, item.MaxMana);
            Assert.Equal(15, item.Speed);
            Assert.Equal(0, item.Regeneration);
            Assert.False(item.isPotion);

        }

        [Fact]
        public void Load_ItemGadget_Initialization()
        {
            Console.SetIn(new StreamReader("../../assets/wood2_single.txt"));

            g = new Game();
            g.Update();

            var item = g.Items[12];

            Assert.Equal("Silver_Gadget_8", item.Name);
            Assert.Equal(376, item.Cost);
            Assert.Equal(0, item.Damage);
            Assert.Equal(504, item.Health);
            Assert.Equal(504, item.MaxHealth);
            Assert.Equal(100, item.Mana);
            Assert.Equal(100, item.MaxMana);
            Assert.Equal(0, item.Speed);
            Assert.Equal(0, item.Regeneration);
            Assert.False(item.isPotion);

        }

        [Fact]
        public void Load_LastItem_Initialization()
        {
            Console.SetIn(new StreamReader("../../assets/wood2_single.txt"));

            g = new Game();
            g.Update();

            var item = g.Items[22];

            Assert.Equal("Legendary_Boots_19", item.Name);
            Assert.Equal(1340, item.Cost);
            Assert.Equal(18, item.Damage);
            Assert.Equal(0, item.Health);
            Assert.Equal(0, item.MaxHealth);
            Assert.Equal(100, item.Mana);
            Assert.Equal(100, item.MaxMana);
            Assert.Equal(150, item.Speed);
            Assert.Equal(26, item.Regeneration);
            Assert.False(item.isPotion);

        }

        [Fact]
        public void Load_EntityCount_HeroRound()
        {
            Console.SetIn(new StreamReader("../../assets/wood2_single.txt"));

            g = new Game();
            g.Update();

            Assert.Equal(2, g.EntityCount);
        }

        [Fact]
        public void Load_EntityCount_GameRound()
        {
            Console.SetIn(new StreamReader("../../assets/wood2_single.txt"));

            g = new Game();
            g.Update();
            g.Update();

            Assert.Equal(12, g.EntityCount);
        }

        [Fact]
        public void Load_Tower_GameRound()
        {
            Console.SetIn(new StreamReader("../../assets/wood2_single.txt"));

            g = new Game();
            g.Update();
            g.Update();
            g.Update();

            var tower = g.Entities[0];

            Assert.Equal(1, tower.Id);
            Assert.Equal(0, tower.Team);
            Assert.Equal("TOWER", tower.UnitType);
            Assert.Equal(100, tower.X);
            Assert.Equal(540, tower.Y);
            Assert.Equal(400, tower.Range);
            Assert.Equal(1500, tower.Health);
            Assert.Equal(1500, tower.MaxHealth);
            Assert.Equal(0, tower.Shield);
            Assert.Equal(100, tower.Damage);
            Assert.Equal(0, tower.Speed);
            Assert.Equal(0, tower.StunDuration);
            Assert.Equal(0, tower.GoldValue);
        }

        [Fact]
        public void Load_Hero_Initialization()
        {
            Console.SetIn(new StreamReader("../../assets/wood2_single.txt"));

            g = new Game();
            g.Update();
            g.Update();
            g.Update();

            var hero = (Hero)g.Entities[0];

            Assert.Equal(3, hero.Id);
            Assert.Equal(0, hero.Team);
            Assert.Equal("HERO", hero.UnitType);
            Assert.Equal(200, hero.X);
            Assert.Equal(590, hero.Y);
            Assert.Equal(95, hero.Range);
            Assert.Equal(1450, hero.Health);
            Assert.Equal(1450, hero.MaxHealth);
            Assert.Equal(0, hero.Shield);
            Assert.Equal(80, hero.Damage);
            Assert.Equal(200, hero.Speed);
            Assert.Equal(0, hero.StunDuration);
            Assert.Equal(300, hero.GoldValue);
            Assert.Equal(0, hero.Cooldown1);
            Assert.Equal(0, hero.Cooldown2);
            Assert.Equal(0, hero.Cooldown3);
            Assert.Equal(0, hero.Mana);
            Assert.Equal(90, hero.MaxMana);
            Assert.Equal(90, hero.ManaRegeneration);
            Assert.Equal("HULK", hero.HeroType);
            Assert.True(hero.Visible);
            Assert.Equal(0, hero.ItemCount);
        }

        [Fact]
        public void Load_Opponent_Initialization()
        {
            Console.SetIn(new StreamReader("../../assets/wood2_single.txt"));

            g = new Game();
            g.Update();

            var item = g.Items[22];

            Assert.Equal("Legendary_Boots_19", item.Name);
            Assert.Equal(1340, item.Cost);
            Assert.Equal(18, item.Damage);
            Assert.Equal(0, item.Health);
            Assert.Equal(0, item.MaxHealth);
            Assert.Equal(100, item.Mana);
            Assert.Equal(100, item.MaxMana);
            Assert.Equal(150, item.Speed);
            Assert.Equal(26, item.Regeneration);
            Assert.False(item.isPotion);

        }
        #endregion

        #region Hero Round Tests

        [Fact]
        public void Load_RoundType_HERO_ROUND()
        {
            Console.SetIn(new StreamReader("../../assets/wood3_hero.txt"));

            g = new Game();
            g.Update();

            Assert.True(g.HeroRound);
            Assert.False(g.GameRound);
        }

        [Fact]
        public void Load_PlayerGold_HERO_ROUND()
        {
            Console.SetIn(new StreamReader("../../assets/wood3_hero.txt"));

            g = new Game();
            g.Update();

            Assert.Equal(g.PlayerGold, 463);
        }

        [Fact]
        public void Load_OpponentGold_HERO_ROUND()
        {
            Console.SetIn(new StreamReader("../../assets/wood3_hero.txt"));

            g = new Game();
            g.Update();

            Assert.Equal(g.OpponentGold, 463);
        }

        #endregion

    #region Game Round Tests (WOOD3)

        [Fact]
        public void Load_RoundType_GAME_ROUND()
        {
            Console.SetIn(new StreamReader("../../assets/wood3_single.txt"));

            g = new Game();
            for (int i = 0; i < 2; i++)
            {
                g.Update();
            }

            Assert.True(g.GameRound);
            Assert.False(g.HeroRound);
        }

        [Fact]
        public void Load_PlayerGold_GAME()
        {
            Console.SetIn(new StreamReader("../../assets/wood3_single.txt"));

            g = new Game();

            for (int i = 0; i < 2; i++)
            {
                g.Update();
            }

            Assert.Equal(g.PlayerGold, 400);
        }

        [Fact]
        public void Load_OpponentGold_GAME()
        {
            Console.SetIn(new StreamReader("../../assets/wood3_single.txt"));

            g = new Game();

            for (int i = 0; i < 2; i++)
            {
                g.Update();
            }

            Assert.Equal(g.OpponentGold, 400);
        }

        [Fact]
        public void Choose_Hero_GAME()
        {
            Console.SetIn(new StreamReader("../../assets/wood3_single.txt"));

            g = new Game();
            g.Update();
            

            Assert.Equal(g.Command, "HULK");
        }
        #endregion

    #region Game Round Tests (WOOD2)

        [Fact]
        public void Load_ItemCount_GAME_ROUND()
        {
            Console.SetIn(new StreamReader("../../assets/wood2_single.txt"));

            g = new Game();
            for (int i = 0; i < 2; i++)
            {
                g.Update();
            }

            Assert.Equal(g.ItemCount, 0);
        }

        #endregion

    #region Game Round Tests (WOOD2)


    #endregion
    }
}
