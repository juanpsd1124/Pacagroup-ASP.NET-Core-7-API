using System;
using AutoMapper;
using Pacagroup.Ecommerce.Application.DTO;
using Pacagroup.Ecommerce.Domain.Entity;
using Pacagroup.Ecommerce.Transversal.Common;
using System.Threading.Tasks;
using System.Collections.Generic;
using Pacagroup.Ecommerce.Application.Interface.UseCases;
using Pacagroup.Ecommerce.Application.Interface.Persistence;

namespace Pacagroup.Ecommerce.Application.UseCases.Categories
{
    public class CustomersApplication : ICustomersApplication
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IAppLogger<CustomersApplication> _logger;
        public CustomersApplication(IUnitOfWork unitOfWork, IMapper mapper, IAppLogger<CustomersApplication> logger)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _logger = logger;
        }

        #region Métodos Síncronos

        public Response<bool> Insert(CustomerDTO customersDto)
        {
            var response = new Response<bool>();
            try
            {
                var customer = _mapper.Map<Customer>(customersDto);
                response.Data = _unitOfWork.Customers.Insert(customer);
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

        public Response<bool> Update(CustomerDTO customersDto)
        {
            var response = new Response<bool>();
            try
            {
                var customer = _mapper.Map<Customer>(customersDto);
                response.Data = _unitOfWork.Customers.Update(customer);
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

        public Response<bool> Delete(string customerId)
        {
            var response = new Response<bool>();
            try
            {
                response.Data = _unitOfWork.Customers.Delete(customerId);
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

        public Response<CustomerDTO> Get(string customerId)
        {
            var response = new Response<CustomerDTO>();
            try
            {
                var customer = _unitOfWork.Customers.Get(customerId);
                response.Data = _mapper.Map<CustomerDTO>(customer);
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

        public Response<IEnumerable<CustomerDTO>> GetAll()
        {
            var response = new Response<IEnumerable<CustomerDTO>>();
            try
            {
                var customers = _unitOfWork.Customers.GetAll();
                response.Data = _mapper.Map<IEnumerable<CustomerDTO>>(customers);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta Exitosa";
                    _logger.LogInformation("Consulta Exitosa");
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
                _logger.LogError(e.Message);
            }
            return response;
        }

        public ResponsePagination<IEnumerable<CustomerDTO>> GetAllWithPagination(int pageNumber, int pageSize)
        {
            var response = new ResponsePagination<IEnumerable<CustomerDTO>>();
            try
            {
                var count = _unitOfWork.Customers.Count();

                var customers = _unitOfWork.Customers.GetAllWithPagination(pageNumber, pageSize);
                response.Data = _mapper.Map<IEnumerable<CustomerDTO>>(customers);

                if (response.Data != null)
                {
                    response.PageNumber = pageNumber;
                    response.TotalPages = (int)Math.Ceiling(count / (double)pageSize);
                    response.TotalCount = count;
                    response.IsSuccess = true;
                    response.Message = "Consulta Paginada Exitosa!!!";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }

        #endregion

        #region Métodos Asíncronos
        public async Task<Response<bool>> InsertAsync(CustomerDTO customersDto)
        {
            var response = new Response<bool>();
            try
            {
                var customer = _mapper.Map<Customer>(customersDto);
                response.Data = await _unitOfWork.Customers.InsertAsync(customer);
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
        public async Task<Response<bool>> UpdateAsync(CustomerDTO customersDto)
        {
            var response = new Response<bool>();
            try
            {
                var customer = _mapper.Map<Customer>(customersDto);
                response.Data = await _unitOfWork.Customers.UpdateAsync(customer);
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

        public async Task<Response<bool>> DeleteAsync(string customerId)
        {
            var response = new Response<bool>();
            try
            {
                response.Data = await _unitOfWork.Customers.DeleteAsync(customerId);
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

        public async Task<Response<CustomerDTO>> GetAsync(string customerId)
        {
            var response = new Response<CustomerDTO>();
            try
            {
                var customer = await _unitOfWork.Customers.GetAsync(customerId);
                response.Data = _mapper.Map<CustomerDTO>(customer);
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
        public async Task<Response<IEnumerable<CustomerDTO>>> GetAllAsync()
        {
            var response = new Response<IEnumerable<CustomerDTO>>();
            try
            {
                var customers = await _unitOfWork.Customers.GetAllAsync();
                response.Data = _mapper.Map<IEnumerable<CustomerDTO>>(customers);
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
        public async Task<ResponsePagination<IEnumerable<CustomerDTO>>> GetAllWithPaginationAsync(int pageNumber, int pageSize)
        {
            var response = new ResponsePagination<IEnumerable<CustomerDTO>>();
            try
            {
                var count = await _unitOfWork.Customers.CountAsync();

                var customers = await _unitOfWork.Customers.GetAllWithPaginationAsync(pageNumber, pageSize);
                response.Data = _mapper.Map<IEnumerable<CustomerDTO>>(customers);

                if (response.Data != null)
                {
                    response.PageNumber = pageNumber;
                    response.TotalPages = (int)Math.Ceiling(count / (double)pageSize);
                    response.TotalCount = count;
                    response.IsSuccess = true;
                    response.Message = "Consulta Paginada Exitosa!!!";
                }
            }
            catch (Exception ex)
            {
                response.Message = ex.Message;
            }
            return response;
        }
        #endregion
    }
}
