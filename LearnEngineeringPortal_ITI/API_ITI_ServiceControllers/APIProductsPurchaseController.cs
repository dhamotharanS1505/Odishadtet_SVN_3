﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Odishadtet.APIServiceControllers
{
    public class APIProductsPurchaseController : ApiController
    {
        // GET: api/APIProductsPurchase
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/APIProductsPurchase/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/APIProductsPurchase
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/APIProductsPurchase/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/APIProductsPurchase/5
        public void Delete(int id)
        {
        }
    }
}
