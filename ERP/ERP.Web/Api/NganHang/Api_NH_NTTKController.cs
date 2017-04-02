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
using System.Dynamic;

namespace ERP.Web.Api.NganHang
{

    
    public class Api_NH_NTTKController : ApiController
    {
        private ERP_DATABASEEntities db = new ERP_DATABASEEntities();
        //GET: api/Api_NH_NTTK
        [HttpGet]
        //public List<NH_NTTK> GetNH_NTTK()
        //{
        //    var vData = db.NH_NTTK;
        //    var result = vData.ToList().Select(x => new NH_NTTK()
        //    {
        //        SO_CHUNG_TU = x.SO_CHUNG_TU,
        //        NGAY_HACH_TOAN = x.NGAY_HACH_TOAN,
        //        NGAY_CHUNG_TU = x.NGAY_CHUNG_TU,
        //        MA_DOI_TUONG = x.MA_DOI_TUONG,
        //        NOP_VAO_TAI_KHOAN = x.NOP_VAO_TAI_KHOAN,
        //        LY_DO_THU = x.LY_DO_THU,
        //        DIEN_GIAI_LY_DO_THU = x.DIEN_GIAI_LY_DO_THU,
        //        NHAN_VIEN_THU = x.NHAN_VIEN_THU,
        //        TONG_TIEN = x.TONG_TIEN,
        //        NGUOI_LAP_BIEU = x.NGUOI_LAP_BIEU,
        //        TRUC_THUOC = x.TRUC_THUOC

        //    }).ToList();
        //    return result;
        //}

        public ExpandoObject GetNH_NTTKLIST(DateTime? from_day = null, DateTime? to_day = null, string so_tai_khoan = null, int current_page = 1, int page_size = 10)
        {
            //return _context.NH_NTTK;
            IEnumerable<NH_NTTK> value = db.NH_NTTK;
            //  var vData = db.NH_NTTK;
            if (so_tai_khoan != null)
            {
                value = value.Where(c => c.NOP_VAO_TAI_KHOAN == so_tai_khoan);
            }

            if (to_day != null)
            {
                value = value.Where(c => c.NGAY_CHUNG_TU <= to_day);
            }

            if (from_day != null)
            {
                value = value.Where(c => c.NGAY_CHUNG_TU >= from_day);
            }

            int count = value.Count();
            value = value.Skip(page_size * (current_page - 1)).Take(page_size);
            int max_page = (count + page_size - 1) / page_size;

            if (max_page < current_page)
            {
                current_page = max_page;
            }

            // List<NH_NTTK> Listtest = value.ToList();
            var result = value.ToList().Select(x => new NH_NTTK()
            {
                SO_CHUNG_TU = x.SO_CHUNG_TU,
                NGAY_HACH_TOAN = x.NGAY_HACH_TOAN,
                NGAY_CHUNG_TU = x.NGAY_CHUNG_TU,
                MA_DOI_TUONG = x.MA_DOI_TUONG,
                NOP_VAO_TAI_KHOAN = x.NOP_VAO_TAI_KHOAN,
                LY_DO_THU = x.LY_DO_THU,
                DIEN_GIAI_LY_DO_THU = x.DIEN_GIAI_LY_DO_THU,
                NHAN_VIEN_THU = x.NHAN_VIEN_THU,
                TONG_TIEN = x.TONG_TIEN,
                NGUOI_LAP_BIEU = x.NGUOI_LAP_BIEU,
                TRUC_THUOC = x.TRUC_THUOC

            }).ToList();

            dynamic res_data = new ExpandoObject();
            res_data.current_page = current_page;
            res_data.page_size = page_size;
            res_data.max_page = max_page;
            res_data.data = result;
            return res_data;
        }

        //GET: api/Api_NH_NTTK/5
        [ResponseType(typeof(NH_NTTK))]
        public IHttpActionResult GetNH_NTTK(string id)
        {
            NH_NTTK nH_NTTK = db.NH_NTTK.Find(id);
            if (nH_NTTK == null)
            {
                return NotFound();
            }

            return Ok(nH_NTTK);
        }

        // PUT: api/Api_NH_NTTK/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutNH_NTTK(string id, NH_NTTK nH_NTTK)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != nH_NTTK.SO_CHUNG_TU)
            {
                return BadRequest();
            }

            db.Entry(nH_NTTK).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NH_NTTKExists(id))
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

        // POST: api/Api_NH_NTTK
        [HttpPost]
        public async Task<IHttpActionResult> PostNH_NTTK([FromBody] NH_NTTK nH_NTTK)
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
            int index = db.NH_NTTK.ToList().Count();
            nH_NTTK.SO_CHUNG_TU = "NTTK" + currentYear + currentMonth + (index + 1).ToString();
            db.NH_NTTK.Add(nH_NTTK);
            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (NH_NTTKExists(nH_NTTK.SO_CHUNG_TU))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            //return this.CreatedAtRoute("GetNH_NTTK", new { id = nH_NTTK.SO_CHUNG_TU }, nH_NTTK);
            return Ok(nH_NTTK);
        }

        // DELETE: api/Api_NH_NTTK/5
        [ResponseType(typeof(NH_NTTK))]
        public IHttpActionResult DeleteNH_NTTK(string id)
        {
            NH_NTTK nH_NTTK = db.NH_NTTK.Find(id);
            if (nH_NTTK == null)
            {
                return NotFound();
            }

            db.NH_NTTK.Remove(nH_NTTK);
            db.SaveChanges();

            return Ok(nH_NTTK);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NH_NTTKExists(string id)
        {
            return db.NH_NTTK.Count(e => e.SO_CHUNG_TU == id) > 0;
        }
    }
}