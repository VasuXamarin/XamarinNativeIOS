using Foundation;
using NativeIOS.Model;
using System;
using UIKit;

namespace NativeIOS
{
    public partial class tableCell : UITableViewCell
    {
        public tableCell (IntPtr handle) : base (handle)
        {
        }

        public void UpdateDropBoxData(DropBoxData.DropBoxRow dropBoxContent)
        {
            if (dropBoxContent.Title != null)
            {
                TitleLbl.Text = $"Title: {dropBoxContent.Title}";
            }
            if (dropBoxContent.Description != null)
            {
                DecriptionLbl.Text = $"Description: {dropBoxContent.Description}";
            }
            if (dropBoxContent.ImageHref != null)
            {
                try
                {
                    if (Imageview.Image == null)
                        Imageview.Image = dropBoxContent.ImageHref.FromUrlTableCell();

                }
                catch (Exception ex)
                {
                    Imageview.Image = UIImage.FromBundle("Noimage.jpg");
                }
            }
            TitleLbl.TextColor = UIColor.DarkTextColor;
            DecriptionLbl.TextColor = UIColor.DarkTextColor;
        }
    }
    public static class CustomTableCellDemo
    {
        public static UIImage FromUrlTableCell(this string uri)
        {
            try
            {
                using (var url = new NSUrl(uri))
                using (var data = NSData.FromUrl(url))
                    return UIImage.LoadFromData(data);
            }
            catch (Exception ex)
            {
                return UIImage.FromBundle("Noimage.jpg");
            }
        }
    }
}