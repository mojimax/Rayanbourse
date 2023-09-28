using Application.Dtos.Base;

namespace Application.Dtos.Products
{
    public interface IBaseProdoctDto 
    {
        string Name { get; set; }
        string ManufacturePhone { get; set; }
        string ManufactureEmail { get; set; }
    }
}
