using System;
using System.Security.Policy;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using Tamagotchi_prog.Models;
using Tamagotchi_prog.Models.GameRules;

namespace Tamagotchi.test
{
    [TestClass]
    public class ActionTest
    {

        private Game _game;
        private Tamagotchi_prog.Models.Tamagotchi _testTamagotchi;
        private MockMyContext _mockMyContext = new MockMyContext();


        //gebruik dit als een constructor waar je alles klaar zet voor je test
        //Deze method draait altijd voordat je een test draait.
        [TestInitialize]
        public void TestInitialize()
        {
            //dit haalt een game object op met de nodige ninject bindings
            Ninject.IKernel kernel = new StandardKernel(new GameRuleModule());
            _game = kernel.Get<Game>();

            _testTamagotchi = new Tamagotchi_prog.Models.Tamagotchi()
            {
                //init je test tamagotchi
            };

        }

        [TestMethod]
        [TestCategory("Actions")]
        //Een test Category is om het netjes te houden zo kun je al je testen netjes grouperen onder uitklapbaren menu's
        public void SleepTest()
        {
            //eerst kijk je wat de data voor de actie is

            //doe de actie

            //kijk met behulp van Assert() of de data gelijk is aan wat je verwacht.
        }
    }
}
