using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Erste.Util
{
    class TimetableItem
    {
        public TimeSpan vrijemeOd { get; set; }
        public TimeSpan vrijemeDo { get; set; }
        public String jezik { get; set; }
        public String nivo { get; set; }
        public String dan { get; set; }

        public override string ToString()
        {
            return vrijemeOd.ToString(@"hh\:mm") + " - " + vrijemeDo.ToString(@"hh\:mm") + Environment.NewLine + jezik + " " + nivo;
        }
    }
}
