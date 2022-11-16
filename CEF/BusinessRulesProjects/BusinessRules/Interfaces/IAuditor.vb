'*************************************************************
'Proposito: Exponer los metodos de la clase
'Autor: María Laura Santisteban Valdez
'Fecha Creacion:27/03/2006
'Modificado por:
'Fecha Mod.:
'*************************************************************

Imports System.Data
Imports CEF.BusinessEntity

Namespace CEF.BusinessRules

    Public Interface IAuditor
        Function leer(ByVal pintCodAuditor As Integer) As BusinessEntity.Auditor
        Function listar(ByVal pbytFlag As Byte, ByVal pbytEstado As Byte) As DataSet
        Function agregar(ByRef pobeAuditor As BusinessEntity.Auditor) As Boolean
        Function modificar(ByRef pobeAuditor As BusinessEntity.Auditor) As Boolean
        Function eliminar(ByVal pintCodAuditor As Integer) As Boolean
    End Interface

End Namespace
