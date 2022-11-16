'*************************************************************
'Proposito: Exponer los metodos de la clase
'Autor: Luis A. Mascaro Jácome
'Fecha Creacion:27/03/2006
'Modificado por:
'Fecha Mod.:
'*************************************************************

Imports System.Data

Namespace CEF.BusinessRules

    Public Interface ICuenta
        Function leer(ByVal pintCodCuenta As Integer) As BusinessEntity.Cuenta
        Function listar(ByVal pbytFlag As Byte, ByVal pbytEstado As Byte) As DataSet
        Function agregar(ByRef pobeCuenta As BusinessEntity.Cuenta) As Boolean
        Function modificar(ByRef pobeCuenta As BusinessEntity.Cuenta) As Boolean
        Function eliminar(ByVal pintCodCuenta As Integer) As Boolean
    End Interface

End Namespace