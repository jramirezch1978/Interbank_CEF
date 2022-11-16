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

Namespace CEF.DataAccess
    Public Class DAO
        Inherits ServicedComponent

        Protected Friend vcManejadoBD As ManejadorBD
        Protected Friend Const ccARCHIVO_LOG As String = "CEFDataLog.xml"

        Sub New()
            vcManejadoBD = Nothing
        End Sub

        Protected Overrides Sub Deactivate()
            If (Not vcManejadoBD Is Nothing) Then
                vcManejadoBD = Nothing
            End If
        End Sub

    End Class
End Namespace
