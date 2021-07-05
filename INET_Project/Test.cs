using INET_Project.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xunit;

namespace INET_Project
{
    public class Test
    {
        public bool IsValidName(string name)
        {
            Regex regex = new Regex(@"/^[a-z ,.'-]+$/i");
            return regex.IsMatch(name);
        }

        [Fact]
        public void ValidName()
        {
            var firstNameValue = HomeController.FirstName;
            var lastNameValue = HomeController.LastName;

            bool isValidFirstName = IsValidName(firstNameValue);
            bool isValidLastNameName = IsValidName(lastNameValue);

            Assert.NotNull(firstNameValue);
            Assert.NotNull(lastNameValue);

            Assert.True(isValidFirstName && isValidLastNameName, "Testowanie formatu imienia i nazwiska");
        }

    }
}
