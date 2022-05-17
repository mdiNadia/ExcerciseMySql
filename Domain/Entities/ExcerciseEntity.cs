using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class ExcerciseEntity
    {
        public string Id { get; set; }
        public DateTime CreateDate { get; set; }
        public string SerialNumber{ get; set; }
        public int DeviceId { get; set; }
        public string RefId { get; set; }
        public string IdMachine { get; set; }
        public string IdEvent { get; set; }

    }
}
