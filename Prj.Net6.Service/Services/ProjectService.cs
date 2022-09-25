﻿using AutoMapper;
using Prj.Net6.Core.Entities;
using Prj.Net6.Core.Interfaces;
using Prj.Net6.Service.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj.Net6.Service.Services
{
    public class ProjectService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProjectService(
            IUnitOfWork unitOfWork,
            IMapper mapper
            )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ProjectDTO>> GetProjectAsync()
        {
            var projects = await _unitOfWork.Projects.GetAll();

            return _mapper.Map<IEnumerable<ProjectDTO>>(projects);
        }

        public async Task<bool> InsertAsync(ProjectDTO projectDTO)
        {
            var project = _mapper.Map<Project>(projectDTO);
            return await _unitOfWork.Projects.Add(project);
        }

        public async Task<int> CompletedAsync()
        {
            return await _unitOfWork.CompletedAsync();
        }


    }
}
