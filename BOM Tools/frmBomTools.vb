﻿
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms

Public Class frmBomTools

    Private ThisApplication As Inventor.Application
    'Private oCompDef As PartComponentDefinition 'reference to the part component definition
    Private mAssyDoc As Inventor.AssemblyDocument
    Private mAssyCompDef As Inventor.AssemblyComponentDefinition
    Private invApp As Inventor.Application
    Private sortCol As Integer
    Private BomExportSettings As mAllBOMExport.BomExportSettings 'settings for BOM Import collection
    Private BomCompareSettings As mAllBOMExport.BomCompareSettings 'settings for BOM compare collection
    Private startAssy As String 'holds the name of the top level assembly
    Private allowChage As Boolean

    Private colorPartNotOnList As Color
    Private colorPartQtyHigher As Color
    Private colorPartQtyLower As Color
    Private colorQtyZero As Color
    Private colorEvolutionPart As Color

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
            mAssyCompDef = mAssyDoc.ComponentDefinition
            lblVersion.Text = "v1.11"
            'Finally reset and comitted successfully.

            'define colors for row highlighting
            colorPartNotOnList = Color.DeepPink
            colorPartQtyHigher = Color.LightGray
            colorPartQtyLower = Color.MediumPurple
            colorQtyZero = Color.Goldenrod
            colorEvolutionPart = Color.Cyan

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
            InitBOMExportListView()

        Catch ex As Exception
            MsgBox("Assembly Document must be active")
        End Try

        allowChage = False

        'load the settings from the configuration file
        'bom compare tab settings
        chkBomCompIncludeBAssy.Checked = My.Settings.BTBomCompIncludeB49Assemblies
        chkBOMCompIncB39Children.Checked = My.Settings.BTBomCompIncludeB39Children
        chkBOMCompIncB45Children.Checked = My.Settings.BTBomCompIncludeB45Children
        chkBomCompIncludeCAssy.Checked = My.Settings.BTBomCompIncludeC49Assemblies
        chkBomCompShowFasteners.Checked = My.Settings.BTBomCompShowFasteners
        chkBomCompShowTLAssy.Checked = My.Settings.BTBomCompIncludeTopLevelAssy
        Me.Location = My.Settings.BTFormLocation

        'bom export tab settings
        chkBomExportAllowB49Parents.Checked = My.Settings.BTBomExportAllowBAssyParent
        chkBomExportShowFasteners.Checked = My.Settings.BTBomExportShowFasteners
        chkBOMExportShowTLAssy.Checked = My.Settings.BTBomExportIncludeTopLevelAssy

        allowChage = True

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
            .LabelEdit = False
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

        Dim bomCompHeader1 As New System.Windows.Forms.ColumnHeader
        Dim bomCompHeader2 As New System.Windows.Forms.ColumnHeader

        'configure BOM Compare Inventor BOM listview options
        With lvBomCompInventor
            .FullRowSelect = True
            .GridLines = True
            .HeaderStyle = Windows.Forms.ColumnHeaderStyle.Clickable
            .LabelEdit = False
            .MultiSelect = False
            .Sorting = Windows.Forms.SortOrder.Ascending
            .View = View.Details
        End With

        With bomCompHeader1
            .Text = "Part Number"
            .Width = 105
        End With
        With bomCompHeader2
            .Text = "Qty"
            .Width = 45
        End With

        'add column headers to listviews
        lvBomCompInventor.Columns.Add(bomCompHeader1)
        lvBomCompInventor.Columns.Add(bomCompHeader2)

    End Sub

    Private Sub InitBOMExportListView()
        'sub for initializing the BOM Export List View

        Dim bomExportHeader1 As New System.Windows.Forms.ColumnHeader
        Dim bomExportHeader2 As New System.Windows.Forms.ColumnHeader
        Dim bomExportHeader3 As New System.Windows.Forms.ColumnHeader
        Dim bomExportHeader4 As New System.Windows.Forms.ColumnHeader
        Dim bomExportHeader5 As New System.Windows.Forms.ColumnHeader
        Dim bomExportHeader6 As New System.Windows.Forms.ColumnHeader

        'configure BOM Export Inventor BOM Listview options

        With lvExportBom
            .FullRowSelect = True
            .GridLines = True
            .HeaderStyle = Windows.Forms.ColumnHeaderStyle.Clickable
            .LabelEdit = False
            .MultiSelect = False
            .Sorting = Windows.Forms.SortOrder.Ascending
            .View = View.Details
        End With

        With bomExportHeader1
            .Text = "Part Number"
            .Width = 110
        End With
        With bomExportHeader2
            .Text = "Qty"
            .Width = 40
        End With
        With bomExportHeader3
            .Text = "Parent"
            .Width = 150
        End With
        With bomExportHeader4
            .Text = "SP"
            .Width = 40
        End With
        With bomExportHeader5
            .Text = "Insp"
            .Width = 40
        End With
        With bomExportHeader6
            .Text = "Cert"
            .Width = 40
        End With

        'add column headers to listviews
        lvExportBom.Columns.Add(bomExportHeader1)
        lvExportBom.Columns.Add(bomExportHeader2)
        lvExportBom.Columns.Add(bomExportHeader3)
        lvExportBom.Columns.Add(bomExportHeader4)
        lvExportBom.Columns.Add(bomExportHeader5)
        lvExportBom.Columns.Add(bomExportHeader6)

    End Sub

    Private Sub btnLoadInventorBom_Click(sender As Object, e As EventArgs) Handles btnLoadInventorBOM.Click
        'call all BOM export and load the results into the inventor bom listview
        Dim proc As New frmProcessing

        'clear listviews
        lvBomCompInventor.Clear()
        lvExportBom.Clear()
        'initialize headers
        InitInventorListView()
        InitBOMExportListView()

        'assign the settings for all parts and new parts
        'bom compare settings
        BomCompareSettings.bBomCompIncludeBAssy = chkBomCompIncludeBAssy.Checked
        BomCompareSettings.bBomCompIncCAssy = chkBomCompIncludeCAssy.Checked
        BomCompareSettings.bBomCompIncB39Children = chkBOMCompIncB39Children.Checked
        BomCompareSettings.bBomCompIncB45Children = chkBOMCompIncB45Children.Checked
        BomCompareSettings.bBomCompShowFasteners = chkBomCompShowFasteners.Checked
        BomCompareSettings.bBomCompShowTopLevelAssy = chkBomCompShowTLAssy.Checked

        'bom export settings
        BomExportSettings.bBomExportShowB49 = chkBomExportAllowB49Parents.Checked
        BomExportSettings.bBomExportShowFasteners = chkBomExportShowFasteners.Checked
        BomExportSettings.bBomExportShowTopLevelAssy = chkBOMExportShowTLAssy.Checked

        'show the processing form
        proc.Show()
        'set the processing form owner
        proc.Owner = Me
        'set the location
        proc.Location = LocateInCenter(Me, proc)
        'disable the bom tools form to grey it out
        Me.Enabled = False

        'get the data from the assembly
        mAllBOMExport.AssemblyCount(invApp, BomExportSettings, BomCompareSettings, "")

        'close the processing form
        proc.Close()
        'enable BOM tools form again
        Me.Enabled = True

        'populate the listview with the data
        PopulateListView(mAllBOMExport.bomCompareList, lvBomCompInventor, txtNumInventorParts)
        PopulateBOMExportLV(mAllBOMExport.bomExportList, lvExportBom, txtBomImportNumParts)
        ColorList(lvBomCompInventor)
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

    Private Sub PopulateBOMExportLV(ByRef PartsList As Collection, MyList As System.Windows.Forms.ListView, TextBox As System.Windows.Forms.TextBox)
        'sub to populate the BOM Export listview based on the collection passed in

        Dim part As cPartInfo
        Dim myItem As System.Windows.Forms.ListViewItem

        'add items to the listview
        For Each part In PartsList
            myItem = MyList.Items.Add(part.PartNum)
            myItem.SubItems.Add(part.Qty)
            myItem.SubItems.Add(part.ParentAssy)
            myItem.SubItems.Add(part.ServiceCode)
            myItem.SubItems.Add(part.InspectField)
            myItem.SubItems.Add(part.Certificate)
        Next
        'display total parts count
        TextBox.Text = PartsList.Count

    End Sub

    'Private Sub btnBCExportInventorBOM_Click(sender As Object, e As EventArgs) Handles btnBCExportInventorBOM.Click
    '    'export bom button clicked
    '    'Pick file location
    '    'export BOM
    '    Dim proc As New frmProcessing

    '    'set save file dialog properties
    '    SaveFileDialog1.Filter = "Excel Documents|*.xlsx;*.xls"
    '    SaveFileDialog1.Title = "Select Location to save BOM export"
    '    SaveFileDialog1.AddExtension = True
    '    SaveFileDialog1.CheckFileExists = False
    '    SaveFileDialog1.InitialDirectory = Environment.SpecialFolder.MyComputer
    '    SaveFileDialog1.OverwritePrompt = True
    '    SaveFileDialog1.FileName = startAssy & "-BOM Compare"

    '    If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
    '        If SaveFileDialog1.FileName IsNot "" Then
    '            'show processing message
    '            proc.Show()

    '            'set the processing form owner to keep it on top of the BOM tools form
    '            proc.Owner = Me
    '            'disable the bom tools form to grey it out
    '            Me.Enabled = False
    '            'locate the processing form on the BOM tools form
    '            proc.Location = LocateInCenter(Me, proc)

    '            'create excel document
    '            If mAllBOMExport.BomCompExportExcel(SaveFileDialog1.FileName, chkBomCompViewImmediatly.Checked) Then
    '                'display results
    '                proc.Close()
    '                MsgBox(mAllBOMExport.mResults)
    '            Else
    '                proc.Close()
    '                MsgBox("No Excel Document Created")
    '            End If

    '        End If

    '    End If

    '    'enable the BOM tools form to activate it
    '    Me.Enabled = True

    'End Sub

    Private Sub btnBomExport_Click(sender As Object, e As EventArgs) Handles btnBOMExport.Click
        'handles clicking the export buton on the BOM Import tab
        Dim proc As New frmProcessing
        Dim path As String

        path = GetFilePath("-BOM Export")

        If Not path = "" Then
            'file path is not empty
            'show processing message
            proc.Show()

            'set the processing form owner to keep it on top of the BOM tools form
            proc.Owner = Me
            'disable the bom tools form to grey it out
            Me.Enabled = False
            'locate the processing form on the BOM tools form
            proc.Location = LocateInCenter(Me, proc)

            'create excel document

            If mAllBOMExport.BOMExportExcel(path, chkBomExportViewImmediately.Checked) Then
                'display results
                proc.Close()
                MsgBox(mAllBOMExport.mResults)
            Else
                proc.Close()
                MsgBox("No Excel Document Created")
            End If
        End If

        'enable the BOM tools form to activate it
        Me.Enabled = True
    End Sub

    Private Function GetFilePath(ByVal suffix As String) As String
        'opens a file dialog and prompts user for input and returns the result
        Dim proc As New frmProcessing

        'set save file dialog properties
        SaveFileDialog1.Filter = "Excel Documents|*.xlsx;*.xls"
        SaveFileDialog1.Title = "Select Location to Save Export File"
        SaveFileDialog1.AddExtension = True
        SaveFileDialog1.CheckFileExists = False
        SaveFileDialog1.InitialDirectory = Environment.SpecialFolder.MyComputer
        SaveFileDialog1.OverwritePrompt = True
        SaveFileDialog1.FileName = startAssy & suffix

        If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK Then
            Return SaveFileDialog1.FileName
        Else
            Return ""
        End If
    End Function

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

        If lvBomCompInventor.Items.Count = 0 Or lvPromanBom.Items.Count = 0 Then
            MsgBox("Both lists must be populated")
            Exit Sub
        End If

        'clear the formatting of the lists
        ClearListColor(lvBomCompInventor)
        ClearListColor(lvPromanBom)

        'compare inventor bom to proman bom
        CompareLists(lvBomCompInventor, lvPromanBom)
        'compare proman bom to inventor bom
        CompareLists(lvPromanBom, lvBomCompInventor)

    End Sub

    Sub ClearListColor(ByVal list As ListView)
        'sub to clear the backcolor formatting on a list and set it to white

        Dim item As ListViewItem

        For Each item In list.Items
            item.BackColor = Color.White
        Next

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
            'get the quantity for the part in list 1
            searchQty = CInt(searchItem.SubItems(1).Text)
            'search for the part number in the other list
            findItem = list2.FindItemWithText(searchItem.Text, False, 0, False)
            Try
                If searchQty = 0 Then
                    'color bom line with 0 qty
                    list1.Items(i).BackColor = colorQtyZero
                Else
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
                End If

            Catch ex As Exception
                'do nothing if errors, handles lists of different lengths
            End Try
            i += 1
        Next
        ColorEvolutionParts(list1, list2)
    End Sub

    Sub ColorEvolutionParts(list1 As ListView, list2 As ListView)
        'sub to color parts containing an evolution number in list1 if they are found in list 2

        Dim list1Item As ListViewItem
        Dim list2Item As ListViewItem
        Dim evolutionPart As String
        Dim evolutionNum As String
        Dim list1Qty As Integer
        Dim list2Qty As Integer
        Dim i As Integer

        i = 0
        For Each list1Item In list1.Items
            If HasEvolution(list1Item.Text) Then
                'part number has an evolution number, grab the string up to the evolution number
                evolutionPart = list1Item.Text.Substring(0, (list1Item.Text.Length - 3))
                evolutionNum = list1Item.Text.Substring(list1Item.Text.Length - 3)

                'look in list2 for a match to the evolutionPart
                For Each list2Item In list2.Items
                    'compare part numbers not including evolution number
                    If evolutionPart = list2Item.Text.Substring(0, list2Item.Text.Length - 3) Then
                        'compare full part number including evolution number
                        If list1Item.Text = list2Item.Text Then 'evolutionNum = list2Item.Text.Substring(list2Item.Text.Length - 3) Then
                            'check the quantities
                            list1Qty = CInt(list1Item.SubItems(1).Text)
                            list2Qty = CInt(list2Item.SubItems(1).Text)
                            If list1Qty = list2Qty Then
                                'item qty is equal
                            Else
                                'item qty is not equal
                                If list1Qty > list2Qty Then
                                    list1Item.BackColor = colorPartQtyHigher
                                Else
                                    list1Item.BackColor = colorPartQtyLower
                                End If
                            End If
                        Else
                            'evolution part match found, but evolution numbers are different
                            'color the part blue on list 1
                            list1.Items(i).BackColor = colorEvolutionPart
                        End If
                    End If
                Next
            End If
            i += 1
        Next

    End Sub

    Function HasEvolution(partNumber As String) As Boolean
        'function to see if the part number has an evolution number
        'looks for period in the third position from the right

        If (partNumber.Substring((partNumber.Length - 3), 1) = ".") Then
            'part number has an evolution
            'MsgBox("Part number: " & partNumber & " has an evolution number")
            Return True
        Else
            'no evolution number
            Return False
        End If

    End Function

    Private Sub frmBomTools_HelpButtonClicked(sender As Object, e As CancelEventArgs) Handles Me.HelpButtonClicked
        'show help
        'describe color coding on charts 

        Dim help As New frmBOMToolsHelp
        help.ShowDialog()
        'cancel the help event so the cursor does not have the question mark next to it
        e.Cancel = True

    End Sub

    Private Sub DeletePromanItem_click(sender As Object, e As EventArgs)
        '****NOT IMPLIMENTED YET****
        'need to add back to menu strip and figure out if this is required

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

    Private Sub IsolatePromanItem_Click(sender As Object, e As EventArgs)
        '****NOT IMPLIMENTED YET******
        'need to add Isolate back to menu strip and figure out how to actually isolate items

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

    Private Sub IsolateInspectionReqd(ByVal PartList As Collection)
        'sub to handle button click for isolating parts that are marked for inspection

        Dim myPart As cPartInfo
        Dim mySelectedObjects As Inventor.ObjectCollection
        Dim myOccs As Inventor.ComponentOccurrencesEnumerator
        Dim myDoc As Inventor.Document
        Dim occ As Inventor.ComponentOccurrence

        'create an object collection
        mySelectedObjects = ThisApplication.TransientObjects.CreateObjectCollection()

        'clear the selected objects collection
        mySelectedObjects.Clear()

        For Each myPart In PartList
            If myPart.InspectField = "Y" Then
                'get the Document of the occurrence that is marked inspection  "Y"
                myDoc = myPart.ComponentOccurrence.Definition.Document
                'look in the current assembly for all the referenced occurrences of myDoc
                myOccs = mAssyCompDef.Occurrences.AllReferencedOccurrences(myDoc)
                'itterate through all the occurrences in my occurrences and add them to the selected objects collection
                For Each occ In myOccs
                    'add to select set
                    mySelectedObjects.Add(occ)
                Next
            End If
        Next

        'clear the select set in the assembly
        mAssyDoc.SelectSet.Clear()
        'create the select set by using the collection mySeleted objects
        mAssyDoc.SelectSet.SelectMultiple(mySelectedObjects)

        'Run the isolate command 
        RunCmd("AssemblyIsolateCmd")

        'clear the select set so everything isnt highlighted
        mAssyDoc.SelectSet.Clear()

    End Sub

    Private Sub IsolateSpareParts(ByVal PartList As Collection)
        'sub to handle isolating the parts that are designated as spares

        Dim myPart As cPartInfo
        Dim mySelectedObjects As Inventor.ObjectCollection
        Dim myOccs As Inventor.ComponentOccurrencesEnumerator
        Dim myDoc As Inventor.Document
        Dim occ As Inventor.ComponentOccurrence

        'create an object collection
        mySelectedObjects = ThisApplication.TransientObjects.CreateObjectCollection()

        'clear the selected objects collection
        mySelectedObjects.Clear()

        For Each myPart In PartList
            If myPart.ServiceCode = "21" Then
                'get the Document of the occurrence that is marked spare "21"
                myDoc = myPart.ComponentOccurrence.Definition.Document
                'look in the current assembly for all the referenced occurrences of myDoc
                myOccs = mAssyCompDef.Occurrences.AllReferencedOccurrences(myDoc)
                'itterate through all the occurrences in my occurrences and add them to the selected objects collection
                For Each occ In myOccs
                    'add to select set
                    mySelectedObjects.Add(occ)
                Next
            End If
        Next

        'clear the select set in the assembly
        mAssyDoc.SelectSet.Clear()
        'create the select set by using the collection mySeleted objects
        mAssyDoc.SelectSet.SelectMultiple(mySelectedObjects)

        'Run the command 
        RunCmd("AssemblyIsolateCmd")

        'clear the select set so everything isnt highlighted
        mAssyDoc.SelectSet.Clear()

    End Sub

    Private Sub IsolateCertReqd(ByVal PartList As Collection)
        'sub to handle isolating the parts that have a certification requirement

        Dim myPart As cPartInfo
        Dim mySelectedObjects As Inventor.ObjectCollection
        Dim myOccs As Inventor.ComponentOccurrencesEnumerator
        Dim myDoc As Inventor.Document
        Dim occ As Inventor.ComponentOccurrence

        'create an object collection
        mySelectedObjects = ThisApplication.TransientObjects.CreateObjectCollection()

        'clear the selected objects collection
        mySelectedObjects.Clear()

        For Each myPart In PartList
            If myPart.Certificate = "Material" Or myPart.Certificate = "Material + Finish" Or myPart.Certificate = "Calibration" Then
                'get the Document of the occurrence that has a certificate required
                myDoc = myPart.ComponentOccurrence.Definition.Document
                'look in the current assembly for all the referenced occurrences of myDoc
                myOccs = mAssyCompDef.Occurrences.AllReferencedOccurrences(myDoc)
                'itterate through all the occurrences in my occurrences and add them to the selected objects collection
                For Each occ In myOccs
                    'add to select set
                    mySelectedObjects.Add(occ)
                Next
            End If
        Next

        'clear the select set in the assembly
        mAssyDoc.SelectSet.Clear()
        'create the select set by using the collection mySeleted objects
        mAssyDoc.SelectSet.SelectMultiple(mySelectedObjects)

        'Run the command 
        RunCmd("AssemblyIsolateCmd")

        'clear the select set so everything isnt highlighted
        mAssyDoc.SelectSet.Clear()

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

    Private Sub frmBomTools_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing

        allowChage = False

        'form closing, need to save settings
        'bom compare settings
        My.Settings.BTBomCompIncludeB49Assemblies = chkBomCompIncludeBAssy.Checked
        My.Settings.BTBomCompIncludeB39Children = chkBOMCompIncB39Children.Checked
        My.Settings.BTBomCompIncludeB45Children = chkBOMCompIncB45Children.Checked
        My.Settings.BTBomCompIncludeC49Assemblies = chkBomCompIncludeCAssy.Checked
        My.Settings.BTBomCompShowFasteners = chkBomCompShowFasteners.Checked
        My.Settings.BTBomCompIncludeTopLevelAssy = chkBomCompShowTLAssy.Checked
        My.Settings.BTFormLocation = Me.Location

        'bom export settings
        My.Settings.BTBomExportAllowBAssyParent = chkBomExportAllowB49Parents.Checked
        My.Settings.BTBomExportShowFasteners = chkBomExportShowFasteners.Checked
        My.Settings.BTBomExportIncludeTopLevelAssy = chkBOMExportShowTLAssy.Checked


        'save settings
        My.Settings.Save()

    End Sub

