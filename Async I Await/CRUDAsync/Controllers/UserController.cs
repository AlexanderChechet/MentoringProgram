using Service.Users;
using Model.Entities;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace CRUDAsync.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public async Task<ActionResult> Index()
        {
            var service = new UserService();
            var users = await service.GetUsers().ConfigureAwait(false);
            return View(users);
        }

        // GET: User/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var service = new UserService();
            var user = await service.GetUserById(id).ConfigureAwait(false);
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
                var service = new UserService();
                await service.AddUser(user).ConfigureAwait(false);
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
            var service = new UserService();
            var user = await service.GetUserById(id).ConfigureAwait(false);
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
                var service = new UserService();
                await service.EditUser(user).ConfigureAwait(false);
                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                var service = new UserService();
                var user = await service.GetUserById(id).ConfigureAwait(false);
                return View(user);
            }
        }

        // GET: User/Delete/5
        public async Task<ActionResult> Delete(int id)
        {
            var service = new UserService();
            var user = await service.GetUserById(id).ConfigureAwait(false);
            return View(user);
        }

        // POST: User/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id, FormCollection collection)
        {
            try
            {
                var service = new UserService();
                await service.DeleteUser(id).ConfigureAwait(false);
                return RedirectToAction("Index");
            }
            catch(Exception e)
            {
                var service = new UserService();
                var user = await service.GetUserById(id).ConfigureAwait(false);
                return View(user);
            }
        }
    }
}
