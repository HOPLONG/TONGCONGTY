using ERP.Web.Models.Database;
using ERP.Web.Models.NewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ERP.Web.Api.Kho
{
    public class Api_ChecktonkhoController : ApiController
    {
        private ERP_DATABASEEntities db = new ERP_DATABASEEntities();
        // GET: api/Checktonkho
        //public List<tonkhohanghoa> Get()
        //{
        //    //var query = db.Database.SqlQuery<tonkhohanghoa>("PROD_HANGHOA");
        //    //var result = query.ToList().Select(x => new tonkhohanghoa()
        //    //{
        //    //    MA_HANG = x.MA_HANG,
        //    //    IVHL01 = x.IVHL01,
        //    //    IVHOPLONG = x.IVHOPLONG,
        //    //    IVTADN = x.IVTADN,
        //    //    IVTAHCM = x.IVTAHCM,
        //    //    IVTAHP = x.IVTAHP
        //    //}).ToList();
            
        //    return result;
        //}
    

    }
}
