'*************************************************************
'Proposito: Exponer los metodos de la clase
'Autor: Luis A. Mascaro Jácome
'Fecha Creacion:27/03/2006
'Modificado por:
'Fecha Mod.:
'*************************************************************

Imports System.Data
Imports CEF.BusinessEntity

Namespace CEF.BusinessRules

    Public Interface ICliente
        Function leer(ByVal pstrCodigoUnico As String) As BusinessEntity.Cliente
        Function buscarXNumeroDocumento(ByVal pstrTipoDocumentoIdentidad As String, ByVal pstrNumeroDocumentoIdentidad As String) As BusinessEntity.Cliente
        Function leerRegOmaesSunat(ByVal pstrRucCliente As String) As DataSet
        Function ObtenerAlgo(ByVal msg As String) As String
        Function ConsultaEEFFxCliente(ByVal pstrCodigoUnico As String, ByVal pstrTipoDocumentoIdentidad As Integer, ByVal pstrNumeroDocumentoIdentidad As String) As DataSet
    End Interface

End Namespace