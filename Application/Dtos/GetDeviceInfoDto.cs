using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public class GetDeviceInfoDto
    {
        public int DeviceId { get; set; }
        public DateTime FirstDate { get; set; }
        public DateTime LastDate { get; set; }
        public string IdEvent { get; set; }
        public string IdMachine { get; set; }
        public string RefId { get; set; }


    }
}
