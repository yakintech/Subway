using System;
namespace Subway.UI.Models.filters
{
    public class DataNotFoundException : Exception
    {
        public DataNotFoundException(string type, object id)
            : base($"{type} türündeki {id} id değerine sahip olan obje bulunamadı! ") { }
    }
}

