# How to end editing a cell when it becomes hidden from the visible region.
By default, the editing cell in the [DataGrid](https://www.syncfusion.com/maui-controls/maui-datagrid) remains in edit mode and cannot be committed while scrolling horizontally or vertically. This behavior can be addressed by utilizing the scrolled event. Please refer to the code example below.
##### xaml:
 
 ```XML
<syncfusion:SfDataGrid  ItemsSource="{Binding Employees}"
                       AutoGenerateColumnsMode="None"
                       AllowEditing="True"
                       NavigationMode="Cell"
                       SelectionMode="Single"
                       DefaultColumnWidth="155">
   <syncfusion:SfDataGrid.Columns>
       <syncfusion:DataGridTextColumn MappingName="EmployeeID"
                                      HeaderText="Employee ID" />
       <syncfusion:DataGridTextColumn MappingName="Name"
                                      HeaderText="Name" />
       <syncfusion:DataGridTextColumn MappingName="IDNumber"
                                      HeaderText="ID Number" />
   </syncfusion:SfDataGrid.Columns>

   <syncfusion:SfDataGrid.Behaviors>
       <behaviors:DataGridBehavior />
   </syncfusion:SfDataGrid.Behaviors>
   
</syncfusion:SfDataGrid> 
 ```
 
##### Behavior:
 
 ```XML
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
 ```
 

[View sample in GitHub](https://github.com/SyncfusionExamples/How-to-end-editing-a-cell-when-it-becomes-hidden-from-the-visible-region/tree/master)

Take a moment to explore this [documentation](https://help.syncfusion.com/maui/datagrid/overview), where you can find more information about Syncfusion .NET MAUI DataGrid (SfDataGrid) with code examples. Please refer to this [link](https://www.syncfusion.com/maui-controls/maui-datagrid) to learn about the essential features of Syncfusion .NET MAUI DataGrid (SfDataGrid).

##### Conclusion

I hope you enjoyed learning about How to end editing a cell when it becomes hidden from the visible region in .NET MAUI DataGrid (SfDataGrid).

You can refer to our [.NET MAUI DataGrid’s feature tour](https://www.syncfusion.com/maui-controls/maui-datagrid) page to learn about its other groundbreaking feature representations. You can also explore our [.NET MAUI DataGrid Documentation](https://help.syncfusion.com/maui/datagrid/getting-started) to understand how to present and manipulate data. 
For current customers, you can check out our .NET MAUI components on the [License and Downloads](https://www.syncfusion.com/sales/teamlicense) page. If you are new to Syncfusion, you can try our 30-day [free trial](https://www.syncfusion.com/downloads/maui) to explore our .NET MAUI DataGrid and other .NET MAUI components. 

If you have any queries or require clarifications, please let us know in the comments below. You can also contact us through our [support forums](https://www.syncfusion.com/forums), [Direct-Trac](https://support.syncfusion.com/create) or [feedback portal](https://www.syncfusion.com/feedback/maui?control=sfdatagrid), or the feedback portal. We are always happy to assist you!</sfdatagrid>

