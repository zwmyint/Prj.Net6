using AutoMapper;
using Prj.Net6.Core.Entities;
using Prj.Net6.Core.Interfaces;
using Prj.Net6.Infrastructure.Repositories;
using Prj.Net6.Service.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prj.Net6.Service.Services
{
    public class PersonService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PersonService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<PersonDTO>> GetAllPersonsAsync()
        {
            var persons = await _unitOfWork.Persons.GetAll();

            List<PersonDTO> personListDTO = new List<PersonDTO>();

            foreach (var item in persons)
            {
                personListDTO.Add(new PersonDTO
                {
                    PersonId = item.PersonId,
                    Name = item.Name,
                    Age = item.Age
                });
            }

            return personListDTO;
        }

        public async Task<IEnumerable<PersonDTO>> GetAdultPersons()
        {
            var persons = await _unitOfWork.Persons.GetAdultPersonsAsync();

            List<PersonDTO> personListDTO = new List<PersonDTO>();

            foreach (var item in persons)
            {
                personListDTO.Add(new PersonDTO
                {
                    PersonId = item.PersonId,
                    Name = item.Name,
                    Age = item.Age
                });
            }

            return personListDTO;
        }


        //
    }
}
