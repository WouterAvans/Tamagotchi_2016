using System;
using System.Security.Policy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using Tamagotchi_prog.Models;
using Tamagotchi_prog.Models.GameRules;
using Tamagotchi_prog.Models.GameActions;
using Tamagotchi_prog.Repository;
using System.Threading;

namespace Tamagotchi.test
{
    [TestClass]
    public class ActionTest
    {

        private Game _game;
        private Tamagotchi_prog.Models.Tamagotchi _testTamagotchi;
        private MyContext _myContext;


        //gebruik dit als een constructor waar je alles klaar zet voor je test
        //Deze method draait altijd voordat je een test draait.
        [TestInitialize]
        public void TestInitialize()
        {
            Ninject.IKernel kernel = new StandardKernel(new GameRuleModule());
            _game = kernel.Get<Game>();
            _myContext = _game.MyContext;

            if(_myContext.Tamagotchis.Find("Tamagotchi") != null)
            {
                _myContext.Tamagotchis.Remove(_myContext.Tamagotchis.Find("Tamagotchi"));
            }
         
            _testTamagotchi = new Tamagotchi_prog.Models.Tamagotchi()
            {
                //init je test tamagotchi
                Boredom = 50,
                Health = 50,
                Hunger = 50,
                Sleep = 50,
                Name = "Tamagotchi",
                IsDead = false,
                LastAccessTime = DateTime.Now,
                LastAction = Actions.None,
                StartActionTime = DateTime.Now,
                StatusEffects = new StatusEffect()
                {
                    Athlete = false,
                    Crazy = false,
                    Munchies = false
                },
                ImageURL = null

            };


            _myContext.Tamagotchis.Add(_testTamagotchi);
            _myContext.SaveChanges();

        }

        [TestMethod]
        [TestCategory("Actions")]
        public void SleepTest()
        {
            
             _game.ExecuteAction(_testTamagotchi, Actions.Sleep);

            if(_testTamagotchi.CooldownTime != 120)
            {
                Assert.Fail();
            }

            _testTamagotchi.CooldownTime = 0;
            Thread.Sleep(1000);
            _game.ExecuteAllRules(_testTamagotchi);

            Assert.AreEqual(0, _testTamagotchi.Sleep);
        }

        [TestMethod]
        [TestCategory("Actions")]
        public void EatTest()
        {
            _game.ExecuteAction(_testTamagotchi, Actions.Eat);

            if (_testTamagotchi.CooldownTime != 0.5)
            {
                Assert.Fail();
            }

            _testTamagotchi.CooldownTime = 0;
            Thread.Sleep(1000);
            _game.ExecuteAllRules(_testTamagotchi);

            Assert.AreEqual(0, _testTamagotchi.Hunger);
        }

        [TestMethod]
        [TestCategory("Actions")]
        public void PlayTest()
        {
            int _boredom = _testTamagotchi.Boredom;
            _game.ExecuteAction(_testTamagotchi, Actions.Play);
            
            if (_testTamagotchi.CooldownTime != 0.5)
            {
                Assert.Fail();
            }

            _testTamagotchi.CooldownTime = 0;
            Thread.Sleep(1000);
            _game.ExecuteAllRules(_testTamagotchi);

            Assert.AreEqual(_boredom - 10, _testTamagotchi.Boredom);
        }

        [TestMethod]
        [TestCategory("Actions")]
        public void WorkoutTest()
        {
            int _health = _testTamagotchi.Health;
            _game.ExecuteAction(_testTamagotchi, Actions.Workout);

            if (_testTamagotchi.CooldownTime != 1)
            {
                Assert.Fail();
            }

            _testTamagotchi.CooldownTime = 0;
            Thread.Sleep(1000);
            _game.ExecuteAllRules(_testTamagotchi);

            Assert.AreEqual(_health - 5, _testTamagotchi.Health);
        }

        [TestMethod]
        [TestCategory("Actions")]
        public void HugTest()
        {
            int _health = _testTamagotchi.Health;
            _game.ExecuteAction(_testTamagotchi, Actions.Hug);

            if (_testTamagotchi.CooldownTime != 1)
            {
                Assert.Fail();
            }

            _testTamagotchi.CooldownTime = 0;
            Thread.Sleep(1000);
            _game.ExecuteAllRules(_testTamagotchi);

            Assert.AreEqual(_health - 10, _testTamagotchi.Health);
        }

        [TestMethod]
        [TestCategory("Other")]
        public void CreateTamagotchi()
        {
            if (_myContext.Tamagotchis.Find("Jantje") != null)
            {
                _myContext.Tamagotchis.Remove(_myContext.Tamagotchis.Find("Jantje"));
            }

            _game.CreateTamagotchi("Jantje");

            Assert.IsTrue(_myContext.Tamagotchis.Find("Jantje") != null);

        }
    }
}
