﻿using Microsoft.AspNetCore.Mvc;
using LojaVirtual.Business;
using Microsoft.AspNetCore.Authorization;
using LojaVirtual.Model;
using System;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace LojaVirtual.Controllers
{
    [ApiVersion("1")]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class FileController : Controller
    {
        private IFileBusiness _fileBusiness;

        public FileController(IFileBusiness fileBusiness)
        {
            _fileBusiness = fileBusiness;
        }

        [HttpGet]
        [SwaggerResponse((200), Type = typeof(byte []))]
        [SwaggerResponse(204)]
        [SwaggerResponse(400)]
        [SwaggerResponse(401)]
        [Authorize("Bearer")]
        public IActionResult GetPDFFile()
        {
            byte[] buffer = _fileBusiness.GetPDFFile() as byte[];
            
            if (buffer != null)
            {
                HttpContext.Response.ContentType = "application/pdf";
                HttpContext.Response.Headers.Add("content-length", buffer.Length.ToString());
                HttpContext.Response.Body.Write(buffer, 0, buffer.Length);
            }
            return new ContentResult();
        }

      
    }
}
