Public Class ColumnManager

    Private myColumns As System.Windows.Forms.DataGridViewColumnCollection
    Private selectedItem As String

    Public Sub New(columns As System.Windows.Forms.DataGridViewColumnCollection)

        ' This call is required by the designer.
        InitializeComponent()

        myColumns = columns

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

        selectedItem = selection.Item(0).Text

    End Sub

    Private Sub ColumnManager_Shown(sender As Object, e As EventArgs) Handles Me.Shown
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
        Dim columnHeader As New System.Windows.Forms.ColumnHeader

        With columnHeader
            .Text = "Column Names"
            .Width = 100
            .TextAlign = System.Windows.Forms.HorizontalAlignment.Left
        End With

        ListView1.Columns.Add(columnHeader)

        'load the columns in the listview
        Dim column As System.Windows.Forms.DataGridViewColumn

        For Each column In myColumns
            'skip the first column in the collection
            If column.HeaderText = myColumns.Item(0).HeaderText Then
                'do not add first column to the list view, this column cannot be deleted
            Else
                ListView1.Items.Add(column.HeaderText)
            End If
        Next


    End Sub



End Class