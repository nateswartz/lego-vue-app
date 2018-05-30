using System.Collections.Generic;
using LegoVueApp.Models;

namespace LegoVueApp.Providers
{
    public interface IWeatherProvider
    {
        List<WeatherForecast> GetForecasts();
    }
}
