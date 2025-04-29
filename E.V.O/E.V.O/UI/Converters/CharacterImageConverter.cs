﻿using E.V.O_.Models.Characters;
using E.V.O_.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace E.V.O_.UI.Converters
{
    public class CharacterImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is string character)
            {
                return $"pack://application:,,,/Resources/Icons/{character.ToLowerInvariant()}.png";
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
