using GuildCars.Data.Interfaces;
using GuildCars.Models.Queries;
using GuildCars.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GuildCars.Data.Repositories.Mock
{
    public class CarsRepositoryMock : ICarsRepository
    {
        private static readonly List<Car> _cars = new List<Car>();
        private readonly MakeRepositoryMock _makeRepo = new MakeRepositoryMock();
        private readonly ModelRepositoryMock _modelRepo = new ModelRepositoryMock();
        private readonly ColorRepositoryMock _colorRepo = new ColorRepositoryMock();
        private readonly BodyStyleRepositoryMock _bodyStyleRepo = new BodyStyleRepositoryMock();
        private readonly TransmissionRepositoryMock _transmissionRepo = new TransmissionRepositoryMock();


        private static readonly Car _carOne = new Car
        {
            CarId = 1,
            ModelYear = new DateTime(2017, 1, 1),
            IsNew = true,
            IsFeatured = false,
            IsSold = true,
            UnitsInStock = 3,
            Mileage = "0",
            VIN = "1ABC1ABC1ABC1ABC1",
            BodyColorId = 1,
            BodyStyleId = 2,
            TransmissionId = 1,
            MakeId = 1,
            ModelId = 1,
            InteriorColorId = 1,
            SalePrice = 50315.00m,
            MSRP = 51815.00m,
            IMGFilePath = "/Images/2017ToyotaTundra1794.jpg",
            VehicleDetails = "Brand New and looks great."
        };

        private static readonly Car _carTwo = new Car
        {
            CarId = 2,
            ModelYear = new DateTime(2018, 1, 1),
            IsNew = true,
            IsFeatured = true,
            IsSold = false,
            UnitsInStock = 5,
            Mileage = "200",
            VIN = "2ABC2ABC2ABC2ABC2",
            BodyColorId = 2,
            BodyStyleId = 2,
            TransmissionId = 2,
            MakeId = 2,
            ModelId = 3,
            InteriorColorId = 3,
            SalePrice = 33000.00m,
            MSRP = 34150.00m,
            IMGFilePath = "/Images/2018AcuraTLX.png",
            VehicleDetails = "A silver bullet of power and dependability."
        };

        private static readonly Car _carThree = new Car
        {
            CarId = 3,
            ModelYear = new DateTime(2017, 1, 1),
            IsNew = false,
            IsFeatured = true,
            IsSold = true,
            UnitsInStock = 1,
            Mileage = "1200",
            VIN = "3ABC3ABC3ABC3ABC3",
            BodyColorId = 5,
            BodyStyleId = 3,
            TransmissionId = 1,
            MakeId = 3,
            ModelId = 1,
            InteriorColorId = 5,
            SalePrice = 22669.00m,
            MSRP = 24500.00m,
            IMGFilePath = "/Images/2017FordEscape.png",
            VehicleDetails = "Loaded! Used Price for Brand New Quality."
        };

        private static readonly Car _carFour = new Car
        {
            CarId = 4,
            ModelYear = new DateTime(2005, 1, 1),
            IsNew = false,
            IsFeatured = false,
            IsSold = false,
            UnitsInStock = 1,
            Mileage = "111200",
            VIN = "4ABC4ABC4ABC4ABC4",
            BodyColorId = 5,
            BodyStyleId = 4,
            TransmissionId = 1,
            MakeId = 4,
            ModelId = 4,
            InteriorColorId = 4,
            SalePrice = 4000.00m,
            MSRP = 5000.00m,
            IMGFilePath = "/Images/2005DodgeGrandCaravan.jpg",
            VehicleDetails = "Certified and ready to take your family anywhere."
        };

        

        public CarsRepositoryMock()
        {
            var carId = 5;
            if (_cars.Count() == 0)
            {
                _cars.Add(_carOne);
                _cars.Add(_carTwo);
                _cars.Add(_carThree);
                _cars.Add(_carFour);

                for (int i = 1; i < 4; i++)
                {
                    Car car = new Car
                    {
                        CarId = carId,
                        BodyColorId = i,
                        InteriorColorId = 1 + i,
                        TransmissionId = 1,
                        IMGFilePath = "/Images/MockUsedCarPhoto.jpg",
                        IsFeatured = false,
                        IsNew = false,
                        BodyStyleId = i,
                        IsSold = false,
                        MakeId = 5,
                        ModelId = 5,
                        Mileage = i.ToString() + "000",
                        ModelYear = new DateTime(2017, 1, 1),
                        MSRP = (i * 2000),
                        SalePrice = (i * 1800),
                        UnitsInStock = i + 1,
                        VehicleDetails = "Mock Used Car Number: " + carId.ToString(),
                        VIN = carId.ToString() + "ABC" + carId.ToString() + "ABC" + carId.ToString() + "ABC" + carId.ToString() + "ABC" + carId.ToString()
                    };

                    carId++;
                    _cars.Add(car);
                }

                for (int i = 1; i < 4; i++)
                {
                    Car car = new Car
                    {
                        CarId = carId,
                        BodyColorId = i,
                        InteriorColorId = 1 + i,
                        TransmissionId = 1,
                        IMGFilePath = "/Images/MockNewCarPhoto.jpg",
                        IsFeatured = true,
                        IsNew = true,
                        BodyStyleId = i,
                        IsSold = false,
                        MakeId = 5,
                        ModelId = 5,
                        Mileage = "0",
                        ModelYear = new DateTime(2017, 1, 1),
                        MSRP = (i * 10000),
                        SalePrice = (i * 9000),
                        UnitsInStock = i + 1,
                        VehicleDetails = "Mock New Car Number: " + carId.ToString(),
                        VIN = carId.ToString() + "ABC" + carId.ToString() + "ABC" + carId.ToString() + "ABC" + carId.ToString() + "ABC" + carId.ToString()
                    };

                    carId++;
                    _cars.Add(car);
                }
            }
        }

        
        public void Delete(int CarId)
        {
            Car car = _cars.FirstOrDefault(c => c.CarId == CarId);

            _cars.Remove(car);

        }

        public void CarsClearList()
        {
            _cars.Clear();
        }

        public IEnumerable<Car> GetAllCars()
        {
            return _cars;
        }

        public IEnumerable<FeaturedShortListItem> GetAllFeaturedCars()
        {
            List<Car> featuredCars = _cars.FindAll(c => c.IsFeatured == true);
            List<FeaturedShortListItem> featuredCarsShortList = new List<FeaturedShortListItem>();
            MakeRepositoryMock makeRepo = new MakeRepositoryMock();
            ModelRepositoryMock modelRepo = new ModelRepositoryMock();

            foreach (var car in featuredCars)
            {
                FeaturedShortListItem featuredCar = new FeaturedShortListItem
                {
                    CarId = car.CarId,
                    ImageURL = car.IMGFilePath,
                    Make = makeRepo.GetMakeById(car.MakeId).MakeName,
                    Model = modelRepo.GetModelById(car.ModelId).ModelName,
                    MakeId = car.MakeId,
                    ModelId = car.ModelId,
                    Year = car.ModelYear,
                    Price = car.SalePrice
                };

                featuredCarsShortList.Add(featuredCar);
            }
            return featuredCarsShortList;
        }

        public IEnumerable<Car> GetAllNewCars()
        {
            return _cars.Where(c => c.IsNew == true);
        }

        public IEnumerable<Car> GetAllSoldCars()
        {
            return _cars.Where(c => c.IsSold == true);
        }

        public IEnumerable<Car> GetAllUnsoldCars()
        {
            return _cars.Where(c => c.IsSold == false);
        }

        public IEnumerable<Car> GetAllUsedCars()
        {
            return _cars.Where(c => c.IsNew == false);
        }

        public Car GetCarById(int CarId)
        {
            return _cars.FirstOrDefault(c => c.CarId == CarId);
        }

        public void Insert(Car car)
        {
            car.CarId = _cars.Max(d => d.CarId) + 1;

            _cars.Add(car);
        }

        public void Update(Car Car)
        {
            int index = _cars.FindIndex(c => c.CarId == Car.CarId);

            _cars.RemoveAt(index);

            if (Car.IsSold == true)
            {
                if (Car.UnitsInStock >= 1)
                {
                    Car.UnitsInStock--;
                }
            }

            _cars.Insert(index, Car);
        }

        public IEnumerable<SearchResultItem> SearchCars(CarsSearchParameters parameters)
        {

            List<SearchResultItem> results = new List<SearchResultItem>();

            var query = _cars.Where(c => c.IsNew == parameters.IsNew);

            if (parameters.MaxYear.HasValue)
            {
                query = query.Where(c => c.ModelYear <= parameters.MaxYear);
            }

            if (parameters.MinYear.HasValue)
            {
                query = query.Where(c => c.ModelYear >= parameters.MinYear);
            }

            if (parameters.MaxPrice > 0)
            {
                query = query.Where(c => c.MSRP <= parameters.MaxPrice);
            }
            if (parameters.MinPrice > 0)
            {
                query = query.Where(c => c.MSRP >= parameters.MinPrice);
            }

            foreach (var car in query)
            {
                SearchResultItem searchResultItem = new SearchResultItem()
                {
                    InteriorColor = _colorRepo.GetColorById(car.InteriorColorId).ColorName,
                    BodyColor = _colorRepo.GetColorById(car.BodyColorId).ColorName,
                    BodyStyle = _bodyStyleRepo.GetBodyStyleById(car.BodyStyleId).BodyStyleType,
                    Transmission = _transmissionRepo.GetTransmissionById(car.TransmissionId).TransmissionType,
                    CarId = car.CarId,
                    IMGURL = car.IMGFilePath,
                    MSRP = car.MSRP,
                    SalePrice = car.SalePrice,
                    Make = _makeRepo.GetMakeById(car.MakeId).MakeName,
                    Model = _modelRepo.GetModelById(car.ModelId).ModelName,
                    Mileage = car.Mileage,
                    VIN = car.VIN,
                    Year = car.ModelYear.Year.ToString()
                };
                results.Add(searchResultItem);
            }

            if (!String.IsNullOrEmpty(parameters.SearchTerm))
            {
                results = results.Where(c => (c.Make).ToLower().Contains(parameters.SearchTerm.ToLower()) || c.Model.ToLower().Contains(parameters.SearchTerm.ToLower()) || c.Year.Contains(parameters.SearchTerm)).Take(20).ToList();
            }

            return results;
        }
    }
}
