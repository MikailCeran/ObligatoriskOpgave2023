using System.Reflection;
using System.Xml.Linq;

namespace BookAssignment
{
    public class Book
    {
        public int? Id { get; set; }
        public string? Title { get; set; }
        public double? Price { get; set; }


        public override string ToString()
        {
            return $"{Id} {Title} {Price}";
        }
        public void ValidateTitle()
        {
            if (Title == null)
            {
                throw new ArgumentNullException(nameof(Title), "Title cannot be null");
            }
            if (Title.Length < 3)
            {
                throw new ArgumentException("Title must be at least 3 characters", nameof(Title));
            }
        }
        public void ValidatePrice()
        {
            if (Price < 0 || Price > 1200)
            {
                throw new ArgumentException("Price must be between 0 and 1200!", nameof(Price));
            }
        }

        public void Validate()
        {
            ValidateTitle();
            ValidatePrice();
        }
    }
}