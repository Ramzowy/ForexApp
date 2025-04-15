using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForexApp.Converters
{
    // Add this class to your project (e.g., in a Converters folder)
    public class CurrencyCodeToFlagConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string rateString)
            {
                // Extract currency code (first 3 characters before ":")
                var currencyCode = rateString.Split(':')[0].Trim();

                // Simple mapping of currency codes to country codes for flags
                // You might want to expand this dictionary
                var currencyToCountry = new Dictionary<string, string>
                {

                    // A
                    ["AED"] = "AE", // UAE
                    ["AFN"] = "AF", // Afghanistan
                    ["ALL"] = "AL", // Albania
                    ["AMD"] = "AM", // Armenia
                    ["ANG"] = "AN", // Netherlands Antilles
                    ["AOA"] = "AO", // Angola
                    ["ARS"] = "AR", // Argentina
                    ["AUD"] = "AU", // Australia
                    ["AWG"] = "AW", // Aruba
                    ["AZN"] = "AZ", // Azerbaijan

                    // B
                    ["BAM"] = "BA", // Bosnia
                    ["BBD"] = "BB", // Barbados
                    ["BDT"] = "BD", // Bangladesh
                    ["BGN"] = "BG", // Bulgaria
                    ["BHD"] = "BH", // Bahrain
                    ["BIF"] = "BI", // Burundi
                    ["BMD"] = "BM", // Bermuda
                    ["BND"] = "BN", // Brunei
                    ["BOB"] = "BO", // Bolivia
                    ["BRL"] = "BR", // Brazil
                    ["BSD"] = "BS", // Bahamas
                    ["BTN"] = "BT", // Bhutan
                    ["BWP"] = "BW", // Botswana
                    ["BYN"] = "BY", // Belarus
                    ["BZD"] = "BZ", // Belize

                    // C
                    ["CAD"] = "CA", // Canada
                    ["CDF"] = "CD", // Congo
                    ["CHF"] = "CH", // Switzerland
                    ["CLP"] = "CL", // Chile
                    ["CNY"] = "CN", // China
                    ["COP"] = "CO", // Colombia
                    ["CRC"] = "CR", // Costa Rica
                    ["CUP"] = "CU", // Cuba
                    ["CVE"] = "CV", // Cape Verde
                    ["CZK"] = "CZ", // Czechia

                    // D
                    ["DJF"] = "DJ", // Djibouti
                    ["DKK"] = "DK", // Denmark
                    ["DOP"] = "DO", // Dominican Republic
                    ["DZD"] = "DZ", // Algeria

                    // E
                    ["EGP"] = "EG", // Egypt
                    ["ERN"] = "ER", // Eritrea
                    ["ETB"] = "ET", // Ethiopia
                    ["EUR"] = "EU", // European Union

                    // F
                    ["FJD"] = "FJ", // Fiji
                    ["FKP"] = "FK", // Falkland Islands

                    // G
                    ["GBP"] = "GB", // UK
                    ["GEL"] = "GE", // Georgia
                    ["GHS"] = "GH", // Ghana
                    ["GIP"] = "GI", // Gibraltar
                    ["GMD"] = "GM", // Gambia
                    ["GNF"] = "GN", // Guinea
                    ["GTQ"] = "GT", // Guatemala
                    ["GYD"] = "GY", // Guyana

                    // H
                    ["HKD"] = "HK", // Hong Kong
                    ["HNL"] = "HN", // Honduras
                    ["HRK"] = "HR", // Croatia
                    ["HTG"] = "HT", // Haiti
                    ["HUF"] = "HU", // Hungary

                    // I
                    ["IDR"] = "ID", // Indonesia
                    ["ILS"] = "IL", // Israel
                    ["INR"] = "IN", // India
                    ["IQD"] = "IQ", // Iraq
                    ["IRR"] = "IR", // Iran
                    ["ISK"] = "IS", // Iceland

                    // J
                    ["JMD"] = "JM", // Jamaica
                    ["JOD"] = "JO", // Jordan
                    ["JPY"] = "JP", // Japan

                    // K
                    ["KES"] = "KE", // Kenya
                    ["KGS"] = "KG", // Kyrgyzstan
                    ["KHR"] = "KH", // Cambodia
                    ["KMF"] = "KM", // Comoros
                    ["KPW"] = "KP", // North Korea
                    ["KRW"] = "KR", // South Korea
                    ["KWD"] = "KW", // Kuwait
                    ["KYD"] = "KY", // Cayman Islands
                    ["KZT"] = "KZ", // Kazakhstan

                    // L
                    ["LAK"] = "LA", // Laos
                    ["LBP"] = "LB", // Lebanon
                    ["LKR"] = "LK", // Sri Lanka
                    ["LRD"] = "LR", // Liberia
                    ["LSL"] = "LS", // Lesotho
                    ["LYD"] = "LY", // Libya

                    // M
                    ["MAD"] = "MA", // Morocco
                    ["MDL"] = "MD", // Moldova
                    ["MGA"] = "MG", // Madagascar
                    ["MKD"] = "MK", // North Macedonia
                    ["MMK"] = "MM", // Myanmar
                    ["MNT"] = "MN", // Mongolia
                    ["MOP"] = "MO", // Macau
                    ["MRU"] = "MR", // Mauritania
                    ["MUR"] = "MU", // Mauritius
                    ["MVR"] = "MV", // Maldives
                    ["MWK"] = "MW", // Malawi
                    ["MXN"] = "MX", // Mexico
                    ["MYR"] = "MY", // Malaysia
                    ["MZN"] = "MZ", // Mozambique

                    // N
                    ["NAD"] = "NA", // Namibia
                    ["NGN"] = "NG", // Nigeria
                    ["NIO"] = "NI", // Nicaragua
                    ["NOK"] = "NO", // Norway
                    ["NPR"] = "NP", // Nepal
                    ["NZD"] = "NZ", // New Zealand

                    // O
                    ["OMR"] = "OM", // Oman

                    // P
                    ["PAB"] = "PA", // Panama
                    ["PEN"] = "PE", // Peru
                    ["PGK"] = "PG", // Papua New Guinea
                    ["PHP"] = "PH", // Philippines
                    ["PKR"] = "PK", // Pakistan
                    ["PLN"] = "PL", // Poland
                    ["PYG"] = "PY", // Paraguay

                    // Q
                    ["QAR"] = "QA", // Qatar

                    // R
                    ["RON"] = "RO", // Romania
                    ["RSD"] = "RS", // Serbia
                    ["RUB"] = "RU", // Russia
                    ["RWF"] = "RW", // Rwanda

                    // S
                    ["SAR"] = "SA", // Saudi Arabia
                    ["SBD"] = "SB", // Solomon Islands
                    ["SCR"] = "SC", // Seychelles
                    ["SDG"] = "SD", // Sudan
                    ["SEK"] = "SE", // Sweden
                    ["SGD"] = "SG", // Singapore
                    ["SHP"] = "SH", // St Helena
                    ["SLL"] = "SL", // Sierra Leone
                    ["SOS"] = "SO", // Somalia
                    ["SRD"] = "SR", // Suriname
                    ["SSP"] = "SS", // South Sudan
                    ["STN"] = "ST", // São Tomé
                    ["SYP"] = "SY", // Syria
                    ["SZL"] = "SZ", // Eswatini

                    // T
                    ["THB"] = "TH", // Thailand
                    ["TJS"] = "TJ", // Tajikistan
                    ["TMT"] = "TM", // Turkmenistan
                    ["TND"] = "TN", // Tunisia
                    ["TOP"] = "TO", // Tonga
                    ["TRY"] = "TR", // Turkey
                    ["TTD"] = "TT", // Trinidad
                    ["TWD"] = "TW", // Taiwan
                    ["TZS"] = "TZ", // Tanzania

                    // U
                    ["UAH"] = "UA", // Ukraine
                    ["UGX"] = "UG", // Uganda
                    ["USD"] = "US", // USA
                    ["UYU"] = "UY", // Uruguay
                    ["UZS"] = "UZ", // Uzbekistan

                    // V
                    ["VES"] = "VE", // Venezuela
                    ["VND"] = "VN", // Vietnam
                    ["VUV"] = "VU", // Vanuatu

                    // W
                    ["WST"] = "WS", // Samoa

                    // X
                    ["XAF"] = "CF", // Central Africa
                    ["XCD"] = "AG", // East Caribbean
                    ["XOF"] = "SN", // West Africa
                    ["XPF"] = "PF", // French Pacific

                    // Y
                    ["YER"] = "YE", // Yemen

                    // Z
                    ["ZAR"] = "ZA", // South Africa
                    ["ZMW"] = "ZM", // Zambia
                    ["ZWL"] = "ZW", // Zimbabwe

                    // Add more mappings as needed
                };

                if (currencyToCountry.TryGetValue(currencyCode, out var countryCode))
                {
                    return string.Concat(countryCode.ToUpper().Take(2).Select(c => char.ConvertFromUtf32(c + 0x1F1A5)));
                }
            }
            return "🏳"; // Default flag if not found
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class CurrencyCodeExtractor : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string rateString)
            {
                return rateString.Split(':')[0].Trim();
            }
            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }

    public class RateValueExtractor : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string rateString)
            {
                var parts = rateString.Split(':');
                if (parts.Length > 1)
                {
                    return parts[1].Trim();
                }
            }
            return string.Empty;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
