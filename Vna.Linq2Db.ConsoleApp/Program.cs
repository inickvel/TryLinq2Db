using AutoMapper;
using AutoMapper.QueryableExtensions;
using LinqToDB;
using LinqToDB.Data;
using System;
using System.Diagnostics;
using System.Linq;
using Vna.Linq2Db.ConsoleApp.Dto;
using Vna.Linq2Db.DataModels;

namespace Vna.Linq2Db.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            InitializeMapper();

            //LinqToDB.Common.Configuration.Linq.AllowMultipleQuery = true;
            DataConnection.TurnTraceSwitchOn();
            DataConnection.WriteTraceLine = (s, s1) => Debug.WriteLine(s, s1);

            using (var db = new NorthwindDb())
            {
                var q =
                    (from o in db.OrderDetails
                        .LoadWith(o => o.OrderDetailsOrder)
                        .LoadWith(o => o.OrderDetailsOrder.Customer)
                        .LoadWith(o => o.OrderDetailsOrder.Employee)
                     where o.OrderDetailsOrder.Employee.LastName.StartsWith("King")
                     select o)
                    .ProjectTo<OrderDto>()
                    .ToList();

                foreach (var o in q)
                {
                    Console.WriteLine(
                        $"OrderDate: {o.OrderDetailsOrderOrderDate}\tOrderDetailsProductProductName:{o.OrderDetailsProductProductName}\tCustomerContactName: {o.OrderDetailsOrderCustomerContactName}\tQuantity: {o.Quantity}");
                }
            }

            Console.ReadLine();
        }

        private static void InitializeMapper()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<OrderDetail, OrderDto>();
            });
            Mapper.AssertConfigurationIsValid();
        }
    }
}
