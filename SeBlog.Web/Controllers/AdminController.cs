using Newtonsoft.Json;
using SeBlog.Core;
using SeBlog.Core.Objects;
using SeBlog.Web.Models;
using SeBlog.Web.Providers;
using System;
using System.Web.Mvc;
using System.Web.Security;

namespace SeBlog.Web.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly IAuthProvider _authProvider;
        private readonly IBlogRepository _blogRepository;

        public AdminController(IAuthProvider authProvider)
        {
            _authProvider = authProvider;
        }

        [AllowAnonymous]
        public ActionResult Login(string returnUrl)
        {
            if (_authProvider.IsLoggedIn)
                return RedirectToUrl(returnUrl);

            ViewBag.ReturnUrl = returnUrl;

            return View();
        }

        [HttpPost, AllowAnonymous, ValidateAntiForgeryToken]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            model.UserName = "admin";
            model.Password = "admin";

            if (ModelState.IsValid && _authProvider.Login(model.UserName, model.Password))
            {
                return RedirectToUrl(returnUrl);
            }

            ModelState.AddModelError("", "The user name or password provided is incorrect.");
            return View(model);
        }

        public ActionResult Manage()
        {
            return View();
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Login", "Admin");
        }

        private ActionResult RedirectToUrl(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Manage");
            }
        }

        public ActionResult Posts(JqInViewModel jqParams)
        {
            var posts = _blogRepository.Posts(jqParams.page - 1, jqParams.rows,
        jqParams.sidx, jqParams.sord == "asc");

            var totalPosts = _blogRepository.TotalPosts(false);

            // TODO: return the posts, count and other information in the
            // JSON format needed by the jqGrid

            /*  return Json(new
              {
                  page = jqParams.page,
                  records = totalPosts,
                  rows = posts,
                  total = Math.Ceiling(Convert.ToDouble(totalPosts) / jqParams.rows)
              }, JsonRequestBehavior.AllowGet);*/

            return Content(JsonConvert.SerializeObject(new
            {
                page = jqParams.page,
                records = totalPosts,
                rows = posts,
                total = Math.Ceiling(Convert.ToDouble(totalPosts) / jqParams.rows)
            }), "application/json");
        }

        [HttpPost]
        public ContentResult AddPost(Post post)
        {
            string json;

            if (ModelState.IsValid)
            {
                var id = _blogRepository.AddPost(post);

                json = JsonConvert.SerializeObject(new
                {
                    id = id,
                    success = true,
                    message = "Post added successfully."
                });
            }
            else
            {
                json = JsonConvert.SerializeObject(new
                {
                    id = 0,
                    success = false,
                    message = "Failed to add the post."
                });
            }

            return Content(json, "application/json");
        }
    }
}
