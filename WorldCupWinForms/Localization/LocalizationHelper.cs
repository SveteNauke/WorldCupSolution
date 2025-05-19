using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WorldCupData.Enums;

namespace WorldCupWinForms.Localization
{
    public static class LocalizationHelper
    {
        public static void ApplyLocalization(Form form)
        {
            var manager = new ComponentResourceManager(form.GetType());
            var culture = Thread.CurrentThread.CurrentUICulture;

            ApplyResourcesToControls(form, manager, culture);
            manager.ApplyResources(form, "$this", culture);
        }

        private static void ApplyResourcesToControls(Control container, ComponentResourceManager manager, CultureInfo culture)
        {
            foreach (Control control in container.Controls)
            {
                manager.ApplyResources(control, control.Name, culture);

                if (control.HasChildren)
                {
                    ApplyResourcesToControls(control, manager, culture);
                }
            }
        }

        public static string GetCultureCode(Language language)
        {
            return language switch
            {
                Language.English => "en",
                Language.Croatian => "hr",
                _ => "en"
            };
        }

        public static void SetCulture(Language language)
        {
            var cultureCode = GetCultureCode(language);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(cultureCode);
        }
    }
}
