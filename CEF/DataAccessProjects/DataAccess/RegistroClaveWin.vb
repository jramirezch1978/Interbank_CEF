'***************************************************************
'Proposito: Soporte de acceso a los registros claves de Windows
'Autor: Luis A. Mascaro Jácome
'Fecha Creacion:
'Modificado por:
'Fecha Mod.:
'***************************************************************
Imports System
Imports Microsoft.Win32

Namespace CEF.DataAccess

    Public NotInheritable Class RegistroClaveWin

        Private vcRegistryKey As RegistryKey
        Private vcSubClave As String

        Sub New(ByVal pvSubClave As String)
            vcSubClave = pvSubClave
            vcRegistryKey = Registry.LocalMachine.OpenSubKey(vcSubClave)
        End Sub

        Protected Overrides Sub Finalize()
            vcRegistryKey.Close()
            MyBase.Finalize()
        End Sub

        Public Function leerValor(ByVal pvNombre As String) As String
            Return (Convert.ToString(vcRegistryKey.GetValue(pvNombre, String.Empty)))
        End Function

        Public Sub escribirValor(ByVal pvNombre As String, ByVal pvValor As String)
            vcRegistryKey.SetValue(pvNombre, pvValor)
        End Sub

    End Class

End Namespace