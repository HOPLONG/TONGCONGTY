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
    public class Api_DM_DOI_TUONGController : ApiController
    {
        private ERP_DATABASEEntities db = new ERP_DATABASEEntities();

        // GET: api/Api_DM_DOI_TUONG
        public List<DM_DOI_TUONG> GetDM_DOI_TUONG()
        {
            var vData = db.DM_DOI_TUONG;
            var result = vData.ToList().Select(x => new DM_DOI_TUONG()
            {
                MA_DOI_TUONG = x.MA_DOI_TUONG,
                TEN_DOI_TUONG = x.TEN_DOI_TUONG,
                DIA_CHI = x.DIA_CHI,
                MA_LOAI_DOI_TUONG = x.MA_LOAI_DOI_TUONG,
                MA_CONG_TY = x.MA_CONG_TY
            }).ToList();
            return result;

        }

        // GET: api/Api_DM_DOI_TUONG/5
        [ResponseType(typeof(DM_DOI_TUONG))]
        public IHttpActionResult GetDM_DOI_TUONG(string id)
        {
            DM_DOI_TUONG dM_DOI_TUONG = db.DM_DOI_TUONG.Find(id);
            if (dM_DOI_TUONG == null)
            {
                return NotFound();
            }

            return Ok(dM_DOI_TUONG);
        }

        // PUT: api/Api_DM_DOI_TUONG/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutDM_DOI_TUONG(string id, DM_DOI_TUONG dM_DOI_TUONG)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != dM_DOI_TUONG.MA_DOI_TUONG)
            {
                return BadRequest();
            }

            db.Entry(dM_DOI_TUONG).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DM_DOI_TUONGExists(id))
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

        // POST: api/Api_DM_DOI_TUONG
        [ResponseType(typeof(DM_DOI_TUONG))]
        public IHttpActionResult PostDM_DOI_TUONG(DM_DOI_TUONG dM_DOI_TUONG)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.DM_DOI_TUONG.Add(dM_DOI_TUONG);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (DM_DOI_TUONGExists(dM_DOI_TUONG.MA_DOI_TUONG))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = dM_DOI_TUONG.MA_DOI_TUONG }, dM_DOI_TUONG);
        }

        // DELETE: api/Api_DM_DOI_TUONG/5
        [ResponseType(typeof(DM_DOI_TUONG))]
        public IHttpActionResult DeleteDM_DOI_TUONG(string id)
        {
            DM_DOI_TUONG dM_DOI_TUONG = db.DM_DOI_TUONG.Find(id);
            if (dM_DOI_TUONG == null)
            {
                return NotFound();
            }

            db.DM_DOI_TUONG.Remove(dM_DOI_TUONG);
            db.SaveChanges();

            return Ok(dM_DOI_TUONG);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool DM_DOI_TUONGExists(string id)
        {
            return db.DM_DOI_TUONG.Count(e => e.MA_DOI_TUONG == id) > 0;
        }
    }
}