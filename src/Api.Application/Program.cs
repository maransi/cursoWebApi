using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Data.Content;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace application
{
    public class Program
    {
        public static void Main(string[] args)
        {
/*
            var ctx = new MyContext();

            using( var context = new MyContext() ){
                var Usuarios = context
                                .Users
                                .AsNoTracking()
                                .OrderBy( u => u.Nome )
                                .ToList();

                Usuarios.ForEach(u => {
                    System.Console.WriteLine($"{u.Nome} | {u.Email}");
                });
            }
*/
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
