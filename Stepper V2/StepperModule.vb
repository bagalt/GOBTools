Imports Inventor

Module StepperModule

    'module for providing the functionality used in the AnimateAssembly form

    Private Structure ActionData

        'structure to hold the data for the instance of each animation action
        Private m_invParameter As Inventor.Parameter
        Private m_paramName As String
        Private m_value As Double
        Private m_offset As Double

        'need get and set 
        Public Property invParameter As Inventor.Parameter
            Get
                Return m_invParameter
            End Get
            Set(value As Inventor.Parameter)
                m_invParameter = value
            End Set
        End Property


    End Structure

    Private Structure AnimationFrame

        'structure to contain the animation frame
        Private parameterData() As ActionData

    End Structure





End Module
