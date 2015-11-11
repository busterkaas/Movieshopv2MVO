namespace MovieShopDTO.ModelDTO
{
    public class OrderlineDTO
    {
        public int Id { get; set; }
        private int amount { get; set; }
        public int Amount {get; set; }
        public int MovieId { get; set; }
        public int OrderId { get; set; }

    }
}
