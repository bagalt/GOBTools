
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

Public Class frmBomTools

    Private ThisApplication As Inventor.Application
    'Private oCompDef As PartComponentDefinition 'reference to the part component definition
    Private mAssyDoc As Inventor.AssemblyDocument
    Private mAssyCompDef As Inventor.AssemblyComponentDefinition
    Private invApp As Inventor.Application
    Private inventorSortCol As Integer
    Private promanSortCol As Integer
    Private BomImportSettings As mAllBOMExport.BomImportSettings 'settings for BOM Import collection
    Private PartCreateSettings As mAllBOMExport.PartCreateSettings 'settings for Part Create collection
    Private BomCompareSettings As mAllBOMExport.BomCompareSettings 'settings for BOM compare collection
    Private startAssy As String 'holds the name of the top level assembly

    Private colorPartNotOnList As Color
    Private colorPartQtyHigher As Color
    Private colorPartQtyLower As Color
    Private colorQtyZero As Color

    Public Sub New(InvApp As Inventor.Application)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ThisApplication = InvApp

        'check for asembly document
        Try
            'Assign the assembly document
            mAssyDoc = g_inventorApplication.ActiveDocument
            'get the top level assembly document name
            startAssy = mAssyDoc.PropertySets.Item("Design Tracking Properties").Item("Part Number").Value
            lblVersion.Text = "v0.2"

            'define colors for row highlighting
            colorPartNotOnList = Color.DeepPink
            colorPartQtyHigher = Color.LightGray
            colorPartQtyLower = Color.MediumPurple
            colorQtyZero = Color.Goldenrod
        Catch
            MsgBox("Assembly document must be active")
            Me.Close()
        End Try

    End Sub

    Private Sub frmBomCompare_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        invApp = GetObject(, "Inventor.Application")
        'these two lines tie the form window to the inventor window
        'needed to hide the form and then apply the show command for it to work correctly
        Me.Visible = False
        Me.Show(New WindowWrapper(invApp.MainFrameHWND))

        Try
            mAssyDoc = invApp.ActiveDocument
            InitInventorListView()
            InitPromanListView()

        Catch ex As Exception
            MsgBox("Assembly Document must be active")
        End Try

    End Sub

    Private Sub InitPromanListView()
        'sub to initialize the proman listview with column headers and options

        Dim promanHeader1 As New System.Windows.Forms.ColumnHeader
        Dim promanHeader2 As New System.Windows.Forms.ColumnHeader

        'configure proman bom options
        With lvPromanBom
            .FullRowSelect = True
            .GridLines = True
            .HeaderStyle = Windows.Forms.ColumnHeaderStyle.Clickable
            .LabelEdit = True
            .MultiSelect = False
            .Sorting = Windows.Forms.SortOrder.Ascending
            .View = View.Details
        End With

        With promanHeader1
            .Text = "Part Number"
            .Width = 105
        End With
        With promanHeader2
            .Text = "Qty"
            .Width = 45
        End With

        'add column headers to listview
        lvPromanBom.Columns.Add(promanHeader1)
        lvPromanBom.Columns.Add(promanHeader2)

    End Sub

    Private Sub InitInventorListView()
        'configure list view controls 

        Dim inventorHeader1 As New System.Windows.Forms.ColumnHeader
        Dim inventorHeader2 As New System.Windows.Forms.ColumnHeader

        'configure inventor bom options
        With lvInventorBom
            .FullRowSelect = True
            .GridLines = True
            .HeaderStyle = Windows.Forms.ColumnHeaderStyle.Clickable
            .LabelEdit = False
            .MultiSelect = False
            .Sorting = Windows.Forms.SortOrder.Ascending
            .View = View.Details
        End With

        With inventorHeader1
            .Text = "Part Number"
            .Width = 105
        End With
        With inventorHeader2
            .Text = "Qty"
            .Width = 45
        End With

        'add column headers to listviews
        lvInventorBom.Columns.Add(inventorHeader1)
        lvInventorBom.Columns.Add(inventorHeader2)

    End Sub

    Private Sub btnLoadInventorBom_Click(sender As Object, e As EventArgs) Handles btnLoadInventorBom.Click
        'call all BOM export and load the results into the inventor bom listview
        Dim proc As New frmProcessing

        'clear listview
        lvInventorBom.Clear()
        'initialize headers
        InitInventorListView()

        'assign the settings for all parts and new parts
        BomImportSettings.bBomImportIncBassy = chkBomImportIncludeBAssy.Checked
        PartCreateSettings.bPartCreatIncBassy = chkPartCreateIncludeBAssy.Checked
        BomCompareSettings.bBomCompIncBassy = chkBomCompIncludeBAssy.Checked

        'show the processing form
        proc.Show()
        'set the processing form owner
        proc.Owner = Me
        'set the location
        proc.Location = LocateInCenter(Me, proc)
        'disable the bom tools form to grey it out
        Me.Enabled = False

        'get the data from the assembly
        mAllBOMExport.AssemblyCount(invApp, BomImportSettings, PartCreateSettings, BomCompareSettings, "")

        'close the processing form
        proc.Close()
        'enable BOM tools form again
        Me.Enabled = True

        'populate the listview with the data
        PopulateListView(mAllBOMExport.PartsList, lvInventorBom, txtNumInventorParts)
        ColorList(lvInventorBom)
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

    Private Sub lvInventorBom_ColumnClick(sender As Object, e As ColumnClickEventArgs) Handles lvInventorBom.ColumnClick
        'sub to handle sorting the inventor bom in ascending/decending order.  will toggle the state

        'determine if the column is the same as the last column clicked
        If e.Column <> inventorSortCol Then
            'set the sort column to the new column
            inventorSortCol = e.Column
            'set the sort order to ascending by default
            lvInventorBom.Sorting = SortOrder.Ascending
        Else
            'determine what the last sort order was and change it
            If lvInventorBom.Sorting = SortOrder.Ascending Then
                lvInventorBom.Sorting = SortOrder.Descending
            Else
                lvInventorBom.Sorting = SortOrder.Ascending
            End If
        End If

        lvInventorBom.ListViewItemSorter = New ListViewItemComparer(e.Column, lvInventorBom.Sorting)
        lvInventorBom.Sort()

    End Sub

    Private Sub lvPromanBom_ColumnClick(sender As Object, e As ColumnClickEventArgs) Handles lvPromanBom.ColumnClick
        'sub to handle sorting the proman bom in ascending/decending order.  will toggle the state

        'determine if the column is the same as the last column clicked
        If e.Column <> promanSortCol Then
            'set the sort column to the new column
            promanSortCol = e.Column
            'set the sort order to ascending by default
            lvPromanBom.Sorting = SortOrder.Ascending
        Else
            'determine what the last sort order was and change it
            If lvPromanBom.Sorting = SortOrder.Ascending Then
                lvPromanBom.Sorting = SortOrder.Descending
            Else
                lvPromanBom.Sorting = SortOrder.Ascending
            End If
        End If

        lvPromanBom.ListViewItemSorter = New ListViewItemComparer(e.Column, lvPromanBom.Sorting)
        lvPromanBom.Sort()
    End Sub

    Private Sub btnExportBOM_Click(sender As Object, e As EventArgs) Handles btnExportBOM.Click
        'export bom button clicked
        'Pick file location
        'export BOM
        Dim proc As New frmProcessing

        'set save file dialog properties
        SaveFileDialog1.Filter = "Excel Documents|*.xlsx;*.xls"
        SaveFileDialog1.Title = "Select Location to save BOM export"
        SaveFileDialog1.AddExtension = True
        SaveFileDialog1.CheckFileExists = False
        SaveFileDialog1.InitialDirectory = Environment.SpecialFolder.MyComputer
        SaveFileDialog1.OverwritePrompt = True
        SaveFileDialog1.FileName = startAssy & "-Export"

        If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            If SaveFileDialog1.FileName IsNot "" Then
                'show processing message
                proc.Show()

                'set the processing form owner to keep it on top of the BOM tools form
                proc.Owner = Me
                'disable the bom tools form to grey it out
                Me.Enabled = False
                'locate the processing form on the BOM tools form
                proc.Location = LocateInCenter(Me, proc)

                'create excel document
                If mAllBOMExport.CreateExcelDoc(SaveFileDialog1.FileName) Then
                    'display results
                    proc.Close()
                    MsgBox(mAllBOMExport.mResults)
                Else
                    proc.Close()
                    MsgBox("No Excel Document Created")
                End If

            End If

        End If

        'enable the BOM tools form to activate it
        Me.Enabled = True

    End Sub

    Private Function LocateInCenter(ByVal parent As Form, ByVal child As Form) As Point
        'function to find the center point of the parent form 
        'and locate the child form in the center of the parent
        'returns the top left location the child should be on the parent

        Dim parentCenter As Point

        'calculate the center locaton of the parent form
        parentCenter.X = Me.Location.X + (Me.Width / 2)
        parentCenter.Y = Me.Location.Y + (Me.Height / 2)
        'calculate the top left point of the child form
        LocateInCenter.X = parentCenter.X - (child.Width / 2)
        LocateInCenter.Y = parentCenter.Y - (child.Height / 2)

        Return LocateInCenter

    End Function

    Private Sub btnLoadPromanBom_Click(sender As Object, e As EventArgs) Handles btnLoadPromanBom.Click
        'Load Proman BOM into listview

        Dim path As String
        Dim proc As New frmProcessing

        'clear proman listview
        lvPromanBom.Clear()
        'initialize proman listview headers
        InitPromanListView()

        'get file path of selected excel document
        path = ExcelTools.GetPath
        If path <> "" Then
            Dim PartCollection As Collection
            Dim collPromanParts As New Collection 'collection to hold all the parts in the expedite all report

            'show the processing form
            proc.Show()
            'set the processing form owner
            proc.Owner = Me
            'set the location
            proc.Location = LocateInCenter(Me, proc)
            'disable the bom tools form to grey it out
            Me.Enabled = False

            'read excel document and load results into proman parts collection
            PartCollection = ExcelTools.ExcelToPartCollection(path, collPromanParts)

            'close the processing form
            proc.Close()
            'enable BOM tools form again
            Me.Enabled = True

            'load collection into listview
            PopulateListView(PartCollection, lvPromanBom, txtNumPromanParts)
            ColorList(lvPromanBom)
        End If

    End Sub

    Private Sub btnRunCompare_Click(sender As Object, e As EventArgs) Handles btnRunCompare.Click
        'run the comparison between the two listview boxes

        If lvInventorBom.Items.Count = 0 Or lvPromanBom.Items.Count = 0 Then
            MsgBox("Both lists must be populated")
            Exit Sub
        End If

        'compare inventor bom to proman bom
        CompareLists(lvInventorBom, lvPromanBom)
        'compare proman bom to inventor bom
        CompareLists(lvPromanBom, lvInventorBom)

    End Sub

    Sub ColorList(ByVal list As ListView)
        'sub to color a list
        'colors 0 Qty parts 

        Dim item As ListViewItem

        For Each item In list.Items
            If CInt(item.SubItems(1).Text) = 0 Then
                'color the row 
                item.BackColor = colorQtyZero
            End If
        Next

    End Sub

    Sub CompareLists(ByVal list1 As ListView, ByVal list2 As ListView)
        'compares list1 against list2 and applies colors to the items accordingly

        'see if items in the inventor BOM are in the Proman BOM
        'check for part number and quantity
        Dim i As Integer
        Dim searchItem As ListViewItem
        Dim findItem As ListViewItem
        Dim searchQty As Integer
        Dim findQty As Integer

        i = 0
        'search through each item in list1 to see if it is in list 2
        For Each searchItem In list1.Items
            searchQty = CInt(searchItem.SubItems(1).Text)
            findItem = list2.FindItemWithText(searchItem.Text, False, 0, False)
            Try
                If Not findItem Is Nothing Then
                    'item found check quantity
                    findQty = CInt(list2.Items(findItem.Index).SubItems(1).Text)
                    If searchQty <> findQty Then
                        'quantity does not match, apply appropriate color
                        If searchQty > findQty Then
                            'qty higher on list1 BOM
                            list1.Items(i).BackColor = colorPartQtyHigher
                        Else
                            'qty lower on list1 bom
                            list1.Items(i).BackColor = colorPartQtyLower
                        End If
                    End If
                Else
                    'item from list1 not found in list2
                    list1.Items(i).BackColor = colorPartNotOnList
                End If
            Catch ex As Exception
                'do nothing if errors, handles lists of different lengths
            End Try
            i += 1
        Next
        ColorList(list1)
    End Sub

    Private Sub frmBomTools_HelpButtonClicked(sender As Object, e As CancelEventArgs) Handles Me.HelpButtonClicked
        'show help
        'describe color coding on charts 

        Dim help As New frmBOMToolsHelp
        help.ShowDialog()
        'cancel the help event so the cursor does not have the question mark next to it
        e.Cancel = True

    End Sub

    Private Sub DeletePromanItem_click(sender As Object, e As EventArgs) Handles PromanLVMenuDeleteItem.Click
        'sub that handles deleting items of the proman listview when right clicked and selected
        'adds a confirmation dialog

        Dim result As Integer
        result = MessageBox.Show("Do you really want to delete " & lvPromanBom.SelectedItems(0).Text & "?", "Confirm Delete", MessageBoxButtons.OKCancel)

        If result = DialogResult.Cancel Then
            'nothing deleted
        ElseIf result = DialogResult.OK Then
            'delete item from listview and recalculate num proman parts
        End If

    End Sub

    Private Sub IsolatePromanItem_Click(sender As Object, e As EventArgs) Handles PromanLVMenuIsolateItem.Click
        'sub that handles isolating items of the proman listview when right clicked and selected
        'adds a confirmation dialog

        Dim result As Integer
        result = MessageBox.Show("Do you really want to Isolate " & lvPromanBom.SelectedItems(0).Text & "?", "Confirm Isolate", MessageBoxButtons.OKCancel)

        If result = DialogResult.Cancel Then
            'nothing deleted
        ElseIf result = DialogResult.OK Then
            'isolate item in assembly
            'need to search for occurrence and 
            'may be able to use "FindCmd" command
            'may be able to use all leaf occurrences and select the matching occurrences then isolate those
        End If

    End Sub

    Private Sub PromanMenuStrip_Opening(sender As Object, e As CancelEventArgs) Handles PromanMenuStrip.Opening
        'check to see if the listview has items before displaying the context menu strip
        'if there is nothing in the listview, it cancels the event and does not appear
        If lvPromanBom.Items.Count = 0 Then
            e.Cancel = True
        End If
        'tempory: disable menustrip until I can figure out how to use it better
        e.Cancel = True
    End Sub

    Private Sub RunCmd(ByVal cmd As String)
        'sub to run a command through command manager

        'define and get the command manager object
        Dim oCmdManager As Inventor.CommandManager
        oCmdManager = invApp.CommandManager

        'get control definition for the line command
        Dim oControlDef As Inventor.ControlDefinition
        oControlDef = oCmdManager.ControlDefinitions.Item(cmd)
        'execute the command
        oControlDef.Execute()

    End Sub

End Class