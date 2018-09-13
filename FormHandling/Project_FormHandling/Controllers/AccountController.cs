using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project_FormHandling.Models;
using Project_FormHandling.ViewModels;

namespace Project_FormHandling.Controllers
{
    [Route("Account")]
    public class AccountController : Controller
    {
        [Route("")]
        [Route("~/")]
        [Route("index")]
        public IActionResult Index()
        {
            var accountViewModel = new AccountViewModel();
            accountViewModel.Account = new Account()
            {
                Id = 777,
                Status = true,
                Gender = "Male"
            };

            List<Language> languages = new List<Language>();
            for (int i = 0; i < 5; i++)
            {
                int incrementalValue = i++;
                languages.Add(new Language() {
                    Id = ""+incrementalValue,
                    Name = "Langauge "+incrementalValue,
                    IsChecked = (incrementalValue % 2 == 0 ? true : false)
                });
            }

            accountViewModel.Languages = languages;

            List<Role> roles = new List<Role>();
            for (int i = 0; i < 5; i++)
            {
                int incrementalValue = i++;
                roles.Add(new Role()
                {
                    Id = "" + incrementalValue,
                    Name = "Role " + incrementalValue
                });
            }

            accountViewModel.Roles = new SelectList(roles,"Id","Name");

            return View("Index", accountViewModel);
        }

        [Route("Save")]
        [HttpPost]
        public IActionResult Save(AccountViewModel accountViewModel, List<Language> languages)
        {
            accountViewModel.Account.Languages = new List<string>();
            foreach (var language in languages)
            {
                if(language.IsChecked)
                {
                    accountViewModel.Account.Languages.Add(language.Id);
                }
            }

            ViewBag.Account = accountViewModel.Account;
            return View("Success");
        }
    }
}