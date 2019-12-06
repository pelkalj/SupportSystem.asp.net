using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TEST.Models
{
    public class SupportListViewModel
    {
        public string id { get; set; }

        [Display(Name = "Ticket No")]
        public Nullable<int> SugestionNo { get; set; }

        [Display(Name = "Rased By")]
        public string CreatedBy { get; set; }
        public string UserID { get; set; }
        public string StatusID { get; set; }
        public string CategoryID { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Raised On")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> CreatedOn { get; set; }


        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> AccepedOn { get; set; }


        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> DueOn { get; set; }


        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> ResolvedOn { get; set; }

        [Display(Name = "Priority")]
        public string PriorityID { get; set; }
        public string Steps { get; set; }
        public string Notes { get; set; }
        public string SelectionID { get; set; }
        public string StepsToReproduces { get; set; }
        public string Title { get; set; }

        [Display(Name = "Severity")]
        public string SeverityID { get; set; }
        public string CommentID { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }
        public virtual List<Category> category { get; set; }
        public virtual List<Priority> priority { get; set; }
        public virtual List<Severity> severity { get; set; }
        public virtual List<Status> status { get; set; }
        public virtual SystemSelection SystemSelection { get; set; }

        public static implicit operator SupportListViewModel(SupportListViewModel v)
        {
            throw new NotImplementedException();
        }
    }
}
