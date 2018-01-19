using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Donau.Services.Abstractions.Customers;
using Donau.Services.Dtos.Customers;
using Donau.Services.Queries.Customers;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.Prerendering;
using Util.Exceptions;
using Util.Files;
using Util.Webs.Controllers;

namespace Util.Samples.Webs.Api.Customers
{
    public class CustomersController : CrudControllerBase<CustomersDto, CustomersQuery> {
        private IFileStore _fileStore;
        public CustomersController(ICustomersService customersService,IFileStore fileStore) : base(customersService) {
            _fileStore = fileStore;
        }

        [HttpGet("test")]
        public IActionResult Test() {
            List<Item> items = new List<Item> {
                new Item( "B","1",2,"Group1" ),
                new Item( "A","2",1,"Group2" ),
                new Item( "D","3",4,"Group1" ),
                new Item( "C","4",3,"Group2" ),
            };
            return Success( items );
        }

        //https://docs.microsoft.com/en-us/aspnet/core/mvc/models/file-uploads
        [HttpPost("upload")]
        public IActionResult Upload() {
            var file = Util.Helpers.Web.GetFile();
            var path = _fileStore.Save( ToBytes( file.OpenReadStream() ), file.FileName );
            return Content( Util.Helpers.Json.ToJson( new { id = Guid.NewGuid(), url = "http://bpic.588ku.com/element_origin_min_pic/17/11/25/c43b3b5a4e58a2ac8cebddd7fc7e8686.jpg", fileName = file.FileName, extension = Path.GetExtension( file.FileName ) } ) );
        }

        /// <summary>
        /// 流转换为字节流
        /// </summary>
        /// <param name="stream">流</param>
        public static byte[] ToBytes( Stream stream ) {
            stream.Seek( 0, SeekOrigin.Begin );
            var buffer = new byte[stream.Length];
            stream.Read( buffer, 0, buffer.Length );
            return buffer;
        }

        public override async Task<IActionResult> CreateAsync([FromBody] CustomersDto dto ) {
            return Success();
        }
    }
}
