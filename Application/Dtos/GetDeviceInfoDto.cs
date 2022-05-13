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
        public int EventId { get; set; }
        public int MachinId { get; set; }
        public int RefId { get; set; }
    }
}
