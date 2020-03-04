using System;
using System.Globalization;
using System.Windows.Data;

namespace gsdc.toolbox.resources
{
   public class MultiplyConverter : IMultiValueConverter
   {
      public object Convert(object[] values, Type targetType,
         object parameter, CultureInfo culture)
      {
         double result = 1.0;
         foreach (object v in values)
         {
            if (v is double)
               result *= (double)v;
         }

         return result;
      }

      public object[] ConvertBack(object value, Type[] targetTypes,
         object parameter, CultureInfo culture)
      {
         throw new Exception("Not implemented");
      }
   }
}