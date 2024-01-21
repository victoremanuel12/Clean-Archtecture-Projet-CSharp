using CleanArchMvc.Domain.Entities;
using CleanArchMvc.Domain.Validation;
using FluentAssertions;
using Xunit;

namespace CleanArchMvc.Domain.Testes
{
    public class ProductUnitTest1
    {
        [Fact(DisplayName = "Create product with valid State")]
        public void CreateProduct_WithValidParameters_ResultObjectValidState()
        {
            Action action = () => new Product(1,"Product Name","Descrição adicionada ao produto",1,1,"image.png");
            action.Should().NotThrow<DomainExceptionValidation>();
        }

        [Fact(DisplayName = "Create product with invalid Id Value")]
        public void CreateProduct_With_NegativeIdValue_DomainExceptionInvalidId()
        {
            Action action = () => new Product(-1, "Product Name", "Descrição adicionada ao produto", 1, 1, "image.png");
            action.Should().Throw<DomainExceptionValidation>().WithMessage("Invalid Id value");
        }

        [Fact(DisplayName = "Create Product with missing name value")]
        public void CreateCategory_With_MissingNameValue_DomainExceptionRequiredName()
        {
            Action action = () => new Product(1, "", "Descrição adicionada ao produto", 1, 1, "image.png");
            action.Should().Throw<DomainExceptionValidation>().
                WithMessage("Invalid name. Name is Required");
        }

        [Fact(DisplayName = "Create product with short name")]
        public void CreateCategory_With_ShortNameValue_DomainExceptionShortName()
        {
            Action action = () => new Product(1, "c", "Descrição adicionada ao produto", 1, 1, "image.png");
            action.Should().Throw<DomainExceptionValidation>().
                WithMessage("Invalid Name. Name is too short");
        }

        [Fact(DisplayName = "Create product with null name value")]
        public void CreateCategory_With_NullPriceValue_DomainExceptionMissingName()
        {
            Action action = () => new Product(1, null, "Descrição adicionada ao produto", 1, 1, "image.png");
            action.Should().Throw<DomainExceptionValidation>().
                WithMessage("Invalid Name. Name is required");
        }

        [Fact(DisplayName = "Create product with negative price value")]
        public void CreateProduct_With_NegativePriceValue_DomainExceptionNegativePrice()
        {
            Action action = () => new Product(1, "Product Name", "Descrição adicionada ao produto", -1, 1, "image.png");
            action.Should().Throw<DomainExceptionValidation>().
                WithMessage("Invalid price value");
        }

        [Fact(DisplayName = "Create product with negative stock value")]
        public void CreateProduct_With_NegativeStockValue_DomainExceptionNegativeStock()
        {
            Action action = () => new Product(1, "Product Name", "Descrição adicionada ao produto", 1, -1, "image.png");
            action.Should().Throw<DomainExceptionValidation>().
                WithMessage("Invalid stock value");
        }

        [Fact(DisplayName = "Create product with long image url value")]
        public void CreateProduct_With_TooLongImageValue_DomainExceptionTooLongImageUrl()
        {
            Action action = () => new Product(1, "Product Name", "Descrição adicionada ao produto", 1, 1, "\r\nhttps://imagensficticias.com/tecnologia-avançada\r\nDescrição: Uma imagem futurística retrata um skyline urbano com arranha-céus iluminados por hologramas vibrantes. No centro, um drone autônomo entrega pacotes, refletindo a integração da tecnologia na vida diária. O céu noturno é iluminado por luzes de veículos voadores, sugerindo um mundo avançado e interconectado.");
            action.Should().Throw<DomainExceptionValidation>().
                WithMessage("Invalid image name, too long, maximum 250 characters");
        }

        [Fact(DisplayName = "Create product with short image url value")]
        public void CreateProduct_With_ShortImageValue_DomainExceptionShortImageUrl()
        {
            Action action = () => new Product(1, "Product Name", "Descrição adicionada ao produto", 1, 1, "aaaaaaaaa");
            action.Should().Throw<DomainExceptionValidation>().
                WithMessage("Invalid image name, too shot, minimun 10 characters");
        }

    }
}
