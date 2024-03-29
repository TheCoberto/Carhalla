﻿using GuildCars.Data.Repositories.ADO;
using GuildCars.Models.Queries;
using GuildCars.Models.Tables;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;

namespace GuildCars.Tests
{
    [TestFixture]
    public class CarsRepositoryTestsADO
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

        [OneTimeTearDown]
        public void TearDown()
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
        public void CanGetCarById()
        {
            CarsRepositoryADO repo = new CarsRepositoryADO();
            Car car = repo.GetCarById(2);

            Assert.IsNotNull(car);

            Assert.AreEqual("2ABC2ABC2ABC2ABC2", car.VIN);
            Assert.AreEqual(2, car.CarId);
            Assert.AreEqual(new DateTime(2020, 1, 1), car.ModelYear);
            Assert.IsTrue(car.IsNew);
            Assert.IsFalse(car.IsSold);
            Assert.IsTrue(car.IsFeatured);
            Assert.AreEqual(3, car.UnitsInStock);
            Assert.AreEqual("200", car.Mileage);
            Assert.AreEqual(2, car.BodyColorId);
            Assert.AreEqual(2, car.BodyStyleId);
            Assert.AreEqual(2, car.TransmissionId);
            Assert.AreEqual(2, car.MakeId);
            Assert.AreEqual(3, car.ModelId);
            Assert.AreEqual(3, car.InteriorColorId);
            Assert.AreEqual(33000.00m, car.SalePrice);
            Assert.AreEqual(34150.00m, car.MSRP);
            Assert.AreEqual("/Images/2018AcuraTLX.png", car.IMGFilePath);
            Assert.AreEqual("Very very very dependable.", car.VehicleDetails);
        }

        [Test]
        public void CanGetAllCars()
        {
            CarsRepositoryADO repo = new CarsRepositoryADO();
            List<Car> cars = repo.GetAllCars().ToList();

            Assert.AreEqual(6, cars.Count);

            Assert.AreEqual("2ABC2ABC2ABC2ABC2", cars[1].VIN);
            Assert.AreEqual(2, cars[1].CarId);
            Assert.AreEqual(new DateTime(2020, 1, 1), cars[1].ModelYear);
            Assert.IsTrue(cars[1].IsNew);
            Assert.IsFalse(cars[1].IsSold);
            Assert.IsTrue(cars[1].IsFeatured);
            Assert.AreEqual(3, cars[1].UnitsInStock);
            Assert.AreEqual("200", cars[1].Mileage);
            Assert.AreEqual(2, cars[1].BodyColorId);
            Assert.AreEqual(2, cars[1].BodyStyleId);
            Assert.AreEqual(2, cars[1].TransmissionId);
            Assert.AreEqual(2, cars[1].MakeId);
            Assert.AreEqual(3, cars[1].ModelId);
            Assert.AreEqual(3, cars[1].InteriorColorId);
            Assert.AreEqual(33000.00m, cars[1].SalePrice);
            Assert.AreEqual(34150.00m, cars[1].MSRP);
            Assert.AreEqual("/Images/2018AcuraTLX.png", cars[1].IMGFilePath);
            Assert.AreEqual("Very very very dependable.", cars[1].VehicleDetails);
        }

        [Test]
        public void CanGetFeaturedCars()
        {
            CarsRepositoryADO repo = new CarsRepositoryADO();
            List<FeaturedShortListItem> featuredCars = repo.GetAllFeaturedCars().ToList();

            Assert.AreEqual(4, featuredCars.Count);

            Assert.AreEqual(2, featuredCars[0].CarId);
            Assert.AreEqual(new DateTime(2020, 1, 1), featuredCars[0].Year);
            Assert.AreEqual(2, featuredCars[0].MakeId);
            Assert.AreEqual(3, featuredCars[0].ModelId);
            Assert.AreEqual(33000.00m, featuredCars[0].Price);
            Assert.AreEqual("/Images/2018AcuraTLX.png", featuredCars[0].ImageURL);
            Assert.AreEqual("Acura", featuredCars[0].Make);
            Assert.AreEqual("TLX", featuredCars[0].Model);
        }

