using AutoMapper;
using FluentValidation;
using Moq;
using MySales.Application.Contracts.Repositories;
using MySales.Application.UseCases;
using MySales.Application.Validators;
using MySales.Model.DTOs.Client;
using MySales.Model.Entities;
using Xunit;
using Xunit.Abstractions;

namespace MySales.UseCase.Tests;

public class CustomerCrudUseCaseTests
{
    private readonly IValidator<InputCustomerDto> _validator;
    private readonly Mock<IRepository<Customer>> _mockCustomerRepository;
    private readonly Mock<IMapper> _mockMapper;
    private readonly ITestOutputHelper _testOutput;

    public CustomerCrudUseCaseTests(ITestOutputHelper testOutput)
    {
        _validator = new CustomerValidation();
        _mockCustomerRepository = new Mock<IRepository<Customer>>();
        _mockMapper = new Mock<IMapper>();
        _testOutput = testOutput;
    }

    [Theory]
    [InlineData("tamir", "17996521180")]
    [InlineData("Tamiriam", "17996521180")]
    [InlineData("Nome com 250 caracteresteTesteTesteTesteTesteTesteTesteTesteTesteTesteTesteTesteTesteTesteTesteTesteTesteTesteTesteTesteTesteTesteTesteTesteTesteTesteTesteTesteTesteTesteTesteTesteTesteTesteTesteTesteTesteTesteTesteTesteTesteTesteTesteTesteTesteTeste", "17996521880")]
    public async Task Validate_NewCustomer_For_ValidAsync(string name, string phone)
    {
        var inputClientDto = new InputCustomerDto(name, phone);

        _mockMapper.Setup(mapper => mapper.Map<Customer>(It.IsAny<InputCustomerDto>())).Returns(new Customer());

        _mockCustomerRepository.Setup(repo => repo.Add(It.IsAny<Customer>()));

        var clientService = new CustomerCrudUseCase(_mockMapper.Object, _mockCustomerRepository.Object, _validator);

        bool success = true;

        // Act
        try
        {
            var result = await clientService.CreateAsync(inputClientDto);
        }
        catch
        {
            success = false;
        }

        // Assert
        Assert.True(success);
        _mockCustomerRepository.Verify(repo => repo.SaveChangesAsync(), Times.Once);
    }

    [Theory]
    [InlineData("", "")]
    [InlineData("Tami", "")]
    [InlineData("Tamiriam", "")]
    [InlineData("Nome com 251 caracteresteTesteTesteTesteTesteTesteTesteTesteTesteTesteTesteTesteTesteTesteTesteTesteTesteTesteTesteTesteTesteTesteTesteTesteTesteTesteTesteTesteTesteTesteTesteTesteTesteTesteTesteTesteTesteTesteTesteTesteTesteTesteTesteTesteTesteTestet", "17996521880")]
    [InlineData("", "17996521880")]
    public async Task Validate_NewCustomer_Erros_For_ValidAsync(string name, string phone)
    {
        var inputClientDto = new InputCustomerDto(name, phone);

        var clientService = new CustomerCrudUseCase(_mockMapper.Object, _mockCustomerRepository.Object, _validator);

        bool success = false;

        // Act
        try
        {
            var result = await clientService.CreateAsync(inputClientDto);
        }
        catch (Exception e)
        {
            if(e is ValidationException validationException)
            {
                success = validationException.Errors.Any();
                if (!success) _testOutput.WriteLine(validationException.Errors?.FirstOrDefault()?.ToString());
            }
        }

        // Assert
        Assert.True(success);
    }
}
