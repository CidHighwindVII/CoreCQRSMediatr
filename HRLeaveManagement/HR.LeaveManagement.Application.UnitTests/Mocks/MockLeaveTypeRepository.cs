using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Domain;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.UnitTests.Mocks
{
    public static class MockLeaveTypeRepository
    {
        public static Mock<ILeaveTypeRepository> GetLeaveTypeRepository()
        {
            var leaveTypes = new List<LeaveType>
            {
                new LeaveType
                {
                    Id = 1,
                    DefaultDays = 10,
                    Name = "Test Vacation"
                },
                new LeaveType
                {
                    Id = 2,
                    DefaultDays = 15,
                    Name = "Test Sick"
                }
            };

            var mockRepo = new Mock<ILeaveTypeRepository>();

            //// Task<T> GetAsync(int id);
            mockRepo.Setup(r => r.GetAsync(It.IsAny<int>())).ReturnsAsync((int row) => leaveTypes.FirstOrDefault(x => x.Id == row));

            //// Task<IReadOnlyList<T>> GetAllAsync();
            mockRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(leaveTypes);

            //// Task<T> AddAsync(T entity);
            mockRepo.Setup(r => r.AddAsync(It.IsAny<LeaveType>())).ReturnsAsync((LeaveType leaveType) =>
            {
                leaveTypes.Add(leaveType);
                return leaveType;
            });

            //// Task<bool> Exists(int id);
            mockRepo.Setup(r => r.Exists(It.IsAny<int>())).ReturnsAsync((int id) =>
            {
                return leaveTypes.Exists(x => x.Id == id);
            });

            //// Task UpdateAsync(T entity);
            mockRepo.Setup(r => r.UpdateAsync(It.IsAny<LeaveType>())).Returns((LeaveType leaveType) =>
            {                
                return Task.Factory.StartNew(() =>
                {
                    var index = leaveTypes.IndexOf(leaveType);
                    leaveTypes[index] = leaveType;
                }); 
            });

            //// Task DeleteAsync(T entity);
            mockRepo.Setup(r => r.DeleteAsync(It.IsAny<LeaveType>())).Returns((LeaveType leaveType) =>
            {
                return Task.Factory.StartNew(() =>
                {
                    var leaveTypeInList = leaveTypes.First(x => x.Id == leaveType.Id);

                    if(leaveTypeInList != null)
                    {
                        leaveTypes.Remove(leaveTypeInList);
                    }
                });
            });

            return mockRepo;
        }
    }
}
