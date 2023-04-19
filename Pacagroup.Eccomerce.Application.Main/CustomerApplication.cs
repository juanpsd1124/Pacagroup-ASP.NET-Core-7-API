using AutoMapper;
using Pacagroup.Ecommerce.Application.DTO;
using Pacagroup.Ecommerce.Application.Interface;
using Pacagroup.Ecommerce.Domain.Entity;
using Pacagroup.Ecommerce.Domain.Interface;
using Pacagroup.Ecommerce.Transversal.Common;
using System.Threading.Tasks;
using System.Collections.Generic;



namespace Pacagroup.Eccomerce.Application.Main
{
    public class CustomerApplication : ICustomersApplication
    {
        private readonly ICustomersDomain _customersDomain;
        private readonly IMapper _mapper;

        public CustomerApplication(ICustomersDomain customersDomain, IMapper mapper) 
        {
            _customersDomain= customersDomain;
            _mapper= mapper;
        }

        #region Métodos Síncronos
        public Response<bool> Insert(CustomersDTO customersDTO) { 
            
            var response = new Response<bool>();
            try 
            {
                var customer = _mapper.Map<Customers>(customersDTO);
                response.Data = _customersDomain.Insert(customer);
                if (response.Data)
                {
                    response.IsSuccess= true;
                    response.Message = "Registro Exitoso";
                }
            }
            catch (Exception e) 
            {
                response.Message = e.Message;
            }
            return response;
        }

        public Response<bool> Update(CustomersDTO customersDTO)
        {

            var response = new Response<bool>();
            try
            {
                var customer = _mapper.Map<Customers>(customersDTO);
                response.Data = _customersDomain.Update(customer);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Actualización Exitosa";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }
        public Response<bool> Delete(string customerId){

            var response = new Response<bool>();
            try
            {
                response.Data = _customersDomain.Delete(customerId);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Borrado Exitoso";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;

        }
        public Response<CustomersDTO> Get(string customerId){

            var response = new Response<CustomersDTO>();
            try
            {
                var customer = _customersDomain.Get(customerId);
                response.Data = _mapper.Map<CustomersDTO>(customer);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta Exitosa";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;

        }
        public Response<IEnumerable<CustomersDTO>> GetAll(){

            var response = new Response<IEnumerable<CustomersDTO>>();
            try
            {
                var customers = _customersDomain.GetAll();
                response.Data = _mapper.Map<IEnumerable<CustomersDTO>>(customers);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta Exitosa";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;

        }
        #endregion

        #region Métodos Asíncronos

        public async Task<Response<bool>> InsertAsync(CustomersDTO customersDTO)
        {
            
            var response = new Response<bool>();
            try
            {
                var customer = _mapper.Map<Customers>(customersDTO);
                response.Data = await _customersDomain.InsertAsync(customer);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Registro Exitoso";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }
        public async Task<Response<bool>> UpdateAsync(CustomersDTO customersDTO)
        {
            
            var response = new Response<bool>();
            try
            {
                var customer = _mapper.Map<Customers>(customersDTO);
                response.Data = await _customersDomain.UpdateAsync(customer);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Actualización Exitosa";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }
        public async Task<Response<bool>> DeleteAsync(string customerId){

            var response = new Response<bool>();
            try
            {
                response.Data = await _customersDomain.DeleteAsync(customerId);
                if (response.Data)
                {
                    response.IsSuccess = true;
                    response.Message = "Borrado Exitoso";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }
        public async Task<Response<CustomersDTO>> GetAsync(string customerId){

            var response = new Response<CustomersDTO>();
            try
            {
                var customer = await _customersDomain.GetAsync(customerId);
                response.Data = _mapper.Map<CustomersDTO>(customer);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta Exitosa";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }
        public async Task<Response<IEnumerable<CustomersDTO>>> GetAllAsync(){

            var response = new Response<IEnumerable<CustomersDTO>>();
            try
            {
                var customers = await _customersDomain.GetAllAsync();
                response.Data = _mapper.Map<IEnumerable<CustomersDTO>>(customers);
                if (response.Data != null)
                {
                    response.IsSuccess = true;
                    response.Message = "Consulta Exitosa";
                }
            }
            catch (Exception e)
            {
                response.Message = e.Message;
            }
            return response;
        }
        #endregion


    }
}