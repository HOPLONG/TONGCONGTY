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
    public class Api_QUY_PHIEU_THUController : ApiController
    {
        private ERP_DATABASEEntities db = new ERP_DATABASEEntities();

        // GET: api/Api_QUY_PHIEU_THU
        public List<QUY_PHIEU_THU> GetQUY_PHIEU_THU()
        {
            var vData = db.QUY_PHIEU_THU;
            var result = vData.ToList().Select(x => new QUY_PHIEU_THU()
            {
                SO_CHUNG_TU = x.SO_CHUNG_TU,
                NGAY_CHUNG_TU = x.NGAY_CHUNG_TU,
                NGAY_HACH_TOAN = x.NGAY_HACH_TOAN,
                MA_DOI_TUONG = x.MA_DOI_TUONG,
                LY_DO_NOP = x.LY_DO_NOP,
                DIEN_GIAI_LY_DO_NOP = x.DIEN_GIAI_LY_DO_NOP,
                NGUOI_NOP = x.NGUOI_NOP,
                NHAN_VIEN_THU = x.NHAN_VIEN_THU,
                TONG_TIEN = x.TONG_TIEN,
                NGUOI_LAP_BIEU = x.NGUOI_LAP_BIEU,
                TRUC_THUOC = x.TRUC_THUOC
            }).ToList();
            return result;
        }

        // GET: api/Api_QUY_PHIEU_THU/5
        [ResponseType(typeof(QUY_PHIEU_THU))]
        public IHttpActionResult GetQUY_PHIEU_THU(string id)
        {
            QUY_PHIEU_THU qUY_PHIEU_THU = db.QUY_PHIEU_THU.Find(id);
            if (qUY_PHIEU_THU == null)
            {
                return NotFound();
            }

            return Ok(qUY_PHIEU_THU);
        }

        // PUT: api/Api_QUY_PHIEU_THU/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutQUY_PHIEU_THU(string id, QUY_PHIEU_THU qUY_PHIEU_THU)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != qUY_PHIEU_THU.SO_CHUNG_TU)
            {
                return BadRequest();
            }

            db.Entry(qUY_PHIEU_THU).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QUY_PHIEU_THUExists(id))
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

        // POST: api/Api_QUY_PHIEU_THU
        [HttpPost]
        public async Task<IHttpActionResult> PostQUY_PHIEU_THU([FromBody] QUY_PHIEU_THU qUY_PHIEU_THU)
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
            int index = db.QUY_PHIEU_THU.ToList().Count();
            qUY_PHIEU_THU.SO_CHUNG_TU = "PT" + currentYear + currentMonth + (index + 1).ToString();
            db.QUY_PHIEU_THU.Add(qUY_PHIEU_THU);
            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (QUY_PHIEU_THUExists(qUY_PHIEU_THU.SO_CHUNG_TU))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return Ok (qUY_PHIEU_THU);
        }

        // DELETE: api/Api_QUY_PHIEU_THU/5
        [ResponseType(typeof(QUY_PHIEU_THU))]
        public IHttpActionResult DeleteQUY_PHIEU_THU(string id)
        {
            QUY_PHIEU_THU qUY_PHIEU_THU = db.QUY_PHIEU_THU.Find(id);
            if (qUY_PHIEU_THU == null)
            {
                return NotFound();
            }

            db.QUY_PHIEU_THU.Remove(qUY_PHIEU_THU);
            db.SaveChanges();

            return Ok(qUY_PHIEU_THU);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool QUY_PHIEU_THUExists(string id)
        {
            return db.QUY_PHIEU_THU.Count((System.Linq.Expressions.Expression<Func<QUY_PHIEU_THU, bool>>)(e => e.SO_CHUNG_TU == id)) > 0;
        }
    }
}