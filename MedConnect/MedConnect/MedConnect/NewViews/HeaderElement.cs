﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms; 

namespace MedConnect.NewViews
{
    public class HeaderElement : StackLayout 
    {
        public HeaderElement(String pageName)
        {
            var pageNameLabel = new Label
            {
                Text = pageName,
                Font = Font.SystemFontOfSize(NamedSize.Large),
                TextColor = Color.FromHex("#FFFFFF"),
                XAlign = TextAlignment.Center,
                YAlign = TextAlignment.Center
            };
            Padding = new Thickness(10, 10, 10, 10);
            HorizontalOptions = LayoutOptions.FillAndExpand;
            BackgroundColor = Color.FromHex("#006166");
            Children.Add(pageNameLabel);
        }
    }
}
