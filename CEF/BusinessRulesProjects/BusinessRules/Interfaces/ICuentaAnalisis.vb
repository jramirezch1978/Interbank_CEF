'*************************************************************
'Proposito: Exponer los metodos de la clase
'Autor: Luis A. Mascaro Jácome
'Fecha Creacion:27/03/2006
'Modificado por:
'Fecha Mod.:
'*************************************************************

Imports System.Data

Namespace CEF.BusinessRules

    Public Interface ICuentaAnalisis
        Function listar(ByVal pshoCodAnalisis As Short) As DataSet
        Function listarMasCuentaLibre(ByVal pshoCodAnalisis As Short, ByVal pintMetodizado As Integer) As DataSet
        Function ListarPorAnalisis(ByVal pshoCodAnalisis As Short, ByVal pintCodCuentaAnalisis As Integer, ByVal pshoIndicador As Short) As DataSet
    End Interface

End Namespace