        [Test]
        public void CanGetNewCars()
        {
            CarsRepositoryADO repo = new CarsRepositoryADO();
            List<Car> cars = repo.GetAllNewCars().ToList();

            Assert.AreEqual(3, cars.Count);

            Assert.AreEqual("2ABC2ABC2ABC2ABC2", cars[1].VIN);
            Assert.AreEqual(2, cars[1].CarId);
            Assert.AreEqual(new DateTime(2020, 1, 1), cars[1].ModelYear);
            Assert.IsTrue(cars[1].IsNew);
            Assert.IsFalse(cars[1].IsSold);
            Assert.IsTrue(cars[1].IsFeatured);
            Assert.AreEqual(3, cars[1].UnitsInStock);
            Assert.AreEqual("200", cars[1].Mileage);
            Assert.AreEqual(2, cars[1].BodyColorId);
            Assert.AreEqual(2, cars[1].BodyStyleId);
            Assert.AreEqual(2, cars[1].TransmissionId);
            Assert.AreEqual(2, cars[1].MakeId);
            Assert.AreEqual(3, cars[1].ModelId);
            Assert.AreEqual(3, cars[1].InteriorColorId);
            Assert.AreEqual(33000.00m, cars[1].SalePrice);
            Assert.AreEqual(34150.00m, cars[1].MSRP);
            Assert.AreEqual("/Images/2018AcuraTLX.png", cars[1].IMGFilePath);
            Assert.AreEqual("Very very very dependable.", cars[1].VehicleDetails);
        }

        [Test]
        public void CanGetUsedCars()
        {
            CarsRepositoryADO repo = new CarsRepositoryADO();
            List<Car> cars = repo.GetAllUsedCars().ToList();

            Assert.AreEqual(3, cars.Count);

            Assert.AreEqual("4ABC4ABC4ABC4ABC4", cars[1].VIN);
            Assert.AreEqual(4, cars[1].CarId);
            Assert.AreEqual(new DateTime(2005, 1, 1), cars[1].ModelYear);
            Assert.IsFalse(cars[1].IsNew);
            Assert.IsFalse(cars[1].IsSold);
            Assert.IsFalse(cars[1].IsFeatured);
            Assert.AreEqual(1, cars[1].UnitsInStock);
            Assert.AreEqual("111200", cars[1].Mileage);
            Assert.AreEqual(5, cars[1].BodyColorId);
            Assert.AreEqual(4, cars[1].BodyStyleId);
            Assert.AreEqual(1, cars[1].TransmissionId);
            Assert.AreEqual(4, cars[1].MakeId);
            Assert.AreEqual(4, cars[1].ModelId);
            Assert.AreEqual(4, cars[1].InteriorColorId);
            Assert.AreEqual(4000.00m, cars[1].SalePrice);
            Assert.AreEqual(5000.00m, cars[1].MSRP);
            Assert.AreEqual("/Images/2005DodgeGrandCaravan.jpg", cars[1].IMGFilePath);
            Assert.AreEqual("Dusty old van.", cars[1].VehicleDetails);
        }

        [Test]
        public void CanGetUnsoldCars()
        {
            CarsRepositoryADO repo = new CarsRepositoryADO();
            List<Car> cars = repo.GetAllUnsoldCars().ToList();

            Assert.AreEqual(5, cars.Count);

            Assert.AreEqual("4ABC4ABC4ABC4ABC4", cars[2].VIN);
            Assert.AreEqual(4, cars[2].CarId);
            Assert.AreEqual(new DateTime(2005, 1, 1), cars[2].ModelYear);
            Assert.IsFalse(cars[2].IsNew);
            Assert.IsFalse(cars[2].IsSold);
            Assert.IsFalse(cars[2].IsFeatured);
            Assert.AreEqual(1, cars[2].UnitsInStock);
            Assert.AreEqual("111200", cars[2].Mileage);
            Assert.AreEqual(5, cars[2].BodyColorId);
            Assert.AreEqual(4, cars[2].BodyStyleId);
            Assert.AreEqual(1, cars[2].TransmissionId);
            Assert.AreEqual(4, cars[2].MakeId);
            Assert.AreEqual(4, cars[2].ModelId);
            Assert.AreEqual(4, cars[2].InteriorColorId);
            Assert.AreEqual(4000.00m, cars[2].SalePrice);
            Assert.AreEqual(5000.00m, cars[2].MSRP);
            Assert.AreEqual("/Images/2005DodgeGrandCaravan.jpg", cars[2].IMGFilePath);
            Assert.AreEqual("Dusty old van.", cars[2].VehicleDetails);
        }

