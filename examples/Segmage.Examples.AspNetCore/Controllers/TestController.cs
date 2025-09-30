using Microsoft.AspNetCore.Mvc;
using Segmage.Models;
using Segmage.AspNetCore.Extensions;
using System.Text;
using Newtonsoft.Json;
using System.Collections.Generic;
using System;
using System.Threading.Tasks;

namespace Segmage.Examples.AspNetCore.Controllers
{
	public class TestController : Controller
	{
		public TestController() { }

		#region Setup
		[HttpGet]
		public IActionResult SetupCookie()
		{
			var sessionData = new SgSession
			{
				Id = Guid.NewGuid().ToString(),
				UserId = "test-user-123",
				DeviceId = Guid.NewGuid().ToString()
			};
			var sessionJson = JsonConvert.SerializeObject(sessionData);
			var base64EncodedBytes = Encoding.UTF8.GetBytes(sessionJson);
			var cookieValue = Convert.ToBase64String(base64EncodedBytes);
			Response.Cookies.Append("__sg", cookieValue, new CookieOptions { HttpOnly = false, Expires = DateTime.Now.AddHours(10) });
			return Ok(new { message = "Cookie has been set.", cookieData = sessionData });
		}

		[HttpGet]
		public async Task<IActionResult> ReadSession()
		{
			var session = await SegmageHttpContext.GetSgSession();
			if (session == null)
			{
				return NotFound("Segmage session not found. Please run /Test/SetupCookie first.");
			}
			return Ok(session);
		}
		#endregion

		#region DataSender Tests

		#region Customer360
		[HttpPost]
		public async Task<IActionResult> TestSaveCustomer360()
		{
			var customer = new Customer360
			{
				Id = "CUST-001",
				FullName = "İlter Yıldız",
				ProfileUrl = "https://example.com/profiles/ilter.yildiz",
				ProfileImageUrl = "https://example.com/images/ilter.jpg",
				Email = "ilter.yildiz@example.com",
				Phone = "2121234567",
				MobilePhone = "5551234567",
				DateOfBirth = new DateTime(1990, 5, 23),
				Gender = "Male",
				Province = "İstanbul",
				District = "Kadıköy",
				Country = "Turkey",
				Neighbourhood = "Caferağa",
				TaxNumber = "12345678901",
				TaxOffice = "Kadıköy V.D.",
				IsEmailGranted = true,
				IsCallGranted = true,
				IsSmsGranted = false,
				IsWebPushGranted = true,
				IsMobilePushGranted = false
			};
			return Ok(await SegmageApp.DefaultInstance.DataSender.SaveCustomer360(customer));
		}
		[HttpPost]
		public async Task<IActionResult> TestSaveBatchCustomer360()
		{
			var customers = new List<Customer360>
			{
				new Customer360
				{
					Id = "CUST-002",
					FullName = "Ayşe Yılmaz",
					ProfileUrl = "https://example.com/profiles/ayse.yilmaz",
					ProfileImageUrl = "https://example.com/images/ayse.jpg",
					Email = "ayse.yilmaz@example.com",
					Phone = "3121112233",
					MobilePhone = "5552223344",
					DateOfBirth = new DateTime(1985, 10, 1),
					Gender = "Female",
					Province = "Ankara",
					District = "Çankaya",
					Country = "Turkey",
					Neighbourhood = "Kızılay",
					TaxNumber = "98765432109",
					TaxOffice = "Çankaya V.D.",
					IsEmailGranted = true,
					IsCallGranted = false,
					IsSmsGranted = true,
					IsWebPushGranted = false,
					IsMobilePushGranted = true
				},
				new Customer360
				{
					Id = "CUST-003",
					FullName = "Mehmet Öztürk",
					ProfileUrl = "https://example.com/profiles/mehmet.ozturk",
					ProfileImageUrl = "https://example.com/images/mehmet.jpg",
					Email = "mehmet.ozturk@example.com",
					Phone = "2324445566",
					MobilePhone = "5553334455",
					DateOfBirth = new DateTime(1992, 2, 15),
					Gender = "Male",
					Province = "İzmir",
					District = "Bornova",
					Country = "Turkey",
					Neighbourhood = "Erzene",
					TaxNumber = "55566677788",
					TaxOffice = "Bornova V.D.",
					IsEmailGranted = false,
					IsCallGranted = true,
					IsSmsGranted = true,
					IsWebPushGranted = true,
					IsMobilePushGranted = true
				}
			};
			return Ok(await SegmageApp.DefaultInstance.DataSender.SaveBatchCustomer360(customers));
		}
		[HttpPut]
		public async Task<IActionResult> TestUpdateCustomer360()
		{
			var customer = new Customer360
			{
				Id = "CUST-001",
				FullName = "İlter Yıldız Updated",
				MobilePhone = "5559876543",
				IsSmsGranted = true
			};
			return Ok(await SegmageApp.DefaultInstance.DataSender.UpdateCustomer360(customer));
		}
		[HttpPut]
		public async Task<IActionResult> TestUpdateBatchCustomer360()
		{
			var customers = new List<Customer360>
			{
				new Customer360
				{
					Id = "CUST-002",
					FullName = "Ayşe Yılmaz Updated",
					IsCallGranted = true
				},
				new Customer360
				{
					Id = "CUST-003",
					FullName = "Mehmet Öztürk Updated",
					IsWebPushGranted = true
				}
			};
			return Ok(await SegmageApp.DefaultInstance.DataSender.UpdateBatchCustomer360(customers));
		}
		[HttpDelete]
		public async Task<IActionResult> TestDeleteCustomer360(string id = "CUST-001")
		{
			return Ok(await SegmageApp.DefaultInstance.DataSender.DeleteCustomer360(id));
		}
		#endregion

