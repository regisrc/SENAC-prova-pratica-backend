using ProvaPratica.Domain.Entities;
using Xunit;

namespace ProvaPratica.Tests.UnitTests.Domain
{
    public class PersonTest
    {
        [Fact]
        public void Create_Object_Should_Return_Person()
        {
            var firstName = "Regis";
            var age = 21;
            var email = "regis@gmail.com";
            var experienceYears = 5;

            var person = new Person(firstName, age, email, experienceYears);

            Assert.Equal(firstName, person.FirstName);
            Assert.Equal(age, person.Age);
            Assert.Equal(email, person.Email);
            Assert.Equal(experienceYears, person.ExperienceYears);
        }

        [Fact]
        public void Create_Object_Should_Return_Person_With_Strings_Null()
        {
            string? firstName = null;
            var age = 21;
            string? email = null;
            var experienceYears = 5;

            var person = new Person(firstName, age, email, experienceYears);

            Assert.Equal("", person.FirstName);
            Assert.Equal(age, person.Age);
            Assert.Equal("", person.Email);
            Assert.Equal(experienceYears, person.ExperienceYears);
        }

        [Fact]
        public void Update_Object_Should_Update_Values()
        {
            var wasFirstName = "Filipe";
            var wasAge = 20;
            var wasEmail = "filipe@gmail.com";
            var wasExperienceYears = 10;

            var shouldBeFirstName = "Regis";
            var shouldBeAge = 21;
            var shouldBeEmail = "regis@gmail.com";
            var shouldBeExperienceYears = 3;

            var person = new Person(wasFirstName, wasAge, wasEmail, wasExperienceYears);

            Assert.Equal(wasFirstName, person.FirstName);
            Assert.Equal(wasAge, person.Age);
            Assert.Equal(wasEmail, person.Email);
            Assert.Equal(wasExperienceYears, person.ExperienceYears);

            person.UpdateFirstName(shouldBeFirstName);
            person.UpdateAge(shouldBeAge);
            person.UpdateEmail(shouldBeEmail);
            person.UpdateExperienceYears(shouldBeExperienceYears);

            Assert.NotEqual(wasFirstName, person.FirstName);
            Assert.NotEqual(wasAge, person.Age);
            Assert.NotEqual(wasEmail, person.Email);
            Assert.NotEqual(wasExperienceYears, person.ExperienceYears);

            Assert.Equal(shouldBeFirstName, person.FirstName);
            Assert.Equal(shouldBeAge, person.Age);
            Assert.Equal(shouldBeEmail, person.Email);
            Assert.Equal(shouldBeExperienceYears, person.ExperienceYears);
        }
    }
}
