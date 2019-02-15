Imports Inventor

Module StepperModule

    'module for providing the functionality used in the AnimateAssembly form


    Public Function LocateInCenter(ByVal parent As System.Windows.Forms.Form, ByVal child As System.Windows.Forms.Form) As System.Drawing.Point
        'function to find the center point of the parent form 
        'and locate the child form in the center of the parent
        'returns the top left location the child should be on the parent

        Dim parentCenter As System.Drawing.Point

        'calculate the center locaton of the parent form
        parentCenter.X = parent.Location.X + (parent.Width / 2)
        parentCenter.Y = parent.Location.Y + (parent.Height / 2)
        'calculate the top left point of the child form
        LocateInCenter.X = parentCenter.X - (child.Width / 2)
        LocateInCenter.Y = parentCenter.Y - (child.Height / 2)

        Return LocateInCenter

    End Function

    Public Function BrowseForPath(ByVal filter As String) As String
        Dim myFileDlog As New System.Windows.Forms.OpenFileDialog 'OpenFileDialog()

        'look for files starting at desktop, doesnt quite work correctly now        
        myFileDlog.InitialDirectory = System.Environment.SpecialFolder.MyComputer

        'specifies what type of data files to look for
        myFileDlog.Filter = filter '"All Files (*.*)|*.*"

        'specifies which data type is focused on start up
        myFileDlog.FilterIndex = 1

        'Gets or sets a value indicating whether the dialog box restores the current directory before closing.
        myFileDlog.RestoreDirectory = True

        'seperates message outputs for files found or not found
        If (myFileDlog.ShowDialog() = System.Windows.Forms.DialogResult.OK) Then
            'Adds the file directory to the text box
            Return myFileDlog.FileName
        Else
            Return ""
        End If

    End Function







End Module
