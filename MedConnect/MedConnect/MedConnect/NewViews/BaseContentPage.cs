using System;
using Xamarin.Forms;

namespace MedConnect
{
	public abstract class BaseContentPage : ContentPage
	{
		protected ActivityIndicator CreateLoadingIndicator()
		{
			var loadingIndicator = new ActivityIndicator {
                Color = Color.Blue,
				Scale = 2
			};

			loadingIndicator.SetBinding (ActivityIndicator.IsVisibleProperty, "IsLoading");
			loadingIndicator.SetBinding (ActivityIndicator.IsRunningProperty, "IsLoading");

			return loadingIndicator;
		}

		protected RelativeLayout CreateLoadingIndicatorRelativeLayout(View content)
		{
			var overlay = new RelativeLayout()
			{
				HorizontalOptions = LayoutOptions.FillAndExpand,
				VerticalOptions = LayoutOptions.FillAndExpand
			};
			var loadingIndicator = CreateLoadingIndicator();
			overlay.Children.Add(content, Constraint.Constant(0), Constraint.Constant(0));
			overlay.Children.Add(loadingIndicator,
				Constraint.RelativeToParent((parent) => { return (parent.Width / 2) - 16; }),
				Constraint.RelativeToParent((parent) => { return (parent.Height / 2) - 16; }));
			return overlay;
		}

		protected AbsoluteLayout CreateLoadingIndicatorAbsoluteLayout(View content)
		{
			var overlay = new AbsoluteLayout();
			var loadingIndicator = CreateLoadingIndicator();
			AbsoluteLayout.SetLayoutFlags(content, AbsoluteLayoutFlags.PositionProportional);
			AbsoluteLayout.SetLayoutBounds(content, new Rectangle(0f, 0f, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
			AbsoluteLayout.SetLayoutFlags(loadingIndicator, AbsoluteLayoutFlags.PositionProportional);
			AbsoluteLayout.SetLayoutBounds(loadingIndicator, new Rectangle(0.5, 0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
			overlay.Children.Add(content);
			overlay.Children.Add(loadingIndicator);
			return overlay;
		}

	
	}
}

