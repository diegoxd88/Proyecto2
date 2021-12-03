using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Topicos.Proyecto2.Sakila.Model.MyValidations
{
    class LeapYear : ValidationAttribute
    {
        bool esBisiesto = true;
        public LeapYear()
        {

        }
        public LeapYear(bool queSeaBisiesto)
        {
            esBisiesto = queSeaBisiesto;
        }
        public override bool IsValid(object value)
        {
            bool resultado = ValidacionAnnoBisiesto(value);

            if (esBisiesto && resultado == true) { 
                return true;
            }
            if (!esBisiesto && resultado == false) { 
                return true;
            }
            return false;
        }

        public bool ValidacionAnnoBisiesto (object value)
        {
            DateTime date = Convert.ToDateTime(value);
            int year = Convert.ToInt32(date.Year);
            return DateTime.IsLeapYear(year);
        }

    }
}
