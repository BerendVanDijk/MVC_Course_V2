using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC_Course_V2.Models
{
    public class MembershipType
    {
        public byte Id { get; set; }
        public short SignUpFee { get; set; }
        public byte DurationInMonths { get; set; }
        public byte DiscountRate { get; set; }
        public string Name { get; set; }


        public static readonly byte Unknown = 0;
        public static readonly byte PayAsYouGo = 1;
        public static readonly byte Monthly = 2;
        public static readonly byte Quaterly = 3;
        public static readonly byte Annualy = 4;

    }
}