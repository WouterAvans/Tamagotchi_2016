using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Tamagotchi_prog.Models;
using Tamagotchi_prog.Models.GameRules;
using Tamagotchi_prog.Repository;

namespace Tamagotchi_prog.Controllers
{
    public class HomeController : Controller
    {

        public ActionResult Index()
        {
            Ninject.IKernel kernel = new StandardKernel(new GameRuleModule());
            var game = kernel.Get<Game>();

            using (var context = new MyContext())
            {
                List<Tamagotchi> deadTamagotchis = new List<Tamagotchi>();

                foreach (Tamagotchi tamagotchi in context.Tamagotchis.ToList())
                {
                    game.ExecuteAllRules(tamagotchi);

                    int[] values = new int[] { tamagotchi.Health, tamagotchi.Hunger, tamagotchi.Sleep, tamagotchi.Boredom };
                    int highestValue = values.Max();

                    if (highestValue != 0)
                    {
                        if (highestValue == tamagotchi.Hunger)
                        {
                            tamagotchi.ImageURL = "../Content/img/hungry_tamagotchi.png";
                        }
                        if (highestValue == tamagotchi.Health)
                        {
                            tamagotchi.ImageURL = "../Content/img/unhealthy_tamagotchi.png";
                        }
                        if (highestValue == tamagotchi.Sleep)
                        {
                            tamagotchi.ImageURL = "../Content/img/sleepy_tamagotchi.png";
                        }
                        if (highestValue == tamagotchi.Boredom)
                        {
                            tamagotchi.ImageURL = "../Content/img/bored_tamagotchi.png";
                        }
                        if (tamagotchi.IsDead)
                        {
                            tamagotchi.ImageURL = "../Content/img/dead_tamagotchi.png";
                            deadTamagotchis.Add(tamagotchi);
                        }
                    }

                    context.SaveChanges();
                }

                ViewBag.DeadTamagotchis = deadTamagotchis;

               return View(context.Tamagotchis.ToList().Where(t => !t.IsDead));
            }
        }


        [HttpPost]
        public ActionResult Create(string name)
        {
            using(var context = new MyContext())
            {
                foreach (Tamagotchi tamagotchi in context.Tamagotchis.ToList())
                {
                    if(tamagotchi.Name.Equals(name))
                    {
                        return RedirectToAction("Index");
                    }
                }

                var newTamagotchi = new Tamagotchi();
                newTamagotchi.Name = name;
                newTamagotchi.Health = 0;
                newTamagotchi.Hunger = 0;
                newTamagotchi.Sleep = 0;
                newTamagotchi.Boredom = 0;
                newTamagotchi.IsDead = false;
                newTamagotchi.ImageURL = "../Content/img/normal_tamagotchi.png";
                newTamagotchi.StatusEffects = null;
                newTamagotchi.StatusEffectId = 1;
                newTamagotchi.LastAccessTime = DateTime.Now;
                
                context.Tamagotchis.Add(newTamagotchi);
                context.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public ActionResult Details(String name)
        {
            Tamagotchi tamagotchi;
            if (name == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            using(var context = new MyContext())
            {
                tamagotchi = context.Tamagotchis.Find(name);
            }
            if (tamagotchi == null)
            {
                return HttpNotFound();
            }
            return View(tamagotchi);
        }
    }
}