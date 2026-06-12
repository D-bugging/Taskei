using AutoMapper;
using Taskei.Application.DTOs;
using Taskei.Domain.Entities;

namespace Taskei.Application.Mappings
{
    public class TaskProfile : Profile
    {
        public TaskProfile()
        {
            CreateMap<CreateTaskDto, TaskItem>();
            CreateMap<UpdateTaskDto, TaskItem>();
        }
    }
}