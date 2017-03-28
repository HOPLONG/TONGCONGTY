using ERP.Web.Models.BusinessModel;
using ERP.Web.Models.Database;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP.Web.Areas.Settings.Controllers
{
    public class ImportBangchamcongController : Controller
    {

        XuLyNgayThang xulydate = new XuLyNgayThang();
        int so_dong_thanh_cong;
        int dong;
        ERP_DATABASEEntities db = new ERP_DATABASEEntities();
        // GET: HopLong/ImportExcel

        #region "Import Bảng chấm công"
        public ActionResult Import_Bangchamcong()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Import_Bangchamcong(FormCollection formCollection)
        {
            try
            {
                if (Request != null)
                {
                    HttpPostedFileBase file = Request.Files["UploadedFile"];
                    if ((file != null) && (file.ContentLength > 0) && !string.IsNullOrEmpty(file.FileName))
                    {
                        string fileName = file.FileName;
                        string fileContentType = file.ContentType;
                        byte[] fileBytes = new byte[file.ContentLength];
                        var data = file.InputStream.Read(fileBytes, 0, Convert.ToInt32(file.ContentLength));
                        //var usersList = new List<Users>();
                        using (var package = new ExcelPackage(file.InputStream))
                        {
                            var currentSheet = package.Workbook.Worksheets;
                            var workSheet = currentSheet.First();
                            var noOfCol = workSheet.Dimension.End.Column;
                            var noOfRow = workSheet.Dimension.End.Row;
                            for (int rowIterator = 2; rowIterator <= noOfRow; rowIterator++)
                            {
                                CCTC_BANG_CHAM_CONG bcc = new CCTC_BANG_CHAM_CONG();
                                bcc.THANG_CHAM_CONG = workSheet.Cells[rowIterator, 15].Value.ToString();
                                bcc.USERNAME = workSheet.Cells[rowIterator, 3].Value.ToString();
                                bcc.NGAY_CHUAN = Convert.ToInt32(workSheet.Cells[rowIterator, 4].Value);
                                bcc.GIO_DI_MUON = Convert.ToDouble(workSheet.Cells[rowIterator, 5].Value);
                                bcc.GIO_VE_SOM = Convert.ToDouble(workSheet.Cells[rowIterator, 6].Value);
                                bcc.TANG_CA_NGAY_THUONG = Convert.ToDouble(workSheet.Cells[rowIterator, 7].Value);
                                bcc.TANG_CA_NGAY_LE = Convert.ToDouble(workSheet.Cells[rowIterator, 8].Value);
                                bcc.SO_LAN_QUEN_CHAM = Convert.ToDouble(workSheet.Cells[rowIterator, 9].Value);
                                bcc.SO_NGAY_NGHI = Convert.ToDouble(workSheet.Cells[rowIterator, 10].Value);
                                bcc.CONG_THUC_TE = Convert.ToDouble(workSheet.Cells[rowIterator, 11].Value);
                                bcc.VAY_TIN_DUNG = Convert.ToDecimal(workSheet.Cells[rowIterator, 12].Value);
                                bcc.UNG_LUONG = Convert.ToDecimal(workSheet.Cells[rowIterator, 13].Value);
                                if (workSheet.Cells[rowIterator, 14].Value != null)
                                    bcc.GHI_CHU = workSheet.Cells[rowIterator, 14].Value.ToString();
                                db.CCTC_BANG_CHAM_CONG.Add(bcc);
                                db.SaveChanges();
                                so_dong_thanh_cong++;
                                dong = rowIterator;
                            }
                        }
                    }
                }
            }
            catch (Exception Ex)
            {
                ViewBag.Error = " Đã xảy ra lỗi, Liên hệ ngay với admin. " + Environment.NewLine + " Thông tin chi tiết về lỗi:" + Environment.NewLine + Ex;
                ViewBag.Information = "Lỗi tại dòng thứ: " + dong;

            }
            finally
            {
                ViewBag.Message = "Đã import thành công " + so_dong_thanh_cong + " dòng";
            }
            return View("Import_Bangchamcong");
        }
        #endregion
    }
}