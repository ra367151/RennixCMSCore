using System;
using System.Collections.Generic;
using System.Text;

namespace RennixCMS.Domain.Menu.Dtos
{
    public class MenuDto
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public string Icon { get; set; }
        public int Sort { get; set; }
    }
}
