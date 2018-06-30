﻿using RennixCMS.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace RennixCMS.Domain.Setting.Models
{
    public class Setting:IEntity
    {
        public int Id { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
