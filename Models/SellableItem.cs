namespace ConsoleApi.Models
{
    public interface SellableItem
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public DateTime DateFirstPutOnMarket { get; set; }

        public long Price { get; set; }


    }
}
