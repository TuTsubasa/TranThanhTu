using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Web;

namespace Bigschool.ViewModels
{
    public class Future : ValidationAttribute
    {
        private DateTime dateTime;

        public object DateTimeStyle { get; private set; }

        public override bool IsValid(object value)
        {
            DateTime datetime;
            var isVaLid = DateTime.TryParseExact(Convert.ToString(value),
                "dd/M/yyyy",
                CultureInfo.CurrentCulture,
                DateTimeStyles.None,
                out dateTime);
            return (isVaLid && dateTime > DateTime.Now);
        }

    }
}