#Region "Sorting functionality for listviews"
    Private Sub lvInventorBom_ColumnClick(sender As Object, e As ColumnClickEventArgs) Handles lvBomCompInventor.ColumnClick
        'sub to handle sorting the inventor bom in ascending/decending order.  will toggle the state

        'determine if the column is the same as the last column clicked
        If e.Column <> sortCol Then
            'set the sort column to the new column
            sortCol = e.Column
            'set the sort order to ascending by default
            lvBomCompInventor.Sorting = SortOrder.Ascending
        Else
            'determine what the last sort order was and change it
            If lvBomCompInventor.Sorting = SortOrder.Ascending Then
                lvBomCompInventor.Sorting = SortOrder.Descending
            Else
                lvBomCompInventor.Sorting = SortOrder.Ascending
            End If
        End If

        lvBomCompInventor.ListViewItemSorter = New ListViewItemComparer(e.Column, lvBomCompInventor.Sorting)
        lvBomCompInventor.Sort()

    End Sub

    Private Sub lvPromanBom_ColumnClick(sender As Object, e As ColumnClickEventArgs) Handles lvPromanBom.ColumnClick
        'sub to handle sorting the proman bom in ascending/decending order.  will toggle the state

        'determine if the column is the same as the last column clicked
        If e.Column <> sortCol Then
            'set the sort column to the new column
            sortCol = e.Column
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

    Private Sub lvFullBOM_ColumnClick(sender As Object, e As ColumnClickEventArgs) Handles lvExportBom.ColumnClick
        'sub to handle sorting the proman bom in ascending/decending order.  will toggle the state

        'determine if the column is the same as the last column clicked
        If e.Column <> sortCol Then
            'set the sort column to the new column
            sortCol = e.Column
            'set the sort order to ascending by default
            lvExportBom.Sorting = SortOrder.Ascending
        Else
            'determine what the last sort order was and change it
            If lvExportBom.Sorting = SortOrder.Ascending Then
                lvExportBom.Sorting = SortOrder.Descending
            Else
                lvExportBom.Sorting = SortOrder.Ascending
            End If
        End If

        lvExportBom.ListViewItemSorter = New ListViewItemComparer(e.Column, lvExportBom.Sorting)
        lvExportBom.Sort()
    End Sub
