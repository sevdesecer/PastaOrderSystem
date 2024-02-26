namespace PastaOrderSystem.DTO
{
    public class JunctionDto
    {
        public Guid PastaId { get; set; }
        public Guid BeverageId { get; set; }
        public Guid OrderId { get; set; }
        public Guid ExtraIngredientId { get; set; }
        public int PastaNumber { get; set; }

    }
}
