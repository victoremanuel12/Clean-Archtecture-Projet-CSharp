using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Validation;
using FluentAssertions;
using Xunit;

namespace CleanArchMvc.Domain.Testes
{
    public class CategoryUnitTest1
    {
        [Fact(DisplayName = "Create Category with valid State")]
        public void CreateCategory_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Category(1, "Category Name");
            action.Should().NotThrow<DomainExceptionValidation>();
        }
        [Fact(DisplayName = "Create Category with invalid Id Value")]
        public void CreateCategory_With_NegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Category(-1, "Category Name");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid Id Value");
        }
        [Fact(DisplayName = "Create Category with missing name value")]
        public void CreateCategory_With_MissingNameValue_DomainExceptionRequiredName()
        {
            Action action = () => new Category(1, "");
            action.Should().Throw<DomainExceptionValidation>().
                WithMessage("Invalid name. Name is Required");
        }
        [Fact(DisplayName = "Create Category with short name")]
        public void CreateCategory_With_ShortNameValue_DomainExceptionShotName()
        {
            Action action = () => new Category(1, "C");
            action.Should().Throw<DomainExceptionValidation>().
                WithMessage("Invalid name. Too short name,minimun 3 charecters");
        }
        [Fact(DisplayName = "Create Category with null name value")]
        public void CreateCategory_With_NullNameValue_DomainExceptionShotName()
        {
            Action action = () => new Category(1, null);
            action.Should().Throw<DomainExceptionValidation>().
                WithMessage("Invalid name. Name is Required");
        }
    }
}