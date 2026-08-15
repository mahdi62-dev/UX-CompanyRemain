using System;

namespace APP
{
    public class HTML
    {
        public string ClassVisible(string CssClass, bool visible)
        {
            if (!String.IsNullOrEmpty(CssClass))
                CssClass = CssClass.Replace("d-none", "");

            if (visible == false)
                CssClass += " d-none";

            return CssClass;
        }

        public string ClassChange(string CssClass, string Class, bool HasExist)
        {
            if (!String.IsNullOrEmpty(CssClass))
                CssClass = CssClass.Replace(Class, "");

            if (HasExist == true)
                CssClass += " " + Class;

            return CssClass;
        }
    }
}