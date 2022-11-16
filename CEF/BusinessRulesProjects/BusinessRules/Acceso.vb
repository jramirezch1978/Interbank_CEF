'********************************************************************
'Proposito: Control del Peril de Usuario para la seguridad de acceso
'Autor: Luis A. Mascaro Jácome
'Fecha Creacion:
'Modificado por:
'Fecha Mod.:
'********************************************************************
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.EnterpriseServices
Imports System.Runtime.InteropServices
Imports CEF.DataAccess
Imports CEF.Common
Imports System.Reflection


Namespace CEF.BusinessRules

    <JustInTimeActivation(True), _
    Synchronization(SynchronizationOption.RequiresNew), _
    Transaction(TransactionOption.RequiresNew)> _
    Public Class Acceso
        Inherits BLO
        Implements IAcceso

        Sub New()
            MyBase.New()
        End Sub

        <AutoComplete(True)> _
        Public Function leer(ByVal pintCodPerfil As Integer) As DataSet Implements IAcceso.leer
            Dim odaAcceso As DataAccess.Acceso = Nothing
            Try
                odaAcceso = New DataAccess.Acceso
                Return (odaAcceso.leer(pintCodPerfil))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaAcceso Is Nothing) Then
                    ServicedComponent.DisposeObject(odaAcceso)
                End If
            End Try
        End Function

    End Class

End Namespace