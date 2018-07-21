using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjekatZaPosao.Models;
using Newtonsoft.Json;

namespace ProjekatZaPosao.Controllers
{
    public class ProizvodJSONController : Controller
    {
        // GET: ProizvodJSON
        public ActionResult Index()
        {
            if (System.IO.File.Exists(@"C:/Users/Admin/Documents\visual studio 2015/Projects/ProjekatZaPosao/ProjekatZaPosao/JSON/jsonData.json"))
            {
                string JSONtxt = System.IO.File.ReadAllText(@"C:/Users/Admin/Documents\visual studio 2015/Projects/ProjekatZaPosao/ProjekatZaPosao/JSON/jsonData.json");
                var proizvodi = JsonConvert.DeserializeObject<List<Proizvod>>(JSONtxt);
                return View(proizvodi.ToList());
            }

            return View();
        }

        // GET: ProizvodJSON/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            List<Proizvod> proizvodi = new List<Proizvod>();
            if (System.IO.File.Exists(@"C:/Users/Admin/Documents\visual studio 2015/Projects/ProjekatZaPosao/ProjekatZaPosao/JSON/jsonData.json"))
            {
                string JSONtxt = System.IO.File.ReadAllText(@"C:/Users/Admin/Documents\visual studio 2015/Projects/ProjekatZaPosao/ProjekatZaPosao/JSON/jsonData.json");
                proizvodi = JsonConvert.DeserializeObject<List<Proizvod>>(JSONtxt);
            }
            Proizvod proizvod = null;
            foreach (Proizvod p in proizvodi)
            {
                if (p.Id == id)
                {
                    proizvod = p;
                }
            }
            return View(proizvod);
        }

        // GET: ProizvodJSON/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProizvodJSON/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Naziv,Opis,Kategorija,Proizvodjac,Dobavljac,Cena")] Proizvod proizvod)
        {
            if (ModelState.IsValid)
            {
                List<Proizvod> proizvodi = new List<Proizvod>();
                int id = 0;
                if (System.IO.File.Exists(@"C:/Users/Admin/Documents\visual studio 2015/Projects/ProjekatZaPosao/ProjekatZaPosao/JSON/jsonData.json"))
                {
                    string JSONtxt = System.IO.File.ReadAllText(@"C:/Users/Admin/Documents\visual studio 2015/Projects/ProjekatZaPosao/ProjekatZaPosao/JSON/jsonData.json");
                    proizvodi = JsonConvert.DeserializeObject<List<Proizvod>>(JSONtxt);
                    id = proizvodi.Count;
                }
                proizvod.Id = id;
                proizvodi.Add(proizvod);
                string str = JsonConvert.SerializeObject(proizvodi);
                System.IO.File.WriteAllText(@"C:/Users/Admin/Documents\visual studio 2015/Projects/ProjekatZaPosao/ProjekatZaPosao/JSON/jsonData.json", str);
                return RedirectToAction("Index");
            }

            return View(proizvod);
        }

        // GET: ProizvodJSON/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            List<Proizvod> proizvodi = new List<Proizvod>();
            if (System.IO.File.Exists(@"C:/Users/Admin/Documents\visual studio 2015/Projects/ProjekatZaPosao/ProjekatZaPosao/JSON/jsonData.json"))
            {
                string JSONtxt = System.IO.File.ReadAllText(@"C:/Users/Admin/Documents\visual studio 2015/Projects/ProjekatZaPosao/ProjekatZaPosao/JSON/jsonData.json");
                proizvodi = JsonConvert.DeserializeObject<List<Proizvod>>(JSONtxt);
            }
            Proizvod proizvod = null;
            foreach (Proizvod p in proizvodi)
            {
                if (p.Id == id)
                {
                    proizvod = p;
                }
            }
            if (proizvod == null)
            {
                return HttpNotFound();
            }
            return View(proizvod);
        }

        // POST: ProizvodJSON/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Naziv,Opis,Kategorija,Proizvodjac,Dobavljac,Cena")] Proizvod proizvod)
        {
            if (ModelState.IsValid)
            {
                List<Proizvod> proizvodi = new List<Proizvod>();
                List<Proizvod> noviProizvodi = new List<Proizvod>();
                if (System.IO.File.Exists(@"C:/Users/Admin/Documents\visual studio 2015/Projects/ProjekatZaPosao/ProjekatZaPosao/JSON/jsonData.json"))
                {
                    string JSONtxt = System.IO.File.ReadAllText(@"C:/Users/Admin/Documents\visual studio 2015/Projects/ProjekatZaPosao/ProjekatZaPosao/JSON/jsonData.json");
                    proizvodi = JsonConvert.DeserializeObject<List<Proizvod>>(JSONtxt);
                }
                foreach (Proizvod p in proizvodi)
                {
                    if (p.Id == proizvod.Id)
                    {
                        noviProizvodi.Add(proizvod);
                    }
                    else
                    {
                        noviProizvodi.Add(p);
                    }
                }
                string str = JsonConvert.SerializeObject(noviProizvodi);
                System.IO.File.WriteAllText(@"C:/Users/Admin/Documents\visual studio 2015/Projects/ProjekatZaPosao/ProjekatZaPosao/JSON/jsonData.json", str);
                return RedirectToAction("Index");
            }
            return View(proizvod);
        }

        // GET: ProizvodJSON/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            List<Proizvod> proizvodi = new List<Proizvod>();
            if (System.IO.File.Exists(@"C:/Users/Admin/Documents\visual studio 2015/Projects/ProjekatZaPosao/ProjekatZaPosao/JSON/jsonData.json"))
            {
                string JSONtxt = System.IO.File.ReadAllText(@"C:/Users/Admin/Documents\visual studio 2015/Projects/ProjekatZaPosao/ProjekatZaPosao/JSON/jsonData.json");
                proizvodi = JsonConvert.DeserializeObject<List<Proizvod>>(JSONtxt);
            }
            Proizvod proizvod = null;
            foreach (Proizvod p in proizvodi)
            {
                if (p.Id == id)
                {
                    proizvod = p;
                }
            }
            if (proizvod == null)
            {
                return HttpNotFound();
            }
            return View(proizvod);
        }

        // POST: ProizvodJSON/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            List<Proizvod> proizvodi = new List<Proizvod>();
            List<Proizvod> noviProizvodi = new List<Proizvod>();
            if (System.IO.File.Exists(@"C:/Users/Admin/Documents\visual studio 2015/Projects/ProjekatZaPosao/ProjekatZaPosao/JSON/jsonData.json"))
            {
                string JSONtxt = System.IO.File.ReadAllText(@"C:/Users/Admin/Documents\visual studio 2015/Projects/ProjekatZaPosao/ProjekatZaPosao/JSON/jsonData.json");
                proizvodi = JsonConvert.DeserializeObject<List<Proizvod>>(JSONtxt);
            }
            foreach (Proizvod p in proizvodi)
            {
                if (p.Id == id)
                {
                    
                }
                else
                {
                    noviProizvodi.Add(p);
                }
            }
            string str = JsonConvert.SerializeObject(noviProizvodi);
            System.IO.File.WriteAllText(@"C:/Users/Admin/Documents\visual studio 2015/Projects/ProjekatZaPosao/ProjekatZaPosao/JSON/jsonData.json", str);
            return RedirectToAction("Index");
        }
    }
}