		#region Product360
		[HttpPost]
		public async Task<IActionResult> TestSaveProduct()
		{
			var product = new Product360
			{
				Id = "PROD-101",
				Name = "Laptop Pro X1 - 16GB RAM, 512GB SSD",
				ProductCode = "LPX1-16-512",
				Affiliation = "Main Store",
				SKU = "SKU-LPX1-16-512",
				Brand = "TechBrand",
				Variant = "Silver",
				Category = "Elektronik",
				Category2 = "Bilgisayar",
				Category3 = "Dizüstü Bilgisayar",
				Category4 = "Ultrabook",
				Category5 = "",
				Unit = "Adet",
				UnitPrice = 25000.00m,
				ProductUrl = "https://example.com/products/lpx1-16-512",
				VatPercentage = 18.0m
			};
			return Ok(await SegmageApp.DefaultInstance.DataSender.SaveProduct(product));
		}
		[HttpPost]
		public async Task<IActionResult> TestSaveBatchProduct()
		{
			var products = new List<Product360>
			{
				new Product360
				{
					Id = "PROD-102",
					Name = "Smartphone Z",
					ProductCode = "SPZ",
					Affiliation = "Main Store",
					SKU = "SKU-SPZ",
					Brand = "TechBrand",
					Variant = "Black",
					Category = "Elektronik",
					Category2 = "Telefon",
					UnitPrice = 8000m,
					ProductUrl = "https://example.com/products/spz",
					VatPercentage = 18m
				},
				new Product360
				{
					Id = "PROD-103",
					Name = "Wireless Mouse",
					ProductCode = "WM1",
					Affiliation = "Accessories",
					SKU = "SKU-WM1",
					Brand = "AccessoryCo",
					Variant = "White",
					Category = "Bilgisayar Aksesuar",
					UnitPrice = 350m,
					ProductUrl = "https://example.com/products/wm1",
					VatPercentage = 18m
				}
			};
			return Ok(await SegmageApp.DefaultInstance.DataSender.SaveBatchProduct(products));
		}
		[HttpPut]
		public async Task<IActionResult> TestUpdateProduct()
		{
			var product = new Product360
			{
				Id = "PROD-101",
				Name = "Laptop Pro X1 - 16GB RAM",
				UnitPrice = 25500.00m
			};
			return Ok(await SegmageApp.DefaultInstance.DataSender.UpdateProduct(product));
		}
		[HttpPut]
		public async Task<IActionResult> TestUpdateBatchProduct()
		{
			var products = new List<Product360>
			{
				new Product360
				{
					Id = "PROD-102",
					Name = "Smartphone Z Updated",
					UnitPrice = 8200m
				},
				new Product360
				{
					Id = "PROD-103",
					Name = "Wireless Mouse V2",
					UnitPrice = 400m
				}
			};
			return Ok(await SegmageApp.DefaultInstance.DataSender.UpdateBatchProduct(products));
		}
		[HttpDelete]
		public async Task<IActionResult> TestDeleteProduct(string id = "PROD-101")
		{
			return Ok(await SegmageApp.DefaultInstance.DataSender.DeleteProduct(id));
		}
		#endregion

