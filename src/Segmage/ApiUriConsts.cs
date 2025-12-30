namespace Segmage
{
    public class ApiUriConsts
    {
        public const string SET_SESSION = "{0}/app/SetSession";
        public const string PAGE_VIEW_EVENT = "{0}/app/{1}/Login";
        public const string LOGIN_EVENT = "{0}/app/{1}/Login";
        public const string LOGOUT_EVENT = "{0}/app/{1}/Logout";
        public const string SEARCH_EVENT = "{0}/app/{1}/Search";
        public const string CUSTOM_EVENT = "{0}/app/{1}/Custom";
        public const string GOAL_EVENT = "{0}/app/{1}/Goal";
        public const string BASEKET_EVENT = "{0}/app/BasketSync";
        public const string ADD_TO_BASEKET_EVENT = "{0}/app/{1}/AddToBasket";
        public const string REMOVE_FROM_BASKET_EVENT = "{0}/app/{1}/RemoveFromBasket";

		// Customer
		public const string CUSTOMER360 = "{0}/dt/customer360"; // POST (Create), PUT (Update) için
		public const string CUSTOMER360_BATCH = "{0}/dt/customer360/batch"; // POST/PUT (Batch) için
		public const string CUSTOMER360_BY_ID = "{0}/dt/customer360/{1}"; // DELETE için

		// Product
		public const string PRODUCT360 = "{0}/dt/product360";
		public const string PRODUCT360_BATCH = "{0}/dt/product360/batch";
		public const string PRODUCT360_BY_ID = "{0}/dt/product360/{1}";

		// Basket
		public const string BASKET = "{0}/dt/basket";
		public const string BASKET_BATCH = "{0}/dt/basket/batch";
		public const string BASKET_BY_ID = "{0}/dt/basket/{1}";
		public const string BASKET_FLUSH = "{0}/dt/basket/flush"; // Özel eylem olarak korundu

		// Opportunity
		public const string OPPORTUNITY = "{0}/dt/opportunity";
		public const string OPPORTUNITY_BATCH = "{0}/dt/opportunity/batch";
		public const string OPPORTUNITY_BY_ID = "{0}/dt/opportunity/{1}";

		// PriceOffer
		public const string PRICEOFFER = "{0}/dt/priceoffer";
		public const string PRICEOFFER_BATCH = "{0}/dt/priceoffer/batch";
		public const string PRICEOFFER_BY_ID = "{0}/dt/priceoffer/{1}";

		// Sale
		public const string SALE = "{0}/dt/sale";
		public const string SALE_BATCH = "{0}/dt/sale/batch";
		public const string SALE_BY_ID = "{0}/dt/sale/{1}";

		// Lead
		public const string LEAD = "{0}/dt/lead";
		public const string LEAD_BATCH = "{0}/dt/lead/batch";
		public const string LEAD_BY_ID = "{0}/dt/lead/{1}";

		// Return
		public const string RETURN = "{0}/dt/return";
		public const string RETURN_BATCH = "{0}/dt/return/batch";
		public const string RETURN_BY_ID = "{0}/dt/return/{1}";

		// ActivityAppointment
		public const string ACTIVITYAPPOINTMENT = "{0}/dt/activityappointment";
		public const string ACTIVITYAPPOINTMENT_BATCH = "{0}/dt/activityappointment/batch";
		public const string ACTIVITYAPPOINTMENT_BY_ID = "{0}/dt/activityappointment/{1}";

		// ActivityMeeting
		public const string ACTIVITYMEETING = "{0}/dt/activitymeeting";
		public const string ACTIVITYMEETING_BATCH = "{0}/dt/activitymeeting/batch";
		public const string ACTIVITYMEETING_BY_ID = "{0}/dt/activitymeeting/{1}";

		// ActivityPhone
		public const string ACTIVITYPHONE = "{0}/dt/activityphone";
		public const string ACTIVITYPHONE_BATCH = "{0}/dt/activityphone/batch";
		public const string ACTIVITYPHONE_BY_ID = "{0}/dt/activityphone/{1}";

		// ActivitySupport
		public const string ACTIVITYSUPPORT = "{0}/dt/activitysupport";
		public const string ACTIVITYSUPPORT_BATCH = "{0}/dt/activitysupport/batch";
		public const string ACTIVITYSUPPORT_BY_ID = "{0}/dt/activitysupport/{1}";

		// MobilePushToken
		public const string MOBILEPUSHTOKEN = "{0}/dt/mobilepushtoken";
		public const string MOBILEPUSHTOKEN_BATCH = "{0}/dt/mobilepushtoken/batch";
		public const string MOBILEPUSHTOKEN_BY_ID = "{0}/dt/mobilepushtoken/{1}";

		// Other
		public const string OTHER = "{0}/dt/other";
		public const string OTHER_BATCH = "{0}/dt/other/batch";
		public const string OTHER_BY_ID = "{0}/dt/other/{1}";

		public const string DATATABLE = "{0}/dt/GetDataTables";

		public const string EVENTS = "{0}/dt/GetEvents";
		public const string TOKENVALIDATE = "{0}/dt/TokenValidation";
	}
}