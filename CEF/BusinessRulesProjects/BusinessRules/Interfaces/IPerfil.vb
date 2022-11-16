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

    Public Interface IPerfil
        Function leer(ByVal pshoCodPerfil As Short) As BusinessEntity.Perfil
        Function listar(ByVal pbytFlag As Byte, ByVal pbytEstado As Byte) As DataSet
        Function agregar(ByRef pobePerfil As BusinessEntity.Perfil) As Boolean
        Function modificar(ByRef pobePerfil As BusinessEntity.Perfil) As Boolean
        Function eliminar(ByVal pshoCodPerfil As Short) As Boolean
        Function listarCarteraPerfil(ByVal pshoCodPerfilResponsable As Short) As BusinessEntity.CarteraPerfilLst
    End Interface

End Namespace