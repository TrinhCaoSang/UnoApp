using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace UnoApp.Models;

public class Product
{
    // Map trường "productID" từ JSON vào biến Id
    [JsonPropertyName("productID")]
    public int Id { get; set; }

    // QUAN TRỌNG: Map trường "productName" từ JSON vào biến Name
    // Để khớp với {Binding Name} bên giao diện XAML
    [JsonPropertyName("productName")]
    public string Name { get; set; }

    // Map trường "price" từ JSON vào biến Price
    [JsonPropertyName("price")]
    public decimal Price { get; set; }

    // Map trường "barcode" từ JSON vào biến Barcode
    [JsonPropertyName("barcode")]
    public string Barcode { get; set; }

    // Map trường "unit" từ JSON vào biến Unit
    [JsonPropertyName("unit")]
    public string Unit { get; set; }
}