		#region Basket
		[HttpPost]
		public async Task<IActionResult> TestSaveBasket()
		{
			var basket = new Basket
			{
				Id = "BASKET-001",
				UserId = "test-user-123",
				Total = 350m,
				TotalDiscount = 0,
				TotalVat = 63m,
				GrandTotal = 413m,
				Items = new List<BasketItem>
				{
					new BasketItem
					{
						Id = "BITEM-001",
						Description = "Ergonomik kablosuz fare",
						Amount = 350m,
						Quantity = 1,
						Vat = 63m,
						Discount = 0m,
						ProductId = "PROD-103",
						ProductCode = "WM1",
						Affiliation = "Accessories",
						SKU = "SKU-WM1",
						Brand = "AccessoryCo",
						Variant = "White",
						Category = "Bilgisayar Aksesuar",
						UnitPrice = 350m,
						VatPercentage = 18,
						VatTotal = 63m,
						DiscountCode = null,
						DiscountPercentage = 0,
						DiscountTotal = 0,
						ItemTotal = 350m,
						BasketId = "BASKET-001",
						UserId = "test-user-123"
					}
				}
			};
			return Ok(await SegmageApp.DefaultInstance.DataSender.SaveBasket(basket));
		}
		[HttpPost]
		public async Task<IActionResult> TestSaveBatchBasket()
		{
			var baskets = new List<Basket>
			{
				new Basket
				{
					Id = "BASKET-002",
					UserId = "test-user-456",
					GrandTotal = 8000m,
					Items = new List<BasketItem>{ new BasketItem { Id="BITEM-002", ProductId="PROD-102", Quantity = 1, UnitPrice=8000m } }
				},
				new Basket
				{
					Id = "BASKET-003",
					UserId = "test-user-789",
					GrandTotal = 700m,
					Items = new List<BasketItem>{ new BasketItem { Id="BITEM-003", ProductId="PROD-103", Quantity=2, UnitPrice=350m } }
				}
			};
			return Ok(await SegmageApp.DefaultInstance.DataSender.SaveBatchBasket(baskets));
		}
		[HttpPut]
		public async Task<IActionResult> TestUpdateBasket()
		{
			var basket = new Basket
			{
				Id = "BASKET-001",
				GrandTotal = 500m
			};
			return Ok(await SegmageApp.DefaultInstance.DataSender.UpdateBasket(basket));
		}
		[HttpPut]
		public async Task<IActionResult> TestUpdateBatchBasket()
		{
			var baskets = new List<Basket>
			{
				new Basket { Id = "BASKET-002", GrandTotal = 1000m },
				new Basket { Id = "BASKET-003", GrandTotal = 1200m }
			};
			return Ok(await SegmageApp.DefaultInstance.DataSender.UpdateBatchBasket(baskets));
		}
		[HttpDelete]
		public async Task<IActionResult> TestDeleteBasket(string id = "BASKET-001")
		{
			return Ok(await SegmageApp.DefaultInstance.DataSender.DeleteBasket(id));
		}
		[HttpPost]
		public async Task<IActionResult> TestFlushBasket(string userId = "test-user-123")
		{
			return Ok(await SegmageApp.DefaultInstance.DataSender.FlushBasket(userId));
		}
		#endregion

		#region Opportunity
		[HttpPost]
		public async Task<IActionResult> TestSaveOpportunity()
		{
			var opportunity = new Opportunity
			{
				Id = "OPP-001",
				UserId = "test-user-123",
				Status = "In Progress",
				ValidityStartDate = DateTime.Now,
				ExpiryDate = DateTime.Now.AddDays(30),
				Title = "Büyük Kurumsal Anlaşma",
				ProbabilityOfSuccess = 75.5
			};
			return Ok(await SegmageApp.DefaultInstance.DataSender.SaveOpportunity(opportunity));
		}
		[HttpPost]
		public async Task<IActionResult> TestSaveBatchOpportunity()
		{
			var opportunities = new List<Opportunity>
			{
				new Opportunity
				{
					Id = "OPP-002",
					UserId = "test-user-456",
					Title = "Kobi Anlaşması",
					Status = "New"
				},
				new Opportunity
				{
					Id = "OPP-003",
					UserId = "test-user-789",
					Title = "Yeni Startup Partnerliği",
					Status = "New"
				}
			};
			return Ok(await SegmageApp.DefaultInstance.DataSender.SaveBatchOpportunity(opportunities));
		}
		[HttpPut]
		public async Task<IActionResult> TestUpdateOpportunity()
		{
			var opportunity = new Opportunity
			{
				Id = "OPP-001",
				Status = "Won",
				ProbabilityOfSuccess = 100.0
			};
			return Ok(await SegmageApp.DefaultInstance.DataSender.UpdateOpportunity(opportunity));
		}
		[HttpPut]
		public async Task<IActionResult> TestUpdateBatchOpportunity()
		{
			var opportunities = new List<Opportunity>
			{
				new Opportunity { Id = "OPP-002", Status = "Lost" },
				new Opportunity { Id = "OPP-003", Status = "On Hold" }
			};
			return Ok(await SegmageApp.DefaultInstance.DataSender.UpdateBatchOpportunity(opportunities));
		}
		[HttpDelete]
		public async Task<IActionResult> TestDeleteOpportunity(string id = "OPP-001")
		{
			return Ok(await SegmageApp.DefaultInstance.DataSender.DeleteOpportunity(id));
		}
		#endregion

