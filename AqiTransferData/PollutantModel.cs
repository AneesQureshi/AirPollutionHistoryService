using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AqiTransferData
{
    class PollutantModel
    {
        public string pol_name { get; set; }
        public string pol_val { get; set; }
        public int station_id { get; set; }
        public Boolean active { get; set; }
        public DateTime createdDate { get; set; }
    }
}
