﻿using RESTCountries.NET;
using RESTCountries.NET.Models;
using RESTCountries.NET.Services;
using System.Globalization;

namespace ForexApp.Services;

public static class CurrencyService
{
   

    public static IEnumerable<ForexApp.Models.Currency> GetAvailableCurrencies()
    {
        var countries = RestCountriesService.GetAllCountries();

        return countries
            .Where(c => c.Currencies != null)
            .SelectMany(c => c.Currencies.Keys
                .Select(currencyCode => new ForexApp.Models.Currency(
                    currencyCode, // Code (position 1)
                    GetCurrencyName(currencyCode, c.Currencies[currencyCode]), // Name (position 2)
                    GetCurrencySymbol(currencyCode), // Symbol (position 3)
                    GetFlagEmoji(c.Cca2) // FlagUrl (position 4)
                ))
            .DistinctBy(c => c.Code)
            .OrderBy(c => c.Name)
            .ToList());
    }

    private static string GetCurrencyName(string code, RESTCountries.NET.Models.Currency currency)
    {
        return !string.IsNullOrWhiteSpace(currency.Name)
            ? currency.Name
            : code switch
            {
                "CNY" => "Chinese Yuan Renminbi",
                "USD" => "US Dollar",
                // Add other fallbacks as needed
                _ => $"Currency ({code})"
            };
    }

    private static string GetFlagEmoji(string countryCode)
    {
        return string.Concat(countryCode
            .ToUpper()
            .Take(2)
            .Select(c => char.ConvertFromUtf32(c + 0x1F1A5)));
    }

    private static string GetCurrencySymbol(string currencyCode)
    {
        if (string.IsNullOrEmpty(currencyCode))
            return "¤";

        try
        {
            return currencyCode switch
            {
                "CNY" => "¥",
                "JPY" => "¥",
                "USD" => "$",
                "EUR" => "€",
                "GBP" => "£",
                _ => new RegionInfo(
                    CultureInfo
                        .GetCultures(CultureTypes.SpecificCultures)
                        .FirstOrDefault(c => new RegionInfo(c.Name).ISOCurrencySymbol == currencyCode)?.Name ?? ""
                ).CurrencySymbol
            };
        }
        catch
        {
            return currencyCode;
        }
    }
}