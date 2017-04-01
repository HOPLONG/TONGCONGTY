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

namespace ERP.Web.Api.NhaCungCap
{
    public class Api_NCCsController : ApiController
    {
        private ERP_DATABASEEntities db = new ERP_DATABASEEntities();

        // GET: api/Api_NCCs
        public List<NCC> GetNCC()
        {
            var vData = db.NCCs;
            var result = vData.ToList().Select(x => new NCC()
            {
                MA_NHA_CUNG_CAP = x.MA_NHA_CUNG_CAP,
                TEN_NHA_CUNG_CAP = x.TEN_NHA_CUNG_CAP,
                PHAN_LOAI_NCC = x.PHAN_LOAI_NCC,
                VAN_PHONG_GIAO_DICH = x.VAN_PHONG_GIAO_DICH,
                DIA_CHI_XUAT_HOA_DON = x.DIA_CHI_XUAT_HOA_DON,
                MST = x.MST,
                SDT = x.SDT,
                EMAIL = x.EMAIL,
                FAX = x.FAX,
                WEBSITE = x.WEBSITE,
                DIEU_KHOAN_THANH_TOAN = x.DIEU_KHOAN_THANH_TOAN,
                SO_NGAY_DUOC_NO = x.SO_NGAY_DUOC_NO,
                SO_NO_TOI_DA = x.SO_NO_TOI_DA,
                DANH_GIA = x.DANH_GIA,
                GHI_CHU = x.GHI_CHU,
                LOGO = x.LOGO
            }).ToList();
            return result;

        }

        // GET: api/Api_NCCs/5
        [ResponseType(typeof(NCC))]
        public IHttpActionResult GetNCC(string id)
        {
            NCC nCC = db.NCCs.Find(id);
            if (nCC == null)
            {
                return NotFound();
            }

            return Ok(nCC);
        }

        // PUT: api/Api_NCCs/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutNCC(string id, NCC nCC)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != nCC.MA_NHA_CUNG_CAP)
            {
                return BadRequest();
            }

            db.Entry(nCC).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NCCExists(id))
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

        // POST: api/Api_NCCs
        [ResponseType(typeof(NCC))]
        public IHttpActionResult PostNCC(NCC nCC)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.NCCs.Add(nCC);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (NCCExists(nCC.MA_NHA_CUNG_CAP))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = nCC.MA_NHA_CUNG_CAP }, nCC);
        }

        // DELETE: api/Api_NCCs/5
        [ResponseType(typeof(NCC))]
        public IHttpActionResult DeleteNCC(string id)
        {
            NCC nCC = db.NCCs.Find(id);
            if (nCC == null)
            {
                return NotFound();
            }

            db.NCCs.Remove(nCC);
            db.SaveChanges();

            return Ok(nCC);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NCCExists(string id)
        {
            return db.NCCs.Count(e => e.MA_NHA_CUNG_CAP == id) > 0;
        }
    }
}