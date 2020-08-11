using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RabbitSqlLib;

namespace Test1.Controllers
{
    [Microsoft.AspNetCore.Cors.EnableCors("AllowAllOrigins")]
    [Route("api/Values")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpGet("testget")]
        public ActionResult TestGet([FromQuery] List<string> bzjh)
        {
            //RabbitAccess access = GetAccess();
            //DataTable dt = access.GetDataTable("select * from ts_j_basicinfo where well_id='DQtFbHtP6C'");
            return Ok(bzjh);
        }

        public RabbitAccess GetAccess()
        {
            DBEntity dBEntity = new DBEntity();
            dBEntity.DBType = "oracle";
            dBEntity.DBPort = "1521";
            dBEntity.DBServer = "132.232.16.136";
            dBEntity.DBName = "orcl";
            dBEntity.DBUser = "dqts";
            dBEntity.DBPwd = "dqts";
            string dBType = "";
            string connstr = dBEntity.GetConnStr(out dBType);
            RabbitAccess access = new RabbitAccess(dBType, connstr);
            return access;
        }

    }
}
