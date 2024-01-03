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
        public const string BATCH_DATA_EVENT = "{0}/dt/integration/{1}/SendBatchData";
        public const string UPLOAD_BATCH_DATA_EVENT = "{0}/dt/integration/{1}/UploadBatchData";

    }
}