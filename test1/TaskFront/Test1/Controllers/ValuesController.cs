﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RabbitSqlLib;
using TaskFront.Common;

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
            string str = "('" + String.Join("','", bzjh) + "')";
            string sql = "select * from ts_j_basicinfo where bzjh in " + str;
            RabbitAccess access = GetAccess();
            DataTable dt = access.GetDataTable(sql);
            StateInfo state = new StateInfo();
            state.data=dt;
            return Ok(state);
        }

        [HttpPost("testpost")]
        public ActionResult TestPost([FromForm] PageModel pageModel)
        {
            string sql = "select * from (select b.*,rownum rowno from ts_j_basicinfo b) where rowno between " + pageModel.getStartNum() + " and " + pageModel.getEndNum();
            RabbitAccess access = GetAccess();
            DataTable dt = access.GetDataTable(sql);
            StateInfo state = new StateInfo();
            state.data = dt;
            return Ok(state);
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
