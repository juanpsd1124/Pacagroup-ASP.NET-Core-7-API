using AutoMapper;
using Pacagroup.Ecommerce.Application.DTO;
using Pacagroup.Ecommerce.Application.Interface.Persistence;
using Pacagroup.Ecommerce.Application.Interface.UseCases;
using Pacagroup.Ecommerce.Application.Validator;
using Pacagroup.Ecommerce.Domain.Entities;
using Pacagroup.Ecommerce.Domain.Entities.Descuento;
using Pacagroup.Ecommerce.Transversal.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pacagroup.Ecommerce.Application.UseCases.Discounts
{
    public class DiscountsApplication : IDiscountsApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly DiscountDtoValidator _discountDtoValidator;

        public DiscountsApplication(IUnitOfWork unitOfWork, IMapper mapper, DiscountDtoValidator discountDtoValidator)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _discountDtoValidator = discountDtoValidator;
        }

        public async Task<Response<bool>> Create(DiscountDTO discountDto, CancellationToken cancellationToken = default)
        {
            var response = new Response<bool>();
            try
            {
                var validation = await _discountDtoValidator.ValidateAsync(discountDto, cancellationToken);
                if (!validation.IsValid)
                {
                    response.Message = "Errores de Validación";
                    response.Errors = validation.Errors;
                    return response;
                }
                var discount = _mapper.Map<Discount>(discountDto);
                await _unitOfWork.Discounts.InsertAsync(discount);

                response.Data = await _unitOfWork.Save(cancellationToken) > 0;
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Registro Exitoso!!!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }

            return response;
        }

        public async Task<Response<bool>> Delete(int id, CancellationToken cancellationToken = default)
        {
            var response = new Response<bool>();
            try
            {
                await _unitOfWork.Discounts.DeleteAsync(id.ToString());
                response.Data = await _unitOfWork.Save(cancellationToken) > 0;
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Eliminación Exitosa!!!";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }

        public async Task<Response<DiscountDTO>> Get(int id, CancellationToken cancellationToken = default)
        {
            var response = new Response<DiscountDTO>();
            try
            {
                var discount = await _unitOfWork.Discounts.GetAsync(id, cancellationToken);
                if (discount is null)
                {
                    response.IsSuccess = true;
                    response.Message = "Descuento no existe...";
                    return response;
                }

                response.Data = _mapper.Map<DiscountDTO>(discount);
                response.IsSuccess = true;
                response.Message = "Consulta Exitosa!!!";
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }

        public async Task<Response<List<DiscountDTO>>> GetAll(CancellationToken cancellationToken = default)
        {
            var response = new Response<List<DiscountDTO>>();
            try
            {
                var discounts = await _unitOfWork.Discounts.GetAllAsync(cancellationToken);
                response.Data = _mapper.Map<List<DiscountDTO>>(discounts);
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

        public async Task<Response<bool>> Update(DiscountDTO discountDto, CancellationToken cancellationToken = default)
        {
            var response = new Response<bool>();
            try
            {
                var validation = await _discountDtoValidator.ValidateAsync(discountDto, cancellationToken);
                if (!validation.IsValid)
                {
                    response.Message = "Errores de Validación";
                    response.Errors = validation.Errors;
                    return response;
                }
                var discount = _mapper.Map<Discount>(discountDto);
                await _unitOfWork.Discounts.UpdateAsync(discount);

                response.Data = await _unitOfWork.Save(cancellationToken) > 0;
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Actualización Exitosa!!!";
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
