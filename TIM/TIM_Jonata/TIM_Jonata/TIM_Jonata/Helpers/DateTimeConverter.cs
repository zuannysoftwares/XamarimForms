using Newtonsoft.Json.Converters;

namespace TIM_Jonata.Helpers
{
    public class DateTimeConverter : IsoDateTimeConverter
    {
        public DateTimeConverter(string dataFormatada)
        {
            DateTimeFormat = dataFormatada;
        }
    }
}