        [Test]
        public void CanGetSoldCars()
        {
            CarsRepositoryADO repo = new CarsRepositoryADO();
            List<Car> cars = repo.GetAllSoldCars().ToList();

            Assert.AreEqual(1, cars.Count);

            Assert.AreEqual("1ABC1ABC1ABC1ABC1", cars[0].VIN);
            Assert.AreEqual(1, cars[0].CarId);
            Assert.AreEqual(new DateTime(2021, 1, 1), cars[0].ModelYear);
            Assert.IsTrue(cars[0].IsSold);
        }

        [Test]
        public void CanAddCar()
        {
            Car car = new Car
            {
                ModelYear = new DateTime(2015, 1, 1),
                IsNew = false,
                IsFeatured = true,
                IsSold = false,
                UnitsInStock = 1,
                Mileage = "20000",
                VIN = "5ABC5ABC5ABC5ABC5",
                BodyColorId = 5,
                BodyStyleId = 3,
                TransmissionId = 2,
                MakeId = 3,
                ModelId = 2,
                InteriorColorId = 5,
                SalePrice = 19500m,
                MSRP = 21000m,
                IMGFilePath = "Images/placeholder.png",
                VehicleDetails = "2015 Ford Escape. Fully Loaded!"
            };

            CarsRepositoryADO repo = new CarsRepositoryADO();
            repo.Insert(car);

            List<Car> cars = repo.GetAllCars().ToList();
            Assert.AreEqual(7, cars.Count);

            Assert.AreEqual(7, cars[6].CarId);
            Assert.AreEqual(car.ModelYear, cars[6].ModelYear);
            Assert.AreEqual(car.IsNew, cars[6].IsNew);
            Assert.AreEqual(car.IsFeatured, cars[6].IsFeatured);
            Assert.AreEqual(car.IsSold, cars[6].IsSold);
            Assert.AreEqual(car.UnitsInStock, cars[6].UnitsInStock);
            Assert.AreEqual(car.Mileage, cars[6].Mileage);
            Assert.AreEqual(car.VIN, cars[6].VIN);
            Assert.AreEqual(car.BodyColorId, cars[6].BodyColorId);
            Assert.AreEqual(car.BodyStyleId, cars[6].BodyStyleId);
            Assert.AreEqual(car.TransmissionId, cars[6].TransmissionId);
            Assert.AreEqual(car.MakeId, cars[6].MakeId);
            Assert.AreEqual(car.ModelId, cars[6].ModelId);
            Assert.AreEqual(car.InteriorColorId, cars[6].InteriorColorId);
            Assert.AreEqual(car.SalePrice, cars[6].SalePrice);
            Assert.AreEqual(car.MSRP, cars[6].MSRP);
            Assert.AreEqual(car.IMGFilePath, cars[6].IMGFilePath);
            Assert.AreEqual(car.VehicleDetails, cars[6].VehicleDetails);
        }

        [Test]
        public void CanDeleteCar()
        {
            Car car = new Car
            {
                ModelYear = new DateTime(2015, 1, 1),
                IsNew = false,
                IsFeatured = true,
                IsSold = false,
                UnitsInStock = 1,
                Mileage = "20000",
                VIN = "5ABC5ABC5ABC5ABC5",
                BodyColorId = 5,
                BodyStyleId = 3,
                TransmissionId = 2,
                MakeId = 3,
                ModelId = 2,
                InteriorColorId = 5,
                SalePrice = 19500m,
                MSRP = 21000m,
                IMGFilePath = "Images/placeholder.png",
                VehicleDetails = "2015 Ford Escape. Fully Loaded!"
            };

            CarsRepositoryADO repo = new CarsRepositoryADO();

            repo.Insert(car);

            var newCar = repo.GetCarById(7);

            Assert.IsNotNull(newCar);

            repo.Delete(7);

            newCar = repo.GetCarById(7);

            Assert.IsNull(newCar);
        }

