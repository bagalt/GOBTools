Public Class frmBomCompare

    Private mAssyDoc As Inventor.AssemblyDocument
    Private mAssyCompDef As Inventor.AssemblyComponentDefinition


    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.

        'check for assembly document
        'get the assembly component definition and assign to global
        Try
            mAssyDoc = g_inventorApplication.ActiveDocument
            mAssyCompDef = mAssyDoc.ComponentDefinition
        Catch
            MsgBox("Assembly document must be active")
            Me.Close()
        End Try

        'initialize list view with column headers
        InitListView()

    End Sub

    Private Sub InitListView()
        'configure list view controls 

        Dim inventorHeader1 As System.Windows.Forms.ColumnHeader = Nothing
        Dim inventorHeader2 As System.Windows.Forms.ColumnHeader = Nothing
        Dim promanHeader1 As System.Windows.Forms.ColumnHeader = Nothing
        Dim promanHeader2 As System.Windows.Forms.ColumnHeader = Nothing

        'configure inventor bom options
        With lvInventorBom
            .FullRowSelect = True
            .GridLines = True
            .HeaderStyle = Windows.Forms.ColumnHeaderStyle.Clickable
            .LabelEdit = False
            .MultiSelect = False
            .Sorting = Windows.Forms.SortOrder.Ascending
        End With
        'configure proman bom options
        With lvPromanBom
            .FullRowSelect = True
            .GridLines = True
            .HeaderStyle = Windows.Forms.ColumnHeaderStyle.Clickable
            .LabelEdit = True
            .MultiSelect = False
            .Sorting = Windows.Forms.SortOrder.Ascending
        End With

        With inventorHeader1
            .Text = "Part Number"
            .Width = 100
        End With
        With inventorHeader2
            .Text = "Qty"
            .Width = 50
        End With
        With promanHeader1
            .Text = "Part Number"
            .Width = 100
        End With
        With promanHeader2
            .Text = "Qty"
            .Width = 50
        End With

        'add column headers to listviews
        lvInventorBom.Columns.Add(inventorHeader1)
        lvInventorBom.Columns.Add(inventorHeader2)
        lvPromanBom.Columns.Add(promanHeader1)
        lvPromanBom.Columns.Add(promanHeader2)
    End Sub

    Private Sub btnLoadInventorBom_Click(sender As Object, e As EventArgs) Handles btnLoadInventorBom.Click
        'call all BOM export and load the results into the inventor bom listview
        Dim InventorParts As Collection
        mAllBOMExport.AssemblyCount(g_inventorApplication, True, "", True)
        InventorParts = mAllBOMExport.PartsList

    End Sub

    Private Sub PopulateListView(ByRef PartsList As Collection, MyList As System.Windows.Forms.ListView, TextBox As System.Windows.Forms.TextBox)
        'sub to populate the listview based on the collection passed in

        Dim part As cPartInfo
        Dim myItem As System.Windows.Forms.ListViewItem

        'add items to the listview
        For Each part In PartsList
            myItem = MyList.Items.Add(part.PartNum)
            myItem.SubItems.Add(part.Qty)
        Next
        'display total parts count
        TextBox.Text = PartsList.Count

    End Sub

    Private Sub btnInventorColor_Click(sender As Object, e As EventArgs) Handles btnInventorColor.Click
        'sub to open a color dialog and pick the color to highlight the inventor parts

    End Sub

    Private Sub btnPromanColor_Click(sender As Object, e As EventArgs) Handles btnPromanColor.Click
        'sub to open a color dialog and pick the color to highlight the proman parts

    End Sub
End Class