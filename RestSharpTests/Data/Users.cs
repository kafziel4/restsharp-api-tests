using RestSharpTests.Models;
using System.Collections.Generic;

namespace RestSharpTests.Data
{
    static internal class Users
    {
        static private readonly List<UserData> _data = new()
        {
            new UserData { Id = 7, Email = "michael.lawson@reqres.in", FirstName = "Michael", LastName = "Lawson", Avatar = "https://reqres.in/img/faces/7-image.jpg" },
            new UserData { Id = 8, Email = "lindsay.ferguson@reqres.in", FirstName = "Lindsay", LastName = "Ferguson", Avatar = "https://reqres.in/img/faces/8-image.jpg" },
            new UserData { Id = 9, Email = "tobias.funke@reqres.in", FirstName = "Tobias", LastName = "Funke", Avatar = "https://reqres.in/img/faces/9-image.jpg" },
            new UserData { Id = 10, Email = "byron.fields@reqres.in", FirstName = "Byron", LastName = "Fields", Avatar = "https://reqres.in/img/faces/10-image.jpg" },
            new UserData { Id = 11, Email = "george.edwards@reqres.in", FirstName = "George", LastName = "Edwards", Avatar = "https://reqres.in/img/faces/11-image.jpg" },
            new UserData { Id = 12, Email = "rachel.howell@reqres.in", FirstName = "Rachel", LastName = "Howell", Avatar = "https://reqres.in/img/faces/12-image.jpg" },
        };

        static public List<UserData> GetUsers()
        {
            return _data;
        }
    }
}
