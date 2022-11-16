'*************************************************************
'Proposito: Exponer los metodos de la clase
'Autor: Luis A. Mascaro Jácome
'Fecha Creacion: 14/01/2006
'Modificado por: 
'Fecha Mod.: 
'*************************************************************

Imports System.Data

Namespace CEF.BusinessRules

    Public Interface IMenuDinamico
        Function buscarOpcion(ByVal pintCodMenu As Integer) As DataSet
        Function buscarOpcionInicio(ByVal pintCodMenu As Integer) As DataSet
        Function buscarOpcionHijos(ByVal pintCodMenu As Integer, ByVal pintCodOpcion As Integer) As DataSet
    End Interface

End Namespace
