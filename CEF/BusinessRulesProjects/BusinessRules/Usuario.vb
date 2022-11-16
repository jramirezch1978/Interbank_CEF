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
    Public Class Usuario
        Inherits BLO
        Implements IUsuario

        Sub New()
            MyBase.New()
        End Sub

        <AutoComplete(True)> _
        Public Function leer(ByVal pstrCodUsuario As String) As BusinessEntity.Usuario Implements IUsuario.leer
            Dim odaUsuario As DataAccess.Usuario = Nothing
            Try
                odaUsuario = New DataAccess.Usuario
                Dim obeUsuario As BusinessEntity.Usuario
                Dim dsUsuario As DataSet = odaUsuario.leer(pstrCodUsuario)
                If dsUsuario.Tables(0).Rows.Count > 0 Then
                    Dim drUsuario As DataRow = dsUsuario.Tables(0).Rows(0)
                    obeUsuario = cargaUsuario(drUsuario)
                End If
                Return (obeUsuario)
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaUsuario Is Nothing) Then
                    ServicedComponent.DisposeObject(odaUsuario)
                End If
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function buscar(ByRef pobeUsuario As BusinessEntity.Usuario) As System.Data.DataSet Implements IUsuario.buscar
            Dim odaUsuario As DataAccess.Usuario = Nothing
            Try
                odaUsuario = New DataAccess.Usuario
                Return (odaUsuario.buscar(pobeUsuario))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaUsuario Is Nothing) Then
                    ServicedComponent.DisposeObject(odaUsuario)
                End If
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function listar(ByVal pbytFlag As Byte, ByVal pbytEstado As Byte) As System.Data.DataSet Implements IUsuario.listar
            Dim odaUsuario As DataAccess.Usuario = Nothing
            Try
                odaUsuario = New DataAccess.Usuario
                Return (odaUsuario.listar(pbytFlag, pbytEstado))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaUsuario Is Nothing) Then
                    ServicedComponent.DisposeObject(odaUsuario)
                End If
            End Try
        End Function

        <AutoComplete(True)> _
        Private Function cargaUsuario(ByRef pdrUsuario As DataRow) As BusinessEntity.Usuario
            Dim obeUsuario As BusinessEntity.Usuario = New BusinessEntity.Usuario
            Try
                obeUsuario.CodUsuario = pdrUsuario.Item("CodUsuario")
                obeUsuario.Nombre = pdrUsuario.Item("Nombre")
                If Not pdrUsuario.IsNull("Email") Then obeUsuario.Email = pdrUsuario.Item("Email")
                obeUsuario.CodPerfil = pdrUsuario.Item("CodPerfil")
                obeUsuario.FecReg = pdrUsuario.Item("FecReg")
                obeUsuario.Estado = pdrUsuario.Item("Estado")
                obeUsuario.Supervisor = pdrUsuario.Item("Supervisor")
                Return (obeUsuario)
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
            End Try

        End Function

        <AutoComplete(True)> _
        Public Function agregar(ByRef pobeUsuario As BusinessEntity.Usuario) As Boolean Implements IUsuario.agregar
            Dim odaUsuario As DataAccess.Usuario = Nothing
            Try
                odaUsuario = New DataAccess.Usuario
                pobeUsuario.FecReg = DateTime.Today()
                Return (odaUsuario.agregar(pobeUsuario))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Return (False)
            Finally
                If (Not odaUsuario Is Nothing) Then
                    ServicedComponent.DisposeObject(odaUsuario)
                End If
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function modificar(ByRef pobeUsuario As BusinessEntity.Usuario) As Boolean Implements IUsuario.modificar
            Dim odaUsuario As DataAccess.Usuario = Nothing
            Try
                odaUsuario = New DataAccess.Usuario
                Return (odaUsuario.modificar(pobeUsuario))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Return (False)
            Finally
                If (Not odaUsuario Is Nothing) Then
                    ServicedComponent.DisposeObject(odaUsuario)
                End If
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function eliminar(ByVal pstrCodUsuario As String) As Boolean Implements IUsuario.eliminar
            Dim odaUsuario As DataAccess.Usuario = Nothing
            Try
                odaUsuario = New DataAccess.Usuario
                Return (odaUsuario.eliminar(pstrCodUsuario))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Return (False)
            Finally
                If (Not odaUsuario Is Nothing) Then
                    ServicedComponent.DisposeObject(odaUsuario)
                End If
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function responsableCarteraUsuario(ByVal pstrCodUsuario As String) As BusinessEntity.Usuario Implements IUsuario.responsableCarteraUsuario
            Dim odaUsuario As DataAccess.Usuario = Nothing
            Try
                odaUsuario = New DataAccess.Usuario
                Dim obeUsuario As BusinessEntity.Usuario
                Dim dsUsuario As DataSet = odaUsuario.responsableCarteraUsuario(pstrCodUsuario)
                If dsUsuario.Tables(0).Rows.Count > 0 Then
                    Dim drUsuario As DataRow = dsUsuario.Tables(0).Rows(0)
                    obeUsuario = cargaUsuario(drUsuario)
                End If
                Return (obeUsuario)
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaUsuario Is Nothing) Then
                    ServicedComponent.DisposeObject(odaUsuario)
                End If
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function listarResponsableCarteraUsuario() As System.Data.DataSet Implements IUsuario.listarResponsableCarteraUsuario
            Dim odaUsuario As DataAccess.Usuario = Nothing
            Try
                odaUsuario = New DataAccess.Usuario
                Return (odaUsuario.listarResponsableCarteraUsuario())
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaUsuario Is Nothing) Then
                    ServicedComponent.DisposeObject(odaUsuario)
                End If
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function listarSubordinadoCarteraUsuario(ByVal pstrCodUsuarioResponsable As String) As System.Data.DataSet Implements IUsuario.listarSubordinadoCarteraUsuario
            Dim odaUsuario As DataAccess.Usuario = Nothing
            Try
                odaUsuario = New DataAccess.Usuario
                Return (odaUsuario.listarSubordinadoCarteraUsuario(pstrCodUsuarioResponsable))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaUsuario Is Nothing) Then
                    ServicedComponent.DisposeObject(odaUsuario)
                End If
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function listarUsuarioPorAsignarCarteraUsuario(ByVal pstrCodUsuarioResponsable As String) As System.Data.DataSet Implements IUsuario.listarUsuarioPorAsignarCarteraUsuario
            Dim odaUsuario As DataAccess.Usuario = Nothing
            Try
                odaUsuario = New DataAccess.Usuario
                Return (odaUsuario.listarUsuarioPorAsignarCarteraUsuario(pstrCodUsuarioResponsable))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaUsuario Is Nothing) Then
                    ServicedComponent.DisposeObject(odaUsuario)
                End If
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function agregarCarteraUsuario(ByRef pobeUsuario As BusinessEntity.Usuario) As DataSet Implements IUsuario.agregarCarteraUsuario
            Dim odaUsuario As DataAccess.Usuario = Nothing
            Try
                odaUsuario = New DataAccess.Usuario
                Return (odaUsuario.agregarCarteraUsuario(pobeUsuario))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaUsuario Is Nothing) Then
                    ServicedComponent.DisposeObject(odaUsuario)
                End If
            End Try
        End Function

        <AutoComplete(True)> _
        Public Function eliminarCarteraUsuario(ByRef pobeUsuario As BusinessEntity.Usuario) As Boolean Implements IUsuario.eliminarCarteraUsuario
            Dim odaUsuario As DataAccess.Usuario = Nothing
            Try
                odaUsuario = New DataAccess.Usuario
                Return (odaUsuario.eliminarCarteraUsuario(pobeUsuario))
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Return (False)
            Finally
                If (Not odaUsuario Is Nothing) Then
                    ServicedComponent.DisposeObject(odaUsuario)
                End If
            End Try
        End Function

        ' 16-01-2014 : XT5022 - JAVILA (CGI) 
        <AutoComplete(True)> _
        Public Function listarResponsableCarteraUsuarioBPE() As System.Data.DataSet Implements IUsuario.listarResponsableCarteraUsuarioBPE
            Dim odaUsuario As DataAccess.Usuario = Nothing
            Try
                odaUsuario = New DataAccess.Usuario
                Return (odaUsuario.listarResponsableCarteraUsuarioBPE())
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaUsuario Is Nothing) Then
                    ServicedComponent.DisposeObject(odaUsuario)
                End If
            End Try
        End Function

        ' 16-01-2014 : XT5022 - JAVILA (CGI) 
        <AutoComplete(True)> _
        Public Function listarResponsableCarteraUsuarioNoBPE() As System.Data.DataSet Implements IUsuario.listarResponsableCarteraUsuarioNoBPE
            Dim odaUsuario As DataAccess.Usuario = Nothing
            Try
                odaUsuario = New DataAccess.Usuario
                Return (odaUsuario.listarResponsableCarteraUsuarioNoBPE())
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If (Not odaUsuario Is Nothing) Then
                    ServicedComponent.DisposeObject(odaUsuario)
                End If
            End Try
        End Function

    End Class

End Namespace