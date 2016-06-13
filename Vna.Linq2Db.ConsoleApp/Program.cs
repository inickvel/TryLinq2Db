using LinqToDB;
using LinqToDB.Data;
using System;
using System.Diagnostics;
using System.Linq;
using Vna.Linq2Db.DataModels;

namespace Vna.Linq2Db.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //LinqToDB.Common.Configuration.Linq.AllowMultipleQuery = true;
            DataConnection.TurnTraceSwitchOn();
            DataConnection.WriteTraceLine = (s, s1) => Debug.WriteLine(s, s1);

            using (var db = new NorthwindDb())
            {
                var q =
                    from o in db.Orders
                        .LoadWith(o => o.Customer)
                        .LoadWith(o => o.Employee)
                    where o.Employee.LastName.StartsWith("King")
                    select o;

                foreach (var o in q)
                {
                    Console.WriteLine(
                        $"{o.OrderDate} CustomerContactName: {o.Customer.ContactName} EmployeeLastName: {o.Employee.LastName}");
                }
            }

            Console.ReadLine();
        }
    }
}
