'*************************************************************
'Proposito: Exponer los metodos de la clase
'Autor: Luis A. Mascaro J�come
'Fecha Creacion: 14/01/2006
'Modificado por: Mar�a Laura Santisteban Valdez
'Fecha Mod.: 28/03/2006
'*************************************************************

Imports System.Data
Imports CEF.BusinessEntity

Namespace CEF.BusinessRules

    Public Interface IGeneral
        Function leer(ByVal pintCodTbl As Integer, ByVal pintCodItem As Integer) As BusinessEntity.General
        Function listar(ByVal pintCodTbl As Integer) As DataSet
        Function agregar(ByRef pobeGeneral As BusinessEntity.General) As Boolean
        Function modificar(ByRef pobeGeneral As BusinessEntity.General) As Boolean
        Function eliminar(ByVal pintCodTbl As Integer, ByVal pintCodItem As Integer) As Boolean
    End Interface

End Namespace