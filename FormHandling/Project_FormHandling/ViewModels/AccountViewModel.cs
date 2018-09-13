using Microsoft.AspNetCore.Mvc.Rendering;
using Project_FormHandling.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project_FormHandling.ViewModels
{
    public class AccountViewModel
    {
        public Account Account { get; set; }
        public List<Language> Languages { get; set; }
        public SelectList Roles { get; set; }
    }
}
