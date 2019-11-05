using System;
using FluentAssertions;
using Moq;
using Paella.Application.Persistence;
using Paella.Application.UseCases.GetById;
using Paella.Domain.Entities;
using Xunit;

namespace UnitTests
{
    public class CreateUseCaseTests
    {
        [Fact]
        public void ProductsAvailable_ShouldReturnAListOfProducts()
        {
            // Arrange
            var repository = GetProductRepository();
            var sut = new GetByIdUseCase(repository);

            var id = Guid.NewGuid();

            // Act
            var actual = sut.Execute(id);

            // Assert
            actual
                .Should()
                .NotBeNull();

            actual.Name
                .Should()
                .Be("Name");
        }

        //[Fact]
        //public void TheProductDoesNotExist_ShouldReturNull()
        //{
        //    // Arrange
        //    var repository = GetEmptyProductRepository();
        //    var sut = new GetByIdUseCase(repository);

        //    var id = Guid.NewGuid();

        //    // Act
        //    var actual = sut.Execute(id);

        //    // Assert
        //    actual
        //        .Should()
        //        .BeNull();
        //}

        private IProductRepository GetEmptyProductRepository()
        {
            var repository = new Mock<IProductRepository>();

            repository
                .Setup(r => r.GetById(It.IsAny<Guid>()))
                .Returns(null as Product);

            return repository.Object;
        }

        private IProductRepository GetProductRepository()
        {
            var repository = new Mock<IProductRepository>();
            var product = new Product("Name", "Description");

            repository
                .Setup(r => r.GetById(It.IsAny<Guid>()))
                .Returns(product);

            return repository.Object;
        }
    }
}