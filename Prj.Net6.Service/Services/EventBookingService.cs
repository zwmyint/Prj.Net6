using AutoMapper;
using Prj.Net6.Core.Entities;
using Prj.Net6.Core.Interfaces;
using Prj.Net6.Service.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj.Net6.Service.Services
{
    public class EventBookingService
    {
        private readonly IEventRepository _eventRepository;
        private readonly IEventBookingRepository _bookingRepository;
        private readonly IMapper _mapper;

        public EventBookingService(IEventRepository eventRepository, IEventBookingRepository bookingRepository, IMapper mapper)
        {
            _eventRepository = eventRepository;
            _bookingRepository = bookingRepository;
            _mapper = mapper;
        }

        public async Task<List<EventBookingViewModel>> GetAllAsync()
        {
            var booking = await _bookingRepository.GetAll();
            return _mapper.Map<List<EventBookingViewModel>>(booking);
        }

        public async Task<bool> AddEventBooking(EventBooking eventBooking)
        {
            return await _bookingRepository.Add(eventBooking);
        }
    }

}
