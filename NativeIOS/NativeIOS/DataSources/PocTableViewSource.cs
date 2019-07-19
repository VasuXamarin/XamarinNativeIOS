using System;
using System.Collections.Generic;
using Foundation;
using NativeIOS.Model;
using UIKit;

namespace NativeIOS
{
    internal class PocTableViewSource : UITableViewSource
    {
        private List<DropBoxData.DropBoxRow> data;

        public PocTableViewSource(List<DropBoxData.DropBoxRow> data)
        {
            this.data = data;
        }

        public override UITableViewCell GetCell(UITableView tableView, NSIndexPath indexPath)
        {

            var cell = (tableCell)tableView.DequeueReusableCell("Cellid", indexPath);

            var dropBoxContent = data[indexPath.Row];

            cell.UpdateDropBoxData(dropBoxContent);

            return cell;
        }

        public override nint RowsInSection(UITableView tableview, nint section)
        {
            return data.Count;
        }
    }
}