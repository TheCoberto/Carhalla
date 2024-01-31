using GuildCars.Data.Repositories.ADO;
using GuildCars.Models.Tables;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;

namespace GuildCars.Tests.BodyStyleRepositoryTests
{
    [TestFixture]
    public class BodyStyleRepositoryTestsADO
    {
        [SetUp]
        public void Init()
        {
            var dbConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

            try
            {
                using (dbConnection)
                {
                    var cmd = new SqlCommand
                    {
                        CommandText = "CarhallaDbReset",
                        CommandType = System.Data.CommandType.StoredProcedure,

                        Connection = dbConnection
                    };
                    dbConnection.Open();

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                string errorMessage = String.Format(CultureInfo.CurrentCulture,
                          "Exception Type: {0}, Message: {1}{2}",
                          ex.GetType(),
                          ex.Message,
                          ex.InnerException == null ? String.Empty :
                          String.Format(CultureInfo.CurrentCulture,
                                       " InnerException Type: {0}, Message: {1}",
                                       ex.InnerException.GetType(),
                                       ex.InnerException.Message));

                System.Diagnostics.Debug.WriteLine(errorMessage);

                dbConnection.Close();
            }
        }

        [Test]
        public void CanGetAllBodyStyles()
        {
            BodyStyleRepositoryADO repo = new BodyStyleRepositoryADO();

            List<BodyStyle> bodyStyles = repo.GetAll().ToList();

            Assert.AreEqual(4, bodyStyles.Count);

            Assert.AreEqual(bodyStyles[2].BodyStyleId, 3);
            Assert.AreEqual(bodyStyles[2].BodyStyleType, "SUV");
        }

        [Test]
        public void CanGetBodyStyleById()
        {
            BodyStyleRepositoryADO repo = new BodyStyleRepositoryADO();

            BodyStyle bodyStyle = repo.GetAll().FirstOrDefault(b => b.BodyStyleId == 3);

            Assert.AreEqual(bodyStyle.BodyStyleId, 3);
            Assert.AreEqual(bodyStyle.BodyStyleType, "SUV");
        }
    }
}
