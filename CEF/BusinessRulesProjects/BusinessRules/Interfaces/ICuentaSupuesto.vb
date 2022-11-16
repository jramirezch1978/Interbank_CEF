'*************************************************************
'Proposito: Exponer los metodos de la clase
'Autor: Luis A. Mascaro Jácome
'Fecha Creacion:27/03/2006
'Modificado por:
'Fecha Mod.:
'*************************************************************

Imports System.Data

Namespace CEF.BusinessRules

    Public Interface ICuentaSupuesto
        Function listar(ByVal pbytFlag As Byte, ByVal pbytEstado As Byte) As DataSet
    End Interface

End Namespace