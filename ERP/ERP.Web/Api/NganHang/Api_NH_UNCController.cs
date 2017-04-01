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

namespace ERP.Web.Api.NganHang
{
    public class Api_NH_UNCController : ApiController
    {
        private ERP_DATABASEEntities db = new ERP_DATABASEEntities();

        // GET: api/Api_NH_UNC
        public IQueryable<NH_UNC> GetNH_UNC()
        {
            return db.NH_UNC;
        }

        // GET: api/Api_NH_UNC/5
        [ResponseType(typeof(NH_UNC))]
        public IHttpActionResult GetNH_UNC(string id)
        {
            NH_UNC nH_UNC = db.NH_UNC.Find(id);
            if (nH_UNC == null)
            {
                return NotFound();
            }

            return Ok(nH_UNC);
        }

        // PUT: api/Api_NH_UNC/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutNH_UNC(string id, NH_UNC nH_UNC)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != nH_UNC.SO_CHUNG_TU)
            {
                return BadRequest();
            }

            db.Entry(nH_UNC).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!NH_UNCExists(id))
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

        // POST: api/Api_NH_UNC
        [ResponseType(typeof(NH_UNC))]
        public IHttpActionResult PostNH_UNC(NH_UNC nH_UNC)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.NH_UNC.Add(nH_UNC);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (NH_UNCExists(nH_UNC.SO_CHUNG_TU))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = nH_UNC.SO_CHUNG_TU }, nH_UNC);
        }

        // DELETE: api/Api_NH_UNC/5
        [ResponseType(typeof(NH_UNC))]
        public IHttpActionResult DeleteNH_UNC(string id)
        {
            NH_UNC nH_UNC = db.NH_UNC.Find(id);
            if (nH_UNC == null)
            {
                return NotFound();
            }

            db.NH_UNC.Remove(nH_UNC);
            db.SaveChanges();

            return Ok(nH_UNC);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool NH_UNCExists(string id)
        {
            return db.NH_UNC.Count(e => e.SO_CHUNG_TU == id) > 0;
        }
    }
}