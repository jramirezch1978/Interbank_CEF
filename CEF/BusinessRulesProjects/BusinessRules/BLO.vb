'*************************************************************
'Proposito:
'Autor: Luis A. Mascaro Jácome
'Fecha Creacion:
'Modificado por:
'Fecha Mod.:
'*************************************************************

Imports System
Imports System.Diagnostics
Imports System.EnterpriseServices
Imports System.Reflection
Imports System.Runtime.InteropServices

Namespace CEF.BusinessRules

    Public Class BLO
        Inherits ServicedComponent

        Protected Friend Const ccARCHIVO_LOG As String = "CEFLogicLog.xml"

        Sub New()
            MyBase.New()
        End Sub

        Protected Overrides Sub Deactivate()
            'nada
        End Sub

    End Class

End Namespace
