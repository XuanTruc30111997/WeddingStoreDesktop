using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingStoreDesktop.Converters;
using WeddingStoreDesktop.Models;
using WeddingStoreDesktop.Models.DesktopModel;
using WeddingStoreDesktop.Models.SystemModel;

namespace WeddingStoreDesktop.Services.DesktopService
{
    public class NgayDatLichService
    {
        public List<NgayDatLichModel> GetNgayDatLich(int thang, int nam)
        {
            List<NgayDatLichModel> myLst = new List<NgayDatLichModel>();

            List<DatLich> lstDatLich = DataProvider.Ins.DB.DatLiches.Where(dl => dl.NgayDat.Value.Month == thang && dl.NgayDat.Value.Year == nam).ToList();

            foreach (var dl in lstDatLich)
            {
                if (myLst.Count == 0)
                {
                    List<DatLich> tt = new List<DatLich>();
                    tt.Add(dl);

                    myLst.Add(new NgayDatLichModel
                    {
                        Ngay = ConvertDateTimeToString.ConverToMyDateFormat(dl.NgayDat),
                        LstDatLich = tt
                    });
                }
                else
                {
                    bool isExist = false;
                    foreach (var my in myLst)
                    {
                        if (my.Ngay == ConvertDateTimeToString.ConverToMyDateFormat(dl.NgayDat))
                        {
                            my.LstDatLich.Add(dl);
                            isExist = true;
                            break;
                        }
                    }
                    if (!isExist)
                    {
                        List<DatLich> tt = new List<DatLich>();
                        tt.Add(dl);

                        myLst.Add(new NgayDatLichModel
                        {
                            Ngay = ConvertDateTimeToString.ConverToMyDateFormat(dl.NgayDat),
                            LstDatLich = tt
                        });
                    }
                }
            }

            return myLst;
        }
    }
}