#End Region

#Region "Menu strip functionality for the listviews"

    Private Sub PromanMenuStrip_Opening(sender As Object, e As CancelEventArgs) Handles PromanMenuStrip.Opening
        'check to see if the listview has items before displaying the context menu strip
        'if there is nothing in the listview, it cancels the event and does not appear
        If lvPromanBom.Items.Count = 0 Then
            e.Cancel = True
        End If
        'tempory: disable menustrip until I can figure out how to use it better
        'e.Cancel = True
    End Sub

    Private Sub InventorMenuStrip_Opening(sender As Object, e As CancelEventArgs) Handles InventorMenuStrip.Opening
        'check to see if the listview has items before displaying the context menu strip
        'if there is nothing in the listview, it cancels the event and does not appear
        If lvBomCompInventor.Items.Count = 0 Then
            e.Cancel = True
        End If
    End Sub

    Private Sub FullBomMenuStrip_Opening(sender As Object, e As CancelEventArgs) Handles BomMenuStrip.Opening
        'check to see if the listview has items before displaying the context menu strip
        'if there is nothing in the listview, it cancels the event and does not appear
        If BomMenuStrip.Items.Count = 0 Then
            e.Cancel = True
        End If
    End Sub

    Private Sub PromanLVMenuCopyItem_Click(sender As Object, e As EventArgs) Handles PromanMenuStripCOPY.Click
        If lvPromanBom.SelectedItems.Count = 0 Then
            Exit Sub
        End If

        'Copy item to clipboard
        CopyToClipboard(lvPromanBom.SelectedItems(0).Text)
    End Sub

    Private Sub InventorMenuStripCOPY_Click(sender As Object, e As EventArgs) Handles InventorMenuStripCOPY.Click
        If lvBomCompInventor.SelectedItems.Count = 0 Then
            Exit Sub
        End If

        'Copy item to clipboard
        CopyToClipboard(lvBomCompInventor.SelectedItems(0).Text)
    End Sub

    Private Sub InventorMenuStripFIND_Click(sender As Object, e As EventArgs) Handles InventorMenuStripFIND.Click
        'handles selecting find in the menu strip
        If lvBomCompInventor.SelectedItems.Count = 0 Then
            Exit Sub
        End If
        'search fpr the selected item
        SearchBox(lvBomCompInventor.SelectedItems(0).Text)
    End Sub

    Private Sub BomMenuStripCopy_Click(sender As Object, e As EventArgs) Handles BomMenuStripCopy.Click
        'handles selecting find in the menu strip
        If lvExportBom.SelectedItems.Count = 0 Then
            Exit Sub
        End If
        'Copy item to clipboard
        CopyToClipboard(lvExportBom.SelectedItems(0).Text)
    End Sub

    Private Sub BomMenuStripFIND_Click(sender As Object, e As EventArgs) Handles BomMenuStripFIND.Click
        'handles selecting find in the menu strip
        If lvExportBom.SelectedItems.Count = 0 Then
            Exit Sub
        End If
        'search fpr the selected item
        SearchBox(lvExportBom.SelectedItems(0).Text)
    End Sub
