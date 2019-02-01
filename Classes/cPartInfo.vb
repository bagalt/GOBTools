Public Class cPartInfo

    'Class module for part information.  It should operate similar to a collection
    'have fields for part number, proman class code, description, and cust serv code
    'support accessing each element
    'support count
    'support seeing if part number already exists

    Private pPartNum As String          'Part number of the part
    Private pPromanCode As String       'Proman class code
    Private pDescription As String      'English description of the part
    Private pServCode As String         'Customer service code

    'for purchased parts
    Private pVendCode As String         '6-character vendor code
    Private pManufName As String        'Manufacturer name
    Private pManufNum As String         'Manufacturer number

    Private pError As Boolean           'error flag, used to indicate missing info
    Private pErrorMsg As String         'holds what the errors are

    Private pParentAssy As String       'parent assembly of the part
    Private pBreadCrumb As Collection   'breadcrumb to the part aka the path down to the part in the assy tree
    Private pQty As Integer             'part quantity per assembly

    Private Sub Class_Initialize()
        pBreadCrumb = New Collection
        pPartNum = ""
        pPromanCode = ""
        pDescription = ""
        pServCode = ""
        pVendCode = ""
        pManufName = ""
        pManufNum = ""
        pError = False
        pErrorMsg = ""
        pParentAssy = ""
        pQty = 0
    End Sub

    'Part Number property
    Public Property PartNum() As String
        Get
            Return pPartNum
        End Get
        Set(value As String)
            'could put data validation code into the let procedures
            'let properties assign values to the class
            pPartNum = value
        End Set
    End Property

    'Class Code property
    Public Property PromanCode() As String
        Get
            Return pPromanCode
        End Get
        Set(value As String)
            pPromanCode = value
        End Set
    End Property

    'description property
    Public Property Description() As String
        Get
            Return pDescription
        End Get
        Set(value As String)
            pDescription = value
        End Set
    End Property

    'Service Code property
    Public Property ServiceCode() As String
        Get
            Return pServCode
        End Get
        Set(value As String)
            pServCode = value
        End Set
    End Property

    '6-character Vendor Code property
    Public Property VendorCode() As String
        Get
            Return pVendCode
        End Get
        Set(value As String)
            pVendCode = value
        End Set
    End Property

    'manufacturer name property
    Public Property ManufName() As String
        Get
            Return pManufName
        End Get
        Set(value As String)
            pManufName = value
        End Set
    End Property

    'manufacturer number property
    Public Property ManufNum() As String
        Get
            Return pManufNum
        End Get
        Set(value As String)
            pManufNum = value
        End Set
    End Property

    'ParentAssy number property
    Public Property ParentAssy() As String
        Get
            Return pParentAssy
        End Get
        Set(value As String)
            pParentAssy = value
        End Set
    End Property

    'Breadcrumb collection property
    Public Property Breadcrumb() As Collection
        Get
            Return pBreadCrumb
        End Get
        Set(value As Collection)
            pBreadCrumb = value
        End Set
    End Property

    'Qty  property
    Public Property Qty() As Integer
        Get
            Return pQty
        End Get
        Set(value As Integer)
            pQty = value
        End Set
    End Property

    'error property
    Public Property PartError() As String
        Get
            Return pError
        End Get
        Set(value As String)
            pError = value
        End Set
    End Property

    'error message property
    Public Property ErrorMsg() As String
        Get
            Return pErrorMsg
        End Get
        Set(value As String)
            pErrorMsg = value
        End Set
    End Property

    Public Function PrintBreadCrumb() As String
        'debug print function to print the breadcrumb

        Dim item As Object
        Dim path As String
        path = ""

        For Each item In pBreadCrumb
            If path = "" Then
                path = item
            Else
                path = path & "->" & item
            End If
        Next

        'Debug.Print path
        PrintBreadCrumb = path

    End Function

    Public Function IncrementQty(Num As Integer) As Integer
        'function to increment the quantity by Num
        'this will allow the quantity per assembly
        pQty = pQty + Num
    End Function
End Class
