using System;
using System.Collections.Generic;
using System.Text;

namespace Entity.FrontDataTypes
{
   public class MenuWithURL
    {
        public MenuWithURL()
        {
            AltMenu = new List<MenuWithURL>();
        }
        public string MenuName { get; set; }
        public string MenuLink { get; set; }
        public int DeepLevel { get; set; } = 1;

        public List<MenuWithURL> AltMenu { get; set; }
    }
}