#End Region

#Region "Key Down events to handle Copy (Ctrl+C) of selected item"
    Private Sub lvInventorBom_KeyDown(sender As Object, e As KeyEventArgs) Handles lvBomCompInventor.KeyDown
        'Handles keydown event on listview.  Allows user to copy selected row (part number only)

        If e.KeyCode = Keys.C AndAlso e.Modifiers = Keys.Control Then
            'Ctrl+c selected            
            If lvBomCompInventor.SelectedItems.Count > 0 Then
                'something selected on inventor BOM
                Clipboard.Clear()
                Clipboard.SetText(lvBomCompInventor.SelectedItems(0).Text)
            End If
        End If
    End Sub

    Private Sub lvPromanBom_KeyDown(sender As Object, e As KeyEventArgs) Handles lvPromanBom.KeyDown
        'Handles keydown event on listview.  Allows user to copy selected row (part number only)

        If e.KeyCode = Keys.C AndAlso e.Modifiers = Keys.Control Then
            'Ctrl+c selected            
            If lvPromanBom.SelectedItems.Count > 0 Then
                'something selected on inventor BOM
                Clipboard.Clear()
                Clipboard.SetText(lvPromanBom.SelectedItems(0).Text)
            End If
        End If
    End Sub

    Private Sub lvFullBOM_KeyDown(sender As Object, e As KeyEventArgs) Handles lvExportBom.KeyDown
        'Handles keydown event on listview.  Allows user to copy selected row (part number only)

        If e.KeyCode = Keys.C AndAlso e.Modifiers = Keys.Control Then
            'Ctrl+c selected            
            If lvExportBom.SelectedItems.Count > 0 Then
                'something selected on inventor BOM
                Clipboard.Clear()
                Clipboard.SetText(lvExportBom.SelectedItems(0).Text)
            End If
        End If
    End Sub