		#region PriceOffer
		[HttpPost]
		public async Task<IActionResult> TestSavePriceOffer()
		{
			var offer = new Offer
			{
				Id = "OFFER-001",
				UserId = "test-user-123",
				OpportunityId = "OPP-001",
				GrandTotal = 28000m
			};
			return Ok(await SegmageApp.DefaultInstance.DataSender.SavePriceOffer(offer));
		}
		[HttpPost]
		public async Task<IActionResult> TestSaveBatchPriceOffer()
		{
			var offers = new List<Offer>
			{
				new Offer { Id = "OFFER-002", UserId = "test-user-456", OpportunityId="OPP-002", GrandTotal = 5000m },
				new Offer { Id = "OFFER-003", UserId = "test-user-789", OpportunityId="OPP-003", GrandTotal = 12000m }
			};
			return Ok(await SegmageApp.DefaultInstance.DataSender.SaveBatchPriceOffer(offers));
		}
		[HttpPut]
		public async Task<IActionResult> TestUpdatePriceOffer()
		{
			var offer = new Offer
			{
				Id = "OFFER-001",
				GrandTotal = 27500m
			};
			return Ok(await SegmageApp.DefaultInstance.DataSender.UpdatePriceOffer(offer));
		}
		[HttpPut]
		public async Task<IActionResult> TestUpdateBatchPriceOffer()
		{
			var offers = new List<Offer>
			{
				new Offer { Id = "OFFER-002", GrandTotal = 5250m },
				new Offer { Id = "OFFER-003", GrandTotal = 12500m }
			};
			return Ok(await SegmageApp.DefaultInstance.DataSender.UpdateBatchPriceOffer(offers));
		}
		[HttpDelete]
		public async Task<IActionResult> TestDeletePriceOffer(string id = "OFFER-001")
		{
			return Ok(await SegmageApp.DefaultInstance.DataSender.DeletePriceOffer(id));
		}
		#endregion

		#region Sale
		[HttpPost]
		public async Task<IActionResult> TestSaveSale()
		{
			var sale = new Sale
			{
				Id = "SALE-001",
				UserId = "test-user-123",
				OpportunityId = "OPP-001",
				OfferId = "OFFER-001",
				Total = 25350m,
				TotalDiscount = 350m,
				TotalVat = 4500m,
				GrandTotal = 29500m,
				Items = new List<SaleItem>
				{
					new SaleItem
					{
						Id = "SITEM-001",
						SaleId = "SALE-001",
						UserId = "test-user-123",
						ProductId = "PROD-101",
						ProductCode = "LPX1-16-512",
						Description = "Yüksek performanslı dizüstü bilgisayar",
						Amount = 25000m,
						Quantity = 1,
						UnitPrice = 25000m,
						ItemTotal = 25000m,
						Vat = 4500m,
						VatPercentage = 18m,
						VatTotal = 4500m,
						Discount = 0,
						DiscountCode = null,
						DiscountPercentage = 0,
						DiscountTotal = 0,
						Affiliation = "Main Store",
						SKU = "SKU-LPX1-16-512",
						Brand = "TechBrand",
						Variant = "Silver",
						Category = "Elektronik"
					}
				}
			};
			return Ok(await SegmageApp.DefaultInstance.DataSender.SaveSale(sale));
		}
		[HttpPost]
		public async Task<IActionResult> TestSaveBatchSale()
		{
			var sales = new List<Sale>
			{
				new Sale
				{
					Id = "SALE-002",
					GrandTotal = 100m,
					UserId = "test-user-456",
					Items = new List<SaleItem> { new SaleItem { Id="SIT-003", ProductId = "PROD-XYZ", Quantity = 1 } }
				},
				new Sale
				{
					Id = "SALE-003",
					GrandTotal = 200m,
					UserId = "test-user-789",
					Items = new List<SaleItem> { new SaleItem { Id="SIT-004", ProductId = "PROD-ABC", Quantity = 2 } }
				}
			};
			return Ok(await SegmageApp.DefaultInstance.DataSender.SaveBatchSale(sales));
		}
		[HttpPut]
		public async Task<IActionResult> TestUpdateSale()
		{
			var sale = new Sale
			{
				Id = "SALE-001",
				GrandTotal = 16000m,
				TotalDiscount = 500m
			};
			return Ok(await SegmageApp.DefaultInstance.DataSender.UpdateSale(sale));
		}
		[HttpPut]
		public async Task<IActionResult> TestUpdateBatchSale()
		{
			var sales = new List<Sale>
			{
				new Sale { Id = "SALE-002", GrandTotal = 150m },
				new Sale { Id = "SALE-003", GrandTotal = 250m }
			};
			return Ok(await SegmageApp.DefaultInstance.DataSender.UpdateBatchSale(sales));
		}
		[HttpDelete]
		public async Task<IActionResult> TestDeleteSale(string id = "SALE-001")
		{
			return Ok(await SegmageApp.DefaultInstance.DataSender.DeleteSale(id));
		}
		#endregion

