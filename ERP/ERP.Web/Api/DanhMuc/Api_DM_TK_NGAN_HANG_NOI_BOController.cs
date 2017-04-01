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

namespace ERP.Web.Api.DanhMuc
{
    public class Api_DM_TK_NGAN_HANG_NOI_BOController : ApiController
    {
        private ERP_DATABASEEntities db = new ERP_DATABASEEntities();

        // GET: api/Api_DM_TK_NGAN_HANG_NOI_BO
        public List<DM_TK_NGAN_HANG_NOI_BO> GetDM_TK_NGAN_HANG_NOI_BO()
        {
            var vData = db.DM_TK_NGAN_HANG_NOI_BO;
            var result = vData.ToList().Select(x => new DM_TK_NGAN_HANG_NOI_BO()
            {
                SO_TAI_KHOAN = x.SO_TAI_KHOAN,
                MA_CONG_TY = x.MA_CONG_TY,
                TEN_TAI_KHOAN = x.TEN_TAI_KHOAN,
                LOAI_TAI_KHOAN = x.LOAI_TAI_KHOAN,
                TEN_NGAN_HANG = x.TEN_NGAN_HANG,
                CHI_NHANH = x.CHI_NHANH,
                TINH_TP = x.TINH_TP,
                GHI_CHU = x.GHI_CHU,
            }).ToList();
            return result;
        }

        // GET: api/Api_DM_TK_NGAN_HANG_NOI_BO/5
        [ResponseType(typeof(DM_TK_NGAN_HANG_NOI_BO))]
        public IHttpActionResult GetDM_TK_NGAN_HANG_NOI_BO(string id)
        {
            DM_TK_NGAN_HANG_NOI_BO dM_TK_NGAN_HANG_NOI_BO = db.DM_TK_NGAN_HANG_NOI_BO.Find(id);
            if (dM_TK_NGAN_HANG_NOI_BO == null)
            {
                return NotFound();
            }

            return Ok(dM_TK_NGAN_HANG_NOI_BO);
        }

        // PUT: api/Api_DM_TK_NGAN_HANG_NOI_BO/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDM_TK_NGAN_HANG_NOI_BO(string id, DM_TK_NGAN_HANG_NOI_BO dM_TK_NGAN_HANG_NOI_BO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dM_TK_NGAN_HANG_NOI_BO.SO_TAI_KHOAN)
            {
                return BadRequest();
            }

            db.Entry(dM_TK_NGAN_HANG_NOI_BO).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DM_TK_NGAN_HANG_NOI_BOExists(id))
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

        // POST: api/Api_DM_TK_NGAN_HANG_NOI_BO
        [ResponseType(typeof(DM_TK_NGAN_HANG_NOI_BO))]
        public IHttpActionResult PostDM_TK_NGAN_HANG_NOI_BO(DM_TK_NGAN_HANG_NOI_BO dM_TK_NGAN_HANG_NOI_BO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DM_TK_NGAN_HANG_NOI_BO.Add(dM_TK_NGAN_HANG_NOI_BO);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (DM_TK_NGAN_HANG_NOI_BOExists(dM_TK_NGAN_HANG_NOI_BO.SO_TAI_KHOAN))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = dM_TK_NGAN_HANG_NOI_BO.SO_TAI_KHOAN }, dM_TK_NGAN_HANG_NOI_BO);
        }

        // DELETE: api/Api_DM_TK_NGAN_HANG_NOI_BO/5
        [ResponseType(typeof(DM_TK_NGAN_HANG_NOI_BO))]
        public IHttpActionResult DeleteDM_TK_NGAN_HANG_NOI_BO(string id)
        {
            DM_TK_NGAN_HANG_NOI_BO dM_TK_NGAN_HANG_NOI_BO = db.DM_TK_NGAN_HANG_NOI_BO.Find(id);
            if (dM_TK_NGAN_HANG_NOI_BO == null)
            {
                return NotFound();
            }

            db.DM_TK_NGAN_HANG_NOI_BO.Remove(dM_TK_NGAN_HANG_NOI_BO);
            db.SaveChanges();

            return Ok(dM_TK_NGAN_HANG_NOI_BO);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DM_TK_NGAN_HANG_NOI_BOExists(string id)
        {
            return db.DM_TK_NGAN_HANG_NOI_BO.Count(e => e.SO_TAI_KHOAN == id) > 0;
        }
    }
}