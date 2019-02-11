Imports Inventor
Imports System.ComponentModel
Imports System.Windows.Forms

Public Class frmHoleMaker

    Private oFace As Inventor.Face
    Private WithEvents oInteraction As InteractionEvents
    Private WithEvents oSelect As SelectEvents
    Private blTemplateSelected As Boolean   'indicates a selection has been made for the hole type
    Private blTolSelected As Boolean    'indicates a selection has been made for the tolerance
    Private oCompDef As PartComponentDefinition 'reference to the part component definition
    Private ThisApplication As Inventor.Application

    'names for the mikron standard hole templates
    Private strMikronHoleStdName As String = "Ansi Metric Profile AMMDE"
    Private strMikronThreadTypeName As String = "ISO Metric Mikron"

    Public Sub New(InvApp As Inventor.Application)

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        ThisApplication = InvApp

        'check for part document
        Try
            'assign the part component definition
            Dim PartDoc As Inventor.PartDocument
            PartDoc = g_inventorApplication.ActiveDocument
            oCompDef = PartDoc.ComponentDefinition
            lblVersion.Text = "v1.0"
        Catch
            MsgBox("Part document must be active")
            Me.Close()
        End Try

    End Sub

    Private Sub frmHoleMaker_Shown(sender As Object, e As EventArgs) Handles Me.Shown

        'create interaction object
        oInteraction = g_inventorApplication.CommandManager.CreateInteractionEvents
        'connect to select events
        oSelect = oInteraction.SelectEvents

        oSelect.AddSelectionFilter(SelectionFilterEnum.kPartFaceFilter)
        oSelect.SingleSelectEnabled = True 'only enable selection of one item
        oInteraction.Start() 'start selection process

        blTemplateSelected = False
        blTolSelected = False

        'set values for cmbTemplate combo box        
        With cmbTemplate
            'add items to template combobox
            .Items.Add("Choose Template")
            .Items.Add("MPG+ 25 Finger")
            .Items.Add("MPG+ 32 Finger")
            .Items.Add("MPG+ 40 Finger")
            .Items.Add("MPG+ 25 Pneu")
            .Items.Add("MPG+ 32 Pneu")
            .Items.Add("MPG+ 40 Pneu")
            .Items.Add("BAG 40mm")
            .Items.Add("BAG 55mm")
            .Items.Add("BAG 75mm A")
            .Items.Add("Escapement Support")
            .Items.Add("S4085.0006.01")
            .Items.Add("S38.14974.00")
        End With

        'set the default text for the template box
        cmbTemplate.Text = cmbTemplate.Items(0)

        'set values for cmbTolerance combo box
        With cmbTolerance
            .Items.Add("No Tolerance")
            .Items.Add("H7 - Slip")
            .Items.Add("P7 - Press")
        End With

        'set the default text for the tolerance box
        cmbTolerance.Text = cmbTolerance.Items(0)

        'disable flipped until selection made
        chkFlip.Enabled = False
        chkThreaded.Enabled = False

    End Sub

    Private Sub oInteraction_OnTerminate() Handles oInteraction.OnTerminate
        'event to handle escaping from the selection task
        oInteraction.Stop()
        oSelect = Nothing
        oInteraction = Nothing
        Me.Close()
    End Sub

    Private Sub oSelect_OnSelect(JustSelectedEntities As ObjectsEnumerator, SelectionDevice As SelectionDeviceEnum, ModelPosition As Point, ViewPosition As Point2d, View As Inventor.View) Handles oSelect.OnSelect
        'on slect update the text boxes with the values if they are the correct type

        'On Error Resume Next
        If JustSelectedEntities.Item(1).Type = Inventor.ObjectTypeEnum.kFaceObject Then '67119408 face selected
            oFace = JustSelectedEntities.Item(1)
            'If blTypeSelected = True And blTolSelected = True Then    

            Select Case cmbTemplate.Text
                Case "MPG+ 25 Finger", "MPG+ 32 Finger", "MPG+ 40 Finger"
                    If blTemplateSelected = True Then
                        MPGFinger(chkFlip.Checked, chkThreaded.Checked, oFace, ModelPosition)
                    End If
                Case "MPG+ 25 Pneu", "MPG+ 32 Pneu", "MPG+ 40 Pneu"
                    If blTemplateSelected = True Then
                        MPGPneu(chkFlip.Checked, oFace, ModelPosition)
                    End If
                Case "BAG 40mm", "BAG 55mm", "BAG 75mm A"
                    If blTemplateSelected = True Then
                        BagSlide(oFace, ModelPosition)
                    End If
                Case "Escapement Support"
                    If blTemplateSelected = True Then
                        EscapementPattern(oFace, ModelPosition)
                    End If
                Case "S4085.0006.01"
                    If blTemplateSelected = True Then
                        slideBlock(oFace, ModelPosition)
                    End If
                Case "S38.14974.00"
                    If blTemplateSelected = True Then
                        NotchedDovetail(oFace, ModelPosition)
                    End If
                Case Else
                    MsgBox("A Template must be selected")
            End Select

        End If
    End Sub

    Private Sub MPGFinger(flip As Boolean, threaded As Boolean, oFace As Face, modPos As Point)
        Dim width As Double
        Dim height As Double
        Dim dowelDia As Double
        Dim clearanceHole As Double
        Dim oHoleTapInfo As HoleTapInfo = Nothing 'variable for tapped hole information
        Dim sketchName As String = ""
        Dim screwFeatName As String = ""
        Dim dowelFeatName As String = ""

        Select Case cmbTemplate.Text
            Case "MPG+ 25 Finger"
                width = 0.6
                height = 0.4
                dowelDia = 0.15
                clearanceHole = 0.45
                sketchName = "MPG+ 25 Finger"
                screwFeatName = "MPG+25 Screw Holes"
                dowelFeatName = "MPG+25 Dowel Holes"
                oHoleTapInfo = oCompDef.Features.HoleFeatures.CreateTapInfo(True, strMikronThreadTypeName, "M3x0.5", "6H", True)
            Case "MPG+ 32 Finger"
                width = 0.8
                height = 0.5
                dowelDia = 0.2
                clearanceHole = 0.55
                sketchName = "MPG+32 Finger"
                screwFeatName = "MPG+32 Screw Holes"
                dowelFeatName = "MPG+32 Dowel Holes"
                oHoleTapInfo = oCompDef.Features.HoleFeatures.CreateTapInfo(True, strMikronThreadTypeName, "M4x0.7", "6H", True)
            Case "MPG+ 40 Finger"
                width = 1
                height = 0.6
                dowelDia = 0.25
                clearanceHole = 0.55
                sketchName = "MPG+ 40 Finger"
                screwFeatName = "MPG+40 Screw Holes"
                dowelFeatName = "MPG+40 Dowel Holes"
                oHoleTapInfo = oCompDef.Features.HoleFeatures.CreateTapInfo(True, strMikronThreadTypeName, "M4x0.7", "6H", True)
            Case Else
                MsgBox("Unknown selection for MPG+ Fingers")
        End Select

        'Start transaction to wrap process into a single undo
        Dim oTrans As Transaction
        oTrans = ThisApplication.TransactionManager.StartTransaction(ThisApplication.ActiveDocument, "MPG Finger Holes")

        'set reference to transient geometry object
        Dim tg As TransientGeometry
        tg = ThisApplication.TransientGeometry

        'create a sketch to contain hole points
        Dim oSketch As PlanarSketch
        oSketch = oCompDef.Sketches.Add(oFace, False) 'creates sketch on selected plane

        'defer updates to sketch to speed things up
        oSketch.DeferUpdates = True

        'get model position point in the sketch coordinate system
        Dim myPoint As Point2d
        myPoint = oSketch.ModelToSketchSpace(modPos)

        'make rectangle using three-point method
        Dim oRectangleLines As SketchEntitiesEnumerator
        oRectangleLines = oSketch.SketchLines.AddAsThreePointRectangle(tg.CreatePoint2d(myPoint.X, myPoint.Y), tg.CreatePoint2d(myPoint.X + width, myPoint.Y), tg.CreatePoint2d(myPoint.X + width, myPoint.Y + height))
        'make central line
        Dim centerLine As SketchLine
        centerLine = oSketch.SketchLines.AddByTwoPoints(oSketch.SketchLines.Item(3).EndSketchPoint, oSketch.SketchLines.Item(1).EndSketchPoint)
        centerLine.Construction = True

        'make all the lines construction
        Dim line As SketchEntity
        For Each line In oRectangleLines
            line.Construction = True
        Next line

        'get reference to dimension constraints and add dimensions
        Dim dimConstraints As DimensionConstraints
        dimConstraints = oSketch.DimensionConstraints
        dimConstraints.AddOffset(oSketch.SketchLines.Item(1), oSketch.SketchLines.Item(3), tg.CreatePoint2d(myPoint.X - 0.3, myPoint.Y + height * 0.5), False)
        dimConstraints.AddOffset(oSketch.SketchLines.Item(2), oSketch.SketchLines.Item(4), tg.CreatePoint2d(myPoint.X + width * 0.5, myPoint.Y - 0.3), False)

        'mark endpoints and midpoints as hole centers
        'Dim bagLine As SketchLine
        Dim oDowelHoleCenters As ObjectCollection
        Dim oScrewHoleCenters As ObjectCollection
        oScrewHoleCenters = ThisApplication.TransientObjects.CreateObjectCollection
        oDowelHoleCenters = ThisApplication.TransientObjects.CreateObjectCollection

        If flip = True Then
            'mark alternate holes as hole centers
            oDowelHoleCenters.Add(oSketch.SketchLines.Item(1).StartSketchPoint) 'add to dowel hole collection
            oDowelHoleCenters.Add(oSketch.SketchLines.Item(3).StartSketchPoint)
            oSketch.SketchLines.Item(1).StartSketchPoint.HoleCenter = True 'mark as hole center
            oSketch.SketchLines.Item(3).StartSketchPoint.HoleCenter = True 'mark as hole center
            oScrewHoleCenters.Add(oSketch.SketchPoints.Add(centerLine.Geometry.MidPoint, True)) 'need midpoint as sketch point
        Else
            'mark holes as hole centers for dowels and screw
            oDowelHoleCenters.Add(oSketch.SketchLines.Item(1).EndSketchPoint)
            oDowelHoleCenters.Add(oSketch.SketchLines.Item(3).EndSketchPoint)
            oSketch.SketchLines.Item(1).EndSketchPoint.HoleCenter = True
            oSketch.SketchLines.Item(3).EndSketchPoint.HoleCenter = True
            oScrewHoleCenters.Add(oSketch.SketchPoints.Add(centerLine.Geometry.MidPoint, True)) 'need midpoint as sketch point
        End If

        'constrain midpoint to line
        Dim geomConstraints As GeometricConstraints
        geomConstraints = oSketch.GeometricConstraints
        'geomConstraints.AddMidpoint(oScrewHoleCenters(1), oSketch.SketchLines.Item(5))
        geomConstraints.AddMidpoint(oScrewHoleCenters(1), centerLine)

        'defer updates to sketch to speed things up
        oSketch.DeferUpdates = False

        'create definitions for screw and dowel placements, then create holes
        Dim oScrewPlacement As SketchHolePlacementDefinition
        Dim oDowelPlacement As SketchHolePlacementDefinition
        oScrewPlacement = oCompDef.Features.HoleFeatures.CreateSketchPlacementDefinition(oScrewHoleCenters)
        oDowelPlacement = oCompDef.Features.HoleFeatures.CreateSketchPlacementDefinition(oDowelHoleCenters)

        'define hole feature for screw holes, this identifies the hole feature that is to be created
        Dim screwHoleFeat As HoleFeature
        'define hole feature for dowel holes, identifies the hole feature that is to be created
        Dim dowelHoleFeat As HoleFeature
        'define the current number of hole features
        Dim numHoleFeatures As Integer
        numHoleFeatures = oCompDef.Features.HoleFeatures.Count

        'create screw clearance holes or threaded hole
        If threaded = True Then
            screwHoleFeat = oCompDef.Features.HoleFeatures.AddDrilledByThroughAllExtent(oScrewPlacement, oHoleTapInfo, Inventor.PartFeatureExtentDirectionEnum.kPositiveExtentDirection) 'tapped hole
        Else
            screwHoleFeat = oCompDef.Features.HoleFeatures.AddDrilledByThroughAllExtent(oScrewPlacement, clearanceHole, Inventor.PartFeatureExtentDirectionEnum.kPositiveExtentDirection)
        End If
        'Name screw features
        screwHoleFeat.Name = screwFeatName & numHoleFeatures + 1


        'create dowel holes
        dowelHoleFeat = oCompDef.Features.HoleFeatures.AddDrilledByThroughAllExtent(oDowelHoleCenters, dowelDia, Inventor.PartFeatureExtentDirectionEnum.kPositiveExtentDirection)
        'name dowel hole feature
        dowelHoleFeat.Name = dowelFeatName & numHoleFeatures + 2

        'add tolerance to dowel hole features
        AddTol(dowelHoleFeat)
        'color faces of holes
        ColorHoles(dowelHoleFeat)

        'rotate by rotation angle if not 0, or set a constraint to fully constrain sketch
        If numRotationAngle.Value <> 0 Then
            RotateSketch(oSketch, oSketch.SketchLines.Item(5).Geometry.MidPoint, numRotationAngle.Value)
        ElseIf numRotationAngle.Value = 0 Then
            'set line to be horizontal to constrain sketch
            geomConstraints.AddHorizontal(oRectangleLines.Item(1))
        End If

        'project the center point into the sketch
        oSketch.AddByProjectingEntity(oCompDef.WorkPoints.Item("Center Point"))

        'rename sketch
        RenameSketch(sketchName)

        'stop transaction
        oTrans.End()

    End Sub

    Private Sub MPGPneu(flip As Boolean, face As Face, modPos As Point)
        'subroutine to draw and create the holes for the pneumatic connections on an MPG40 Gripper
        Dim width As Double
        Dim portWidth As Double
        Dim portHeight As Double
        Dim sleeveDia As Double
        Dim sleeveDepth As Double
        Dim screwDia As Double
        Dim oRingDia As Double
        Dim pneuDia As Double
        Dim pneuDepth As Double
        Dim xOffset As Double
        Dim yOffset As Double
        Dim sketchName As String = ""
        Dim screwFeatName As String = ""
        Dim airPortFeatName As String = ""

        Select Case cmbTemplate.Text
            Case "MPG+ 40 Pneu"
                width = 3.2
                portWidth = 2.4
                portHeight = 1.38
                sleeveDia = 0.6
                sleeveDepth = 0.27
                screwDia = 0.45
                oRingDia = 0.5
                pneuDia = 0.3
                pneuDepth = 0.06
                sketchName = "MPG+ 40 Direct"
                airPortFeatName = "40 Direct Air Holes"
                screwFeatName = "40 Direct Screw Holes"
                If flip = True Then
                    xOffset = 1.2
                    yOffset = 0.88
                Else
                    xOffset = 1.2
                    yOffset = 0.5
                End If
            Case "MPG+ 32 Pneu"
                width = 2.5
                portWidth = 1.8
                portHeight = 1.38
                sleeveDia = 0.6
                sleeveDepth = 0.27
                screwDia = 0.45
                oRingDia = 0.5
                pneuDia = 0.3
                pneuDepth = 0.06
                sketchName = "MPG+ 32 Direct"
                airPortFeatName = "32 Direct Air Holes"
                screwFeatName = "32 Direct Screw Holes"
                If flip = True Then
                    xOffset = 0.95
                    yOffset = 0.75
                Else
                    xOffset = 0.85
                    yOffset = 0.63
                End If
            Case "MPG+ 25 Pneu"
                width = 2
                portWidth = 1.45
                portHeight = 1.2
                sleeveDia = 0.5
                sleeveDepth = 0.22
                screwDia = 0.34
                oRingDia = 0.5
                pneuDia = 0.3
                pneuDepth = 0.06
                sketchName = "MPG+ 25 Direct"
                airPortFeatName = "25 Direct Air Holes"
                screwFeatName = "25 Direct Screw Holes"
                If flip = True Then
                    xOffset = 0.75
                    yOffset = 0.6
                Else
                    xOffset = 0.7
                    yOffset = 0.6
                End If
            Case Else
                MsgBox("Unknown selection")
                Exit Sub
        End Select

        'Start transaction to wrap process into a single undo
        Dim oTrans As Transaction
        oTrans = ThisApplication.TransactionManager.StartTransaction(ThisApplication.ActiveDocument, "MPG Pneu Holes")

        'set reference to transient geometry object
        Dim tg As TransientGeometry
        tg = ThisApplication.TransientGeometry

        'create a sketch to contain hole points
        Dim oSketch As PlanarSketch
        oSketch = oCompDef.Sketches.Add(face, False) 'creates sketch on selected plane

        'defer updates to sketch to speed things up
        oSketch.DeferUpdates = True

        'get model position point in the sketch coordinate system
        Dim myPoint As Point2d
        myPoint = oSketch.ModelToSketchSpace(modPos)

        'make rectangle using two point method
        Dim oRectangleLines As SketchEntitiesEnumerator
        oRectangleLines = oSketch.SketchLines.AddAsTwoPointRectangle(tg.CreatePoint2d(myPoint.X, myPoint.Y), tg.CreatePoint2d((myPoint.X + portWidth), (myPoint.Y + portHeight)))

        'make the lines construction
        Dim line As SketchEntity
        For Each line In oRectangleLines
            line.Construction = True
        Next line

        'get reference to the sketch lines collection
        Dim lines As SketchLines
        lines = oSketch.SketchLines
        Dim points As SketchPoints
        points = oSketch.SketchPoints

        'creat middle line for mounting holes
        Dim line5 As SketchLine 'line for mounting holes and centering sleeves
        Dim line6 As SketchLine 'line for direct porting holes
        line5 = lines.AddByTwoPoints(tg.CreatePoint2d((myPoint.X - (width * 0.5 - xOffset)), (myPoint.Y + yOffset)), tg.CreatePoint2d((myPoint.X - (width * 0.5 - xOffset)) + width, (myPoint.Y + yOffset))) 'line for mounting holes
        'lines.Item(lines.Count).Construction = True
        line5.Construction = True
        line6 = lines.AddByTwoPoints(lines.Item(3).Geometry.MidPoint, lines.Item(1).Geometry.MidPoint) 'draws centerline but not constrained
        'lines.Item(lines.Count).Construction = True
        line6.Construction = True

        'add some helping points
        Dim point1 As SketchPoint
        Dim point2 As SketchPoint

        point1 = points.Add(line5.Geometry.MidPoint, False) 'midpoint on line5
        point2 = points.Add(line6.Geometry.MidPoint, False) 'midpoint on line6

        'marking the hole centers on the lines
        oSketch.SketchLines.Item(1).StartSketchPoint.HoleCenter = True
        oSketch.SketchLines.Item(2).EndSketchPoint.HoleCenter = True
        line5.StartSketchPoint.HoleCenter = True
        line5.EndSketchPoint.HoleCenter = True

        'get reference to geometric constraints
        Dim geomConstraints As GeometricConstraints
        geomConstraints = oSketch.GeometricConstraints

        'constrain middle line to center of rectangle
        geomConstraints.AddMidpoint(line6.StartSketchPoint, lines.Item(3))
        geomConstraints.AddMidpoint(line6.EndSketchPoint, lines.Item(1))
        geomConstraints.AddMidpoint(point1, line5) 'constrain point to midpoint of line5
        geomConstraints.AddMidpoint(point2, line6) 'make point2 midpoint on line6
        geomConstraints.AddPerpendicular(line5, line6) 'make line5 perpendicular to line6

        'get reference to dimension constraints
        Dim dimConstraints As DimensionConstraints
        dimConstraints = oSketch.DimensionConstraints
        'add dimension constraints
        dimConstraints.AddTwoPointDistance(line5.StartSketchPoint, line5.EndSketchPoint, Inventor.DimensionOrientationEnum.kAlignedDim, tg.CreatePoint2d(myPoint.X + width * 0.5, (myPoint.Y - 0.6)), False) 'centering sleeve dimension
        dimConstraints.AddOffset(oSketch.SketchLines.Item(1), oSketch.SketchLines.Item(3), tg.CreatePoint2d(myPoint.X + width + 0.3, myPoint.Y + portHeight * 0.5), False) 'portHeight dimension
        dimConstraints.AddOffset(oSketch.SketchLines.Item(4), oSketch.SketchLines.Item(2), tg.CreatePoint2d(myPoint.X + portWidth * 0.5, myPoint.Y - 0.3), False) 'portWidth dimension
        'xOffset dimension constraint
        dimConstraints.AddOffset(oSketch.SketchLines.Item(4), points.Item(points.Count - 1), tg.CreatePoint2d(myPoint.X + portWidth * 0.25, (myPoint.Y + portHeight + 0.3)), False)
        'yOffset dimension constraint
        dimConstraints.AddOffset(oSketch.SketchLines.Item(1), line5.StartSketchPoint, tg.CreatePoint2d(myPoint.X - 1, myPoint.Y + portHeight * 0.25), False)

        'Undo Defer Updates, will update the sketch
        oSketch.DeferUpdates = False

        'add hole feature for screw holes
        Dim oHoleCenters As ObjectCollection
        oHoleCenters = ThisApplication.TransientObjects.CreateObjectCollection
        'add points to the object collection
        oHoleCenters.Add(line5.StartSketchPoint)
        oHoleCenters.Add(line5.EndSketchPoint)

        'define hole feature for centering sleeve holes, identifies the hole feature that is to be created
        Dim sleeveHoleFeat As HoleFeature
        Dim numHoleFeatures As Integer
        numHoleFeatures = oCompDef.Features.HoleFeatures.Count

        Dim oHolePlacement As SketchHolePlacementDefinition
        oHolePlacement = oCompDef.Features.HoleFeatures.CreateSketchPlacementDefinition(oHoleCenters)
        'create counterbore thru holes
        sleeveHoleFeat = oCompDef.Features.HoleFeatures.AddCBoreByThroughAllExtent(oHolePlacement, screwDia, Inventor.PartFeatureExtentDirectionEnum.kPositiveExtentDirection, sleeveDia, sleeveDepth)
        sleeveHoleFeat.Name = screwFeatName & numHoleFeatures + 1
        oHoleCenters.Clear()

        'add tolerance for centering sleeve hole feature
        If cmbTolerance.Text = "H7 - Slip" Then
            sleeveHoleFeat.CBoreDiameter.Tolerance.SetToFits(ToleranceTypeEnum.kLimitsFitsShowSizeTolerance, "H7", "")
            'add colors to centering sleeve faces
            sleeveHoleFeat.Faces.Item(2).SetRenderStyle(StyleSourceTypeEnum.kOverrideRenderStyle, ThisApplication.ActiveDocument.RenderStyles.Item("Fit - Slip"))
            sleeveHoleFeat.Faces.Item(5).SetRenderStyle(StyleSourceTypeEnum.kOverrideRenderStyle, ThisApplication.ActiveDocument.RenderStyles.Item("Fit - Slip"))
        ElseIf cmbTolerance.Text = "P7 - Press" Then
            sleeveHoleFeat.CBoreDiameter.Tolerance.SetToFits(ToleranceTypeEnum.kLimitsFitsShowSizeTolerance, "P7", "")
            'add colors to centering sleeve faces
            sleeveHoleFeat.Faces.Item(2).SetRenderStyle(StyleSourceTypeEnum.kOverrideRenderStyle, ThisApplication.ActiveDocument.RenderStyles.Item("Fit - Press"))
            sleeveHoleFeat.Faces.Item(5).SetRenderStyle(StyleSourceTypeEnum.kOverrideRenderStyle, ThisApplication.ActiveDocument.RenderStyles.Item("Fit - Press"))
        End If

        'define holes for direct pneumatic connection
        oHoleCenters.Add(oSketch.SketchLines.Item(1).StartSketchPoint)
        oHoleCenters.Add(oSketch.SketchLines.Item(2).EndSketchPoint)
        oHolePlacement = oCompDef.Features.HoleFeatures.CreateSketchPlacementDefinition(oHoleCenters)

        'create pneumatic connection holes
        Dim airHoleFeat As HoleFeature
        airHoleFeat = oCompDef.Features.HoleFeatures.AddCBoreByThroughAllExtent(oHolePlacement, pneuDia, Inventor.PartFeatureExtentDirectionEnum.kPositiveExtentDirection, oRingDia, pneuDepth)
        airHoleFeat.Name = airPortFeatName & numHoleFeatures + 2

        'rotate by rotation angle if not 0
        If numRotationAngle.Value <> 0 Then
            RotateSketch(oSketch, oSketch.SketchLines.Item(5).Geometry.MidPoint, numRotationAngle.Value)
        ElseIf numRotationAngle.Value = 0 Then
            'set line to be horizontal to constrain sketch
            'horizontal constraint already exists due to two-point method of creating the rectangle
        End If

        'project the center point into the sketch
        oSketch.AddByProjectingEntity(oCompDef.WorkPoints.Item("Center Point"))

        'rename sketch
        RenameSketch(sketchName)

        'end transaction for creating a single undo operation
        oTrans.End()

    End Sub

    Private Sub BagSlide(face As Face, modPos As Point)
        Dim square As Double
        Dim dowelDia As Double
        Dim screwDia As Double
        Dim sketchName As String
        Dim innerSquare As Double
        Dim screwFeatName As String = ""
        Dim dowelFeatName As String = ""
        Dim centerHoleFeatName As String = ""

        Select Case cmbTemplate.Text
            Case "BAG 40mm"
                square = 2.6
                dowelDia = 0.3
                screwDia = 0.55
                sketchName = "BAG 40mm"
                screwFeatName = "BAG40 Screw Holes"
                dowelFeatName = "BAG40 Dowel Holes"
            Case "BAG 55mm"
                square = 3.5
                dowelDia = 0.3
                screwDia = 0.55
                sketchName = "BAG 55mm"
                screwFeatName = "BAG55 Screw Holes"
                dowelFeatName = "BAG55 Dowel Holes"
            Case "BAG 75mm A"
                square = 5.5
                dowelDia = 0.5
                screwDia = 0.55
                innerSquare = 2.5
                sketchName = "BAG 75mm A"
                screwFeatName = "BAG75A Screw Holes"
                dowelFeatName = "BAG75A Dowel Holes"
                centerHoleFeatName = "BAG75A Center Holes"
            Case Else
                sketchName = "unknown"
        End Select

        'Start transaction to wrap process into a single undo
        Dim oTrans As Transaction
        oTrans = ThisApplication.TransactionManager.StartTransaction(ThisApplication.ActiveDocument, "BAG 25mm Holes")

        'set reference to transient geometry object
        Dim tg As TransientGeometry
        tg = ThisApplication.TransientGeometry

        'create a sketch to contain hole points
        Dim oSketch As PlanarSketch
        oSketch = oCompDef.Sketches.Add(face, False) 'creates sketch on selected plane

        'defer updates to sketch to speed things up
        oSketch.DeferUpdates = True

        'get model position point in the sketch coordinate system
        Dim myPoint As Point2d
        myPoint = oSketch.ModelToSketchSpace(modPos)

        'make rectangle using 3-point method
        Dim oRectangleLines As SketchEntitiesEnumerator
        oRectangleLines = oSketch.SketchLines.AddAsThreePointRectangle(tg.CreatePoint2d(myPoint.X, myPoint.Y), tg.CreatePoint2d(myPoint.X + square, myPoint.Y), tg.CreatePoint2d(myPoint.X + square, myPoint.Y + square))

        'make temporary collections for screw and dowel holes
        Dim oDowelHoleCenters As ObjectCollection
        Dim oScrewHoleCenters As ObjectCollection
        Dim innerScrewCenters As ObjectCollection
        oScrewHoleCenters = ThisApplication.TransientObjects.CreateObjectCollection
        oDowelHoleCenters = ThisApplication.TransientObjects.CreateObjectCollection
        innerScrewCenters = ThisApplication.TransientObjects.CreateObjectCollection

        'make helper line
        Dim outerCL As SketchLine
        outerCL = oSketch.SketchLines.AddByTwoPoints(oSketch.SketchLines.Item(3).Geometry.MidPoint, oSketch.SketchLines.Item(1).Geometry.MidPoint)

        'make all the lines construction
        Dim line As SketchEntity
        For Each line In oSketch.SketchLines
            line.Construction = True
        Next line

        'set reference to dimension constraints and add dimensions
        Dim dimConstraints As DimensionConstraints
        dimConstraints = oSketch.DimensionConstraints

        'set reference to geometry constraints
        Dim geomConstraints As GeometricConstraints
        geomConstraints = oSketch.GeometricConstraints

        'constrain outerCL
        Dim centerPoint As SketchPoint
        centerPoint = oSketch.SketchPoints.Add(outerCL.Geometry.MidPoint, False)
        geomConstraints.AddMidpoint(outerCL.StartSketchPoint, oSketch.SketchLines.Item(3))
        geomConstraints.AddMidpoint(outerCL.EndSketchPoint, oSketch.SketchLines.Item(1))
        geomConstraints.AddMidpoint(centerPoint, outerCL)

        'if 75mm make inner rectangle
        If cmbTemplate.Text = "BAG 75mm A" Then
            Dim oInnerRectangleLines As SketchEntitiesEnumerator
            Dim innerX As Double
            Dim innerY As Double
            innerX = myPoint.X + 1.5
            innerY = myPoint.Y + 1.5
            'make inner rectangle with 3-point method
            oInnerRectangleLines = oSketch.SketchLines.AddAsThreePointRectangle(tg.CreatePoint2d(innerX, innerY), tg.CreatePoint2d(innerX + innerSquare, innerY), tg.CreatePoint2d(innerX + innerSquare, innerY + innerSquare))

            'mark inner lines as construction and add midpoints to screw hole centers collection
            Dim innerLine As SketchLine
            For Each innerLine In oInnerRectangleLines
                innerLine.Construction = True
                innerScrewCenters.Add(oSketch.SketchPoints.Add(innerLine.Geometry.MidPoint, True)) 'add inner rectangle points to screw hole centers
            Next innerLine

            'helper line
            Dim innerCL As SketchLine
            innerCL = oSketch.SketchLines.AddByTwoPoints(oSketch.SketchLines.Item(8).Geometry.MidPoint, oSketch.SketchLines.Item(6).Geometry.MidPoint)
            innerCL.Construction = True

            'add dimension constraints
            dimConstraints.AddTwoPointDistance(oSketch.SketchLines.Item(6).StartSketchPoint, oSketch.SketchLines.Item(6).EndSketchPoint, Inventor.DimensionOrientationEnum.kAlignedDim, tg.CreatePoint2d(innerX + innerSquare * 0.5, innerY - 0.3))

            'geometry constraints for inner rectangle
            geomConstraints.AddEqualLength(oSketch.SketchLines.Item(6), oSketch.SketchLines.Item(7))
            geomConstraints.AddMidpoint(innerCL.StartSketchPoint, oSketch.SketchLines.Item(9))
            geomConstraints.AddMidpoint(innerCL.EndSketchPoint, oSketch.SketchLines.Item(7))
            geomConstraints.AddMidpoint(centerPoint, innerCL)

            'constrain innerScrewCenters
            Dim j As Integer
            For j = 1 To innerScrewCenters.Count
                geomConstraints.AddMidpoint(innerScrewCenters.Item(j), oSketch.SketchLines.Item(j + 5))
            Next
        End If

        'add dimension constraints to outer rectangle
        dimConstraints.AddOffset(oRectangleLines.Item(4), oRectangleLines.Item(2), tg.CreatePoint2d(myPoint.X + square * 0.5, myPoint.Y - 0.3), False)
        dimConstraints.AddOffset(oRectangleLines.Item(1), oRectangleLines.Item(3), tg.CreatePoint2d(myPoint.X - 0.3, myPoint.Y + square * 0.5), False)

        'Undo defer updates, will update the sketch
        oSketch.DeferUpdates = False

        'add outer rectangle points to screw or dowel collection
        Dim bagLine As SketchLine
        For Each bagLine In oRectangleLines
            bagLine.StartSketchPoint.HoleCenter = True
            oScrewHoleCenters.Add(bagLine.StartSketchPoint)  'add start point to oScrewHolesCenters collection
            'bagLine.EndSketchPoint.HoleCenter = True
            'oScrewHoleCenters.Add bagLine.EndSketchPoint    'add end point to oScrewHolesCenters collection
            oDowelHoleCenters.Add(oSketch.SketchPoints.Add(bagLine.Geometry.MidPoint, True)) 'add midpoints to oDowelHoleCenters collection and mark as hole center
        Next bagLine

        'add midpoints of oRectangleLines to geometry constraints
        Dim i As Integer
        For i = 1 To oRectangleLines.Count 'oSketch.SketchLines.count
            geomConstraints.AddMidpoint(oDowelHoleCenters.Item(i), oRectangleLines.Item(i))
        Next

        'define dowel and hole feature for dowel holes, identifies the hole feature that is to be created
        Dim dowelHoleFeat As HoleFeature
        Dim screwHoleFeat As HoleFeature

        Dim numHoleFeatures As Integer
        numHoleFeatures = oCompDef.Features.HoleFeatures.Count

        'define screw and dowel placement definitions
        Dim oScrewPlacement As SketchHolePlacementDefinition
        Dim oDowelPlacement As SketchHolePlacementDefinition

        oScrewPlacement = oCompDef.Features.HoleFeatures.CreateSketchPlacementDefinition(oScrewHoleCenters)
        oDowelPlacement = oCompDef.Features.HoleFeatures.CreateSketchPlacementDefinition(oDowelHoleCenters)

        'create screw clearance holes
        screwHoleFeat = oCompDef.Features.HoleFeatures.AddDrilledByThroughAllExtent(oScrewHoleCenters, screwDia, Inventor.PartFeatureExtentDirectionEnum.kPositiveExtentDirection)
        'rename screw feature
        screwHoleFeat.Name = screwFeatName & numHoleFeatures + 1

        'create dowel holes
        dowelHoleFeat = oCompDef.Features.HoleFeatures.AddDrilledByThroughAllExtent(oDowelHoleCenters, dowelDia, Inventor.PartFeatureExtentDirectionEnum.kPositiveExtentDirection)

        'rename dowel hole feature
        dowelHoleFeat.Name = dowelFeatName & numHoleFeatures + 2

        'make center holes if needed
        If cmbTemplate.Text = "BAG 75mm A" Then
            Dim centerHoles As HoleFeature
            centerHoles = oCompDef.Features.HoleFeatures.AddDrilledByThroughAllExtent(innerScrewCenters, screwDia, Inventor.PartFeatureExtentDirectionEnum.kPositiveExtentDirection)
            centerHoles.Name = centerHoleFeatName & numHoleFeatures + 3
        End If

        'add tolerance to dowel pin holes
        AddTol(dowelHoleFeat)
        'color faces of dowel pin holes
        ColorHoles(dowelHoleFeat)
        'end transaction for creating a single undo operation

        'rotate by rotation angle if not 0
        If numRotationAngle.Value <> 0 Then
            RotateSketch(oSketch, oSketch.SketchLines.Item(1).Geometry.MidPoint, numRotationAngle.Value)
        ElseIf numRotationAngle.Value = 0 Then
            'set line to be horizontal to constrain sketch
            geomConstraints.AddHorizontal(oRectangleLines.Item(1))
        End If

        'project the center point into the sketch
        oSketch.AddByProjectingEntity(oCompDef.WorkPoints.Item("Center Point"))

        'rename sketch
        RenameSketch(sketchName)

        'stop transaction
        oTrans.End()

    End Sub

    Private Sub EscapementPattern(face As Face, modPos As Point)
        'pattern for the single and double escapement support S4085.0004.01 and S4085.0005.01

        Dim width As Double
        Dim height As Double
        Dim innerWidth As Double
        Dim innerHeight As Double
        Dim screwDia As Double
        Dim dowelDia As Double
        Dim offset As Double
        Dim sketchName As String

        width = 5.5
        height = 5.5
        innerWidth = 2.5
        innerHeight = 2.5
        screwDia = 0.55
        dowelDia = 0.5
        offset = 1.5
        sketchName = "Escap Pattern"

        'Start transaction to wrap process into a single undo
        Dim oTrans As Transaction
        oTrans = ThisApplication.TransactionManager.StartTransaction(ThisApplication.ActiveDocument, "BAG 25mm Holes")

        'set reference to transient geometry object
        Dim tg As TransientGeometry
        tg = ThisApplication.TransientGeometry

        'create a sketch to contain hole points
        Dim oSketch As PlanarSketch
        oSketch = oCompDef.Sketches.Add(face, False) 'creates sketch on selected plane

        'defer updates to sketch to speed things up
        oSketch.DeferUpdates = True

        'get model position point in the sketch coordinate system
        Dim myPoint As Point2d
        myPoint = oSketch.ModelToSketchSpace(modPos)

        'make outer rectangle using 3-point method
        Dim oOuterRectangleLines As SketchEntitiesEnumerator
        oOuterRectangleLines = oSketch.SketchLines.AddAsThreePointRectangle(tg.CreatePoint2d(myPoint.X, myPoint.Y), tg.CreatePoint2d(myPoint.X + width, myPoint.Y), tg.CreatePoint2d(myPoint.X + width, myPoint.Y + height))

        'make inner lines
        oSketch.SketchLines.AddByTwoPoints(oSketch.SketchLines.Item(4).Geometry.MidPoint, oSketch.SketchLines.Item(2).Geometry.MidPoint)
        oSketch.SketchLines.AddByTwoPoints(oSketch.SketchLines.Item(3).Geometry.MidPoint, oSketch.SketchLines.Item(1).Geometry.MidPoint)

        'make inner rectangle using 3-point method
        Dim oInnerRectangleLines As SketchEntitiesEnumerator
        oInnerRectangleLines = oSketch.SketchLines.AddAsThreePointRectangle(tg.CreatePoint2d(myPoint.X + offset, myPoint.Y + offset), tg.CreatePoint2d(myPoint.X + offset + innerWidth, myPoint.Y + offset), tg.CreatePoint2d(myPoint.X + offset + innerWidth, myPoint.Y + offset + innerHeight))

        'make the lines construction
        Dim line As SketchEntity
        For Each line In oSketch.SketchLines
            line.Construction = True
        Next line

        'add inner screw points
        Dim innerPoints As ObjectCollection 'collection of sketchpoints
        innerPoints = ThisApplication.TransientObjects.CreateObjectCollection

        With innerPoints
            .Add(oSketch.SketchPoints.Add(oSketch.SketchLines.Item(7).Geometry.MidPoint, True))
            .Add(oSketch.SketchPoints.Add(oSketch.SketchLines.Item(8).Geometry.MidPoint, True))
            .Add(oSketch.SketchPoints.Add(oSketch.SketchLines.Item(9).Geometry.MidPoint, True))
            .Add(oSketch.SketchPoints.Add(oSketch.SketchLines.Item(10).Geometry.MidPoint, True))
        End With

        'add outer dowel pin points
        Dim outerPoints As ObjectCollection
        outerPoints = ThisApplication.TransientObjects.CreateObjectCollection

        With outerPoints
            .Add(oSketch.SketchLines.Item(5).StartSketchPoint)
            .Add(oSketch.SketchLines.Item(5).EndSketchPoint)
            .Add(oSketch.SketchLines.Item(6).StartSketchPoint)
            .Add(oSketch.SketchLines.Item(6).EndSketchPoint)
        End With

        Dim i As Integer
        For i = 1 To outerPoints.Count
            outerPoints.Item(i).HoleCenter = True
        Next i

        'mark centerpoint for easy rotation
        Dim centerPoint As Point2d
        centerPoint = oSketch.SketchLines.Item(6).Geometry.MidPoint

        'get reference to geometric constraints object
        Dim geomConstraints As GeometricConstraints
        geomConstraints = oSketch.GeometricConstraints

        'add geometric constraints to lines
        geomConstraints.AddEqualLength(oOuterRectangleLines.Item(1), oOuterRectangleLines.Item(2))
        geomConstraints.AddEqualLength(oInnerRectangleLines.Item(1), oInnerRectangleLines.Item(2))
        geomConstraints.AddMidpoint(innerPoints.Item(1), oInnerRectangleLines.Item(1))
        geomConstraints.AddCoincident(innerPoints.Item(1), oSketch.SketchLines.Item(6))
        geomConstraints.AddMidpoint(innerPoints.Item(2), oInnerRectangleLines.Item(2))
        geomConstraints.AddCoincident(innerPoints.Item(2), oSketch.SketchLines.Item(5))
        geomConstraints.AddMidpoint(innerPoints.Item(3), oInnerRectangleLines.Item(3))
        geomConstraints.AddMidpoint(innerPoints.Item(4), oInnerRectangleLines.Item(4))
        geomConstraints.AddCoincident(innerPoints.Item(4), oSketch.SketchLines.Item(5))
        'make crossing lines coincident on rectangle midpoints
        geomConstraints.AddMidpoint(outerPoints.Item(1), oOuterRectangleLines.Item(4))
        geomConstraints.AddMidpoint(outerPoints.Item(2), oOuterRectangleLines.Item(2))
        geomConstraints.AddMidpoint(outerPoints.Item(3), oOuterRectangleLines.Item(3))
        geomConstraints.AddMidpoint(outerPoints.Item(4), oOuterRectangleLines.Item(1))

        'get reference to dimension constraints and add dimensions
        Dim dimConstraints As DimensionConstraints
        dimConstraints = oSketch.DimensionConstraints
        dimConstraints.AddOffset(oSketch.SketchLines.Item(4), oSketch.SketchLines.Item(2), tg.CreatePoint2d(myPoint.X + width * 0.5, myPoint.Y - 0.3), False)
        dimConstraints.AddOffset(oSketch.SketchLines.Item(10), oSketch.SketchLines.Item(8), tg.CreatePoint2d(myPoint.X + width * 0.5, myPoint.Y + offset - 0.3), False)

        Dim oScrewPlacement As SketchHolePlacementDefinition
        Dim oDowelPlacement As SketchHolePlacementDefinition
        oScrewPlacement = oCompDef.Features.HoleFeatures.CreateSketchPlacementDefinition(innerPoints)
        oDowelPlacement = oCompDef.Features.HoleFeatures.CreateSketchPlacementDefinition(outerPoints)

        'Enable updates and rebuild the sketch
        oSketch.DeferUpdates = False

        'define hole feature for dowel holes, identifies the hole feature that is to be created
        Dim screwHoleFeat As HoleFeature
        Dim dowelHoleFeat As HoleFeature

        'holder for number of hole features
        Dim numHoleFeatures As Integer
        numHoleFeatures = oCompDef.Features.HoleFeatures.Count

        'create screw clearance holes
        screwHoleFeat = oCompDef.Features.HoleFeatures.AddDrilledByThroughAllExtent(oScrewPlacement, screwDia, Inventor.PartFeatureExtentDirectionEnum.kPositiveExtentDirection)
        'name screw features
        screwHoleFeat.Name = "Escap Screw Holes" & numHoleFeatures + 1
        'create dowel holes
        dowelHoleFeat = oCompDef.Features.HoleFeatures.AddDrilledByThroughAllExtent(oDowelPlacement, dowelDia, Inventor.PartFeatureExtentDirectionEnum.kPositiveExtentDirection)
        'name dowel features
        dowelHoleFeat.Name = "Escap Dowel Holes" & numHoleFeatures + 2

        'add tolerance to dowel holes
        AddTol(dowelHoleFeat)
        'add color to dowel holes
        ColorHoles(dowelHoleFeat)

        'rotate by rotation angle if not 0
        If numRotationAngle.Value <> 0 Then
            RotateSketch(oSketch, centerPoint, numRotationAngle.Value)
        ElseIf numRotationAngle.Value = 0 Then
            'set line to be horizontal to constrain sketch
            geomConstraints.AddHorizontal(oOuterRectangleLines.Item(1))
        End If

        'project the center point into the sketch
        oSketch.AddByProjectingEntity(oCompDef.WorkPoints.Item("Center Point"))

        'rename sketch
        RenameSketch(sketchName)

        'end transaction for creating a single undo operation
        oTrans.End()

    End Sub

    'S4085.0006.01
    Private Sub slideBlock(face As Face, modPos As Point)
        'routine to draw and create holes for the 38mm slide block S4085.0006.01

        Dim square As Double
        Dim innerHeight As Double
        Dim offsetY As Double
        Dim screwDia As Double
        Dim dowelDia As Double
        Dim sketchName As String

        square = 5.5
        innerHeight = 2.5
        offsetY = 1.5
        screwDia = 0.55
        dowelDia = 0.5
        sketchName = "S4085.0006.01 Pattern"

        'Start transaction to wrap process into a single undo
        Dim oTrans As Transaction
        oTrans = ThisApplication.TransactionManager.StartTransaction(ThisApplication.ActiveDocument, "S4085.0006.01 Holes")

        'set reference to transient geometry object
        Dim tg As TransientGeometry
        tg = ThisApplication.TransientGeometry

        'create a sketch to contain hole points
        Dim oSketch As PlanarSketch
        oSketch = oCompDef.Sketches.Add(face, False) 'creates sketch on selected plan

        'defer updates to sketch to speed things up
        oSketch.DeferUpdates = True

        'get model position point in the sketch coordinate system
        Dim myPoint As Point2d
        myPoint = oSketch.ModelToSketchSpace(modPos)

        'make rectangle using 3-point method
        Dim oRectangleLines As SketchEntitiesEnumerator
        oRectangleLines = oSketch.SketchLines.AddAsThreePointRectangle(tg.CreatePoint2d(myPoint.X, myPoint.Y), tg.CreatePoint2d(myPoint.X + square, myPoint.Y), tg.CreatePoint2d(myPoint.X + square, myPoint.Y + square))

        'make the lines construction
        Dim line As SketchEntity
        For Each line In oRectangleLines
            line.Construction = True
        Next line

        'make all the start points of the rectangle hole centers
        Dim recLine As SketchLine
        For Each recLine In oSketch.SketchLines
            recLine.StartSketchPoint.HoleCenter = True
            'add midpoints of lines to sketchpoints and make hole centers
            oSketch.SketchPoints.Add(recLine.Geometry.MidPoint, True)
        Next recLine

        'draw line 5 and line 6
        Dim line5 As SketchLine
        Dim line6 As SketchLine
        line5 = oSketch.SketchLines.AddByTwoPoints(oSketch.SketchLines.Item(4).Geometry.MidPoint, oSketch.SketchLines.Item(2).Geometry.MidPoint)
        line6 = oSketch.SketchLines.AddByTwoPoints(tg.CreatePoint2d((myPoint.X + square * 0.5), (myPoint.Y + square - offsetY)), tg.CreatePoint2d((myPoint.X + square * 0.5), (myPoint.Y + square - offsetY - innerHeight)))
        'mark line 5&6 as construction
        line5.Construction = True
        line6.Construction = True
        'make start and endpoint of lines 5 hole centers
        line5.StartSketchPoint.HoleCenter = True
        line5.EndSketchPoint.HoleCenter = True
        'make start and endpoint of lines 6 hole centers
        line6.StartSketchPoint.HoleCenter = True
        line6.EndSketchPoint.HoleCenter = True
        'central point for easy rotations
        oSketch.SketchPoints.Add(line6.Geometry.MidPoint, False)

        'get reference to geometric constraints object
        Dim geomConstraints As GeometricConstraints
        geomConstraints = oSketch.GeometricConstraints

        'add geometric constraints to lines
        geomConstraints.AddPerpendicular(line5, line6)
        geomConstraints.AddEqualLength(oRectangleLines.Item(1), oRectangleLines.Item(2))
        geomConstraints.AddMidpoint(line5.StartSketchPoint, oRectangleLines.Item(4))  'make line5 midpoint on rectangle line 4
        geomConstraints.AddMidpoint(line5.EndSketchPoint, oRectangleLines.Item(2)) 'make line5 midpoint on rectangle line 2
        geomConstraints.AddMidpoint(oSketch.SketchPoints.Item(oSketch.SketchPoints.Count), line6) 'make last created point, the center point, midpoint on line6
        geomConstraints.AddMidpoint(oSketch.SketchPoints.Item(oSketch.SketchPoints.Count), line5) 'make last created point midpoint on line5
        geomConstraints.AddMidpoint(oSketch.SketchPoints.Item(5), oSketch.SketchLines.Item(1))
        geomConstraints.AddMidpoint(oSketch.SketchPoints.Item(6), oSketch.SketchLines.Item(2))
        geomConstraints.AddMidpoint(oSketch.SketchPoints.Item(7), oSketch.SketchLines.Item(3))
        geomConstraints.AddMidpoint(oSketch.SketchPoints.Item(8), oSketch.SketchLines.Item(4))

        'get reference to dimension constraints and add dimensions
        Dim dimConstraints As DimensionConstraints
        dimConstraints = oSketch.DimensionConstraints

        dimConstraints.AddOffset(oRectangleLines.Item(1), oRectangleLines.Item(3), tg.CreatePoint2d(myPoint.X - 0.3, (myPoint.Y + square * 0.5)), False)
        'dimConstraints.AddOffset(oSketch.SketchLines.Item(1), oSketch.SketchLines.Item(3), tg.CreatePoint2d(myPoint.X - 0.3, (myPoint.Y + square * 0.5)), False)
        dimConstraints.AddTwoPointDistance(line6.StartSketchPoint, line6.EndSketchPoint, Inventor.DimensionOrientationEnum.kAlignedDim, tg.CreatePoint2d(myPoint.X + square * 0.5 - 0.3, myPoint.Y + square * 0.5))

        'Undo defer updats, will update the sketch
        oSketch.DeferUpdates = False

        'define screw hole centers and dowel hole centers
        Dim oDowelHoleCenters As ObjectCollection 'these will be collections of sketchpoints
        Dim oScrewHoleCenters As ObjectCollection
        oScrewHoleCenters = ThisApplication.TransientObjects.CreateObjectCollection
        oDowelHoleCenters = ThisApplication.TransientObjects.CreateObjectCollection

        'add sketch points to their respective collection for screws or dowel pins
        With oDowelHoleCenters
            .Add(oSketch.SketchPoints.Item(5))
            .Add(oSketch.SketchPoints.Item(7))
        End With

        With oScrewHoleCenters
            .Add(oSketch.SketchLines.Item(1).StartSketchPoint)
            .Add(oSketch.SketchLines.Item(1).EndSketchPoint)
            .Add(oSketch.SketchLines.Item(2).EndSketchPoint)
            .Add(oSketch.SketchLines.Item(3).EndSketchPoint)
            .Add(oSketch.SketchLines.Item(4).EndSketchPoint)
            .Add(line5.StartSketchPoint)
            .Add(line5.EndSketchPoint)
            .Add(line6.StartSketchPoint)
            .Add(line6.EndSketchPoint)
        End With

        Dim oScrewPlacement As SketchHolePlacementDefinition
        Dim oDowelPlacement As SketchHolePlacementDefinition
        oScrewPlacement = oCompDef.Features.HoleFeatures.CreateSketchPlacementDefinition(oScrewHoleCenters)
        oDowelPlacement = oCompDef.Features.HoleFeatures.CreateSketchPlacementDefinition(oDowelHoleCenters)

        'define hole feature for dowel holes, identifies the hole feature that is to be created
        Dim dowelHoleFeat As HoleFeature
        Dim screwHoleFeat As HoleFeature

        'holder for number of hole features
        Dim numHoleFeatures As Integer
        numHoleFeatures = oCompDef.Features.HoleFeatures.Count

        'create screw clearance holes
        screwHoleFeat = oCompDef.Features.HoleFeatures.AddDrilledByThroughAllExtent(oScrewHoleCenters, screwDia, Inventor.PartFeatureExtentDirectionEnum.kPositiveExtentDirection)
        'name screw hole features
        screwHoleFeat.Name = "S4085.0006.01 Screw Holes" & numHoleFeatures + 1
        'create dowel holes
        dowelHoleFeat = oCompDef.Features.HoleFeatures.AddDrilledByThroughAllExtent(oDowelHoleCenters, dowelDia, Inventor.PartFeatureExtentDirectionEnum.kPositiveExtentDirection)
        dowelHoleFeat.Name = "S4085.0006.01 Dowel Holes" & numHoleFeatures + 2

        'rotate by rotation angle if not 0
        If numRotationAngle.Value <> 0 Then
            RotateSketch(oSketch, line5.Geometry.MidPoint, numRotationAngle.Value)
        ElseIf numRotationAngle.Value = 0 Then
            'set line to be horizontal to constrain sketch
            geomConstraints.AddHorizontal(oRectangleLines.Item(1))
        End If

        'project the center point into the sketch
        oSketch.AddByProjectingEntity(oCompDef.WorkPoints.Item("Center Point"))

        'add tolerance to dowel holes
        AddTol(dowelHoleFeat)
        'add color to dowel holes
        ColorHoles(dowelHoleFeat)

        'rename sketch
        RenameSketch(sketchName)

        'end transactions
        oTrans.End()

    End Sub

    Private Sub NotchedDovetail(face As Face, modPos As Point)
        'routine to draw and create holes for the notched dovetail S38.14974.00

        Dim xWidth As Double
        Dim yHeight As Double
        Dim dowelWidth As Double
        Dim screwDia As Double
        Dim dowelDia As Double
        Dim offset As Double
        Dim sketchName As String

        xWidth = 1.8
        yHeight = 1
        dowelWidth = 3
        screwDia = 0.55
        dowelDia = 0.4
        offset = (dowelWidth - xWidth) * 0.5
        sketchName = "S38.14974.00 Pattern"

        'Start transaction to wrap process into a single undo
        Dim oTrans As Transaction
        oTrans = ThisApplication.TransactionManager.StartTransaction(ThisApplication.ActiveDocument, "BAG 25mm Holes")

        'set reference to transient geometry object
        Dim tg As TransientGeometry
        tg = ThisApplication.TransientGeometry

        'create a sketch to contain hole points
        Dim oSketch As PlanarSketch
        oSketch = oCompDef.Sketches.Add(face, False) 'creates sketch on selected plan

        'defer updates to sketch to speed things up
        oSketch.DeferUpdates = True

        'get model position point in the sketch coordinate system
        Dim myPoint As Point2d
        myPoint = oSketch.ModelToSketchSpace(modPos)

        'make rectangle using 3-point method
        Dim oRectangleLines As SketchEntitiesEnumerator
        oRectangleLines = oSketch.SketchLines.AddAsThreePointRectangle(myPoint, tg.CreatePoint2d(myPoint.X + xWidth, myPoint.Y),
        tg.CreatePoint2d(myPoint.X + xWidth, myPoint.Y + yHeight))
        'Set oRectangleLines = oSketch.SketchLines.AddAsTwoPointRectangle(tg.CreatePoint2d(myPoint.X, myPoint.Y), _
        tg.CreatePoint2d((myPoint.X + xWidth), (myPoint.Y + yHeight))
        'make the lines construction
        Dim line As SketchEntity
        For Each line In oRectangleLines
            line.Construction = True
        Next line
        'make hole centers
        oSketch.SketchLines.Item(1).EndSketchPoint.HoleCenter = True
        oSketch.SketchLines.Item(3).EndSketchPoint.HoleCenter = True

        'draw line 5 and line 6
        Dim line5 As SketchLine
        Dim line6 As SketchLine
        line5 = oSketch.SketchLines.AddByTwoPoints(tg.CreatePoint2d(myPoint.X - offset, myPoint.Y + yHeight * 0.5), tg.CreatePoint2d(myPoint.X + xWidth + offset, myPoint.Y + yHeight * 0.5))
        line6 = oSketch.SketchLines.AddByTwoPoints(oSketch.SketchLines.Item(3).Geometry.MidPoint, oSketch.SketchLines.Item(1).Geometry.MidPoint)
        'mark line 5&6 as construction
        line5.Construction = True
        line6.Construction = True
        'make start and endpoint of lines 65 hole centers
        line5.StartSketchPoint.HoleCenter = True
        line5.EndSketchPoint.HoleCenter = True
        'central point for easy rotations
        Dim centerPoint As SketchPoint
        centerPoint = oSketch.SketchPoints.Add(line6.Geometry.MidPoint, False)

        'helper point for constraining lines
        Dim point1 As SketchPoint
        point1 = oSketch.SketchPoints.Add(oSketch.SketchLines.Item(4).Geometry.MidPoint, False)

        'get reference to geometric constraints object
        Dim geomConstraints As GeometricConstraints
        geomConstraints = oSketch.GeometricConstraints

        'add geometric constraints to lines
        geomConstraints.AddMidpoint(line6.StartSketchPoint, oRectangleLines.Item(3))  'make line6 midpoint on rectangle line 3
        geomConstraints.AddMidpoint(line6.EndSketchPoint, oRectangleLines.Item(1)) 'make line6 midpoint on rectangle line 1
        geomConstraints.AddMidpoint(centerPoint, line5) 'make last created point midpoint on line5
        geomConstraints.AddMidpoint(centerPoint, line6) 'make last created point midpoint on line6
        geomConstraints.AddMidpoint(point1, oSketch.SketchLines.Item(4)) 'make point1 midpoint on line 4
        geomConstraints.AddCoincident(point1, line5) 'make point1 coincident to line5

        'get reference to dimension constraints and add dimensions
        Dim dimConstraints As DimensionConstraints
        dimConstraints = oSketch.DimensionConstraints
        dimConstraints.AddTwoPointDistance(oSketch.SketchLines.Item(1).StartSketchPoint, oSketch.SketchLines.Item(4).StartSketchPoint, Inventor.DimensionOrientationEnum.kAlignedDim, tg.CreatePoint2d(myPoint.X - offset - 0.4, (myPoint.Y + yHeight * 0.5))) 'height of the rectangle
        dimConstraints.AddTwoPointDistance(oSketch.SketchLines.Item(1).StartSketchPoint, oSketch.SketchLines.Item(1).EndSketchPoint, Inventor.DimensionOrientationEnum.kAlignedDim, tg.CreatePoint2d(myPoint.X + xWidth * 0.5, myPoint.Y - 0.3)) 'width of the rectangle
        dimConstraints.AddTwoPointDistance(line5.StartSketchPoint, line5.EndSketchPoint, Inventor.DimensionOrientationEnum.kAlignedDim, tg.CreatePoint2d(myPoint.X + xWidth * 0.5, myPoint.Y - 0.6))

        'Undo defer updates, will update the sketch
        oSketch.DeferUpdates = False

        'define screw hole centers and dowel hole centers
        Dim oDowelHoleCenters As ObjectCollection 'these will be collections of sketchpoints
        Dim oScrewHoleCenters As ObjectCollection
        oScrewHoleCenters = ThisApplication.TransientObjects.CreateObjectCollection
        oDowelHoleCenters = ThisApplication.TransientObjects.CreateObjectCollection
        'add sketch points to their respective collection for screws or dowel pins
        With oDowelHoleCenters
            .Add(line5.StartSketchPoint)
            .Add(line5.EndSketchPoint)
        End With

        With oScrewHoleCenters
            If chkFlip.Checked = False Then
                .Add(oSketch.SketchLines.Item(1).EndSketchPoint)
                .Add(oSketch.SketchLines.Item(3).EndSketchPoint)
            Else
                .Add(oSketch.SketchLines.Item(1).StartSketchPoint)
                .Add(oSketch.SketchLines.Item(3).StartSketchPoint)
            End If
        End With

        Dim oScrewPlacement As SketchHolePlacementDefinition
        Dim oDowelPlacement As SketchHolePlacementDefinition
        oScrewPlacement = oCompDef.Features.HoleFeatures.CreateSketchPlacementDefinition(oScrewHoleCenters)
        oDowelPlacement = oCompDef.Features.HoleFeatures.CreateSketchPlacementDefinition(oDowelHoleCenters)

        'define hole feature for dowel holes, identifies the hole feature that is to be created
        Dim dowelHoleFeat As HoleFeature
        Dim screwHoleFeat As HoleFeature

        Dim numHoleFeatures As Integer
        numHoleFeatures = oCompDef.Features.HoleFeatures.Count
        'create screw clearance holes
        screwHoleFeat = oCompDef.Features.HoleFeatures.AddDrilledByThroughAllExtent(oScrewHoleCenters, screwDia, Inventor.PartFeatureExtentDirectionEnum.kPositiveExtentDirection)
        'name screw features
        screwHoleFeat.Name = "S38.14974.00 Screw Holes" & numHoleFeatures + 1
        'create dowel holes
        dowelHoleFeat = oCompDef.Features.HoleFeatures.AddDrilledByThroughAllExtent(oDowelHoleCenters, dowelDia, Inventor.PartFeatureExtentDirectionEnum.kPositiveExtentDirection)
        'name dowel features
        dowelHoleFeat.Name = "S38.14974.00 Dowel Holes" & numHoleFeatures + 2

        'add tolerance to dowel holes
        AddTol(dowelHoleFeat)
        'color holes
        ColorHoles(dowelHoleFeat)

        'rotate by rotation angle if not 0
        If numRotationAngle.Value <> 0 Then
            RotateSketch(oSketch, line5.Geometry.MidPoint, numRotationAngle.Value)
        ElseIf numRotationAngle.Value = 0 Then
            'set line to be horizontal to constrain sketch
            geomConstraints.AddHorizontal(oRectangleLines.Item(1))
        End If

        'project the center point into the sketch
        oSketch.AddByProjectingEntity(oCompDef.WorkPoints.Item("Center Point"))

        'rename sketch
        RenameSketch(sketchName)

        'end transaction for creating a single undo operation
        oTrans.End()

    End Sub

    Private Sub AddTol(ByRef dowelHole As HoleFeature)
        'subroutine to add tolerance to holes, requires the holeFeature for the dowel holes

        If cmbTolerance.Text = "H7 - Slip" Then
            dowelHole.HoleDiameter.Tolerance.SetToFits(ToleranceTypeEnum.kLimitsFitsShowSizeTolerance, "H7", "")
        ElseIf cmbTolerance.Text = "P7 - Press" Then
            dowelHole.HoleDiameter.Tolerance.SetToFits(ToleranceTypeEnum.kLimitsFitsShowSizeTolerance, "P7", "")
        End If

        ThisApplication.ActiveDocument.Rebuild() 'rebuild to have tolerance take effect
    End Sub

    Private Sub ColorHoles(ByRef dowelHole As HoleFeature)
        'add color to dowel holes, requires the holeFeature for the dowel holes
        Dim dowelFace As Face

        For Each dowelFace In dowelHole.Faces
            If cmbTolerance.Text = "H7 - Slip" Then
                dowelFace.SetRenderStyle(StyleSourceTypeEnum.kOverrideRenderStyle, ThisApplication.ActiveDocument.RenderStyles.Item("Fit - Slip"))
            ElseIf cmbTolerance.Text = "P7 - Press" Then
                dowelFace.SetRenderStyle(StyleSourceTypeEnum.kOverrideRenderStyle, ThisApplication.ActiveDocument.RenderStyles.Item("Fit - Press"))
            End If
        Next dowelFace

    End Sub

    Private Sub RotateSketch(ByRef mySketch As PlanarSketch, rotatePoint As Point2d, Angle As Integer)
        'sub routine to rotate the sketch by a specified angle and around a rotatePoint
        Dim pi As Double
        Dim radians As Double
        pi = 3.141592654
        radians = (Angle * pi) / 180

        Dim sketchObjects As ObjectCollection
        sketchObjects = ThisApplication.TransientObjects.CreateObjectCollection

        'add each sketch entity to the object collection
        Dim oSketchEntity As SketchEntity
        For Each oSketchEntity In mySketch.SketchEntities
            sketchObjects.Add(oSketchEntity)
        Next

        'Rotate object around center point, dont copy, dont remove constraints
        mySketch.RotateSketchObjects(sketchObjects, rotatePoint, radians, False, False)
        ThisApplication.ActiveDocument.Rebuild() 'rebuild to have everything take effect

    End Sub

    Private Sub RenameSketch(sketchName As String)
        'sub to rename the sketch, if an error then it changes the count and appends the sketchName
        Dim count As Integer = 1
        Dim stringLength As Integer
        Dim loc As Integer
        Dim renamed As Boolean = False

        'try to rename sketch until it can, renamed = true
        Do Until renamed = True
            Try
                oCompDef.Sketches.Item(oCompDef.Sketches.Count).Name = sketchName
                renamed = True
            Catch
                count = count + 1
                'looks for the underscore in the sketch name, if it is not there, the sketch name 
                'has not been appended yet            
                If InStr(1, sketchName, "_") = 0 Then
                    'sketch does not have appended name
                    sketchName = sketchName & "_" & count

                ElseIf InStr(1, sketchName, "_") > 0 Then
                    stringLength = Len(sketchName)
                    'find location of "_"
                    loc = InStr(1, sketchName, "_")
                    'remove end of string including underscore
                    'sketchName = Left(sketchName, loc - 1)
                    sketchName = sketchName.Substring(0, loc - 1)
                    'rebuild the string with the new number at the end
                    sketchName = sketchName & "_" & count
                End If

            End Try
        Loop


    End Sub

    Private Sub cmbTemplate_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbTemplate.SelectionChangeCommitted
        'display thumbnail based on combobox selection, enable/disable options based on selection

        'mark the flag that a template selection has been made
        blTemplateSelected = True

        'Define an image thumbnail to show
        Dim myImage As System.Drawing.Bitmap

        Select Case cmbTemplate.Text
            Case "MPG+ 25 Finger"
                'picThumbnail.Image(My.Resources.BAG40mm)
                myImage = My.Resources.MPG25
                chkFlip.Enabled = True
            Case "MPG+ 32 Finger"
                myImage = My.Resources.MPG32
                chkFlip.Enabled = True
            Case "MPG+ 40 Finger"
                myImage = My.Resources.MPG40
                chkFlip.Enabled = True
            Case "MPG+ 25 Pneu"
                myImage = My.Resources.MPG25_pneu
                chkFlip.Enabled = True
            Case "MPG+ 32 Pneu"
                myImage = My.Resources.MPG32_pneu
                chkFlip.Enabled = True
            Case "MPG+ 40 Pneu"
                myImage = My.Resources.MPG40_Pneu
                chkFlip.Enabled = True
            Case "BAG 40mm"
                myImage = My.Resources.BAG40mm
                chkFlip.Enabled = False
                chkThreaded.Enabled = False
            Case "BAG 55mm"
                myImage = My.Resources.BAG55mm
                chkFlip.Enabled = False
                chkThreaded.Enabled = False
            Case "BAG 75mm A"
                myImage = My.Resources.BAG75mm
                chkFlip.Enabled = False
                chkThreaded.Enabled = False
            Case "Escapement Support"
                myImage = My.Resources.S4085_0004_01
                chkFlip.Enabled = False
                chkThreaded.Enabled = False
            Case "S4085.0006.01"
                myImage = My.Resources.S4085_0006_01
                chkFlip.Enabled = False
                chkThreaded.Enabled = False
            Case "S38.14974.00"
                myImage = My.Resources.S38_14974_00
                chkFlip.Enabled = False
                chkThreaded.Enabled = False
            Case Else
                myImage = Nothing
                'do nothing
        End Select

        'display thumbnail based on selection
        If Not myImage Is Nothing Then
            picThumbnail.Image = CType(myImage, System.Drawing.Image)
        End If

    End Sub

    Private Sub cmbTolerance_SelectionChangeCommitted(sender As Object, e As EventArgs) Handles cmbTolerance.SelectionChangeCommitted
        'mark the flag that a tolerance selection has been made
        blTolSelected = True

    End Sub

    Private Sub chkShowThumb_CheckedChanged(sender As Object, e As EventArgs) Handles chkShowThumb.CheckedChanged
        'expands or contracts the form window based on the show thumb checkbox
        If (chkShowThumb.Checked = True) Then
            Me.Width = 350
        Else
            Me.Width = 185
        End If
    End Sub

    Private Sub frmHoleMaker_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        'would like to cancel interaction when the form is closing to not have the cursor have the + mark along with it

        If Not oInteraction Is Nothing Then
            oInteraction.Stop()
        End If

        oSelect = Nothing
        oInteraction = Nothing
    End Sub

    Private Sub frmHoleMaker_HelpButtonClicked(sender As Object, e As CancelEventArgs) Handles Me.HelpButtonClicked

    End Sub


End Class