        [Test]
        public void CanUpdateCar()
        {
            Car car = new Car
            {
                ModelYear = new DateTime(2015, 1, 1),
                IsNew = false,
                IsFeatured = true,
                IsSold = false,
                UnitsInStock = 1,
                Mileage = "20000",
                VIN = "5ABC5ABC5ABC5ABC5",
                BodyColorId = 5,
                BodyStyleId = 3,
                TransmissionId = 2,
                MakeId = 3,
                ModelId = 2,
                InteriorColorId = 5,
                SalePrice = 19500m,
                MSRP = 21000m,
                IMGFilePath = "Images/placeholder.png",
                VehicleDetails = "2015 Ford Escape. Fully Loaded!"
            };

            CarsRepositoryADO repo = new CarsRepositoryADO();

            repo.Insert(car);

            car.BodyColorId = 2;
            car.InteriorColorId = 5;
            car.SalePrice = 17500m;
            car.MSRP = 19200m;
            car.IMGFilePath = "Images/updatedImage.png";
            car.IsSold = true;
            car.IsNew = true;
            car.IsFeatured = true;
            car.VIN = "6ABC6ABC6ABC6ABC6";
            car.VehicleDetails = "Updated";
            car.Mileage = "3";
            car.ModelYear = new DateTime(2018, 1, 1);
            car.MakeId = 2;
            car.ModelId = 3;
            car.TransmissionId = 1;
            car.UnitsInStock = 9;
            car.BodyStyleId = 2;

            repo.Update(car);

            var updatedCar = repo.GetCarById(7);

            Assert.AreEqual(updatedCar.BodyStyleId, 2);
            Assert.AreEqual(updatedCar.BodyColorId, 2);
            Assert.AreEqual(updatedCar.InteriorColorId, 5);
            Assert.AreEqual(updatedCar.IMGFilePath, "Images/updatedImage.png");
            Assert.AreEqual(updatedCar.SalePrice, 17500m);
            Assert.AreEqual(updatedCar.MSRP, 19200m);
            Assert.AreEqual(updatedCar.IsNew, true);
            Assert.AreEqual(updatedCar.IsFeatured, true);
            Assert.AreEqual(updatedCar.IsSold, true);
            Assert.AreEqual(updatedCar.VIN, "6ABC6ABC6ABC6ABC6");
            Assert.AreEqual(updatedCar.VehicleDetails, "Updated");
            Assert.AreEqual(updatedCar.Mileage, "3");
            Assert.AreEqual(updatedCar.ModelYear, new DateTime(2018, 1, 1));
            Assert.AreEqual(updatedCar.MakeId, 2);
            Assert.AreEqual(updatedCar.ModelId, 3);
            Assert.AreEqual(updatedCar.TransmissionId, 1);
            Assert.AreEqual(updatedCar.UnitsInStock, 8);
        }

        [Test]
        public void CanSearchForNewCarOnMinYear()
        {
            CarsRepositoryADO repo = new CarsRepositoryADO();

            CarsSearchParameters searchParameters = new CarsSearchParameters
            {
                IsNew = true,
                MinYear = new DateTime(2017,1,1),
                MaxYear =  null,
                MaxPrice = null,
                MinPrice = null,
                SearchTerm = null
            };

            List<SearchResultItem> searchCarResults = repo.SearchCars(searchParameters).ToList();

            Assert.AreEqual(2, searchCarResults.Count);

            Assert.AreEqual(5, searchCarResults[1].CarId);
            Assert.AreEqual(new DateTime(2020,1,1).Year.ToString(), searchCarResults[1].Year);
            Assert.AreEqual("Mock", searchCarResults[1].Make);
            Assert.AreEqual("Vehicle", searchCarResults[1].Model);
            Assert.AreEqual("Silver", searchCarResults[1].BodyColor);
            Assert.AreEqual("Gray", searchCarResults[1].InteriorColor);
            Assert.AreEqual("Manual", searchCarResults[1].Transmission);
            Assert.AreEqual("/Images/MockNewCarPhoto.png", searchCarResults[1].IMGURL);
            Assert.AreEqual("5ABC5ABC5ABC5ABC5", searchCarResults[1].VIN);
            Assert.AreEqual("0", searchCarResults[1].Mileage);
            Assert.AreEqual(10000m, searchCarResults[1].SalePrice);
            Assert.AreEqual(10000m, searchCarResults[1].MSRP);
        }

