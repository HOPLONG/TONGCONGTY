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

namespace ERP.Web.Api.KhachHang
{
    public class Api_ArrayLienHeKHController : ApiController
    {
        private ERP_DATABASEEntities db = new ERP_DATABASEEntities();

        // GET: api/Api_ArrayLienHeKH
        public IQueryable<KH_LIEN_HE> GetKH_LIEN_HE()
        {
            return db.KH_LIEN_HE;
        }

        // GET: api/Api_ArrayLienHeKH/5
        [ResponseType(typeof(KH_LIEN_HE))]
        public IHttpActionResult GetKH_LIEN_HE(int id)
        {
            KH_LIEN_HE kH_LIEN_HE = db.KH_LIEN_HE.Find(id);
            if (kH_LIEN_HE == null)
            {
                return NotFound();
            }

            return Ok(kH_LIEN_HE);
        }

        // PUT: api/Api_ArrayLienHeKH/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutKH_LIEN_HE(int id, KH_LIEN_HE kH_LIEN_HE)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != kH_LIEN_HE.ID_LIEN_HE)
            {
                return BadRequest();
            }

            db.Entry(kH_LIEN_HE).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KH_LIEN_HEExists(id))
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

        // POST: api/Api_ArrayLienHeKH
        [HttpPost]
        [Route("api/Api_ArrayLienHeKH/{makh}")]
        public async Task<IHttpActionResult> PostMultiArrayLienHeKH(string makh, [FromBody] List<KH_LIEN_HE> qUY_CHI_TIET_PHIEU_CHI)
        {
            for (int i = 0; i < qUY_CHI_TIET_PHIEU_CHI.Count(); i++)
            {
                //nH_NTTKs[i].ID = (index + i + 1).ToString();
                db.KH_LIEN_HE.Add(qUY_CHI_TIET_PHIEU_CHI[i]);
            }
            try
            {
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
            return Ok(qUY_CHI_TIET_PHIEU_CHI);
        }

        // DELETE: api/Api_ArrayLienHeKH/5
        [ResponseType(typeof(KH_LIEN_HE))]
        public IHttpActionResult DeleteKH_LIEN_HE(int id)
        {
            KH_LIEN_HE kH_LIEN_HE = db.KH_LIEN_HE.Find(id);
            if (kH_LIEN_HE == null)
            {
                return NotFound();
            }

            db.KH_LIEN_HE.Remove(kH_LIEN_HE);
            db.SaveChanges();

            return Ok(kH_LIEN_HE);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool KH_LIEN_HEExists(int id)
        {
            return db.KH_LIEN_HE.Count(e => e.ID_LIEN_HE == id) > 0;
        }
    }
}