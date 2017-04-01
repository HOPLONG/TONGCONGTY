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
    public class Api_QUY_CT_PHIEU_THUController : ApiController
    {
        private ERP_DATABASEEntities db = new ERP_DATABASEEntities();

        // GET: api/Api_QUY_CT_PHIEU_THU
        public IQueryable<QUY_CT_PHIEU_THU> GetQUY_CT_PHIEU_THU()
        {
            return db.QUY_CT_PHIEU_THU;
        }

        // GET: api/Api_QUY_CT_PHIEU_THU/5
        [ResponseType(typeof(QUY_CT_PHIEU_THU))]
        public IHttpActionResult GetQUY_CT_PHIEU_THU(int id)
        {
            QUY_CT_PHIEU_THU qUY_CT_PHIEU_THU = db.QUY_CT_PHIEU_THU.Find(id);
            if (qUY_CT_PHIEU_THU == null)
            {
                return NotFound();
            }

            return Ok(qUY_CT_PHIEU_THU);
        }

        // PUT: api/Api_QUY_CT_PHIEU_THU/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutQUY_CT_PHIEU_THU(int id, QUY_CT_PHIEU_THU qUY_CT_PHIEU_THU)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != qUY_CT_PHIEU_THU.ID)
            {
                return BadRequest();
            }

            db.Entry(qUY_CT_PHIEU_THU).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QUY_CT_PHIEU_THUExists(id))
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

        [HttpPost]
        [ActionName("Multi")]
        public async Task<IHttpActionResult> PostMultiQUY_CT_PHIEU_THU([FromBody] List<QUY_CT_PHIEU_THU> qUY_CT_PHIEU_THU)
        {
            for (int i = 0; i < qUY_CT_PHIEU_THU.Count(); i++)
            {
                //nH_NTTKs[i].ID = (index + i + 1).ToString();
                db.QUY_CT_PHIEU_THU.Add(qUY_CT_PHIEU_THU[i]);
            }
            try
            {
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
            return Ok(qUY_CT_PHIEU_THU);
        }

        // DELETE: api/Api_QUY_CT_PHIEU_THU/5
        [ResponseType(typeof(QUY_CT_PHIEU_THU))]
        public IHttpActionResult DeleteQUY_CT_PHIEU_THU(int id)
        {
            QUY_CT_PHIEU_THU qUY_CT_PHIEU_THU = db.QUY_CT_PHIEU_THU.Find(id);
            if (qUY_CT_PHIEU_THU == null)
            {
                return NotFound();
            }

            db.QUY_CT_PHIEU_THU.Remove(qUY_CT_PHIEU_THU);
            db.SaveChanges();

            return Ok(qUY_CT_PHIEU_THU);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool QUY_CT_PHIEU_THUExists(int id)
        {
            return db.QUY_CT_PHIEU_THU.Count(e => e.ID == id) > 0;
        }
    }
}