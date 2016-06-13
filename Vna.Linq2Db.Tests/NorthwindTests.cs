using Vna.Linq2Db.DataModels;
using Xunit;
using System.Linq;
using System.Diagnostics;

namespace Vna.Linq2Db.Tests
{
    public class NorthwindTests
    {
        [Fact]
        public void SimpleQuery()
        {
            using (var db = new NorthwindDb())
            {
                var q =
                    from c in db.Categories
                    select c;

                foreach (var c in q)
                    Debug.WriteLine(c.CategoryName);
            }
        }
    }
}
