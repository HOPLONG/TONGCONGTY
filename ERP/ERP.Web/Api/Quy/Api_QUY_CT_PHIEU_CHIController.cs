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
    public class Api_QUY_CT_PHIEU_CHIController : ApiController
    {
        private ERP_DATABASEEntities db = new ERP_DATABASEEntities();

        // GET: api/Api_QUY_CT_PHIEU_CHI
        public IQueryable<QUY_CT_PHIEU_CHI> GetQUY_CT_PHIEU_CHI()
        {
            return db.QUY_CT_PHIEU_CHI;
        }

        // GET: api/Api_QUY_CT_PHIEU_CHI/5
        [ResponseType(typeof(QUY_CT_PHIEU_CHI))]
        public IHttpActionResult GetQUY_CT_PHIEU_CHI(int id)
        {
            QUY_CT_PHIEU_CHI qUY_CT_PHIEU_CHI = db.QUY_CT_PHIEU_CHI.Find(id);
            if (qUY_CT_PHIEU_CHI == null)
            {
                return NotFound();
            }

            return Ok(qUY_CT_PHIEU_CHI);
        }

        // PUT: api/Api_QUY_CT_PHIEU_CHI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutQUY_CT_PHIEU_CHI(int id, QUY_CT_PHIEU_CHI qUY_CT_PHIEU_CHI)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != qUY_CT_PHIEU_CHI.ID)
            {
                return BadRequest();
            }

            db.Entry(qUY_CT_PHIEU_CHI).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QUY_CT_PHIEU_CHIExists(id))
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
        public async Task<IHttpActionResult> PostQUY_CT_PHIEU_CHI([FromBody] List<QUY_CT_PHIEU_CHI> qUY_CT_PHIEU_CHI)
        {
            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}
            //int index = _context.NH_CT_NTTK.ToList().Count();
            foreach (var item  in qUY_CT_PHIEU_CHI)
            {
                db.QUY_CT_PHIEU_CHI.Add(item);
            }
            //for (int i = 0; i < qUY_CT_PHIEU_CHI.Count(); i++)
            //{
            //    //nH_NTTKs[i].ID = (index + i + 1).ToString();
            //    db.QUY_CT_PHIEU_CHI.Add(qUY_CT_PHIEU_CHI[i]);
            //}
            try
            {
                await db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return Ok(ex.Message);
            }
            return Ok(qUY_CT_PHIEU_CHI);
        }

        // DELETE: api/Api_QUY_CT_PHIEU_CHI/5
        [ResponseType(typeof(QUY_CT_PHIEU_CHI))]
        public IHttpActionResult DeleteQUY_CT_PHIEU_CHI(int id)
        {
            QUY_CT_PHIEU_CHI qUY_CT_PHIEU_CHI = db.QUY_CT_PHIEU_CHI.Find(id);
            if (qUY_CT_PHIEU_CHI == null)
            {
                return NotFound();
            }

            db.QUY_CT_PHIEU_CHI.Remove(qUY_CT_PHIEU_CHI);
            db.SaveChanges();

            return Ok(qUY_CT_PHIEU_CHI);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool QUY_CT_PHIEU_CHIExists(int id)
        {
            return db.QUY_CT_PHIEU_CHI.Count(e => e.ID == id) > 0;
        }
    }
}