#End Region

    Private Sub CopyToClipboard(ByVal copyText As String)
        'sub to copy text to the clipboard
        'Copy item to clipboard
        Clipboard.Clear()
        Clipboard.SetText(copyText)
    End Sub

    Private Sub SearchBox(ByVal searchText As String)
        'sub to use the search box by right clicking on listview item
        Dim oPane As Inventor.BrowserPane

        'get the broweser pane that supports the search box
        oPane = mAssyDoc.BrowserPanes("AmBrowserArrangement")

        Dim oSearchBox As Inventor.SearchBox
        oSearchBox = oPane.SearchBox

        'enable search box and display it in the browser pane for search text
        oSearchBox.Enabled = True
        oSearchBox.Visible = True
        oSearchBox.Search(searchText)

    End Sub

    Private Sub BomCompSettingsChanged(sender As Object, e As EventArgs) Handles chkBomCompShowTLAssy.CheckedChanged,
            chkBomCompShowFasteners.CheckedChanged, chkBomCompIncludeBAssy.CheckedChanged, chkBomCompIncludeCAssy.CheckedChanged,
            chkBOMCompIncB39Children.CheckedChanged, chkBOMCompIncB45Children.CheckedChanged

        'handles the change event for all the settings on the BOM Compare tab
        'this should trigger a reload of the inventor BOM
        If allowChage Then
            btnLoadInventorBOM.PerformClick()
        End If

    End Sub

    Private Sub BomExportSettingsChanged(sender As Object, e As EventArgs) Handles chkBOMExportShowTLAssy.CheckedChanged,
            chkBomExportAllowB49Parents.CheckedChanged, chkBomExportShowFasteners.CheckedChanged

        'handles the change event for all the settings on the BOM export Tab
        'should trigger a reload of the inventor bom
        If allowChage Then
            btnLoadInventorBOM.PerformClick()
        End If
    End Sub

    Private Sub btnIsolateSpare_Click(sender As Object, e As EventArgs) Handles btnIsolateSpare.Click
        IsolateSpareParts(mAllBOMExport.bomExportList)
    End Sub

    Private Sub btnIsolateInspect_Click(sender As Object, e As EventArgs) Handles btnIsolateInspect.Click
        IsolateInspectionReqd(mAllBOMExport.bomExportList)
    End Sub

    Private Sub btnIsolateCert_Click(sender As Object, e As EventArgs) Handles btnIsolateCert.Click
        IsolateCertReqd(mAllBOMExport.bomExportList)
    End Sub

    Private Sub btnUndoIsolate_Click(sender As Object, e As EventArgs) Handles btnUndoIsolate.Click
        RunCmd("AssemblyIsolateUndoCmd")
    End Sub
End Class