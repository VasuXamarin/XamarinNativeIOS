using Foundation;
using System;
using UIKit;
using static NativeIOS.Model.DropBoxData;

namespace NativeIOS
{
    public partial class CustomCell : UITableViewCell
    {
        public CustomCell (IntPtr handle) : base (handle)
        {
        }
        public void UpdateDropBoxData(DropBoxRow dropBoxContent)
        {

            if (dropBoxContent.Title != null)
            {
                LblTitle.Text = $"Title: {dropBoxContent.Title}";
            }
            if (dropBoxContent.Description != null)
            {
                LblDescription.Text = $"Description: {dropBoxContent.Description}";
            }
            if(dropBoxContent.ImageHref != null)
            {
                try
                {
                    if (Imageview.Image == null)
                    Imageview.Image = dropBoxContent.ImageHref.FromUrl();

                }
                catch (Exception ex)
                {
                    Imageview.Image = UIImage.FromBundle("Noimage");
                }
            }
            LblTitle.TextColor = UIColor.DarkTextColor;
            LblDescription.TextColor = UIColor.DarkTextColor;
        }
    }
    public static class CustomCellDemo
    {
        public static UIImage FromUrl(this string uri)
        {
            try
            {
                using (var url = new NSUrl(uri))
                using (var data = NSData.FromUrl(url))
                    return UIImage.LoadFromData(data);
            }
            catch (Exception ex)
            {
                return UIImage.FromBundle("Noimage");
            }
        }
    }
}