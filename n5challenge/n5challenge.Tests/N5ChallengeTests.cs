using FluentAssertions;
using Moq;
using n5challenge.Handlers.Commands;
using n5challenge.Handlers.Queries;
using n5challenge.Infraestructure.UnitOfWork.Interface;
using n5challenge.Infraestructure.UnitOfWork.Repositories.Interface;

namespace n5challenge.Tests
{
    public class N5ChallengeTests
    {
        private Mock<IUnitOfWork> _unitOfWorkMock;
        private Mock<IRepository> _repositoryMock;

        public N5ChallengeTests() { }



        [Fact]
        public async Task CreatePermission()
        {
            var requestPermission = new RequestPermissionsCommand()
            {
                EmployeeForename = "Juan",
                EmployeeSurname = "Perez",
                PermissionType = 1
            };

            var handler = new RequestPermissionsCommandHandler(_unitOfWorkMock.Object);
            Func<Task> action = async() => await handler.Handle(requestPermission, new CancellationToken());

            action.Should().NotBeNull();
        }

        [Fact]
        public async Task ModifyPermission()
        {
            var modifyPermission = new ModifyPermissionsCommand()
            {
                Id = 1,
                EmployeeForename = "Juan",
                EmployeeSurname = "Perez",
                PermissionType = 1
            };

            var handler = new ModifyPermissionsCommandHandler(_unitOfWorkMock.Object);
            Func<Task> action = async () => await handler.Handle(modifyPermission, new CancellationToken());

            action.Should().NotBeNull();
        }

        [Fact]
        public async Task GetPermissions()
        {
            var query = new GetPermissionsQuery();

            var handler = new GetPermissionsQueryHandler(_unitOfWorkMock.Object);
            Func<Task> action = async () => await handler.Handle(query, new CancellationToken());

            action.Should().NotBeNull();
        }
    }
}