        [Test]
        public void CanSearchForNewCarOnMaxYear()
        {
            CarsRepositoryADO repo = new CarsRepositoryADO();

            CarsSearchParameters searchParameters = new CarsSearchParameters
            {
                IsNew = true,
                MinYear = null,
                MaxYear = new DateTime(2020,1,1),
                MaxPrice = null,
                MinPrice = null,
                SearchTerm = null
            };

            List<SearchResultItem> searchCarResults = repo.SearchCars(searchParameters).ToList();

            Assert.AreEqual(2, searchCarResults.Count);

            Assert.AreEqual(2, searchCarResults[0].CarId);
        }

        [Test]
        public void CanSearchForNewCarOnMaxPrice()
        {
            CarsRepositoryADO repo = new CarsRepositoryADO();

            CarsSearchParameters searchParameters = new CarsSearchParameters
            {
                IsNew = true,
                MinYear = null,
                MaxYear = null,
                MaxPrice = 51000m,
                MinPrice = null,
                SearchTerm = null
            };

            List<SearchResultItem> searchCarResults = repo.SearchCars(searchParameters).ToList();

            Assert.AreEqual(2, searchCarResults.Count);
            Assert.AreEqual(2, searchCarResults[0].CarId);
            Assert.AreEqual(new DateTime(2020,1,1).Year.ToString(), searchCarResults[0].Year);
            Assert.AreEqual("Acura", searchCarResults[0].Make);
            Assert.AreEqual("TLX", searchCarResults[0].Model);
            Assert.AreEqual("Silver", searchCarResults[0].BodyColor);
            Assert.AreEqual("Gray", searchCarResults[0].InteriorColor);
            Assert.AreEqual("Manual", searchCarResults[0].Transmission);
            Assert.AreEqual("/Images/2018AcuraTLX.png", searchCarResults[0].IMGURL);
            Assert.AreEqual("2ABC2ABC2ABC2ABC2", searchCarResults[0].VIN);
            Assert.AreEqual("200", searchCarResults[0].Mileage);
            Assert.AreEqual(33000m, searchCarResults[0].SalePrice);
            Assert.AreEqual(34150m, searchCarResults[0].MSRP);
        }

        [Test]
        public void CanSearchForNewCarOnMinPrice()
        {
            CarsRepositoryADO repo = new CarsRepositoryADO();

            CarsSearchParameters searchParameters = new CarsSearchParameters
            {
                IsNew = true,
                MinYear = null,
                MaxYear = null,
                MaxPrice = null,
                MinPrice = 30000m,
                SearchTerm = null
            };

            List<SearchResultItem> searchCarResults = repo.SearchCars(searchParameters).ToList();

            Assert.AreEqual(1, searchCarResults.Count);

            Assert.AreEqual(2, searchCarResults[0].CarId);
            Assert.AreEqual(new DateTime(2020,1,1).Year.ToString(), searchCarResults[0].Year);
            Assert.AreEqual("Acura", searchCarResults[0].Make);
            Assert.AreEqual("TLX", searchCarResults[0].Model);
            Assert.AreEqual(33000m, searchCarResults[0].SalePrice);
            Assert.AreEqual(34150m, searchCarResults[0].MSRP);
        }

