using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfMultilanguageByCsvSample2
{
    [TypeConverter(typeof(GenderTypeConverter))]
    public enum Gender
    {        
        Male,       
        Female
    }
    public class GenderTypeConverter : EnumConverter
    {
        public GenderTypeConverter(Type type) : base(type) {}

        public override object ConvertTo(ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (value != null)
            {
                return Application.Current.Resources[value.ToString()];
            }
            else
            { return string.Empty; }
        }
    }    
}
