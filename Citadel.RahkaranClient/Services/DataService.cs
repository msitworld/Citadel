using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Citadel.RahkaranClient.Dtos;
using Citadel.RahkaranClient.Models.Data;

namespace Citadel.RahkaranClient.Services
{
    public static class DataService
    {
        public static async Task<T> Fetch<T>(this RahkaranService service, FetchModel fetchModel)
        {
            var url = "/Framework/Services/DataService.svc/Fetch";

            return await service.HttpRequestService.SendAsync<T>(url, HttpMethod.Post, fetchModel);
        }

        public static async Task<InventoryVoucherItemsForBatchOperationResult[]> FetchInventoryVoucherItems(this RahkaranService service, FetchInventoryVoucherItemsDto inventoryVoucherItemsDto)
        {
            var jsonSerializerSettings = new JsonSerializerSettings()
            {
                TypeNameHandling = TypeNameHandling.None
            };

            var fetchModel = new FetchModel
            {
                PageIndex = inventoryVoucherItemsDto.PageIndex,
                PageSize = inventoryVoucherItemsDto.PageSize,
                SearchText = inventoryVoucherItemsDto.SearchText,
                Sorts = inventoryVoucherItemsDto.Sorts,
                Filters = inventoryVoucherItemsDto.Filters,
                ComponentName = "SystemGroup.Logistics.VoucherProcessing",
                EntityName = "InventoryVoucherItem",
                ViewName = "InventoryVoucherItemsForBatchOperation",
                Parameters = new[]
                    {
                        new Parameter()
                        {
                            Name = "inventoryVoucherSpecificationRef",
                            SerializedValue = JsonConvert.SerializeObject(null, jsonSerializerSettings)
                        },
                        new Parameter()
                        {
                            Name = "categories",
                            SerializedValue = JsonConvert.SerializeObject(null, jsonSerializerSettings)
                        },
                        new Parameter()
                        {
                            Name = "startDate",
                            SerializedValue = JsonConvert.SerializeObject(inventoryVoucherItemsDto.StartDate, jsonSerializerSettings)
                        },
                        new Parameter()
                        {
                            Name = "finishDate",
                            SerializedValue = JsonConvert.SerializeObject(inventoryVoucherItemsDto.FinishDate, jsonSerializerSettings)
                        },
                        new Parameter()
                        {
                            Name = "storeRef",
                            SerializedValue = JsonConvert.SerializeObject(inventoryVoucherItemsDto.StoreRef, jsonSerializerSettings)
                        },
                        new Parameter()
                        {
                            Name = "partCategoryRef",
                            SerializedValue = JsonConvert.SerializeObject(null, jsonSerializerSettings)
                        },
                        new Parameter()
                        {
                            Name = "partRef",
                            SerializedValue = JsonConvert.SerializeObject(null, jsonSerializerSettings)
                        },
                        new Parameter()
                        {
                            Name = "partGroupRef",
                            SerializedValue = JsonConvert.SerializeObject(null, jsonSerializerSettings)
                        },
                        new Parameter()
                        {
                            Name = "counterpart4EntityCode",
                            SerializedValue = JsonConvert.SerializeObject(null, jsonSerializerSettings)
                        },
                        new Parameter()
                        {
                            Name = "counterpart4EntityRef",
                            SerializedValue = JsonConvert.SerializeObject(null, jsonSerializerSettings)
                        },
                        new Parameter()
                        {
                            Name = "branchRef",
                            SerializedValue = JsonConvert.SerializeObject(null, jsonSerializerSettings)
                        },
                        new Parameter()
                        {
                            Name = "voucherState",
                            SerializedValue = JsonConvert.SerializeObject(inventoryVoucherItemsDto.VoucherState, jsonSerializerSettings)
                        },
                        new Parameter()
                        {
                            Name = "pricingState",
                            SerializedValue = JsonConvert.SerializeObject(inventoryVoucherItemsDto.PricingState, jsonSerializerSettings)
                        },
                        new Parameter()
                        {
                            Name = "slResolvingState",
                            SerializedValue = JsonConvert.SerializeObject(inventoryVoucherItemsDto.SlResolvingState, jsonSerializerSettings)
                        },
                        new Parameter()
                        {
                            Name = "accountingState",
                            SerializedValue = JsonConvert.SerializeObject(inventoryVoucherItemsDto.AccountingState, jsonSerializerSettings)
                        },
                        new Parameter()
                        {
                            Name = "inventoryVoucherDirection",
                            SerializedValue = JsonConvert.SerializeObject(inventoryVoucherItemsDto.InventoryVoucherDirection, jsonSerializerSettings)
                        },
                        new Parameter()
                        {
                            Name = "dateTypeFilter",
                            SerializedValue = JsonConvert.SerializeObject(inventoryVoucherItemsDto.DateTypeFilter, jsonSerializerSettings)
                        }
                    }
            };

            return await Fetch<InventoryVoucherItemsForBatchOperationResult[]>(service, fetchModel);
        }
    }
}