		#region Lead
		[HttpPost]
		public async Task<IActionResult> TestSaveLead()
		{
			var lead = new Lead
			{
				Id = "LEAD-001",
				FullName = "Potansiyel Müşteri Adayı",
				LeadExternalId = "CRM-LEAD-789",
				RawData = "{'source':'webinar'}",
				Email = "potential.customer@example.com",
				Phone = "2169876543",
				MobilePhone = "5551112233",
				IsEmailGranted = true,
				IsSmsGranted = true,
				IsCallGranted = false,
				IsWebPushGranted = false,
				IsMobilePushGranted = false,
				UserId = "test-user-123"
			};
			return Ok(await SegmageApp.DefaultInstance.DataSender.SaveLead(lead));
		}
		[HttpPost]
		public async Task<IActionResult> TestSaveBatchLead()
		{
			var leads = new List<Lead>
			{
				new Lead
				{
					Id = "LEAD-002",
					FullName = "PM 2",
					Email="pm2@example.com",
					IsEmailGranted = true
				},
				new Lead
				{
					Id = "LEAD-003",
					FullName = "PM 3",
					Email="pm3@example.com",
					IsEmailGranted = false
				}
			};
			return Ok(await SegmageApp.DefaultInstance.DataSender.SaveBatchLead(leads));
		}
		[HttpPut]
		public async Task<IActionResult> TestUpdateLead()
		{
			var lead = new Lead
			{
				Id = "LEAD-001",
				FullName = "PM Updated",
				IsCallGranted = true
			};
			return Ok(await SegmageApp.DefaultInstance.DataSender.UpdateLead(lead));
		}
		[HttpPut]
		public async Task<IActionResult> TestUpdateBatchLead()
		{
			var leads = new List<Lead>
			{
				new Lead { Id = "LEAD-002", FullName = "PM 2 Updated" },
				new Lead { Id = "LEAD-003", FullName = "PM 3 Updated" }
			};
			return Ok(await SegmageApp.DefaultInstance.DataSender.UpdateBatchLead(leads));
		}
		[HttpDelete]
		public async Task<IActionResult> TestDeleteLead(string id = "LEAD-001")
		{
			return Ok(await SegmageApp.DefaultInstance.DataSender.DeleteLead(id));
		}
		#endregion

		#region Return
		[HttpPost]
		public async Task<IActionResult> TestSaveReturn()
		{
			var productReturn = new ProductReturn
			{
				Id = "RET-001",
				UserId = "test-user-123",
				GrandTotal = 350m,
				SaleId = "SALE-001",
				OfferId = "OFFER-001",
				OpportunityId = "OPP-001",
				Items = new List<ProductReturnItem>
				{
					new ProductReturnItem
					{
						Id = "RITEM-001",
						ProductId = "PROD-103",
						Quantity = 1,
						ProductReturnId = "RET-001",
						UserId = "test-user-123",
						UnitPrice = 350m
					}
				}
			};
			return Ok(await SegmageApp.DefaultInstance.DataSender.SaveReturn(productReturn));
		}
		[HttpPost]
		public async Task<IActionResult> TestSaveBatchReturn()
		{
			var returns = new List<ProductReturn>
			{
				new ProductReturn { Id = "RET-002", UserId = "test-user-456", GrandTotal = 100m },
				new ProductReturn { Id = "RET-003", UserId = "test-user-789", GrandTotal = 200m }
			};
			return Ok(await SegmageApp.DefaultInstance.DataSender.SaveBatchReturn(returns));
		}
		[HttpPut]
		public async Task<IActionResult> TestUpdateReturn()
		{
			var productReturn = new ProductReturn
			{
				Id = "RET-001",
				GrandTotal = 300m
			};
			return Ok(await SegmageApp.DefaultInstance.DataSender.UpdateReturn(productReturn));
		}
		[HttpPut]
		public async Task<IActionResult> TestUpdateBatchReturn()
		{
			var returns = new List<ProductReturn> { new ProductReturn { Id = "RET-002", GrandTotal = 100 } };
			return Ok(await SegmageApp.DefaultInstance.DataSender.UpdateBatchReturn(returns));
		}
		[HttpDelete]
		public async Task<IActionResult> TestDeleteReturn(string id = "RET-001")
		{
			return Ok(await SegmageApp.DefaultInstance.DataSender.DeleteReturn(id));
		}
		#endregion

