using CleanArchMvc.Domain.Validation;

namespace CleanArchMvc.Domain.Entities
{
    public sealed class Category : EntityBase
    {
        public string? Name { get; private set; }
        public ICollection<Product>? Products { get; private set; }
        public void Update(string name)
        {
            ValidateDomain(name);
        }
        public Category(string name)
        {
            ValidateDomain(name);
        }
        public Category(int id, string name)
        {
            DomainExceptionValidation.When(id < 0, "Invalid Id Value");
            Id = id;
            ValidateDomain(name);

        }
        private void ValidateDomain(string name)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name. Name is Required");
            DomainExceptionValidation.When(name.Length < 3, "Invalid name. Too short name,minimun 3 charecters");
            Name = name;

        }
    }
}
