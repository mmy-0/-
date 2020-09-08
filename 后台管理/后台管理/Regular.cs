using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace 后台管理
{ 
    public class Regular
    {
        public static bool IsTelephone(string str_telephone)
        {
            return Regex.IsMatch(str_telephone, @"^[1]+[3,5,7,8,9]+\d{9}");
        }

        public static bool IsIdentification(string str_ID)
        {
            return Regex.IsMatch(str_ID, @"\d{15}|^\d{17}[\d|X]$");
        }

        public static bool IsPassword(string password)
        {
            return Regex.IsMatch(password, @"^(?![0-9]+$)(?![a-zA-Z]+$)[0-9A-Za-z]{6,10}$");
        }

        public static bool IsElectricityCard(string num)
        {
            return Regex.IsMatch(num, @"\d{10}");
        }
    }
}
