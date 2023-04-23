using AutoMapper;
using Pacagroup.Ecommerce.Application.DTO;
using Pacagroup.Ecommerce.Application.Interface;
using Pacagroup.Ecommerce.Domain.Interface;
using Pacagroup.Ecommerce.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pacagroup.Ecommerce.Application.Main
{
    public class CategoriesApplication : ICategoriesApplication
    {
        private readonly ICategoriesDomain _categoriesDomain;
        private readonly IMapper _mapper;

        public CategoriesApplication(ICategoriesDomain categoriesDomain, IMapper mapper)
        {
            _categoriesDomain = categoriesDomain;
            _mapper = mapper;
        }

        public async Task<Response<IEnumerable<CategoriesDTO>>> GetAll()
        {
            var response = new Response <IEnumerable<CategoriesDTO>>();

            try 
            {
                var categories = await _categoriesDomain.GetAll();
                response.Data = _mapper.Map<IEnumerable<CategoriesDTO>>(categories);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta Exitosa!!!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }
    }
}
