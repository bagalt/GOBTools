Public Class ColumnManager

    Private myColumns As System.Windows.Forms.DataGridViewColumnCollection
    Private selectedItem As String
    Private myParentForm As System.Windows.Forms.Form

    Public Sub New(columns As System.Windows.Forms.DataGridViewColumnCollection, ParentForm As System.Windows.Forms.Form)

        ' This call is required by the designer.
        InitializeComponent()

        myColumns = columns
        myParentForm = ParentForm
    End Sub

    Public Property ColumnToDelete As String
        Get
            Return selectedItem
        End Get
        Set(value As String)

        End Set

    End Property

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click

    End Sub

    Private Sub btnOK_Click(sender As Object, e As EventArgs) Handles btnOK.Click

        Dim selection As Windows.Forms.ListView.SelectedListViewItemCollection
        selection = ListView1.SelectedItems

        'selectedItem = selection.Item(0).Text
        selectedItem = selection.Item(0).SubItems(1).Text

    End Sub

    Private Sub ColumnManager_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        'locate the column manager form in the center of the animate form
        Me.Location = StepperModule.LocateInCenter(myParentForm, Me)

        ' Add any initialization after the InitializeComponent() call.
        ListView1.Clear()

        'set listview options
        With ListView1
            .GridLines = True
            .HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable 'ColumnHeaderStyle.Nonclickable
            .LabelEdit = False
            .FullRowSelect = True
            .MultiSelect = False
        End With

        'create listview column header
        Dim column1Header As New System.Windows.Forms.ColumnHeader
        Dim column2Header As New System.Windows.Forms.ColumnHeader

        With column1Header
            .Text = "Column Name"
            .Width = 160
            .TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        End With

        With column2Header
            .Text = "Param Name"
            .Width = 80
            .TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        End With

        ListView1.Columns.Add(column1Header)
        ListView1.Columns.Add(column2Header)

        'load the columns in the listview
        Dim column As System.Windows.Forms.DataGridViewColumn
        Dim myItem As Windows.Forms.ListViewItem

        For Each column In myColumns
            'skip the first column in the collection
            If column.HeaderText = myColumns.Item(0).HeaderText Then
                'do not add first column to the list view, this column cannot be deleted
            Else
                myItem = ListView1.Items.Add(column.HeaderText)
                myItem.SubItems.Add(column.Name)
            End If
        Next


    End Sub



End Class