        [Test]
        public void CanSearchForNewCarSearchTerm()
        {
            CarsRepositoryADO repo = new CarsRepositoryADO();

            CarsSearchParameters searchParametersMake = new CarsSearchParameters
            {
                IsNew = true,
                MinYear = null,
                MaxYear = null,
                MaxPrice = null,
                MinPrice = null,
                SearchTerm = "Acu"
            };

            CarsSearchParameters searchParametersModel = new CarsSearchParameters
            {
                IsNew = true,
                MinYear = null,
                MaxYear = null,
                MaxPrice = null,
                MinPrice = null,
                SearchTerm = "TLX"
            };

            CarsSearchParameters searchParametersYear = new CarsSearchParameters
            {
                IsNew = true,
                MinYear = null,
                MaxYear = null,
                MaxPrice = null,
                MinPrice = null,
                SearchTerm = "2020"
            };

            List<SearchResultItem> searchCarResults = repo.SearchCars(searchParametersMake).ToList();

            Assert.AreEqual(1, searchCarResults.Count);

            Assert.AreEqual(2, searchCarResults[0].CarId);
            Assert.AreEqual(new DateTime(2020,1,1).Year.ToString(), searchCarResults[0].Year);
            Assert.AreEqual("Acura", searchCarResults[0].Make);
            Assert.AreEqual("TLX", searchCarResults[0].Model);
            Assert.AreEqual("Silver", searchCarResults[0].BodyColor);
            Assert.AreEqual("Gray", searchCarResults[0].InteriorColor);
            Assert.AreEqual("Manual", searchCarResults[0].Transmission);
            Assert.AreEqual("/Images/2018AcuraTLX.png", searchCarResults[0].IMGURL);
            Assert.AreEqual("2ABC2ABC2ABC2ABC2", searchCarResults[0].VIN);
            Assert.AreEqual("200", searchCarResults[0].Mileage);
            Assert.AreEqual(33000m, searchCarResults[0].SalePrice);
            Assert.AreEqual(34150m, searchCarResults[0].MSRP);
        }

        [Test]
        public void CanSearchForUsedCarOnMinYear()
        {
            CarsRepositoryADO repo = new CarsRepositoryADO();

            CarsSearchParameters searchParameters = new CarsSearchParameters
            {
                IsNew = false,
                MinYear = new DateTime(2017, 1, 1),
                MaxYear = null,
                MaxPrice = null,
                MinPrice = null,
                SearchTerm = null
            };

            List<SearchResultItem> searchCarResults = repo.SearchCars(searchParameters).ToList();

            Assert.AreEqual(2, searchCarResults.Count);

            Assert.AreEqual(6, searchCarResults[0].CarId);
            Assert.AreEqual(new DateTime(2017,1,1).Year.ToString(), searchCarResults[0].Year);
            Assert.AreEqual("Mock", searchCarResults[0].Make);
            Assert.AreEqual("Vehicle", searchCarResults[0].Model);
            Assert.AreEqual("Silver", searchCarResults[0].BodyColor);
            Assert.AreEqual("Gray", searchCarResults[0].InteriorColor);
            Assert.AreEqual("Manual", searchCarResults[0].Transmission);
            Assert.AreEqual("/Images/MockUsedCarPhoto.png", searchCarResults[0].IMGURL);
            Assert.AreEqual("8ABC8ABC8ABC8ABC8", searchCarResults[0].VIN);
            Assert.AreEqual("0", searchCarResults[0].Mileage);
            Assert.AreEqual(40000m, searchCarResults[0].SalePrice);
            Assert.AreEqual(40000m, searchCarResults[0].MSRP);
        }

        [Test]
        public void CanSearchForUsedCarOnMaxYear()
        {
            CarsRepositoryADO repo = new CarsRepositoryADO();

            CarsSearchParameters searchParameters = new CarsSearchParameters
            {
                IsNew = false,
                MinYear = null,
                MaxYear = new DateTime(2017, 1, 1),
                MaxPrice = null,
                MinPrice = null,
                SearchTerm = null
            };

            List<SearchResultItem> searchCarResults = repo.SearchCars(searchParameters).ToList();

            Assert.AreEqual(2, searchCarResults.Count);

            Assert.AreEqual(4, searchCarResults[1].CarId);
            Assert.AreEqual(new DateTime(2005,1,1).Year.ToString(), searchCarResults[1].Year);
            Assert.AreEqual("Dodge", searchCarResults[1].Make);
            Assert.AreEqual("Grand Caravan", searchCarResults[1].Model);
            Assert.AreEqual("White", searchCarResults[1].BodyColor);
            Assert.AreEqual("Tan", searchCarResults[1].InteriorColor);
            Assert.AreEqual("Automatic", searchCarResults[1].Transmission);
            Assert.AreEqual("/Images/2005DodgeGrandCaravan.jpg", searchCarResults[1].IMGURL);
            Assert.AreEqual("4ABC4ABC4ABC4ABC4", searchCarResults[1].VIN);
            Assert.AreEqual("111200", searchCarResults[1].Mileage);
            Assert.AreEqual(4000m, searchCarResults[1].SalePrice);
            Assert.AreEqual(5000m, searchCarResults[1].MSRP);
        }

