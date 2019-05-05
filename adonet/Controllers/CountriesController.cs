using adonet.Data;
using System.Collections.Generic;
using System.Web.Mvc;

namespace adonet.Controllers
{
    public class CountriesController : Controller
    {
        //private readonly Country _country;

        //public CountriesController(Country country)
        //{
        //    _country = country;
        //}

        // GET: Countries
        public ActionResult Index()
        {
            //Country country = new Country();
            //List<Country> countries = country.GetAll();
            //return View(countries);

            Countries countries = new Countries();
            List<Country> countryList = countries.GetCountries();
            return View(countryList);
        }

        // GET: Countries/Details/5
        public ActionResult Details(int id)
        {
            Countries countries = new Countries();
            Country country = countries.GetCountry(id);
            return View(country);
        }

        // GET: Countries/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Countries/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Countries/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Countries/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Countries/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Countries/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