		#region ActivityAppointment
		[HttpPost]
		public async Task<IActionResult> TestSaveActivityAppointment()
		{
			var activity = new ActivityAppointment
			{
				Id = "ACT-APP-001",
				UserId = "test-user-123",
				Location = "Müşteri Ofisi",
				Status = "Planned",
				PlannedDate = DateTime.Now.AddDays(5),
				CompletionDate = null
			};
			return Ok(await SegmageApp.DefaultInstance.DataSender.SaveActivityAppointment(activity));
		}
		[HttpPost]
		public async Task<IActionResult> TestSaveBatchActivityAppointment()
		{
			var activities = new List<ActivityAppointment>
			{
				new ActivityAppointment { Id = "ACT-APP-002", UserId = "test-user-456", Location = "Ofis A" },
				new ActivityAppointment { Id = "ACT-APP-003", UserId = "test-user-789", Location = "Ofis B" }
			};
			return Ok(await SegmageApp.DefaultInstance.DataSender.SaveBatchActivityAppointment(activities));
		}
		[HttpPut]
		public async Task<IActionResult> TestUpdateActivityAppointment()
		{
			var activity = new ActivityAppointment
			{
				Id = "ACT-APP-001",
				Status = "Completed",
				CompletionDate = DateTime.Now
			};
			return Ok(await SegmageApp.DefaultInstance.DataSender.UpdateActivityAppointment(activity));
		}
		[HttpPut]
		public async Task<IActionResult> TestUpdateBatchActivityAppointment()
		{
			var activities = new List<ActivityAppointment> { new ActivityAppointment { Id = "ACT-APP-002", Status = "Canceled" } };
			return Ok(await SegmageApp.DefaultInstance.DataSender.UpdateBatchActivityAppointment(activities));
		}
		[HttpDelete]
		public async Task<IActionResult> TestDeleteActivityAppointment(string id = "ACT-APP-001")
		{
			return Ok(await SegmageApp.DefaultInstance.DataSender.DeleteActivityAppointment(id));
		}
		#endregion

		#region ActivityMeeting
		[HttpPost]
		public async Task<IActionResult> TestSaveActivityMeeting()
		{
			var activity = new ActivityMeeting
			{
				Id = "ACT-MET-001",
				UserId = "test-user-123",
				Status = "Held",
				PlannedDate = DateTime.Now.AddDays(-1),
				CompletionDate = DateTime.Now
			};
			return Ok(await SegmageApp.DefaultInstance.DataSender.SaveActivityMeeting(activity));
		}
		[HttpPost]
		public async Task<IActionResult> TestSaveBatchActivityMeeting()
		{
			var activities = new List<ActivityMeeting>
			{
				new ActivityMeeting { Id = "ACT-MET-002", UserId = "test-user-123" },
				new ActivityMeeting { Id = "ACT-MET-003", UserId = "test-user-456" }
			};
			return Ok(await SegmageApp.DefaultInstance.DataSender.SaveBatchActivityMeeting(activities));
		}
		[HttpPut]
		public async Task<IActionResult> TestUpdateActivityMeeting()
		{
			var activity = new ActivityMeeting
			{
				Id = "ACT-MET-001",
				Status = "Postponed"
			};
			return Ok(await SegmageApp.DefaultInstance.DataSender.UpdateActivityMeeting(activity));
		}
		[HttpPut]
		public async Task<IActionResult> TestUpdateBatchActivityMeeting()
		{
			var activities = new List<ActivityMeeting> { new ActivityMeeting { Id = "ACT-MET-002", Status = "Completed" } };
			return Ok(await SegmageApp.DefaultInstance.DataSender.UpdateBatchActivityMeeting(activities));
		}
		[HttpDelete]
		public async Task<IActionResult> TestDeleteActivityMeeting(string id = "ACT-MET-001")
		{
			return Ok(await SegmageApp.DefaultInstance.DataSender.DeleteActivityMeeting(id));
		}
		#endregion

