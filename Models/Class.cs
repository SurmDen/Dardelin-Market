namespace DardelinMarket.Models
{
    public class Data
    {
        public string postal_code { get; set; }
        public string country { get; set; }
        public string country_iso_code { get; set; }
        public string federal_district { get; set; }
        public string region_fias_id { get; set; }
        public string region_kladr_id { get; set; }
        public string region_iso_code { get; set; }
        public string region_with_type { get; set; }
        public string region_type { get; set; }
        public string region_type_full { get; set; }
        public string region { get; set; }
        public object area_fias_id { get; set; }
        public object area_kladr_id { get; set; }
        public object area_with_type { get; set; }
        public object area_type { get; set; }
        public object area_type_full { get; set; }
        public object area { get; set; }
        public string city_fias_id { get; set; }
        public string city_kladr_id { get; set; }
        public string city_with_type { get; set; }
        public string city_type { get; set; }
        public string city_type_full { get; set; }
        public string city { get; set; }
    }

    public class Location
    {
        public string value { get; set; }
        public string unrestricted_value { get; set; }
        public Data data { get; set; }
    }

    public class Root
    {
        public Location location { get; set; }
    }
}
