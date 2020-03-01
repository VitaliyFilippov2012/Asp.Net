using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Aspects
{
    public class DateAttribute : RangeAttribute
    {
        public DateAttribute() : base(typeof(DateTime), DateTime.Now.AddYears(-120).ToShortDateString(), DateTime.Now.ToShortDateString())
        {

        }
    }
}