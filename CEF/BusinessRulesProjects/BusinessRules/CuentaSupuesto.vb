'*************************************************************
'Proposito:
'Autor: Luis A. Mascaro Jácome
'Fecha Creacion: 14/01/2006
'Modificado por:
'Fecha Mod.:
'*************************************************************

Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.EnterpriseServices
Imports System.Runtime.InteropServices
Imports CEF.DataAccess
Imports CEF.BusinessEntity
Imports CEF.Common
Imports System.Reflection

Namespace CEF.BusinessRules

    <JustInTimeActivation(True), _
    Synchronization(SynchronizationOption.RequiresNew), _
    Transaction(TransactionOption.RequiresNew)> _
    Public Class CuentaSupuesto
        Inherits BLO
        Implements ICuentaSupuesto

        Sub New()
            MyBase.New()
        End Sub

        <AutoComplete(True)> _
        Public Function listar(ByVal pbytFlag As Byte, ByVal pbytEstado As Byte) As DataSet Implements ICuentaSupuesto.listar
            Dim odaCuentaSupuesto As DataAccess.CuentaSupuesto = Nothing
            Try
                odaCuentaSupuesto = New DataAccess.CuentaSupuesto
                Return (odaCuentaSupuesto.listar(pbytFlag, pbytEstado))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaCuentaSupuesto Is Nothing) Then
                    ServicedComponent.DisposeObject(odaCuentaSupuesto)
                End If
            End Try
        End Function

    End Class

End Namespace