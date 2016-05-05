﻿using Api.Ai.ApplicationService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Api.Ai.Domain.DataTransferObject;
using Api.Ai.Domain.DataTransferObject.Response;
using Api.Ai.Domain.Service.Factories;
using Api.Ai.Infrastructure.Json;
using Api.Ai.Domain.DataTransferObject.Extensions;
using Api.Ai.Domain.Enum;

namespace Api.Ai.ApplicationService
{
    public class EntitiesAppService : ApiAiAppService, IEntitiesAppService
    {
        #region Contructor

        public EntitiesAppService(IServiceProvider serviceProvider, IHttpClientFactory httpClientFactory)
                : base(serviceProvider, httpClientFactory)
        {
        }

        #endregion

        #region IEntitiesAppService Members

        public async Task<EntitiesResponse> GetAllAsync()
        {
            using (var httpClient = HttpClientFactory.Create(AccessToken))
            {
                var httpResponseMessage = await httpClient.GetAsync(new Uri($"{BaseUrl}/entities"));

                if (httpResponseMessage != null)
                {
                    var content = await httpResponseMessage.ToStringContentAsync();
                    return ApiAiJson<EntitiesResponse>.Deserialize(content);
                }
                else
                {
                    throw new Exception("Unexpected error EntitiesAppService - Method: GetAllAsync - httpResponseMessage is null.");
                }
            }
        }

        public async Task<Entity> GetByIdAsync(string id)
        {
            using (var httpClient = HttpClientFactory.Create(AccessToken))
            {
                var httpResponseMessage = await httpClient.GetAsync(new Uri($"{BaseUrl}/entities/{id}?v={ApiAiVersion.Default.ToString()}"));

                if (httpResponseMessage != null)
                {
                    var content = await httpResponseMessage.ToStringContentAsync();
                    return ApiAiJson<Entity>.Deserialize(content);
                }
                else
                {
                    throw new Exception("Unexpected error EntitiesAppService - Method: GetByIdAsync - httpResponseMessage is null.");
                }
            }
        }
        
        public Task<Entity> CreateAsync(Entity entity)
        {
            throw new NotImplementedException();
        }

        public Task AddEntriesSpecifiedEntityAsync(string id, List<Entry> entries)
        {
            throw new NotImplementedException();
        }

        public Task CreateUpdateAsync(List<Entity> eintities)
        {
            throw new NotImplementedException();
        }

        public Task DeleteASync(string id)
        {
            throw new NotImplementedException();
        }
        
        public Task UpdateASync(string id)
        {
            throw new NotImplementedException();
        }

        public Task UpdatesEntityEntriesAsync(List<Entry> entries)
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}