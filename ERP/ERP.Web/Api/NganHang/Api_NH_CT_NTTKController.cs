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
    public class Api_NH_CT_NTTKController : ApiController
    {
        private ERP_DATABASEEntities db = new ERP_DATABASEEntities();

        // GET: api/Api_NH_CT_NTTK
        public IQueryable<NH_CT_NTTK> GetNH_CT_NTTK()
        {
            return db.NH_CT_NTTK;
        }

        // GET: api/Api_NH_CT_NTTK/5
        [ResponseType(typeof(NH_CT_NTTK))]
        public IHttpActionResult GetNH_CT_NTTK(int id)
        {
            NH_CT_NTTK nH_CT_NTTK = db.NH_CT_NTTK.Find(id);
            if (nH_CT_NTTK == null)
            {
                return NotFound();
            }

            return Ok(nH_CT_NTTK);
        }

        // PUT: api/Api_NH_CT_NTTK/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutNH_CT_NTTK(int id, NH_CT_NTTK nH_CT_NTTK)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != nH_CT_NTTK.ID)
            {
                return BadRequest();
            }

            db.Entry(nH_CT_NTTK).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NH_CT_NTTKExists(id))
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

        // POST: api/Api_NH_CT_NTTK
        [HttpPost]
        [ActionName("Multi")]
        public async Task<IHttpActionResult> PostMultiNH_NTTK([FromBody] List<NH_CT_NTTK> nH_NTTKs)
        {
            for (int i = 0; i < nH_NTTKs.Count(); i++)
            {
                //nH_NTTKs[i].ID = (index + i + 1).ToString();
                db.NH_CT_NTTK.Add(nH_NTTKs[i]);
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

        // DELETE: api/Api_NH_CT_NTTK/5
        [ResponseType(typeof(NH_CT_NTTK))]
        public IHttpActionResult DeleteNH_CT_NTTK(int id)
        {
            NH_CT_NTTK nH_CT_NTTK = db.NH_CT_NTTK.Find(id);
            if (nH_CT_NTTK == null)
            {
                return NotFound();
            }

            db.NH_CT_NTTK.Remove(nH_CT_NTTK);
            db.SaveChanges();

            return Ok(nH_CT_NTTK);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NH_CT_NTTKExists(int id)
        {
            return db.NH_CT_NTTK.Count(e => e.ID == id) > 0;
        }
    }
}