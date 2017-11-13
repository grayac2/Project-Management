using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Project2.Models.Entities;

namespace Project2.Models.ViewModels
{
    public class CreateProjectVM
    {
        [Required, StringLength(30)]
        public string Name { get; set; }

        [Required, DisplayName("Start Date")]
        public DateTime StartDate { get; set; }

        [DisplayName("End Date")]
        public DateTime EndDate { get; set; }

        public Project CreateProject()
        {
            return new Project { Name = Name, StartDate = StartDate, EndDate = EndDate };
        }
    }
}
