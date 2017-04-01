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

namespace ERP.Web.Api.NganHang
{

    public class Api_XL_THAM_CHIEU_CHUNG_TUController : ApiController
    {
        private ERP_DATABASEEntities db = new ERP_DATABASEEntities();

        // GET: api/Api_XL_THAM_CHIEU_CHUNG_TU
        public IQueryable<XL_THAM_CHIEU_CHUNG_TU> GetXL_THAM_CHIEU_CHUNG_TU()
        {
            return db.XL_THAM_CHIEU_CHUNG_TU;
        }

        // GET: api/Api_XL_THAM_CHIEU_CHUNG_TU/5
        [ResponseType(typeof(XL_THAM_CHIEU_CHUNG_TU))]
        public IHttpActionResult GetXL_THAM_CHIEU_CHUNG_TU(int id)
        {
            XL_THAM_CHIEU_CHUNG_TU xL_THAM_CHIEU_CHUNG_TU = db.XL_THAM_CHIEU_CHUNG_TU.Find(id);
            if (xL_THAM_CHIEU_CHUNG_TU == null)
            {
                return NotFound();
            }

            return Ok(xL_THAM_CHIEU_CHUNG_TU);
        }

        // PUT: api/Api_XL_THAM_CHIEU_CHUNG_TU/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutXL_THAM_CHIEU_CHUNG_TU(int id, XL_THAM_CHIEU_CHUNG_TU xL_THAM_CHIEU_CHUNG_TU)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != xL_THAM_CHIEU_CHUNG_TU.ID)
            {
                return BadRequest();
            }

            db.Entry(xL_THAM_CHIEU_CHUNG_TU).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!XL_THAM_CHIEU_CHUNG_TUExists(id))
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

        // POST: api/Api_XL_THAM_CHIEU_CHUNG_TU
        [HttpPost]
        [ActionName("Multi")]
        public async Task<IHttpActionResult> PostMultiNH_NTTK([FromBody] List<XL_THAM_CHIEU_CHUNG_TU> nH_NTTKs)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            for (int i = 0; i < nH_NTTKs.Count(); i++)
            {
                //nH_NTTKs[i].ID = (index + i + 1).ToString();
                db.XL_THAM_CHIEU_CHUNG_TU.Add(nH_NTTKs[i]);
            }

            try
            {
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
            return Ok(nH_NTTKs);

        }

        // DELETE: api/Api_XL_THAM_CHIEU_CHUNG_TU/5
        [ResponseType(typeof(XL_THAM_CHIEU_CHUNG_TU))]
        public IHttpActionResult DeleteXL_THAM_CHIEU_CHUNG_TU(int id)
        {
            XL_THAM_CHIEU_CHUNG_TU xL_THAM_CHIEU_CHUNG_TU = db.XL_THAM_CHIEU_CHUNG_TU.Find(id);
            if (xL_THAM_CHIEU_CHUNG_TU == null)
            {
                return NotFound();
            }

            db.XL_THAM_CHIEU_CHUNG_TU.Remove(xL_THAM_CHIEU_CHUNG_TU);
            db.SaveChanges();

            return Ok(xL_THAM_CHIEU_CHUNG_TU);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool XL_THAM_CHIEU_CHUNG_TUExists(int id)
        {
            return db.XL_THAM_CHIEU_CHUNG_TU.Count(e => e.ID == id) > 0;
        }
    }
}