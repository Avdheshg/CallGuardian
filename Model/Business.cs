using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CallGuardian.Common;
using CallGuardian.Model.Common;

namespace CallGuardian.Model
{
    public class Business
    {
        public string BusinessName { get; set; }
        public string BusinessDescription { get; set; }
        public TagType TagType { get; set; }
        public BusinessSizeType BusinessSizeType { get; set; }
        public Dictionary<DayType, OperatingHours> OpenHours = new Dictionary<DayType, OperatingHours>();
        public Contact Contact { get; set; }
        public PersonalInfo PersonalInfo { get; set; }
        public SocialInfo SocialInfo { get; set; }

    }
}
