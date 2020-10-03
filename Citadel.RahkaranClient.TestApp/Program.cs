using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Citadel.RahkaranClient.Dtos;
using Citadel.RahkaranClient.Models.Authentication;
using Citadel.RahkaranClient.Models.Data;
using Citadel.RahkaranClient.Models.Voucher;
using Citadel.RahkaranClient.Models.VoucherProcessing;
using Citadel.RahkaranClient.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Citadel.RahkaranClient.TestApp
{
    class Program
    {
        private static async Task Main()
        {
            var services = new ServiceCollection();

            services.AddRahkaranClient(new Configuration
            {
                BaseAddress = "http://{SERVER_ADDRESS}",
                SgName = "{SG_NAME}",
                UserName = "{USERNAME}",
                Password = "{PASSWORD}"
            });

            var provider = services.BuildServiceProvider();

            var x = provider.GetService<RahkaranService>();

            var InventoryVoucherItems = await x.FetchInventoryVoucherItems(new FetchInventoryVoucherItemsDto
            {
                PageIndex = 0,
                PageSize = 50,
                StartDate = DateTime.Today.AddDays(-10),
                FinishDate = DateTime.Now,
                Sorts = new[]
                {
                    new Sort()
                    {
                        Ascending = false,
                        Name = "ID"
                    }
                },
                Filters = new[]
                {
                    new Filter
                    {
                        Name = "ID",
                        Operator = FilterOperator.GreaterThan,
                        SerializedValues = new[]{ 
                            JsonConvert.SerializeObject(0, new JsonSerializerSettings{TypeNameHandling = TypeNameHandling.None})}
                    }
                }
            });


            //var vocher = await x.RegisterVoucher(new VocherData()
            //{
            //    BranchRef = 1,
            //    Date = DateTime.Now,
            //    VoucherTypeRef = 4,
            //    VoucherItems = new List<VoucherItemData>
            //     {
            //         new VoucherItemData
            //         {
            //             Description = "شرح سند",
            //             Credit = 1000,
            //             DL4 = "200165",
            //             SLCode = "212003"
            //         },
            //         new VoucherItemData
            //         {
            //             Description = "شرح سند",
            //             Debit = 1000,
            //             DL4 = "200165",
            //             SLCode = "212003"
            //         }
            //     }
            //});

            var validateVocher = await x.ValidateVoucher(new VocherData()
            {
                BranchRef = 1,
                Date = DateTime.Now,
                VoucherTypeRef = 4,
                VoucherItems = new List<VoucherItemData>
                {
                    new VoucherItemData
                    {
                        Description = "شرح سند",
                        Credit = 1000,
                        DL4 = "200165",
                        SLCode = "212003"
                    },
                    new VoucherItemData
                    {
                        Description = "شرح سند",
                        Debit = 1000,
                        DL4 = "200165",
                        SLCode = "212003"
                    }
                }
            });

            var part = await x.GetPartByCode(2222222);

            //var vv = await x.RegisterInventoryVoucher(new InventoryVoucher()
            //{
            //    Date = DateTime.Now,
            //    InventoryVoucherSpecificationId = 69,
            //    StoreId = 10,
            //    Items = new List<InventoryVoucherItem>()
            //    {
            //        new InventoryVoucherItem()
            //        {
            //            PartId = part.Info.Id,
            //            Quantity = 1,
            //            UnitId = part.MajorUnitID
            //        }
            //    }
            //});
        }
    }
}
