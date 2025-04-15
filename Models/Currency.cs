
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ForexApp.Models
{
    public record Currency(string Code, string Name, string Symbol, string FlagUrl)
    {
        public string DisplayString => $"{FlagUrl} {Code} - {Name} ({Symbol})";
    };

}
