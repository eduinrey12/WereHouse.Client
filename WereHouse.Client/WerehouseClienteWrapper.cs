using Grpc.Core;
using Grpc.Net.Client;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WereHouse.Server;

namespace WereHouse.Client
{
    internal class WerehouseClienteWrapper
    {
        private readonly Server.WereHouse.WereHouseClient _client;

        public WerehouseClienteWrapper(string address) 
        { 
            var channel =  GrpcChannel.ForAddress(address);
            _client = new Server.WereHouse.WereHouseClient(channel);
        }

        public async Task<Product> GetProductByIdAsync(string id)
        {
            try 
            {
                var grpcCall = _client.GetProducttByIdAsync(new ProductID { Id = id });
                return await CallGrpcServiceAsync(grpcCall);
            }
            catch (RpcException)
            {
                return null;
            }
            catch (Exception) 
            {
                throw;
            }
        }

        public async Task<Product> GetProductByNameAsync(string name)
        {
            try
            {
                var grpcCall = _client.GetProducttByNameAsync(new ProductName { Name = name });
                return await CallGrpcServiceAsync(grpcCall);
            }
            catch (RpcException)
            {
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<string> AddProductAsync(string id, string name, int cantidad)
        {
            try 
            {
                var grpcCall = _client.AddProducttByIdAsync(new Product { Id = id, Name = name, Cantidad = cantidad });
                var response = await CallGrpcServiceAsync(grpcCall);
                return response.Id;
            }
            catch (RpcException)
            {
                return null;
            }
            catch (Exception) 
            {
                throw;
            }
        }

        private async Task<T> CallGrpcServiceAsync<T>(AsyncUnaryCall<T> grpcCall)
        {
            try
            {
                return await grpcCall.ResponseAsync;
            }
            catch (RpcException ex)
            {
                HandleRpcException(ex);
                throw;
            }
        }

        private void HandleRpcException(RpcException ex)
        {
            switch (ex.StatusCode)
            {
                case StatusCode.NotFound:
                    Console.WriteLine($"Error: {ex.Status.Detail}");
                    break;
                case StatusCode.Unavailable:
                    Console.WriteLine("El server esta inactivo. Intenta mas tarde");
                    break;
                default:
                    Console.WriteLine($"Ocurrio un error: {ex.Status.Detail}");
                    break;
            }
        }
    }
}
