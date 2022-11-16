'***************************************************************
'Proposito: Administración de las ejecuciciones de Base de Datos
'Autor: Luis A. Mascaro Jácome
'Fecha Creacion:
'Modificado por:
'Fecha Mod.:
'***************************************************************
Imports System
Imports System.Data
Imports System.Data.SqlClient
Imports System.Diagnostics
Imports System.Reflection
Imports System.EnterpriseServices
Imports System.Runtime.InteropServices
Imports System.Collections
Imports Microsoft.VisualBasic
Imports CEF.Common

Namespace CEF.DataAccess

    Public NotInheritable Class ManejadorBD
        Implements IDisposable

        Private vcCadenaConexion As String
        Private vcCommand As SqlCommand

        Sub New(ByVal pvRegistroClaveWin As String, ByVal pvNombreValor As String)
            Dim voRegistroClaveWin As New RegistroClaveWin(pvRegistroClaveWin)
            vcCadenaConexion = voRegistroClaveWin.leerValor(pvNombreValor)
        End Sub

        Sub New(ByVal pvArchivoDataConfig As String, ByVal pvSeccion As String, ByVal pvClave As String)
            Dim voDataConfig As New DataConfig(pvArchivoDataConfig)
            vcCadenaConexion = voDataConfig.leerValor(pvSeccion, pvClave)
        End Sub

        Sub New(ByVal pvCadenaConexion As String)
            vcCadenaConexion = pvCadenaConexion
        End Sub

        Public ReadOnly Property CadenaConexion() As String
            Get
                Return Me.vcCadenaConexion
            End Get
        End Property

        Public Sub Dispose() Implements IDisposable.Dispose
            Dispose(True)
            GC.SuppressFinalize(True)
        End Sub

        Private Sub Dispose(ByVal disposing As Boolean)
            If (Not disposing) Then
                Exit Sub
            End If
            If Not vcCommand Is Nothing Then
                Dim voConnection As SqlConnection = vcCommand.Connection
                Debug.Assert(Not voConnection Is Nothing)
                vcCommand.Dispose()
                vcCommand = Nothing
                voConnection.Dispose()
            End If
        End Sub

        Protected Overrides Sub Finalize()
            vcCommand = Nothing
            vcCadenaConexion = Nothing
            MyBase.Finalize()
        End Sub

        ' XT5022 : 21-01-2014 - JAVILA (CGI)
        ' Agregando modificación timeout
        Public Function traerDatos(ByVal pvSProc As String, ByVal pvParametros() As SqlParameter, Optional ByVal piTimeOut As Integer = 0) As DataSet
            Try
                pintarDebug("traerDatos", pvSProc, pvParametros)
                Dim voDataAdapter As SqlDataAdapter = New SqlDataAdapter(pvSProc, vcCadenaConexion)

                Dim voDataSet As New DataSet
                With voDataAdapter.SelectCommand
                    .CommandType = CommandType.StoredProcedure
                    If Not pvParametros Is Nothing Then
                        For Each voParameter As SqlParameter In pvParametros
                            .Parameters.Add(voParameter)
                        Next
                    End If
                    ' XT5022 : 21-01-2014 - JAVILA (CGI)
                    If piTimeOut <> 0 Then
                        .CommandTimeout = piTimeOut
                    End If
                End With

                voDataAdapter.Fill(voDataSet)

                Return (voDataSet)
            Catch ex As Exception
                'Debug.WriteLine(e.Message)
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            End Try
        End Function

        Public Function ejecutarSProc(ByVal pvSProc As String, ByVal pvParametros() As SqlParameter, Optional ByVal piTimeOut As Integer = 0) As Boolean
            pintarDebug("ejecutarSProc", pvSProc, pvParametros)
            Try
                vcCommand = New SqlCommand(pvSProc, New SqlConnection(vcCadenaConexion))
                vcCommand.CommandType = CommandType.StoredProcedure
                For Each voParameter As SqlParameter In pvParametros
                    vcCommand.Parameters.Add(voParameter)
                Next

                If piTimeOut <> 0 Then
                    vcCommand.CommandTimeout = piTimeOut
                End If

                vcCommand.Connection.Open()
                vcCommand.ExecuteNonQuery()
                Return (True)
            Catch ex As Exception
                Logger.Error(MethodInfo.GetCurrentMethod, ex, "")
                Throw ex
            Finally
                If Not vcCommand Is Nothing Then
                    vcCommand.Connection.Close()
                    vcCommand.Dispose()
                End If
            End Try
        End Function


        '<= HMM:INDRA 14-11-2013
        Sub pintarDebug(ByVal argMetodo As String, ByVal argSp As String, ByVal voParameters() As SqlParameter)

            Dim strCadena As String = ""
            Dim strTipo As Integer
            Dim i As Integer
            Debug.WriteLine("--------------ManejadorBD::Metodo::" & argMetodo & "--------------")
            Debug.WriteLine("argSp:" & argSp)
            ' javila [CGI] : 18.12.13
            'Debug.WriteLine("argParm:" & voParameters.Length)
            ''For i As Integer = 0 To argParm.Size - 1
            'For Each commandParameter As SqlParameter In voParameters

            '    ' Dim objAls As ArrayList = voParameters(i)
            '    'Debug.WriteLine("argParm(" & i & ")=" & objAls(0) & "|" & objAls(3)) ' & "|" & objAls(2))
            '    'strTipo = voParameters.GetType.GetType.
            '    If i = 0 Then
            '        strCadena = " " & formatoArg(strTipo, commandParameter.Value)
            '    Else
            '        strCadena = strCadena & "," & formatoArg(strTipo, commandParameter.Value)
            '    End If
            'Next
            'Debug.WriteLine("Exec " & argSp & strCadena)

            Debug.WriteLine("-------------------------------------------------------")
        End Sub

        Function formatoArg(ByVal strTipo As Integer, ByVal strValor As String) As String
            Dim strformat As String = ""
            Select Case strTipo
                Case 4, 5, 11, 12 'datetime,decimal,nvarchar,ntext
                    strformat = "'" & (IIf(strValor = Nothing, "", strValor)) & "'"
                Case Else
                    strformat = strValor
            End Select
            Return strformat
        End Function

    End Class

End Namespace