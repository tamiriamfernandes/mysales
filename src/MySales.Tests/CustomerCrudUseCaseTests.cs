using AutoMapper;
using Moq;
using MySales.Application.Contracts.Repositories;
using MySales.Application.UseCases;
using MySales.Model.DTOs.Client;
using MySales.Model.Entities;
using Xunit;

namespace MySales.UseCase.Tests;

public class CustomerCrudUseCaseTests
{
    private readonly Mock<IRepository<Customer>> mockCustomerRepository = new Mock<IRepository<Customer>>();
    private readonly Mock<IMapper> mockMapper = new Mock<IMapper>();

    [Fact]
    public async Task CreateAsync_NewCustomer_ReturnCustomerId()
    {
        // Arrange
        var createClientDto = new CreateCustomerDto("Tamiriam", "17996521880"); //TODO usar um automock

        var expectedClientId = 1;

        mockMapper.Setup(mapper => mapper.Map<Customer>(It.IsAny<CreateCustomerDto>()))
                 .Returns(new Customer());

        mockCustomerRepository.Setup(repo => repo.Add(It.IsAny<Customer>()))
                            .Callback<Customer>(customer => customer.Id = expectedClientId);

        var clientService = new CustomerCrudUseCase(mockMapper.Object, mockCustomerRepository.Object);

        // Act
        var result = await clientService.CreateAsync(createClientDto);

        // Assert
        Assert.Equal(expectedClientId, result);

        mockCustomerRepository.Verify(repo => repo.SaveChangesAsync(), Times.Once);
    }
}
