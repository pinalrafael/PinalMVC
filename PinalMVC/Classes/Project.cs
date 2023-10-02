using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PinalMVC.Classes
{
    public class Project
    {
        public string nameproject { get; set; }
        public DateTime createdate { get; set; }
        public string includes { get; set; }
        public string root { get; set; }
        public string models { get; set; }
        public string views { get; set; }
        public string controllers { get; set; }
        public string page_errors { get; set; }
        public string pages_layouts { get; set; }
        public string models_suffix { get; set; }
        public string views_suffix { get; set; }
        public string controllers_suffix { get; set; }
        public string page_errors_suffix { get; set; }
        public string name { get; set; }
        public string author { get; set; }
        public string bugs { get; set; }
        public string repository { get; set; }
        public string homepage { get; set; }
        public bool api { get; set; }

        public Project()
        {
            this.nameproject = "NewProject" + DateTime.Now.ToString("yyyyMMddHHmmss");
            this.createdate = DateTime.Now;
            this.includes = "includes/PinalMVC/";
            this.root = "/";
            this.models = "Models/";
            this.views = "Views/";
            this.controllers = "Controllers/";
            this.page_errors = "PagesErrors/";
            this.pages_layouts = "Views/Layout/";
            this.models_suffix = ".class";
            this.views_suffix = "";
            this.controllers_suffix = "";
            this.page_errors_suffix = "";
            this.name = "PinalMVC";
            this.author = "Rafael Pinal";
            this.repository = "https://github.com/pinalrafael/PinalMVC";
            this.bugs = "https://github.com/pinalrafael/PinalMVC/issues";
            this.homepage = "http://rafaelpinal.siteprofissional.com/PinalMVC/";
            this.api = false;
        }
    }
}
