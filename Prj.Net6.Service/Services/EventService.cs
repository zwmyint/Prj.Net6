using AutoMapper;
using Prj.Net6.Core.Entities;
using Prj.Net6.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj.Net6.Service.Services
{
    public class EventService
    {
        private readonly EventRepository _repository;
        private readonly IMapper _mapper;

        public EventService(EventRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Event>> GetAllAsync()
        {
            return await _repository.GetAll();
        }

        public async Task<Event> GetById(Guid id)
        {
            return await _repository.GetById(id);
        }

        public async Task<bool> Delete(Guid id)
        {
            return await _repository.Remove(id);
        }

        public async Task<bool> Update(Event entity)
        {
            return await _repository.Update(entity);
        }

    }

}