		#region ActivityPhone
		[HttpPost]
		public async Task<IActionResult> TestSaveActivityPhone()
		{
			var activity = new ActivityPhone
			{
				Id = "ACT-PHN-001",
				UserId = "test-user-123",
				Phone = "5551234567",
				Caller = "Agent 007",
				Status = "Completed",
				PlannedDate = DateTime.Now,
				CompletionDate = DateTime.Now
			};
			return Ok(await SegmageApp.DefaultInstance.DataSender.SaveActivityPhone(activity));
		}
		[HttpPost]
		public async Task<IActionResult> TestSaveBatchActivityPhone()
		{
			var activities = new List<ActivityPhone>
			{
				new ActivityPhone { Id = "ACT-PHN-002", Phone="5552223344" },
				new ActivityPhone { Id = "ACT-PHN-003", Phone="5553334455" }
			};
			return Ok(await SegmageApp.DefaultInstance.DataSender.SaveBatchActivityPhone(activities));
		}
		[HttpPut]
		public async Task<IActionResult> TestUpdateActivityPhone()
		{
			var activity = new ActivityPhone
			{
				Id = "ACT-PHN-001",
				Status = "No Answer"
			};
			return Ok(await SegmageApp.DefaultInstance.DataSender.UpdateActivityPhone(activity));
		}
		[HttpPut]
		public async Task<IActionResult> TestUpdateBatchActivityPhone()
		{
			var activities = new List<ActivityPhone> { new ActivityPhone { Id = "ACT-PHN-002", Status = "Voicemail" } };
			return Ok(await SegmageApp.DefaultInstance.DataSender.UpdateBatchActivityPhone(activities));
		}
		[HttpDelete]
		public async Task<IActionResult> TestDeleteActivityPhone(string id = "ACT-PHN-001")
		{
			return Ok(await SegmageApp.DefaultInstance.DataSender.DeleteActivityPhone(id));
		}
		#endregion

		#region ActivitySupport
		[HttpPost]
		public async Task<IActionResult> TestSaveActivitySupport()
		{
			var activity = new ActivitySupport
			{
				Id = "ACT-SUP-001",
				UserId = "test-user-123",
				Status = "Open",
				PlannedDate = DateTime.Now,
				CompletionDate = null
			};
			return Ok(await SegmageApp.DefaultInstance.DataSender.SaveActivitySupport(activity));
		}
		[HttpPost]
		public async Task<IActionResult> TestSaveBatchActivitySupport()
		{
			var activities = new List<ActivitySupport>
			{
				new ActivitySupport { Id = "ACT-SUP-002", UserId="test-user-456" },
				new ActivitySupport { Id = "ACT-SUP-003", UserId="test-user-789" }
			};
			return Ok(await SegmageApp.DefaultInstance.DataSender.SaveBatchActivitySupport(activities));
		}
		[HttpPut]
		public async Task<IActionResult> TestUpdateActivitySupport()
		{
			var activity = new ActivitySupport
			{
				Id = "ACT-SUP-001",
				Status = "Closed",
				CompletionDate = DateTime.Now
			};
			return Ok(await SegmageApp.DefaultInstance.DataSender.UpdateActivitySupport(activity));
		}
		[HttpPut]
		public async Task<IActionResult> TestUpdateBatchActivitySupport()
		{
			var activities = new List<ActivitySupport> { new ActivitySupport { Id = "ACT-SUP-002", Status = "In Progress" } };
			return Ok(await SegmageApp.DefaultInstance.DataSender.UpdateBatchActivitySupport(activities));
		}
		[HttpDelete]
		public async Task<IActionResult> TestDeleteActivitySupport(string id = "ACT-SUP-001")
		{
			return Ok(await SegmageApp.DefaultInstance.DataSender.DeleteActivitySupport(id));
		}
		#endregion

		#region Utility
		[HttpGet]
		public async Task<IActionResult> TestGetDataTables()
		{
			return Ok(await SegmageApp.DefaultInstance.DataSender.GetDataTables());
		}
		[HttpGet]
		public async Task<IActionResult> TestValidateToken()
		{
			return Ok(new { IsTokenValid = await SegmageApp.DefaultInstance.DataSender.ValidateToken() });
		}
		#endregion

		#endregion