        [Test]
        public void CanSearchForUsedCarOnMaxPrice()
        {
            CarsRepositoryADO repo = new CarsRepositoryADO();

            CarsSearchParameters searchParameters = new CarsSearchParameters
            {
                IsNew = false,
                MinYear = null,
                MaxYear = null,
                MaxPrice = 51000m,
                MinPrice = null,
                SearchTerm = null
            };

            List<SearchResultItem> searchCarResults = repo.SearchCars(searchParameters).ToList();

            Assert.AreEqual(3, searchCarResults.Count);

            Assert.AreEqual(4, searchCarResults[2].CarId);
            Assert.AreEqual(new DateTime(2005,1,1).Year.ToString(), searchCarResults[2].Year);
            Assert.AreEqual("Dodge", searchCarResults[2].Make);
            Assert.AreEqual("Grand Caravan", searchCarResults[2].Model);
            Assert.AreEqual("White", searchCarResults[2].BodyColor);
            Assert.AreEqual("Tan", searchCarResults[2].InteriorColor);
            Assert.AreEqual("Automatic", searchCarResults[2].Transmission);
            Assert.AreEqual("/Images/2005DodgeGrandCaravan.jpg", searchCarResults[2].IMGURL);
            Assert.AreEqual("4ABC4ABC4ABC4ABC4", searchCarResults[2].VIN);
            Assert.AreEqual("111200", searchCarResults[2].Mileage);
            Assert.AreEqual(4000m, searchCarResults[2].SalePrice);
            Assert.AreEqual(5000m, searchCarResults[2].MSRP);
        }

        [Test]
        public void CanSearchForUsedCarOnMinPrice()
        {
            CarsRepositoryADO repo = new CarsRepositoryADO();

            CarsSearchParameters searchParameters = new CarsSearchParameters
            {
                IsNew = false,
                MinYear = null,
                MaxYear = null,
                MaxPrice = null,
                MinPrice = 4000m,
                SearchTerm = null
            };

            List<SearchResultItem> searchCarResults = repo.SearchCars(searchParameters).ToList();

            Assert.AreEqual(3, searchCarResults.Count);
            Assert.AreEqual(4, searchCarResults[2].CarId);
            Assert.AreEqual(new DateTime(2005,1,1).Year.ToString(), searchCarResults[2].Year);
            Assert.AreEqual("Dodge", searchCarResults[2].Make);
            Assert.AreEqual("Grand Caravan", searchCarResults[2].Model);
            Assert.AreEqual("White", searchCarResults[2].BodyColor);
            Assert.AreEqual("Tan", searchCarResults[2].InteriorColor);
            Assert.AreEqual("Automatic", searchCarResults[2].Transmission);
            Assert.AreEqual("/Images/2005DodgeGrandCaravan.jpg", searchCarResults[2].IMGURL);
            Assert.AreEqual("4ABC4ABC4ABC4ABC4", searchCarResults[2].VIN);
            Assert.AreEqual("111200", searchCarResults[2].Mileage);
            Assert.AreEqual(4000m, searchCarResults[2].SalePrice);
            Assert.AreEqual(5000m, searchCarResults[2].MSRP);
        }

