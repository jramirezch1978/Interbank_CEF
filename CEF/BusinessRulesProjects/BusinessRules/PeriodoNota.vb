Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.EnterpriseServices
Imports System.Runtime.InteropServices
Imports CEF.DataAccess

Imports CEF.BusinessEntity
Imports System.Collections
Imports CEF.Common
Imports System.Reflection

Namespace CEF.BusinessRules

    <JustInTimeActivation(True), _
    Synchronization(SynchronizationOption.RequiresNew), _
    Transaction(TransactionOption.RequiresNew)> _
    Public Class PeriodoNota
        Inherits BLO
        Implements IPeriodoNota

        Sub New()
            MyBase.New()
        End Sub

        <AutoComplete(True)> _
        Public Function listarBD(ByVal pstrCodMetodizado As Int32, ByVal pstrArrayPeriodoFiltrado As String, ByVal pintCodigoCuenta As Int16) As ArrayList Implements IPeriodoNota.listarBD
            Dim odaPeriodoNota As DataAccess.PeriodoNota = Nothing

            Try
                Dim arrPeriodo As String() = pstrArrayPeriodoFiltrado.Split(";")
                Array.Reverse(arrPeriodo)
                Dim arrRetorno As New ArrayList

                For Each tper As String In arrPeriodo
                    odaPeriodoNota = New DataAccess.PeriodoNota
                    Dim odaPeriodoDR As DataRow = (odaPeriodoNota.listarBD(pstrCodMetodizado, CType(tper, Int16), pintCodigoCuenta)).Rows(0)

                    Dim periodoNota As New CEF.BusinessEntity.PeriodoNota
                    periodoNota.CodMetodizado = CType(odaPeriodoDR("CODMETODIZADO"), Int32)
                    periodoNota.CodPeriodo = CType(odaPeriodoDR("CODPERIODO"), Int16)
                    periodoNota.CodCuenta = CType(odaPeriodoDR("CODCUENTA"), Int16)
                    periodoNota.Nota = CType(odaPeriodoDR("DESNOTA"), String)
                    periodoNota.FechaPeriodo = CType(odaPeriodoDR("FECPERIODO"), String)
                    periodoNota.NombreUsuario = CType(odaPeriodoDR("NOMBREUSUARIO"), String)
                    periodoNota.Estado = CType(odaPeriodoDR("ESTADO"), String)
                    periodoNota.Situacion = CType(odaPeriodoDR("SITUACION"), String)
                    periodoNota.AuditorDesc = CType(odaPeriodoDR("AUDITORDESC"), String)

                    arrRetorno.Add(periodoNota)

                Next

                Return arrRetorno

            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex

            Finally
                If Not odaPeriodoNota Is Nothing Then
                    ServicedComponent.DisposeObject(odaPeriodoNota)
                End If
            End Try

        End Function

        '<AutoComplete(True)> _
        'Public Function listarNotaPeriodo(ByVal pstrCodMetodizado As Int32, ByVal pstrArrayPeriodoFiltrado As String, ByVal pstrCodCuenta As Int16) As ArrayList
        '    Dim dtNota As DataTable = listarBD(pstrCodMetodizado, pstrArrayPeriodoFiltrado, pstrCodCuenta)
        '    Dim arrRetorno As New ArrayList

        '    For Each dtRow As DataRow In dtNota.Rows
        '        Dim periodoNota As New CEF.BusinessEntity.PeriodoNota
        '        With periodoNota
        '            .CodCuenta = pstrCodCuenta
        '            .CodMetodizado = Int32.Parse(dtRow("CODMETODIZADO"))
        '            .CodPeriodo = Int16.Parse(dtRow("CODPERIODO"))
        '            .Nota = CType(dtRow("NOTA"), String)
        '            .UsuarioIns = CType(dtRow("CODUSUARIOINS"), String)
        '            .UsuarioUpd = CType(dtRow("CODUSUARIOUPD"), String)
        '            .AuditorDesc = CType(dtRow("AUDITORDESC"), String)
        '            .Estado = CType(dtRow("ESTADO"), String)
        '            .Situacion = CType(dtRow("SITUACION"), String)
        '            .NombreUsuario = CType(dtRow("NOMBREUSUARIO"), String)
        '            .CodPeriodo = Int16.Parse(dtRow("CODPERIODO"))
        '            .FechaPeriodo = CType(dtRow("FECPERIODO"), String)

        '        End With
        '        arrRetorno.Add(periodoNota)
        '    Next
        '    Return arrRetorno
        'End Function

        <AutoComplete(True)> _
        Public Function EnviaDatos(ByVal parms As String, ByVal user As String) As Int16
            Dim cad As String() = parms.Split("*")
            Dim arrEnviaDatos As New ArrayList
            Try
                For Each arrpar As String In cad
                    Dim subcad As String() = arrpar.Split("|")
                    Dim ePeriodoNota As New CEF.BusinessEntity.PeriodoNota
                    ePeriodoNota.CodMetodizado = CType(subcad(0), Int32)
                    ePeriodoNota.CodPeriodo = CType(subcad(1), Int16)
                    ePeriodoNota.CodCuenta = CType(subcad(2), Int16)
                    ePeriodoNota.Nota = subcad(3)
                    ePeriodoNota.UsuarioIns = user
                    ePeriodoNota.UsuarioUpd = user
                    arrEnviaDatos.Add(ePeriodoNota)
                Next

                Return guardar(arrEnviaDatos)
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex

            End Try
 

        End Function

        <AutoComplete(True)> _
        Public Function guardar(ByVal ListaNotas As ArrayList) As Int16 Implements IPeriodoNota.guardar
            Dim odaNotaPeriodo As CEF.DataAccess.PeriodoNota = Nothing
            Try
                odaNotaPeriodo = New CEF.DataAccess.PeriodoNota

                For Each objListaNota As Object In ListaNotas
                    Dim entListaNota As New CEF.BusinessEntity.PeriodoNota
                    entListaNota = CType(objListaNota, CEF.BusinessEntity.PeriodoNota)
                    odaNotaPeriodo.guardar(entListaNota)
                Next

                Return 1
            Catch Ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, Ex, "")
                Return 0
            Finally
                If Not odaNotaPeriodo Is Nothing Then
                    ServicedComponent.DisposeObject(odaNotaPeriodo)
                End If
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function verificarExistenciaNota(ByVal pstrCodMetodizado As Int32, ByVal pstrArrayPeriodoFiltrado As String, ByVal pintCodigoCuenta As Int16) As Int16 Implements IPeriodoNota.verificarExistenciaNota
            Dim odaPeriodoNota As DataAccess.PeriodoNota = Nothing
            Try
                odaPeriodoNota = New CEF.DataAccess.PeriodoNota
                Return odaPeriodoNota.verificarExistenciaNota(pstrCodMetodizado, pstrArrayPeriodoFiltrado, pintCodigoCuenta)
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            End Try
        End Function

    End Class

End Namespace
