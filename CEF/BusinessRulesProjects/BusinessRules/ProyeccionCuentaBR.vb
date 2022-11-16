Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.EnterpriseServices
Imports CEF.DataAccess

Imports CEF.BusinessEntity
Imports CEF.Common.Globals
Imports CEF.Common
Imports System.Reflection

Namespace CEF.BusinessRules
    <JustInTimeActivation(True), _
    Synchronization(SynchronizationOption.RequiresNew), _
    Transaction(TransactionOption.RequiresNew)> _
    Public Class ProyeccionCuentaBR
        Inherits BLO
        Implements IProyeccionCuenta

        Sub New()
            MyBase.New()
        End Sub

        <AutoComplete(True)> _
        Public Function leer(ByVal intCodMetodizado As Integer, ByVal intCodProyeccion As Integer) As System.Data.DataSet Implements IProyeccionCuenta.leer
            Dim odaProyeccionCuenta As New DataAccess.ProyeccionCuentaDA
            Try
                'If (intCodProyeccion = ecEstadoCreacionProyeccion.NUEVO) Then
                'Return odaProyeccionCuenta.leer(intCodMetodizado, ecEstadoCreacionProyeccion.NUEVO)
                'Else
                Return odaProyeccionCuenta.leer(intCodMetodizado, intCodProyeccion)
                'End If
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaProyeccionCuenta Is Nothing) Then
                    ServicedComponent.DisposeObject(odaProyeccionCuenta)
                End If
            End Try
        End Function
    End Class
End Namespace
