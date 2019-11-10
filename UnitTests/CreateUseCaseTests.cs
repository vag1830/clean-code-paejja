using System;
using FluentAssertions;
using Moq;
using Paella.Application.Persistence;
using Paella.Application.UseCases.Create;
using Paella.Application.UseCases.Create.Parameters;
using Paella.Domain.Entities;
using Paella.Domain.Exceptions;
using Paella.Infrastructure;
using Xunit;

namespace UnitTests
{
    public class CreateUseCaseTests
    {
        [Fact]
        public void ProductAlreadyExists_ShouldThrowException()
        {
            // Arrange
            var repository = GetProductRepository();
            var sut = new CreateUseCase(repository);

            var input = new CreateInput { Name = "Name", Description = "Description" };

            // Act
            Action action = () => sut.Execute(input);

            // Assert
            action
                .Should()
                .Throw<ProductAlreadyExistsException>();
        }

        [Fact]
        public void NewProduct_ShouldAddTheProduct()
        {
            // Arrange
            var repository = new InMemoryProductRepository();
            var sut = new CreateUseCase(repository);

            var input = new CreateInput { Name = "Name", Description = "Description" };

            // Act
            Action action = () => sut.Execute(input);

            // Assert
            action
                .Should()
                .NotThrow();
        }

        private IProductRepository GetProductRepository()
        {
            var repository = new Mock<IProductRepository>();
            var product = new Product("Name", "Description");

            repository
                .Setup(r => r.Create(It.IsAny<Product>()))
                .Throws(new ProductAlreadyExistsException());

            return repository.Object;
        }
    }
}