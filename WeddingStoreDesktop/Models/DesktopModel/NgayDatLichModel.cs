using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingStoreDesktop.Models.SystemModel;

namespace WeddingStoreDesktop.Models.DesktopModel
{
    public class NgayDatLichModel
    {
        public string Ngay { get; set; }
        public List<DatLich> LstDatLich { get; set; }
    }
}
