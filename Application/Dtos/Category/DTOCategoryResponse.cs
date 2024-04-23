namespace Application.Dtos.Category
{
    public class DTOCategoryResponse
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }


        public override string ToString()
        {
            return $"{CategoryId}) {Name}";
        }
    }
}
