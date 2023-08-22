using System.Globalization;

namespace MySales.Model.DTOs.Product;

public record DetailProductDto(long id, string description, decimal value, DateTime createdDate);
