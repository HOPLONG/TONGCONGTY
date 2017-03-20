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

namespace ERP.Web.Api.HeThong
{
    public class Api_HangDuocQuanTamController : ApiController
    {
        private ERP_DATABASEEntities db = new ERP_DATABASEEntities();

        // GET: api/Api_HangDuocQuanTam
        public List<HH_HANG_DUOC_QUAN_TAM> GetHH_HANG_DUOC_QUAN_TAM()
        {
            var vData = db.HH_HANG_DUOC_QUAN_TAM;
            var result = vData.ToList().Select(x => new HH_HANG_DUOC_QUAN_TAM()
            {
                MA_HANG = x.MA_HANG,
                USERNAME = x.USERNAME
            }).ToList();
            return result;
        }

        // GET: api/Api_HangDuocQuanTam/5
        [ResponseType(typeof(HH_HANG_DUOC_QUAN_TAM))]
        public IHttpActionResult GetHH_HANG_DUOC_QUAN_TAM(string id)
        {
            List<HH> listhang = new List<HH>();
            var vData = db.HH_HANG_DUOC_QUAN_TAM;
            var result = vData.ToList().Where(y => y.USERNAME == id).Select(x => new HH_HANG_DUOC_QUAN_TAM()
            {
                MA_HANG = x.MA_HANG,
                USERNAME = x.USERNAME
            }).ToList();
            foreach (var item in result)
            {
                var hh = db.HHs.Where(x => x.MA_HANG == item.MA_HANG).FirstOrDefault();
                listhang.Add(hh);
            }
            var kq = listhang.ToList().Select(x => new HH()
            {
                MA_HANG = x.MA_HANG,
                TEN_HANG = x.TEN_HANG,
                MA_NHOM_HANG = x.MA_NHOM_HANG,
                DON_VI_TINH = x.DON_VI_TINH,
                KHOI_LUONG = x.KHOI_LUONG,
                XUAT_XU = x.XUAT_XU,
                BAO_HANH = x.BAO_HANH,
                THONG_SO_KY_THUAT = x.THONG_SO_KY_THUAT,
                QUY_CACH_DONG_GOI = x.QUY_CACH_DONG_GOI,
                HINH_ANH = x.HINH_ANH,
                GHI_CHU = x.GHI_CHU,
                TK_HACH_TOAN_KHO = x.TK_HACH_TOAN_KHO,
                TK_DOANH_THU = x.TK_DOANH_THU,
                TK_CHI_PHI = x.TK_CHI_PHI
            }).ToList();
            if (kq == null)
            {
                return NotFound();
            }

            return Ok(kq);
        }

        // PUT: api/Api_HangDuocQuanTam/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutHH_HANG_DUOC_QUAN_TAM(int id, HH_HANG_DUOC_QUAN_TAM hH_HANG_DUOC_QUAN_TAM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != hH_HANG_DUOC_QUAN_TAM.ID)
            {
                return BadRequest();
            }

            db.Entry(hH_HANG_DUOC_QUAN_TAM).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HH_HANG_DUOC_QUAN_TAMExists(id))
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

        // POST: api/Api_HangDuocQuanTam
        [ResponseType(typeof(HH_HANG_DUOC_QUAN_TAM))]
        public IHttpActionResult PostHH_HANG_DUOC_QUAN_TAM(HH_HANG_DUOC_QUAN_TAM hH_HANG_DUOC_QUAN_TAM)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.HH_HANG_DUOC_QUAN_TAM.Add(hH_HANG_DUOC_QUAN_TAM);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = hH_HANG_DUOC_QUAN_TAM.ID }, hH_HANG_DUOC_QUAN_TAM);
        }

        // DELETE: api/Api_HangDuocQuanTam/5
        [ResponseType(typeof(HH_HANG_DUOC_QUAN_TAM))]
        public IHttpActionResult DeleteHH_HANG_DUOC_QUAN_TAM(int id)
        {
            HH_HANG_DUOC_QUAN_TAM hH_HANG_DUOC_QUAN_TAM = db.HH_HANG_DUOC_QUAN_TAM.Find(id);
            if (hH_HANG_DUOC_QUAN_TAM == null)
            {
                return NotFound();
            }

            db.HH_HANG_DUOC_QUAN_TAM.Remove(hH_HANG_DUOC_QUAN_TAM);
            db.SaveChanges();

            return Ok(hH_HANG_DUOC_QUAN_TAM);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HH_HANG_DUOC_QUAN_TAMExists(int id)
        {
            return db.HH_HANG_DUOC_QUAN_TAM.Count(e => e.ID == id) > 0;
        }
    }
}