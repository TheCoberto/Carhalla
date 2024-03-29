using GuildCars.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using GuildCars.Models.Tables;
using System.Runtime.InteropServices;

namespace GuildCars.Data.Repositories.Mock
{
    public class MakeRepositoryMock : IMakeRepository
    {
        private static List<Make> _makes = new List<Make>();

        private static Make Toyota = new Make
        {
            MakeId = 1,
            MakeName = "Toyota",
            DateAdded = new DateTime(2017, 7, 19),
            AddedBy = "admin3@test.com"
        };

        private static Make Acura = new Make
        {
            MakeId = 2,
            MakeName = "Acura",
            DateAdded = new DateTime(2017, 7, 2),
            AddedBy = "admin3@test.com"

        };

        private static Make Ford = new Make
        {
            MakeId = 3,
            MakeName = "Ford",
            DateAdded = new DateTime(2015, 6, 2),
            AddedBy = "admin3@test.com"

        };

        private static Make Dodge = new Make
        {
            MakeId = 4,
            MakeName = "Dodge",
            DateAdded = new DateTime(2009, 5, 1),
            AddedBy = "admin3@test.com"

        };

        private static Make Subaru = new Make
        {
            MakeId = 5,
            MakeName = "Subaru",
            DateAdded = new DateTime(2009, 5, 1),
            AddedBy = "admin3@test.com"

        };

        public MakeRepositoryMock()
        {
            if (_makes.Count() == 0)
            {
                _makes.Add(Toyota);
                _makes.Add(Acura);
                _makes.Add(Ford);
                _makes.Add(Dodge);
                _makes.Add(Subaru);
            }
        }

        public void ClearMakesList()
        {
            _makes.Clear();
        }

        public IEnumerable<Make> GetAll()
        {
            return _makes;
        }

        public Make GetMakeById(int MakeId)
        {
            return _makes.FirstOrDefault(m => m.MakeId == MakeId);
        }

        public void Insert(Make make)
        {
            make.MakeId = _makes.Max(m => make.MakeId) + 1;

            _makes.Add(make);
        }
    }
}
