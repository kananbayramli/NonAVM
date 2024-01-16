using ECommerse.Business.DTO_s;
using ECommerse.Business.Services.Abstract;
using ECommerse.Core.Entities;
using ECommerse.Core.Identity;
using ECommerse.WebUI.Models.Basket;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;
using System.Security.Claims;

namespace ECommerse.WebUI.Controllers;
public class BasketController : BaseController
{
    private readonly IProductService _productService;
    private readonly IProductItemService _productItemService;
    private readonly IBasketService _basketService;
    private readonly IBasketItemService _basketItemService;
    public BasketController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<AppRole> roleManager, IProductItemService productItemService, IBasketService basketService, IBasketItemService basketItemService, IProductService productService) : base(userManager, signInManager, roleManager)
    {
        _productItemService = productItemService;
        _basketService = basketService;
        _basketItemService = basketItemService;
        _productService = productService;
    }

    public async Task<IActionResult> Index(int productId)
    {
        var userId = User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;
        var basket = await _basketService.GetAsync(b => b.UserID == userId);
        if (basket is null)
        {
            var basketItem = new BasketDTO()
            {
                UserID = userId
            };
            await _basketService.Create(basketItem);
        }

        var items = await _basketItemService.GetAllAsync();

        var tbms = new List<TempBasketModel>();

        foreach (var item in items)
        {
            var pitem = await _productItemService.GetAsync(p => p.Id == item.ProductItemID);
            var product = await _productService.GetAsync(p => p.Id == pitem.ProductID);
            var tbm = new TempBasketModel
            {
                Id = item.Id,
                Name = product.Name,
                Price = pitem.Price,
                Quantity = item.Count,
                Image = product?.Image
            };
            tbms.Add(tbm);
        }
        return View(tbms);
    }

    public async Task<IActionResult> AddToBasket(int productId)
    {
        var userId = User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value;

        var basket = await _basketService.GetAsync(b => b.UserID == userId);

        var bItem = new BasketDTO()
        {
            TotalPrice = 100,
            UserID = userId
        };
        if (basket is null)
        {
            await _basketService.Create(bItem);
            basket = bItem;
        }

        var newItem = new ProductItemDTO
        {
            SKU = RandomStringGenerator.GenerateRandomString(7),
            Quantity = new Random().Next(0, 50),
            Price = Convert.ToDecimal(new Random().Next(0, 50)),
            Image = string.Empty,
            ProductID = productId
        };

        var oldItem = await _productItemService.GetAsync(p => p.ProductID == productId);

        if (oldItem is null)
        {
            await _productItemService.Create(newItem);

            var basketItem = new BasketItemDTO()
            {
                BasketID = basket.Id,
                ProductItemID = newItem.Id,
                Count = 1
            };
            await _basketItemService.Create(basketItem);
        }
        else
        {
            var basketItem = await _basketItemService.GetAsync(b => b.ProductItemID == oldItem.Id);
            if (basketItem is not null)
            {
                basketItem.Count++;
                //_basketItemService.Update(basketItem);
                await _basketItemService.SaveChangesAsync(CancellationToken.None);
            }
            else
            {
                await _basketItemService.Create(
                new BasketItemDTO()
                {
                    BasketID = basket.Id,
                    ProductItemID = oldItem.Id,
                    Count = 1
                });

            }
        }

        return RedirectToAction("Index");
    }

    public async Task<IActionResult> Delete(int itemId)
    {
        var basketItem = await _basketItemService.GetAsync(b => b.Id == itemId);
        _basketItemService.Remove(basketItem);

        return RedirectToAction("Index");
    }
}

public static class RandomStringGenerator
{

    public static string GenerateRandomString(int length)
    {
        Random random = new Random();
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        char[] randomString = new char[length];

        for (int i = 0; i < length; i++)
        {
            randomString[i] = chars[random.Next(chars.Length)];
        }

        return new string(randomString);
    }
}