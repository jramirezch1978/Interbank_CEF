'*************************************************************
'Proposito: Exponer los metodos de la clase
'Autor: Luis A. Mascaro J�come
'Fecha Creacion: 14/01/2006
'Modificado por: 
'Fecha Mod.: 
'*************************************************************

Imports System.Data

Namespace CEF.BusinessRules

    Public Interface IAcceso
        Function leer(ByVal pintCodPerfil As Integer) As DataSet
    End Interface

End Namespace