        [Test]
        public void CanSearchForUsedCarSearchTerm()
        {
            CarsRepositoryADO repo = new CarsRepositoryADO();

            CarsSearchParameters searchParametersMake = new CarsSearchParameters
            {
                IsNew = false,
                MinYear = null,
                MaxYear = null,
                MaxPrice = null,
                MinPrice = null,
                SearchTerm = "For"
            };

            CarsSearchParameters searchParametersModel = new CarsSearchParameters
            {
                IsNew = false,
                MinYear = null,
                MaxYear = null,
                MaxPrice = null,
                MinPrice = null,
                SearchTerm = "Esc"
            };

            CarsSearchParameters searchParametersYear = new CarsSearchParameters
            {
                IsNew = false,
                MinYear = null,
                MaxYear = null,
                MaxPrice = null,
                MinPrice = null,
                SearchTerm = "2019"
            };

            List<SearchResultItem> searchCarResults = repo.SearchCars(searchParametersMake).ToList();

            Assert.AreEqual(1, searchCarResults.Count);

            Assert.AreEqual(3, searchCarResults[0].CarId);
            Assert.AreEqual(new DateTime(2019,1,1).Year.ToString(), searchCarResults[0].Year);
            Assert.AreEqual("Ford", searchCarResults[0].Make);
            Assert.AreEqual("Escape", searchCarResults[0].Model);
            Assert.AreEqual("White", searchCarResults[0].BodyColor);
            Assert.AreEqual("White", searchCarResults[0].InteriorColor);
            Assert.AreEqual("Automatic", searchCarResults[0].Transmission);
            Assert.AreEqual("/Images/2017FordEscape.png", searchCarResults[0].IMGURL);
            Assert.AreEqual("3ABC3ABC3ABC3ABC3", searchCarResults[0].VIN);
            Assert.AreEqual("1200", searchCarResults[0].Mileage);
            Assert.AreEqual(22669m, searchCarResults[0].SalePrice);
            Assert.AreEqual(24500m, searchCarResults[0].MSRP);
        }

        [Test]
        public void CanReturnNewCarsWithoutParameters()
        {
            CarsRepositoryADO repo = new CarsRepositoryADO();

            CarsSearchParameters searchParameters = new CarsSearchParameters
            {
                IsNew = true,
                MinYear = null,
                MaxYear = null,
                MaxPrice = null,
                MinPrice = null,
                SearchTerm = null 
            };

            List<SearchResultItem> searchCarResults = repo.SearchCars(searchParameters).ToList();

            Assert.AreEqual(2, searchCarResults.Count);

            Assert.AreEqual(5, searchCarResults[1].CarId);
            Assert.AreEqual(new DateTime(2020,1,1).Year.ToString(), searchCarResults[1].Year);
            Assert.AreEqual("Mock", searchCarResults[1].Make);
            Assert.AreEqual("Vehicle", searchCarResults[1].Model);
            Assert.AreEqual("Silver", searchCarResults[1].BodyColor);
            Assert.AreEqual("Gray", searchCarResults[1].InteriorColor);
            Assert.AreEqual("Manual", searchCarResults[1].Transmission);
            Assert.AreEqual("/Images/MockNewCarPhoto.png", searchCarResults[1].IMGURL);
            Assert.AreEqual("5ABC5ABC5ABC5ABC5", searchCarResults[1].VIN);
            Assert.AreEqual("0", searchCarResults[1].Mileage);
            Assert.AreEqual(10000, searchCarResults[1].SalePrice);
            Assert.AreEqual(10000, searchCarResults[1].MSRP);
        }

        [Test]
        public void CanReturnUsedCarsWithoutParameters()
        {
            CarsRepositoryADO repo = new CarsRepositoryADO();

            CarsSearchParameters searchParameters = new CarsSearchParameters
            {
                IsNew = false,
                MinYear = null,
                MaxYear = null,
                MaxPrice = null,
                MinPrice = null,
                SearchTerm = null
            };

            List<SearchResultItem> searchCarResults = repo.SearchCars(searchParameters).ToList();

            Assert.AreEqual(3, searchCarResults.Count);

            Assert.AreEqual(4, searchCarResults[2].CarId);
            Assert.AreEqual(new DateTime(2005,1,1).Year.ToString(), searchCarResults[2].Year);
            Assert.AreEqual("Dodge", searchCarResults[2].Make);
            Assert.AreEqual("Grand Caravan", searchCarResults[2].Model);
            Assert.AreEqual("White", searchCarResults[2].BodyColor);
            Assert.AreEqual("Tan", searchCarResults[2].InteriorColor);
            Assert.AreEqual("Automatic", searchCarResults[2].Transmission);
            Assert.AreEqual("/Images/2005DodgeGrandCaravan.jpg", searchCarResults[2].IMGURL);
            Assert.AreEqual("4ABC4ABC4ABC4ABC4", searchCarResults[2].VIN);
            Assert.AreEqual("111200", searchCarResults[2].Mileage);
            Assert.AreEqual(4000m, searchCarResults[2].SalePrice);
            Assert.AreEqual(5000m, searchCarResults[2].MSRP);
        }
    }
}

