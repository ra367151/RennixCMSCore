using RennixCMS.Infrastructure.Data;
using RennixCMS.Infrastructure.Data.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace RennixCMS.Application
{
    public class MapDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public bool ValidateProperties()
        {
            return true;
        }
    }

    public class Map : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
