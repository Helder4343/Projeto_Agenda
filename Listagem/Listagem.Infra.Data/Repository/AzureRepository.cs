﻿using Listagem.Domain.Core.Models;
using Listagem.Domain.Interfaces;
using Listagem.Models;
using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Listagem.Repository
{
    public class AzureRepository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        private IMobileServiceClient Client;
        private IMobileServiceTable<TEntity> Table;

        public AzureRepository()
        {
            string MyAppServiceURL = "https://apppucminas2018.azurewebsites.net/";
            Client = new MobileServiceClient(MyAppServiceURL);
            Table = Client.GetTable<TEntity>();
        }

        public async Task<IEnumerable<TEntity>> RetonarAll()
        {
            var empty = new TEntity[0];
            try
            {
                return await Table.ToEnumerableAsync();
            }
            catch (Exception)
            {
                return empty;
            }
        }

        public async Task Insert(TEntity tEntity)
        {
            await Table.InsertAsync(tEntity);
        }

        public async Task Update(TEntity tEntity)
        {
            await Table.UpdateAsync(tEntity);
        }

        public async Task Delete(TEntity tEntity)
        {
            await Table.DeleteAsync(tEntity);
        }

        public async Task<TEntity> Find(string id)
        {
            var itens = await Table.Where(i => i.Id == id).ToListAsync();
            return (itens.Count > 0) ? itens[0] : null;
        }

        public async Task<TEntity> GetFirst()
        {
            var itens = await Table.ToListAsync();
            return (itens.Count > 0) ? itens[0] : null;
        }
    }
}
