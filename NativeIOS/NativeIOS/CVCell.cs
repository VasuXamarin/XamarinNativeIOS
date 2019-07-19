using Foundation;
using NativeIOS.Model;
using System;
using UIKit;

namespace NativeIOS
{
    public partial class CVCell : UICollectionViewCell
    {
        public CVCell (IntPtr handle) : base (handle)
        {
        }

        public void UpdateDropBoxData(DropBoxData.DropBoxRow dropBoxContent)
        {
            if (dropBoxContent.Title != null)
            {
                Title.Text = $"Title: {dropBoxContent.Title}";
            }
            if (dropBoxContent.Description != null)
            {
                Description.Text = $"Description: {dropBoxContent.Description}";
            }
            if (dropBoxContent.ImageHref != null)
            {
                try
                {
                    if (Imageview.Image == null)
                        Imageview.Image = dropBoxContent.ImageHref.FromCollectionViewUrl();

                }
                catch (Exception ex)
                {
                    Imageview.Image = UIImage.FromBundle("Defaultimg");
                }
            }
            Title.TextColor = UIColor.DarkTextColor;
            Description.TextColor = UIColor.DarkTextColor;
        }
    }
    public static class CustomCVCellDemo
    {
        public static UIImage FromCollectionViewUrl(this string uri)
        {
            try
            {
                using (var url = new NSUrl(uri))
                using (var data = NSData.FromUrl(url))
                    return UIImage.LoadFromData(data);
            }
            catch (Exception ex)
            {
                return UIImage.FromBundle("Defaultimg");
            }
        }
    }
}