using Carts.Domain;
using Carts.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Carts.Tests.Common
{
    public class CartsContextFactory
    {
        public static Guid machineAId = Guid.NewGuid();
        public static Guid machineBId = Guid.NewGuid();

        public static Guid CartIdForDelete = Guid.NewGuid();
        public static Guid CartIdForUpdate = Guid.NewGuid();

        public static CartsDbContext Create()
        {
            var opt = new DbContextOptionsBuilder<CartsDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var context = new CartsDbContext(opt);
            context.Database.EnsureCreated();
            context.Carts.AddRange(
                new Cart
                {
                    Goods = "1-Мука-100₽",
                    SessionId = Guid.Parse("C2FE989D-9237-475A-BEB0-49880EA0A1C1"),
                    machineId = machineAId
                },
                 new Cart
                 {
                     Goods = "2-Хлеб-27₽",
                     SessionId = Guid.Parse("B7CB9179-3F69-4F22-BADC-9D297FB6CC90"),
                     machineId = machineBId
                 },
                 /* new Cart
                  {
                      Goods = "2-Хлеб-27₽",
                      SessionId = Guid.Parse("804CA7DC-F1A8-476B-91D3-B511B718D668"),
                      machineId = Guid.Parse(System.Environment.MachineName)
                  },*/

                 new Cart
                 {
                     Goods = "5-Яйца-58₽",
                     SessionId = CartIdForDelete,
                     machineId = machineAId
                 },
                 new Cart
                 {
                     Goods = "1-Ferrero-389₽",
                     SessionId = CartIdForUpdate,
                     machineId = machineBId
                 }


            ) ;

            context.SaveChanges();
            return context;
        }

        public static void Destroy(CartsDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
