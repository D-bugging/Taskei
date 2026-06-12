using AutoMapper;
using Taskei.API.DTOs;
using Taskei.API.Entities;

namespace Taskei.API.Mappings
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