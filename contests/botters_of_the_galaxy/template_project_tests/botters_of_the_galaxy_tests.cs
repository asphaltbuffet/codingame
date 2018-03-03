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

        #region Game Round Tests

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

    }
}
