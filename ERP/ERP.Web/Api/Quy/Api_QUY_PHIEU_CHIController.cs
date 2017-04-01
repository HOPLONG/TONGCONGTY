using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ERP.Web.Models.Database;
using System.Threading.Tasks;

namespace ERP.Web.Api.Quy
{
    public class Api_QUY_PHIEU_CHIController : ApiController
    {
        private ERP_DATABASEEntities db = new ERP_DATABASEEntities();

        // GET: api/Api_QUY_PHIEU_CHI
        public List<QUY_PHIEU_CHI> GetQUY_PHIEU_CHI()
        {
            var vData = db.QUY_PHIEU_CHI;
            var result = vData.ToList().Select(x => new QUY_PHIEU_CHI()
            {
                SO_CHUNG_TU = x.SO_CHUNG_TU,
                NGAY_CHUNG_TU = x.NGAY_CHUNG_TU,
                NGAY_HACH_TOAN = x.NGAY_HACH_TOAN,
                MA_DOI_TUONG = x.MA_DOI_TUONG,
                NHAN_VIEN_MUA_HANG = x.NHAN_VIEN_MUA_HANG,
                LY_DO_CHI = x.LY_DO_CHI,
                DIEN_GIAI_LY_DO_CHI = x.DIEN_GIAI_LY_DO_CHI,
                NGUOI_NHAN = x.NGUOI_NHAN,
                TONG_TIEN = x.TONG_TIEN,
                NGUOI_LAP_BIEU = x.NGUOI_LAP_BIEU,
                TRUC_THUOC = x.TRUC_THUOC
            }).ToList();
            return result;
        }

        // GET: api/Api_QUY_PHIEU_CHI/5
        [ResponseType(typeof(QUY_PHIEU_CHI))]
        public IHttpActionResult GetQUY_PHIEU_CHI(string id)
        {
            QUY_PHIEU_CHI qUY_PHIEU_CHI = db.QUY_PHIEU_CHI.Find(id);
            if (qUY_PHIEU_CHI == null)
            {
                return NotFound();
            }

            return Ok(qUY_PHIEU_CHI);
        }

        // PUT: api/Api_QUY_PHIEU_CHI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutQUY_PHIEU_CHI(string id, QUY_PHIEU_CHI qUY_PHIEU_CHI)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != qUY_PHIEU_CHI.SO_CHUNG_TU)
            {
                return BadRequest();
            }

            db.Entry(qUY_PHIEU_CHI).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QUY_PHIEU_CHIExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Api_QUY_PHIEU_CHI
        [HttpPost]
        public async Task<IHttpActionResult> PostQUY_PHIEU_CHI([FromBody] QUY_PHIEU_CHI qUY_PHIEU_CHI)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}
            string currentMonth = DateTime.Now.Month.ToString();
            if (!currentMonth.Contains("0"))
            {
                currentMonth = "0" + currentMonth;
            }
            string currentYear = DateTime.Now.Year.ToString();
            char[] years = currentYear.ToArray();
            currentYear = years[2].ToString() + years[3].ToString();
            int index = db.QUY_PHIEU_CHI.ToList().Count();
            qUY_PHIEU_CHI.SO_CHUNG_TU = "PC" + currentYear + currentMonth + (index + 1).ToString();
            db.QUY_PHIEU_CHI.Add(qUY_PHIEU_CHI);
            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (QUY_PHIEU_CHIExists(qUY_PHIEU_CHI.SO_CHUNG_TU))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Ok(qUY_PHIEU_CHI);
        }

        // DELETE: api/Api_QUY_PHIEU_CHI/5
        [ResponseType(typeof(QUY_PHIEU_CHI))]
        public IHttpActionResult DeleteQUY_PHIEU_CHI(string id)
        {
            QUY_PHIEU_CHI qUY_PHIEU_CHI = db.QUY_PHIEU_CHI.Find(id);
            if (qUY_PHIEU_CHI == null)
            {
                return NotFound();
            }

            db.QUY_PHIEU_CHI.Remove(qUY_PHIEU_CHI);
            db.SaveChanges();

            return Ok(qUY_PHIEU_CHI);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool QUY_PHIEU_CHIExists(string id)
        {
            return db.QUY_PHIEU_CHI.Count(e => e.SO_CHUNG_TU == id) > 0;
        }
    }
}