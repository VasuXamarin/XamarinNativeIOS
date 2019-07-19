using System;
using System.Collections.Generic;
using NativeIOS.Model;
using UIKit;

namespace NativeIOS
{
    public class DropBoxCVS : UICollectionViewSource
    {
        private List<DropBoxData.DropBoxRow> data;

        public DropBoxCVS(List<DropBoxData.DropBoxRow> data)
        {
            this.data = data;
        }
        public override UICollectionViewCell GetCell(UICollectionView collectionView, Foundation.NSIndexPath indexPath)
        {
            var cell = (CVCell)collectionView.DequeueReusableCell("Cellid", indexPath);

            var dropBoxContent = data[indexPath.Row];

            cell.UpdateDropBoxData(dropBoxContent);

            return cell;
        }
       
        public override nint GetItemsCount(UICollectionView collectionView, nint section)
        {
            return data.Count;
        }
    }
}