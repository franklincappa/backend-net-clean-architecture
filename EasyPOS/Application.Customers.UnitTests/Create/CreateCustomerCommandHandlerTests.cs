using Application.Customers.Create;
using Domain.Customers;
using Domain.Primitives;

namespace Application.Customers.UnitTests.Create
{
    public class CreateCustomerCommandHandlerTests
    {
        private readonly Mock<ICustomerRepository> _mockCustomerRepository;
        private readonly Mock<IUnitOfWork> _mockUnitOfWork;
        private readonly CreateCustomerCommandHandler _handler;

        public CreateCustomerCommandHandlerTests() 
        {
            _mockCustomerRepository = new Mock<ICustomerRepository>();
            _mockUnitOfWork = new Mock<IUnitOfWork>();
            _handler = new CreateCustomerCommandHandler(_mockCustomerRepository.Object, _mockUnitOfWork.Object);
        }

        //Que vamos a probar
        //El escenario
        //Que retornara
        [Fact]
        public void HandleCreateCustomer_WhenPhoneNumberHasBadFormat_ShouldReturnValidationError()
        {

        }
    }
}