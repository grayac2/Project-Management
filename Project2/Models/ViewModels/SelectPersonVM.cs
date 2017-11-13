﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project2.Models.ViewModels
{
    public class PersonNameVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class SelectPersonVM
    {
        public int ProjectId { get; set; }
        public IEnumerable<PersonNameVM> PersonNames { get; set; }
    }
}
