using Microsoft.EntityFrameworkCore;
using ProvaPratica.API.Controllers;
using ProvaPratica.Application.Dtos;
using ProvaPratica.Application.Services;
using ProvaPratica.Infrastructure.Context;
using ProvaPratica.Infrastructure.Repositories;
using System.Reflection;
using Xunit;

namespace ProvaPratica.Tests.IntegrationTests
{
    public class PersonIntregationTest
    {
        internal DbContextOptionsBuilder<ProvaPraticaContext> InitOptionsBuilder()
        {
            DbContextOptionsBuilder<ProvaPraticaContext> optionsBuilder = new();
            optionsBuilder.UseInMemoryDatabase(MethodBase.GetCurrentMethod().Name);

            return optionsBuilder;
        }

        [Fact]
        public async Task PersonController_Post_And_List_Persons_From_Db()
        {
            using ProvaPraticaContext ctx = new(InitOptionsBuilder().Options);

            await ctx.Database.EnsureDeletedAsync();

            var repository = new PersonRepository(ctx);

            var service = new PersonService(repository);

            var controller = new PersonController(service);

            var personDtoList = new List<PersonDto>
            {
                new PersonDto
                {
                    FirstName = "Regis",
                    Age = 21,
                    Email = "regis@gmail.com",
                    ExperienceYears = 3
                },
                new PersonDto
                {
                    FirstName = "Regis2",
                    Age = 22,
                    Email = "regis2@gmail.com",
                    ExperienceYears = 4
                },
                new PersonDto
                {
                    FirstName = "Regis3",
                    Age = 23,
                    Email = "regis3@gmail.com",
                    ExperienceYears = 5
                }
            };

            personDtoList.ForEach(async x => await controller.Post(x));

            var result = await controller.GetActive();

            Assert.NotNull(result);
            Assert.Equal(personDtoList.Count, result.Count);

            Assert.Equal(personDtoList[0].FirstName, result[0].FirstName);
            Assert.Equal(personDtoList[0].Age, result[0].Age);
            Assert.Equal(personDtoList[0].Email, result[0].Email);
            Assert.Equal(personDtoList[0].ExperienceYears, result[0].ExperienceYears);

            Assert.Equal(personDtoList[1].FirstName, result[1].FirstName);
            Assert.Equal(personDtoList[1].Age, result[1].Age);
            Assert.Equal(personDtoList[1].Email, result[1].Email);
            Assert.Equal(personDtoList[1].ExperienceYears, result[1].ExperienceYears);

            Assert.Equal(personDtoList[2].FirstName, result[2].FirstName);
            Assert.Equal(personDtoList[2].Age, result[2].Age);
            Assert.Equal(personDtoList[2].Email, result[2].Email);
            Assert.Equal(personDtoList[2].ExperienceYears, result[2].ExperienceYears);
        }

        [Fact]
        public async Task PersonController_Post_And_Put_And_List_Persons()
        {
            using ProvaPraticaContext ctx = new(InitOptionsBuilder().Options);

            await ctx.Database.EnsureDeletedAsync();

            var repository = new PersonRepository(ctx);

            var service = new PersonService(repository);

            var controller = new PersonController(service);

            var wasPersonDto = new PersonDto
            {
                FirstName = "Regis",
                Age = 21,
                Email = "regis@gmail.com",
                ExperienceYears = 3
            };

            await controller.Post(wasPersonDto);

            var wasResult = await controller.GetActive();

            Assert.NotNull(wasResult);
            Assert.Single(wasResult);

            var wasSingleValue = wasResult[0];

            Assert.Equal(wasPersonDto.FirstName, wasSingleValue.FirstName);
            Assert.Equal(wasPersonDto.Age, wasSingleValue.Age);
            Assert.Equal(wasPersonDto.Email, wasSingleValue.Email);
            Assert.Equal(wasPersonDto.ExperienceYears, wasSingleValue.ExperienceYears);

            var shouldBePersonDto = new PersonDto
            {
                FirstName = "Filipe",
                Age = 22,
                Email = "filipe@gmail.com",
                ExperienceYears = 4
            };

            await controller.Put(wasSingleValue.Id, shouldBePersonDto);

            var shouldBeResult = await controller.GetActive();

            Assert.NotNull(shouldBeResult);
            Assert.Single(shouldBeResult);

            var shouldBeSingleValue = shouldBeResult[0];

            Assert.NotEqual(wasPersonDto.FirstName, shouldBeSingleValue.FirstName);
            Assert.NotEqual(wasPersonDto.Age, shouldBeSingleValue.Age);
            Assert.NotEqual(wasPersonDto.Email, shouldBeSingleValue.Email);
            Assert.NotEqual(wasPersonDto.ExperienceYears, shouldBeSingleValue.ExperienceYears);

            Assert.Equal(shouldBePersonDto.FirstName, shouldBeSingleValue.FirstName);
            Assert.Equal(shouldBePersonDto.Age, shouldBeSingleValue.Age);
            Assert.Equal(shouldBePersonDto.Email, shouldBeSingleValue.Email);
            Assert.Equal(shouldBePersonDto.ExperienceYears, shouldBeSingleValue.ExperienceYears);
        }

        [Fact]
        public async Task PersonController_Delete_Person()
        {
            using ProvaPraticaContext ctx = new(InitOptionsBuilder().Options);

            await ctx.Database.EnsureDeletedAsync();

            var repository = new PersonRepository(ctx);

            var service = new PersonService(repository);

            var controller = new PersonController(service);

            var personDto = new PersonDto
            {
                FirstName = "Regis",
                Age = 21,
                Email = "regis@gmail.com",
                ExperienceYears = 3
            };

            await controller.Post(personDto);

            var result = await controller.GetActive();

            Assert.NotNull(result);
            Assert.Single(result);

            var singleValue = result[0];

            Assert.Equal(personDto.FirstName, singleValue.FirstName);
            Assert.Equal(personDto.Age, singleValue.Age);
            Assert.Equal(personDto.Email, singleValue.Email);
            Assert.Equal(personDto.ExperienceYears, singleValue.ExperienceYears);

            await controller.Delete(singleValue.Id);

            var deletedResult = await controller.GetActive();

            Assert.NotNull(deletedResult);
            Assert.Empty(deletedResult);

            var desactivatedResult = await controller.Get();

            Assert.NotNull(desactivatedResult);
            Assert.NotEmpty(desactivatedResult);

            var singleDesactivatedValue = desactivatedResult[0];

            Assert.Equal(personDto.FirstName, singleDesactivatedValue.FirstName);
            Assert.Equal(personDto.Age, singleDesactivatedValue.Age);
            Assert.Equal(personDto.Email, singleDesactivatedValue.Email);
            Assert.Equal(personDto.ExperienceYears, singleDesactivatedValue.ExperienceYears);
            Assert.False(singleDesactivatedValue.Active);
        }
    }
}