		#region EventSender Tests
		[HttpPost]
		public async Task<IActionResult> TestSetSession()
		{
			var sgSession = await SegmageHttpContext.GetSgSession();
			var session = new Session
			{
				Id = Guid.Parse(sgSession.Id),
				ProjectId = Guid.NewGuid(),
				IntegrationId = Guid.NewGuid(),
				DeviceId = Guid.Parse(sgSession.DeviceId),
				PageId = Guid.NewGuid(),
				Created = DateTime.UtcNow,
				GoogleAnalyticsId = "UA-123456-1",
				Time = DateTime.Now.ToShortTimeString(),
				UserId = sgSession.UserId,
				Latitude = 41.0082,
				Longitude = 28.9784,
				Ip = "88.255.10.10",
				AsnNumber = 12735,
				AsnName = "Turk Telekom",
				Country = "Turkey",
				City = "Istanbul",
				Town = "Fatih",
				Referer = "https://www.google.com/",
				RefererSource = "google",
				RefererMedium = "organic",
				Term = "cdp nedir",
				Sgclid = Guid.NewGuid().ToString(),
				FullName = "İlter Yıldız (Session)",
				IsFullNameReliable = true,
				LeadId = Guid.NewGuid(),
				LastActiveDate = DateTime.Now,
				UtmId = "utm-id-123",
				UtmSource = "newsletter",
				UtmMedium = "email",
				UtmCampaign = "september_promo",
				UtmTerm = "special_offer",
				UtmContent = "banner_ad_1",
				CampaignId = Guid.NewGuid(),
				StepId = Guid.NewGuid(),
				CampaignItemId = Guid.NewGuid(),
				LinkIdentifier = "main-link",
				Gclid = "gclid-test-token",
				Fbclid = "fbclid-test-token",
				CreatedSystemUser = "System",
				CreatedSystemDate = DateTime.Now,
				DeviceBrowser = "Chrome",
				DeviceBrowserVersion = "105.0",
				DeviceDeviceType = "Desktop",
				DeviceLanguage = "tr-TR",
				DevicePlatform = "Windows",
				DevicePlatformVersion = "10.0",
				DevicePlatformProcessor = "x64",
				DeviceScreen = "1920x1080",
				DeviceTimeZone = "Europe/Istanbul"
			};
			return Ok(await SegmageApp.DefaultInstance.EventSender.SetSessionAsync(session));
		}
		[HttpPost]
		public async Task<IActionResult> TestSendLoginEvent()
		{
			var loginEvent = new Login();
			return Ok(await SegmageApp.DefaultInstance.EventSender.SendLoginEventAsync("loginEventUniqName", loginEvent));
		}
		[HttpPost]
		public async Task<IActionResult> TestSendLogoutEvent()
		{
			var logoutEvent = new Logout();
			return Ok(await SegmageApp.DefaultInstance.EventSender.SendLogoutEventAsync("logoutEventUniqName", logoutEvent));
		}
		[HttpPost]
		public async Task<IActionResult> TestSendAddToBasketEvent()
		{
			var addToBasketEvent = new AddToBasket
			{
				ProductId = "PROD-101",
				ProductCode = "LPX1-16-512",
				ProductText = "Laptop Pro X1 - 16GB RAM, 512GB SSD",
				Affiliation = "Main Store",
				SKUId = "SKU-LPX1-16-512",
				Brand = "TechBrand",
				Variant = "Silver",
				Category = "Elektronik",
				Category2 = "Bilgisayar",
				Category3 = "Dizüstü Bilgisayar",
				Category4 = "Ultrabook",
				Category5 = "",
				Unit = "Adet",
				UnitPrice = 25000m,
				VatPercentage = 18m,
				VatTotal = 4500m,
				DiscountCode = null,
				DiscountPercentage = 10m,
				DiscountTotal = 2500m,
				ItemTotal = 22500m
			};
			return Ok(await SegmageApp.DefaultInstance.EventSender.SendAddToBasketEventAsync("addToBasketUniqName", addToBasketEvent));
		}
		[HttpPost]
		public async Task<IActionResult> TestSendRemoveFromBasketEvent()
		{
			var removeFromBasketEvent = new RemoveFromBasket
			{
				ProductId = "PROD-101",
				ProductCode = "LPX1-16-512",
				ProductText = "Laptop Pro X1 - 16GB RAM, 512GB SSD",
				Affiliation = "Main Store",
				SKUId = "SKU-LPX1-16-512",
				Brand = "TechBrand",
				Variant = "Silver",
				Category = "Elektronik",
				UnitPrice = 25000m,
				ItemTotal = 22500m
			};
			return Ok(await SegmageApp.DefaultInstance.EventSender.SendRemoveFromBasketEventAsync("removeFromBasketUniqName", removeFromBasketEvent));
		}
		[HttpPost]
		public async Task<IActionResult> TestSendPageViewEvent()
		{
			var pageViewEvent = new PageView
			{
				PageId = Guid.NewGuid(),
				Url = "/home/index"
			};
			return Ok(await SegmageApp.DefaultInstance.EventSender.SendPageViewEventAsync("pageViewUniqName", pageViewEvent));
		}
		[HttpPost]
		public async Task<IActionResult> TestSendGoalEvent()
		{
			var goalEvent = new Goal
			{
				Value = 100.0m
			};
			return Ok(await SegmageApp.DefaultInstance.EventSender.SendGoalEventAsync("goalUniqName", goalEvent));
		}
		[HttpPost]
		public async Task<IActionResult> TestSendSearchEvent()
		{
			var searchEvent = new Search
			{
				Data = "C# SDK Test"
			};
			return Ok(await SegmageApp.DefaultInstance.EventSender.SendSearchEventAsync("searchUniqName", searchEvent));
		}
		[HttpPost]
		public async Task<IActionResult> TestSendCustomEvent()
		{
			var customEvent = new Custom
			{
				Data = "{\"key\":\"value\", \"message\":\"This is a test event from ASP.NET Core\"}"
			};
			return Ok(await SegmageApp.DefaultInstance.EventSender.SendCustomEventAsync("customEventUniqName", customEvent));
		}
		#endregion
	}
}