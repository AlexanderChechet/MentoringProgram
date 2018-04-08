using ShopRepository.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace CRUDAsync.Controllers
{
    public class UserController : Controller
    {
        private string dbName = "ShopDb.sqlite";
        // GET: User
        public async Task<ActionResult> Index()
        {
            var repo = new UserRepository(dbName);
            var users = await repo.GetUsers().ConfigureAwait(false);
            return View(users);
        }

        // GET: User/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var repo = new UserRepository(dbName);
            var user = await repo.GetUserById(id).ConfigureAwait(false);
            return View(user);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public async Task<ActionResult> Create(FormCollection collection)
        {
            try
            {
                var user = new User();
                user.Name = collection["Name"];
                user.Surname = collection["Surname"];
                user.Age = int.Parse(collection["Age"]);
                var repo = new UserRepository(dbName);
                await repo.AddUser(user).ConfigureAwait(false);
                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                return View();
            }
        }

        // GET: User/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var repo = new UserRepository(dbName);
            var user = await repo.GetUserById(id).ConfigureAwait(false);
            return View(user);
        }

        // POST: User/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(int id, FormCollection collection)
        {
            try
            {
                var user = new User();
                user.Id = id;
                user.Name = collection["Name"];
                user.Surname = collection["Surname"];
                user.Age = int.Parse(collection["Age"]);
                var repo = new UserRepository(dbName);
                await repo.EditUser(user).ConfigureAwait(false);
                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                var repo = new UserRepository(dbName);
                var user = await repo.GetUserById(id).ConfigureAwait(false);
                return View(user);
            }
        }

        // GET: User/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var repo = new UserRepository(dbName);
            var user = await repo.GetUserById(id).ConfigureAwait(false);
            return View(user);
        }

        // POST: User/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id, FormCollection collection)
        {
            try
            {
                var repo = new UserRepository(dbName);
                await repo.DeleteUser(id).ConfigureAwait(false);
                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                var repo = new UserRepository(dbName);
                var user = await repo.GetUserById(id).ConfigureAwait(false);
                return View(user);
            }
        }
    }
}
