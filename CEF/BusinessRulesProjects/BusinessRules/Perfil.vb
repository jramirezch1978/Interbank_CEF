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
    Public Class Perfil
        Inherits BLO
        Implements IPerfil

        Sub New()
            MyBase.New()
        End Sub

        <AutoComplete(True)> _
        Public Function leer(ByVal pshoCodPerfil As Short) As BusinessEntity.Perfil Implements IPerfil.leer
            Dim odaPerfil As DataAccess.Perfil = Nothing
            Dim dsPerfil As DataSet
            Try
                odaPerfil = New DataAccess.Perfil
                dsPerfil = odaPerfil.leer(pshoCodPerfil)
                Dim obePerfil As BusinessEntity.Perfil
                If dsPerfil.Tables(0).Rows.Count > 0 Then
                    obePerfil = New BusinessEntity.Perfil
                    obePerfil.CodPerfil = dsPerfil.Tables(0).Rows(0)("CodPerfil")
                    obePerfil.Nombre = dsPerfil.Tables(0).Rows(0)("Nombre")
                    obePerfil.FecReg = dsPerfil.Tables(0).Rows(0)("FecReg")
                    obePerfil.Estado = dsPerfil.Tables(0).Rows(0)("Estado")
                End If
                Return (obePerfil)
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaPerfil Is Nothing) Then
                    ServicedComponent.DisposeObject(odaPerfil)
                End If
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function listar(ByVal pbytFlag As Byte, ByVal pbytEstado As Byte) As DataSet Implements IPerfil.listar
            Dim odaPerfil As DataAccess.Perfil = Nothing
            Try
                odaPerfil = New DataAccess.Perfil
                Return (odaPerfil.listar(pbytFlag, pbytEstado))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaPerfil Is Nothing) Then
                    ServicedComponent.DisposeObject(odaPerfil)
                End If
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function agregar(ByRef pobePerfil As BusinessEntity.Perfil) As Boolean Implements IPerfil.agregar
            Dim odaPerfil As DataAccess.Perfil = Nothing
            Try
                odaPerfil = New DataAccess.Perfil
                pobePerfil.FecReg = DateTime.Today()
                Return (odaPerfil.agregar(pobePerfil))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Return (False)
            Finally
                If (Not odaPerfil Is Nothing) Then
                    ServicedComponent.DisposeObject(odaPerfil)
                End If
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function modificar(ByRef pobePerfil As BusinessEntity.Perfil) As Boolean Implements IPerfil.modificar
            Dim odaPerfil As DataAccess.Perfil = Nothing
            Try
                odaPerfil = New DataAccess.Perfil
                Return (odaPerfil.modificar(pobePerfil))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Return (False)
            Finally
                If (Not odaPerfil Is Nothing) Then
                    ServicedComponent.DisposeObject(odaPerfil)
                End If
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function eliminar(ByVal pshoCodPerfil As Short) As Boolean Implements IPerfil.eliminar
            Dim odaPerfil As DataAccess.Perfil = Nothing
            Try
                odaPerfil = New DataAccess.Perfil
                Return (odaPerfil.eliminar(pshoCodPerfil))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Return (False)
            Finally
                If (Not odaPerfil Is Nothing) Then
                    ServicedComponent.DisposeObject(odaPerfil)
                End If
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function listarCarteraPerfil(ByVal pshoCodPerfilResponsable As Short) As BusinessEntity.CarteraPerfilLst Implements IPerfil.listarCarteraPerfil
            Dim odaPerfil As DataAccess.Perfil = Nothing
            Try
                odaPerfil = New DataAccess.Perfil
                Dim dsCarteraPerfil As DataSet = odaPerfil.listarCarteraPerfil(pshoCodPerfilResponsable)
                Dim obeCarteraPerfilLst As BusinessEntity.CarteraPerfilLst = New BusinessEntity.CarteraPerfilLst
                For Each drCarteraPerfil As DataRow In dsCarteraPerfil.Tables(0).Rows
                    Dim obeCarteraPerfil As BusinessEntity.CarteraPerfil = New BusinessEntity.CarteraPerfil
                    obeCarteraPerfil.CodPerfilResponsable = drCarteraPerfil.Item("CodPerfilResponsable")
                    obeCarteraPerfil.CodPerfilSubordinado = drCarteraPerfil.Item("CodPerfilSubordinado")
                    obeCarteraPerfilLst.Add(obeCarteraPerfil)
                Next
                Return (obeCarteraPerfilLst)
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaPerfil Is Nothing) Then
                    ServicedComponent.DisposeObject(odaPerfil)
                End If
            End Try
        End Function

    End Class

End Namespace