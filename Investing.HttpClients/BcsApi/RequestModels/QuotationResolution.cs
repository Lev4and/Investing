namespace Investing.HttpClients.BcsApi.RequestModels
{
    public enum QuotationResolution : uint
    {
        Minute = 1, 
        FiveMinutes = 5, 
        QuaterHour = 15, 
        HalfHour = 30, 
        Hour = 60, 
        Day = 1440, 
        Week = 10080, 
        FourWeeks = 40320
    }
}
