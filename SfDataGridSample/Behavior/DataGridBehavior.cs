using Syncfusion.Maui.DataGrid;
using Syncfusion.Maui.DataGrid.Helper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SfDataGridSample.Behaviors
{
    public class DataGridBehavior : Behavior<SfDataGrid>
    {
        protected override void OnAttachedTo(SfDataGrid dataGrid)
        {
            dataGrid.GetVisualContainer().ScrollOwner.Scrolled += ScrollOwner_Scrolled;
            base.OnAttachedTo(dataGrid);
        }

        protected override void OnDetachingFrom(SfDataGrid dataGrid)
        {
            dataGrid.GetVisualContainer().ScrollOwner.Scrolled -= ScrollOwner_Scrolled;
            base.OnDetachingFrom(dataGrid);
        }

        private void ScrollOwner_Scrolled(object? sender, ScrolledEventArgs e)
        {
            SfDataGrid grid = (sender as DataGridScrollView).Parent as SfDataGrid;

            var visualContainer = grid.GetVisualContainer();
            var row = visualContainer.ScrollRows.GetVisibleLineAtLineIndex(grid.CurrentCell.RowIndex);

            if (row != null && row.Region == Syncfusion.Maui.GridCommon.ScrollAxis.ScrollAxisRegion.Header)
                return;

            var column = visualContainer.ScrollColumns.GetVisibleLineAtLineIndex(grid.CurrentCell.ColumnIndex);

            // Need to perform EndEdit only when current cell disappears from the view. 
            if ((row == null || column == null))
            {
                grid.EndEdit();
            }

        }
    }
}
