using Microsoft.AspNetCore.Http.Connections;
using WereHouse.Client;

var clientWrapper = new WerehouseClienteWrapper("https://localhost:7213");

Console.WriteLine("\n Agregando producto 1...");
var prodcut1ID = await clientWrapper.AddProductAsync("1", "Coca Cola", 100);
if (!string.IsNullOrEmpty(prodcut1ID))
{
    Console.WriteLine($"Nuevo producto agregado con ID: {prodcut1ID}");
}
else
{
    Console.WriteLine("No se puedo agregar el producto");
}

Console.WriteLine("\n Agregando producto 2...");
var prodcut2ID = await clientWrapper.AddProductAsync("2", "Doritos", 50);
if (!string.IsNullOrEmpty(prodcut2ID))
{
    Console.WriteLine($"Nuevo producto agregado con ID: {prodcut2ID}");
}
else
{
    Console.WriteLine("No se puedo agregar el producto");
}

Console.WriteLine("\n Agregando producto 3...");
var prodcut3ID = await clientWrapper.AddProductAsync("3", "Papa con pollo", 70);
if (!string.IsNullOrEmpty(prodcut3ID))
{
    Console.WriteLine($"Nuevo producto agregado con ID: {prodcut3ID}");
}
else
{
    Console.WriteLine("No se puedo agregar el producto");
}

Console.WriteLine("\n Buscando el producto con ID '2'");
var product = await clientWrapper.GetProductByIdAsync("2");
if (product!=null)
{
    Console.WriteLine($"El producto es: {product.Name}, Cantidad: {product.Cantidad}");
}
else
{
    Console.WriteLine("No se encontro el producto");
}

Console.WriteLine("\n Buscando el producto con ID '5'");
var product5 = await clientWrapper.GetProductByIdAsync("5");
if (product5 != null)
{
    Console.WriteLine($"El producto es: {product5.Name}, Cantidad: {product5.Cantidad}");
}
else
{
    Console.WriteLine("No se encontro el producto");
}

Console.WriteLine("\nPreciona una tecla para salir");
Console.ReadKey();